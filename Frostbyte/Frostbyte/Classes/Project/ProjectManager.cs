/**
 * Frostbyte
 *
 * Frostbyte is an open source software licensed under the Apache 2.0 license.
 *
 * www.trdwll.com
 *
 *
 *  Copyright 2015-2019 Russ 'trdwll' Treadwell and Jack 'OhYea777' Taylor
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using Frostbyte.Classes.Arma3;



namespace Frostbyte.Classes.Project
{
    public class ProjectManager
    {

        public static Project GetProject(string path)
        {
            string MetaPath = Path.Combine(path, ".frostbyte");
            string MetaFile = Path.Combine(MetaPath, "proj.frbt");

            if (Directory.Exists(MetaPath) && File.Exists(MetaFile))
            {
                try
                {
                    string json = File.ReadAllText(MetaFile);

                    return new JavaScriptSerializer().Deserialize<Project>(json).SetLocation(path);
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public static bool SaveProject(string path, Project project)
        {
            string MetaFile = Path.Combine(path, ".frostbyte", "proj.frbt");
            string SourcePath = Path.Combine(path, project.BaseSourceDirectory);

            try
            {
                string json = JsonHelper.FormatJson(new JavaScriptSerializer().Serialize(project));

                Directory.CreateDirectory(SourcePath);
                Directory.CreateDirectory(Path.GetDirectoryName(MetaFile));
                File.WriteAllText(MetaFile, json);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Configuration.DEBUGMODE ? ex.ToString() : ex.Message);
                return false;
            }
        }

        public static Project CreateNewProject(string ProjectPath, string ProjectName, Dictionary<string, string> FilesToAdd, string ProjectMap = null)
        {
            try
            {
                Project newproj = new Project();
                newproj.ProjectName = ProjectName;
                newproj.SetLocation(ProjectPath);

                MapList MapList = MapList.GetByName(ProjectMap);

                if (MapList.MapFiles != null)
                {
                    foreach (MapFile file in MapList.MapFiles)
                    {
                        FilesToAdd.Add(file.FileName, file.LocalFileName);
                    }
                }

                foreach (KeyValuePair<string, string> Entry in FilesToAdd)
                {
                    try
                    {
                        ProjectMeta meta = new ProjectMeta(newproj, Entry.Key);

                        string path = Path.Combine(newproj.GetSourceDirectory(), Entry.Key);
                        string p = Path.GetDirectoryName(path);

                        if (!Directory.Exists(p))
                        {
                            Directory.CreateDirectory(p);
                        }

                        File.WriteAllText(path, meta.ParseFileContents(File.ReadAllText(Entry.Value)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Configuration.DEBUGMODE ? ex.ToString() : ex.Message);
                    }
                }

                ProjectManager.SaveProject(ProjectPath, newproj);

                Properties.Settings.Default.ProjectLocations.Add(ProjectPath);
                Properties.Settings.Default["CurrentOpenProject"] = ProjectPath;
                Properties.Settings.Default.Save();

                return newproj;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Configuration.DEBUGMODE ? ex.ToString() : ex.Message);
                return null;
            }
        }
    }

    public class JsonHelper
    {
        private const string INDENT_STRING = "  ";
        public static string FormatJson(string str)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }

}
