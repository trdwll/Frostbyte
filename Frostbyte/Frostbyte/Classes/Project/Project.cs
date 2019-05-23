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

namespace Frostbyte.Classes.Project
{
    public class Project
    {
        public string ProjectName;
        public string BaseSourceDirectory = "src";
        public Dictionary<string, Dictionary<string, ProjectFile>> ProjectFiles = new Dictionary<string, Dictionary<string, ProjectFile>>();
        public List<string> ExcludedPaths = new List<string>();

        private string Location;

        public Project SetLocation(string location)
        {
            this.Location = location;

            if (!ExcludedPaths.Contains(".frostbyte"))
            {
                ExcludedPaths.Add(".frostbyte");
            }

            return this;
        }

        public void AddFile(ProjectFile file, bool create = false)
        {
            string path = file.GetPath(this).Replace(GetSourceDirectory(), "%BASE_DIR%");

            if (!ExcludedPaths.Contains(path))
            {
                if (!ProjectFiles.ContainsKey(path))
                {
                    ProjectFiles[path] = new Dictionary<string, ProjectFile>();
                }

                if (!ProjectFiles[path].ContainsKey(file.FileName))
                {
                    ProjectFiles[path].Add(file.FileName, file);
                }

                if (!File.Exists(file.GetLocation(this)) && create)
                {
                    File.Create(file.GetLocation(this)).Close();
                }
            }
        }

        public ProjectFile GetFile(string path, string fileName)
        {
            if (ProjectFiles.ContainsKey(path) && ProjectFiles[path].ContainsKey(fileName))
            {
                return ProjectFiles[path][fileName];
            }

            return null;
        }

        public void RenameFile(ProjectFile file, string fileName, bool move = true)
        {
            string path = file.GetPath(this).Replace(GetSourceDirectory(), "%BASE_DIR%");

            if (ProjectFiles.ContainsKey(path) && ProjectFiles[path].ContainsKey(file.FileName))
            {
                string oldFilePath = file.GetLocation(this);

                ProjectFiles[path].Remove(file.FileName);

                file.FileName = fileName;

                ProjectFiles[path].Add(fileName, file);

                File.Move(oldFilePath, file.GetLocation(this));
            }
        }

        public void RemoveFile(ProjectFile file, bool delete = true)
        {
            string path = file.GetPath(this).Replace(GetSourceDirectory(), "%BASE_DIR%");

            if (ProjectFiles.ContainsKey(path) && ProjectFiles[path].ContainsKey(file.FileName))
            {
                ProjectFiles[path].Remove(file.FileName);

                if (ProjectFiles[path].Count == 0)
                {
                    ProjectFiles.Remove(path);
                }
                
                if (delete)
                {
                    File.Delete(file.GetLocation(this));
                }
            }
        }

        public void RemoveDirectory(string directory, bool delete = true)
        {
            string path = directory.Replace(GetSourceDirectory(), "%BASE_DIR%");

            if (ProjectFiles.ContainsKey(path))
            {
               // ProjectFiles.Remove(path);
                Console.WriteLine("Removed " + ProjectFiles.Remove(path));

                if (delete)
                {
                    Directory.Delete(directory, true);
                }
                ProjectManager.SaveProject(GetLocation(), this); 
            }
        }

        public Dictionary<string, Dictionary<string, ProjectFile>> IndexProjectFiles()
        {
            Directory.CreateDirectory(GetSourceDirectory());

            List<string> toRemove = new List<string>();

            foreach (KeyValuePair<string, Dictionary<string, ProjectFile>> entry in ProjectFiles)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    ProjectFile file = entry.Value.ElementAt(i).Value;

                    if (!File.Exists(file.GetLocation(this)))
                    {
                        RemoveFile(file, false);
                    }
                }
            }

            IndexFiles(ProjectFiles, GetSourceDirectory());

            return ProjectFiles;
        }

        public void IndexFiles(Dictionary<string, Dictionary<string, ProjectFile>> projectFiles, string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                string extension = Path.GetExtension(file).StartsWith(".") ? Path.GetExtension(file).Substring(1) : Path.GetExtension(file);
                FileType fileType = FileType.GetByExtension(extension);
                ProjectFile projectFile = new ProjectFile();

                projectFile.FileDirectory = Path.GetDirectoryName(file).Replace(GetSourceDirectory(), "%BASE_DIR%");
                projectFile.FileName = Path.GetFileName(file);

                if (fileType != FileType.UNKNOWN) projectFile.FileExtension = fileType.Extension;

                AddFile(projectFile);
            }

            foreach (string directory in Directory.GetDirectories(path))
            {
                if (!ProjectFiles.ContainsKey(directory.Replace(GetSourceDirectory(), "%BASE_DIR%")))
                {
                    ProjectFiles.Add(directory.Replace(GetSourceDirectory(), "%BASE_DIR%"), new Dictionary<string, ProjectFile>());
                }

                IndexFiles(projectFiles, directory);
            }
        }

        public string GetSourceDirectory()
        {
            return Path.Combine(Location, BaseSourceDirectory);
        }

        public string GetLocation()
        {
            return Location;
        }

    }
}
