/**
 * Frostbyte
 *
 * Frostbyte is an open source software licensed under the Apache 2.0 license.
 *
 * www.trdwll.com
 *a
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using FastColoredTextBoxNS;

using Frostbyte.Classes;
using Frostbyte.Classes.Project;
using Frostbyte.Classes.Arma3;
using Frostbyte.Forms;



namespace Frostbyte
{
    public partial class MainForm : Form
    {
        public FrostbyteCore FrostbyteCore { get; set; }

        public Project project;

        private int cnt = -1;

        public MainForm(Project project)
        {
            this.project = project;

            InitializeComponent();

            this.Text += " - " + project.GetLocation();
            toolStripStatusLabel1.Text = "Project " + project.ProjectName + " Loaded";
        }

        public TreeView GetTreeView()
        {
            return treeView1;
        }

        public TabControl GetTabControl()
        {
            return tabControl1;
        }

        public ProjectFile GetProjectFile(TreeNode node)
        {
            string path = GetPath(node);
            string fileName = path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1);

            return project.GetFile(path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar)).Replace(project.GetSourceDirectory(), "%BASE_DIR%"), fileName);
        }

        public string GetPath(TreeNode node)
        {
            return Path.Combine(project.GetLocation(), node.Name);
        }

        public bool IsDir(TreeNode node)
        {
            return Directory.Exists(GetPath(node));
        }

        private void hierarchy_Click(object sender, EventArgs e)
        {
            hierarchy.Checked = !hierarchy.Checked;

            Wait.ShowWaitForm();

            treeView1.Nodes.Clear();
            FrostbyteCore.TreeViewer.PopulateTreeView(hierarchy.Checked);
            
            Wait.CloseWaitForm();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ProjectFile file = GetProjectFile(e.Node);

            if (file != null)
            {
                FrostbyteCore.Tabs.CreateNewTab(file.FileName, file);
            }
            else
            {
                Console.WriteLine("Directory");
            }
        }

        private void onTreeViewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y);

                if (node != null && node.Name != project.BaseSourceDirectory)
                {
                    ContextMenu cm = new ContextMenu();

                    if (!IsDir(node))
                    {
                        AddMenuItem(cm, "Rename", onNodeRename).Tag = node;
                    }

                    AddMenuItem(cm, "Delete", onNodeDelete).Tag = node;

                    cm.Show(treeView1, e.Location);
                }
            }
        }

        private void onNodeDelete(object sender, EventArgs e)
        {
            Wait.ShowWaitForm();

            MenuItem menuItem = (MenuItem)sender;
            TreeNode node = (TreeNode)menuItem.Tag;

            if (node != null)
            {
                DeleteNode(node);

                ProjectManager.SaveProject(project.GetLocation(), project);
            }

            Wait.CloseWaitForm();
        }

        private void DeleteNode(TreeNode node)
        {
            if (node != null)
            {
                ProjectFile file = GetProjectFile(node);

                if (file != null)
                {
                    project.RemoveFile(file);
                    treeView1.Nodes.Remove(node);
                }
                else
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        DeleteNode(childNode);
                    }

                    project.RemoveDirectory(GetPath(node));
                    FrostbyteCore.TreeViewer.PopulateTreeView();
                }

            }
        }

        private void onNodeRename(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            TreeNode node = (TreeNode)menuItem.Tag;

            treeView1.LabelEdit = true;

            if (!node.IsEditing)
            {
                node.BeginEdit();
            }
        }

        private MenuItem AddMenuItem(ContextMenu cm, string text, EventHandler handler)
        {
            MenuItem item = new MenuItem(text, handler);
            cm.MenuItems.Add(item);

            return item;
        }

        private void onNodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (IsDir(e.Node))
            {
                Console.WriteLine(e.Node.ImageIndex);

                int index = e.Node.IsExpanded ? 1 : 0;
                e.Node.ImageIndex = index;
                e.Node.SelectedImageIndex = index;
            }
        }

        private void onNodeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == e.Node.Name)
            {
                e.Node.EndEdit(true);
            }
            else if (e.Label.Length == 0)
            {
                e.CancelEdit = true;
                MessageBox.Show("Invalid file name.\nThe file name cannot be blank", "File Rename");
                e.Node.BeginEdit();

                return;
            }
            else
            {
                Regex containsABadCharacter = new Regex("[" + new string(Path.GetInvalidPathChars()) + "]");

                if (containsABadCharacter.IsMatch(e.Label))
                {
                    MessageBox.Show("Invalid file name.\nThe file name contains invalid characters", "File Rename");
                    e.Node.EndEdit(true);

                    return;
                }
                else
                {
                    ProjectFile file = GetProjectFile(e.Node);

                    if (file != null)
                    {
                        project.RenameFile(file, e.Label);

                        e.Node.Name = file.GetLocation(project);
                        e.Node.EndEdit(false);
                        treeView1.LabelEdit = false;

                        ProjectManager.SaveProject(project.GetLocation(), project);

                        return;
                    }

                    treeView1.LabelEdit = false;
                    e.Node.EndEdit(true);
                }
            }
        }

        private void onFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Editor Event Handlers

        public void Editor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        public void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            toolStripStatusLabel2.Text = "Current Length: " + (FrostbyteCore.Workspace.GetActiveWorkspace() == null ? "0" : FrostbyteCore.Workspace.GetActiveWorkspace().Text.Length.ToString());
        }

        public void Editor_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {

        }

        public void Editor_SelectionChangedDelayed(object sender, EventArgs e)
        {
            
        }

        public void Editor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        public void Editor_DragDrop(object sender, DragEventArgs e)
        {
            object filename = e.Data.GetData("FileDrop");

            if (filename != null)
            {
                string[] list = filename as string[];

                if (list != null && !string.IsNullOrWhiteSpace(list[0]))
                {
                    foreach (var fileName in list)
                    {
                        try
                        {
                            if (tabControl1.SelectedTab != null && (tabControl1.SelectedTab.Text == "New File" && FrostbyteCore.Workspace.GetActiveWorkspace().Text == ""))
                            {
                                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                            }

                           // FrostbyteCore.Tabs.CreateOpenFileTab(fileName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(string.Format("Unable to load file:\n\n{0}", fileName));
                        }
                    }
                }
            }
        }

        #endregion

        private void newSQFFileMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updaterMenuItem_Click(object sender, EventArgs e)
        {
            Utils.CheckForUpdates(Configuration.UpdateURL, Configuration.DownloadURL, Configuration.version);
        }

        private void newFileToolStrip_Click(object sender, EventArgs e)
        {
            FrostbyteCore.Tabs.CreateNewTab(++cnt == 0 ? "Untitled" : ("Untitled (" + cnt + ")"));
        }

        private void closeFileToolStrip_Click(object sender, EventArgs e)
        {
            FrostbyteCore.Tabs.CloseTab(tabControl1.SelectedTab);
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void issueMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://github.com/trdwll/Frostbyte/issues");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabCount > 0)
            {
                toolStripStatusLabel1.Text = tabControl1.SelectedTab.Name;
                toolStripStatusLabel2.Text = "Current Length: " + FrostbyteCore.Workspace.GetActiveWorkspace().Text.Length.ToString();
            }
        }

        private void onViewSettings(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        /// <summary>
        /// Shortcut Keys
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region Edit Menu
            if (FrostbyteCore.Workspace.GetActiveWorkspace() != null)
            {
                FastColoredTextBox textBox = FrostbyteCore.Workspace.GetActiveWorkspace();

                if (keyData == (Keys.Control | Keys.F))
                {
                    textBox.ShowFindDialog();

                    Console.WriteLine("Find form");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.R))
                {
                    textBox.ShowReplaceDialog();

                    Console.WriteLine("Find and Replace Form");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.Z))
                {
                    textBox.Undo();

                    Console.WriteLine("Undo");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.Y))
                {
                    textBox.Redo();

                    Console.WriteLine("Redo");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.X))
                {
                    string selectedText = textBox.SelectedText;

                    if (selectedText.Length > 0)
                    {
                        Clipboard.SetText(selectedText);
                    }

                    return true;
                }
                else if (keyData == (Keys.Control | Keys.C))
                {
                    string selectedText = textBox.SelectedText;

                    if (selectedText.Length > 0)
                    {
                        Clipboard.SetText(selectedText);
                    }

                    Console.WriteLine("Copy");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.V))
                {
                    string copiedText = Clipboard.GetText();

                    if (copiedText.Length > 0)
                    {
                        textBox.InsertText(copiedText);
                    }

                    Console.WriteLine("Paste");
                    return true;
                }
                else if (keyData == (Keys.Delete))
                {
                    Console.WriteLine("Delete");
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.A))
                {
                    textBox.SelectAll();

                    Console.WriteLine("Select All");
                    return true;
                }
            }
            #endregion Edit Menu

            #region File Menu

            if (keyData == (Keys.Control | Keys.S))
            {
                saveFile(GetTabControl().SelectedTab);

                Console.WriteLine("Save File");
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                saveAll();

                Console.WriteLine("Save All Files");
                return true;
            }
            else if (keyData == (Keys.Control | Keys.W))
            {
                onClose();

                Console.WriteLine("Close File");
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.W))
            {
                onCloseAll();

                Console.WriteLine("Close All Files");
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.F4))
            {
                onFormExit();

                Console.WriteLine("Form Exit");
                return true;
            }

            #endregion File Menu

            #region Other

            else if (keyData == (Keys.F1))
            {
                Utils.OpenURL("https://github.com/trdwll/Frostbyte/issues");
                return true;
            }

            #endregion Other

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void onNewProject(object sender, EventArgs e)
        {
            NewProjectForm npf = new NewProjectForm();
            npf.ShowDialog();

            string NewProjectName = Properties.Settings.Default.NewProjectName;
            string NewProjectLocation = Properties.Settings.Default.NewProjectLocation;
            string NewProjectMap = Properties.Settings.Default.NewProjectMap;
            
            if (!Utils.IsEmpty(NewProjectName) && !Utils.IsEmpty(NewProjectLocation))
            {
                Dictionary<string, string> Files = new Dictionary<string, string>();

                Files.Add("description.ext", "data/description.ext");

                ProjectManager.CreateNewProject(NewProjectLocation, NewProjectName, Files, NewProjectMap);

                saveAll();
                Environment.SetEnvironmentVariable("project", NewProjectLocation);
                Application.Restart();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Reset specific settings
            Properties.Settings.Default["CurrentOpenProject"] = "";
            Properties.Settings.Default["NewProjectName"] = "";
            Properties.Settings.Default["NewProjectLocation"] = "";
            Properties.Settings.Default["NewProjectMap"] = "";
            Properties.Settings.Default.Save();
        }

        private void saveAll(object sender = null, EventArgs e = null)
        {
            bool populateTreeView = false;

            foreach (TabPage tab in GetTabControl().TabPages)
            {
                if (saveFile(tab, true))
                {
                    populateTreeView = true;
                }
            }

            if (populateTreeView)
            {
                FrostbyteCore.TreeViewer.PopulateTreeView(hierarchy.Checked);
            }
        }

        public void saveFile(object sender, EventArgs e)
        {
            saveFile(GetTabControl().SelectedTab);
        }

        private bool saveFile(TabPage tab, bool saveAll = false)
        {
            FastColoredTextBox textBox;

            if (tab != null && tab.Controls.Count > 0 && tab.Controls[0] is FastColoredTextBox && (textBox = (FastColoredTextBox) tab.Controls[0]) != null)
            {
                bool populateTreeView = false;
                string path = "";

                if (tab.Tag != null && tab.Tag is ProjectFile)
                {
                    path = ((ProjectFile) tab.Tag).GetLocation(project);
                }
                else
                {
                    TreeNode selectedNode = null;

                    for (selectedNode = treeView1.SelectedNode; selectedNode != null && !IsDir(selectedNode); selectedNode = selectedNode.Parent) ;

                    if (selectedNode == null)
                    {
                        path = project.GetSourceDirectory() + Path.DirectorySeparatorChar + tab.Name;
                    }
                    else
                    {
                        path = GetPath(selectedNode) + Path.DirectorySeparatorChar + tab.Name;
                    }

                    populateTreeView = true;
                }

                textBox.SaveToFile(path, UnicodeEncoding.Default);

                if (populateTreeView && !saveAll) FrostbyteCore.TreeViewer.PopulateTreeView(hierarchy.Checked);

                Console.WriteLine("Saving file to: " + path);

                return populateTreeView;
            }

            return false;
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            NewFileForm nff = new NewFileForm(ref treeView1);
            nff.ShowDialog();

            Console.WriteLine("Count: " + treeView1.Nodes.Count.ToString());
        }

        private void onProjectClose(object sender, EventArgs e)
        {
            saveAll();
            Environment.SetEnvironmentVariable("project", "");
            Application.Restart();
        }

        private void onCloseAll(object sender = null, EventArgs e = null)
        {
            saveAll();

            tabControl1.TabPages.Clear();
        }

        private void onClose(object sender = null, EventArgs e = null)
        {
            saveFile(tabControl1.SelectedTab);

            FrostbyteCore.Tabs.CloseTab(tabControl1.SelectedTab);
        }

        private void onFormExit(object sender = null, EventArgs e = null)
        {
            saveAll();

            Application.Exit();
        }

    }
}
