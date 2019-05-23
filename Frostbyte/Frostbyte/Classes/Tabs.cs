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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.IO;

using Frostbyte.Classes.Project;
using Frostbyte.Classes.SyntaxHighlighting;

using FastColoredTextBoxNS;

namespace Frostbyte.Classes
{
    public class Tabs
    {
        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 15;

        public TabControl MainTabControl { get; set; }

        public FrostbyteCore FrostbyteCore { get; set; }

        /// <summary>
        /// Tabs Constructor
        /// </summary>
        /// <param name="_MainTabControl"></param>
        /// <param name="_FrostbyteCore"></param>
        public Tabs(TabControl _MainTabControl, FrostbyteCore _FrostbyteCore)
        {
            MainTabControl = _MainTabControl;
            FrostbyteCore = _FrostbyteCore;
        }

        public void NewFile(string file, FileType fileType, TreeView TreeView = null)    
        {
            bool UpdateTreeView = false;
            if (TreeView == null)
            {
                TreeView = FrostbyteCore.MainForm.GetTreeView();
                UpdateTreeView = true;
            }

            try
            {
                Console.WriteLine("Nodes: " + TreeView.Nodes.Count.ToString());
                TreeNode node = TreeView.SelectedNode == null ? TreeView.Nodes[0] : TreeView.SelectedNode;

                while (!FrostbyteCore.MainForm.IsDir(node))
                {
                    node = node.Parent;
                }

                string path = FrostbyteCore.MainForm.GetPath(node) + Path.DirectorySeparatorChar + file;
                string extension = fileType.Extension == "" ? "" : ("." + fileType.Extension);
                string actualPath = path + extension;

                int i = 1;

                while (File.Exists(actualPath))
                {
                    actualPath = path + " (" + (i++) + ")" + extension;
                }

                Console.WriteLine("Actual Path: " + actualPath);

                ProjectFile projectFile = new ProjectFile()
                {
                    FileDirectory = FrostbyteCore.MainForm.GetPath(node).Replace(FrostbyteCore.MainForm.project.GetSourceDirectory(), "%BASE_DIR%"),
                    FileExtension = fileType.Extension,
                    FileName = actualPath.Substring(actualPath.LastIndexOf(Path.DirectorySeparatorChar + "") + 1)
                };

                Console.WriteLine(JsonHelper.FormatJson(new JavaScriptSerializer().Serialize(projectFile)));

                TreeNode newNode = node.Nodes.Add(projectFile.FileName);
                newNode.Name = actualPath;
                newNode.ImageIndex = fileType.IconIndex;
                newNode.SelectedImageIndex = fileType.IconIndex;

                FrostbyteCore.MainForm.project.AddFile(projectFile, true);
                ProjectManager.SaveProject(FrostbyteCore.MainForm.project.GetLocation(), FrostbyteCore.MainForm.project);

                CreateNewTab(projectFile.FileName, projectFile, UpdateTreeView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Configuration.DEBUGMODE ? ex.ToString() : ex.Message);
            }
        }

        public void CreateNewTab(string FileName, ProjectFile projectFile = null, bool PopulateTreeView = false)
        {
            if (!MainTabControl.TabPages.ContainsKey(FileName))
            {
                MainTabControl.TabPages.Add(new TabPage(FileName) { Name = FileName, Tag = projectFile });
                MainTabControl.SuspendLayout();

                bool add = true;
                FastColoredTextBox workspace = FrostbyteCore.Workspace.CreateWorkspace();

                if (projectFile != null)
                {
                    try
                    {
                        workspace.Text = File.ReadAllText(projectFile.GetLocation(FrostbyteCore.MainForm.project));
                        add = workspace.Text.Length == 0;

                        new Syntax(workspace, projectFile.getFileType());
                    }
                    catch { }
                }
                else
                {
                    new Syntax(workspace, FileType.UNKNOWN);
                }

                if (add && Properties.Settings.Default.TopFileComment.Length > 0)
                {
                    string comment = Properties.Settings.Default.TopFileComment;
                    ProjectMeta meta = new ProjectMeta(FrostbyteCore.MainForm.project, FileName);

                    foreach (string replace in meta.variables.Keys)
                    {
                        comment = comment.Replace(replace, meta.variables[replace]);
                    }

                    workspace.Text = comment + '\n' + workspace.Text;
                }

                MainTabControl.TabPages[FileName].Controls.Add(workspace);
                MainTabControl.ResumeLayout();
                MainTabControl.SelectTab(FileName);
            }
            else
            {
                MainTabControl.SelectedTab = MainTabControl.TabPages[FileName];
            }

            FrostbyteCore.MainForm.toolStripStatusLabel1.Text = FrostbyteCore.Tabs.MainTabControl.SelectedTab.Name;
            FrostbyteCore.MainForm.toolStripStatusLabel2.Text = "Current Length: " + FrostbyteCore.Workspace.GetActiveWorkspace().Text.Length.ToString();

            if (PopulateTreeView)
            {
                FrostbyteCore.TreeViewer.PopulateTreeView();
            }
        }

        public void CloseTab(TabPage Tab)
        {
            if (Tab == null) return;

            int TabIndex = MainTabControl.SelectedIndex;

            if (MainTabControl.TabPages.Count > 0)
            {
                MainTabControl.TabPages.Remove(MainTabControl.TabPages[TabIndex]);
                MainTabControl.SelectedIndex = (TabIndex > 1 ? TabIndex - 1 : 0);
                FrostbyteCore.MainForm.toolStripStatusLabel1.Text = "Project " + FrostbyteCore.MainForm.project.ProjectName + " Loaded";
                FrostbyteCore.MainForm.toolStripStatusLabel2.Text = "Current Length: null";
            }
        }

    }
}
