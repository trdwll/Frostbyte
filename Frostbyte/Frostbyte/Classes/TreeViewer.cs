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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



using Frostbyte.Classes.Project;

namespace Frostbyte.Classes
{
    public class TreeViewer
    {
        public MainForm MainForm { get; set; }

        public TreeView MainTreeView { get; set; }

        public FrostbyteCore FrostbyteCore { get; set; }

        /// <summary>
        /// Treeview Class constructor
        /// </summary>
        /// <param name="_MainTreeView"></param>
        /// <param name="_FrostByteCore"></param>
        /// <param name="_MainForm"></param>
        public TreeViewer(TreeView _MainTreeView, FrostbyteCore _FrostByteCore, ref MainForm _MainForm)
        {
            MainTreeView = _MainTreeView;
            FrostbyteCore = _FrostByteCore;
            MainForm = _MainForm;
        }

        public void PopulateTreeView(bool hierarchy = true)
        {
            try
            {
                MainTreeView.Nodes.Clear();

                MainTreeView.Nodes.Add(MainForm.project.BaseSourceDirectory).Name = MainForm.project.BaseSourceDirectory;

                Dictionary<string, Dictionary<string, ProjectFile>> projectFiles = MainForm.project.IndexProjectFiles();

                List<string> ToRemove = new List<string>();

                foreach (KeyValuePair<string, Dictionary<string, ProjectFile>> entry in projectFiles)
                {
                    TreeNode node = null;
                    string path = "", path2 = "";

                    path2 = entry.Key.Replace("%BASE_DIR%", MainForm.project.GetSourceDirectory());
                    if (!Directory.Exists(path2) && !File.Exists(path2))
                    {
                        //MainForm.project.RemoveDirectory(path2, false);
                        ToRemove.Add(path2);
                        continue;
                    }
                    if (hierarchy)
                    {
                        string[] parts = entry.Key.Replace("%BASE_DIR%", MainForm.project.BaseSourceDirectory).Split(Path.DirectorySeparatorChar);

                        for (int i = 0; i < parts.Length; i++)
                        {
                            path += (i != 0 ? Path.DirectorySeparatorChar + "" : "") + parts[i];

                            if (node == null)
                            {
                                node = MainTreeView.Nodes.ContainsKey(path) ? MainTreeView.Nodes[path] : MainTreeView.Nodes.Add(parts[i]);
                            }
                            else
                            {
                                node = node.Nodes.ContainsKey(path) ? node.Nodes[path] : node.Nodes.Add(parts[i]);
                            }

                            node.Name = path;
                        }

                        if (path == "")
                        {
                            break;
                        }
                    }
                    else
                    {
                        path = entry.Key.Replace("%BASE_DIR%", MainForm.project.BaseSourceDirectory);
                        if (path != MainForm.project.BaseSourceDirectory)
                        {
                           node = MainTreeView.Nodes.Add(path);
                        }
                        else
                        {
                            node = MainTreeView.Nodes.Find(MainForm.project.BaseSourceDirectory, false)[0];
                        }
                    }

                    node.Name = path;

                    foreach (KeyValuePair<string, ProjectFile> file in entry.Value)
                    {
                        TreeNode fileNode = node.Nodes.Add(file.Key);

                        fileNode.Name = file.Value.GetLocation(MainForm.project);
                        fileNode.ImageIndex = file.Value.getFileType().IconIndex;
                        fileNode.SelectedImageIndex = file.Value.getFileType().IconIndex;
                    }
                }

                foreach (string remove in ToRemove)
                {
                    MainForm.project.RemoveDirectory(remove, false);
                }

                MainTreeView.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Configuration.DEBUGMODE ? ex.ToString() : ex.Message);
            }
        }
    }
}
