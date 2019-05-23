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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Frostbyte.Classes;
using Frostbyte.Classes.Project;
using Frostbyte.Forms;



namespace Frostbyte
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();

            WaitConfiguration.Reverse = true;

            Wait.ShowWaitForm();

            if (Configuration.s_CheckForUpdatesAutomatically)
            {
                Utils.CheckForUpdates(Configuration.UpdateURL, Configuration.DownloadURL, Configuration.version, true);
            }
        }

        private void LoadProjects()
        {
            if (Properties.Settings.Default.ProjectLocations.Count > 0)
            {
                foreach (string projectLocation in Properties.Settings.Default.ProjectLocations)
                {
                    Console.WriteLine(projectLocation);

                    Project project = ProjectManager.GetProject(projectLocation);

                    if (project != null)
                    {
                        project.IndexProjectFiles();
                        ProjectManager.SaveProject(projectLocation, project);

                        Button b = new Button();
                        b.Text = project.ProjectName + "\n" + project.GetLocation();
                        b.Size = new Size(393, 50);//22);
                        b.Click += (object sender, EventArgs e) =>
                        {
                            Populate(project);
                        };

                        flowLayoutPanel1.Controls.Add(b);
                    }
                }
            }
        }

        private void onFormShown(object sender, EventArgs e)
        {
            Project project;

            Utils.Println("Hi");

            if (Environment.GetEnvironmentVariable("project") != null && (project = ProjectManager.GetProject(Environment.GetEnvironmentVariable("project"))) != null)
            {
                Wait.CloseWaitForm();
                Populate(project);
            }
            else
            {
                LoadProjects();
                Wait.CloseWaitForm();
            }
        }

        private void onSettingsReset(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset your settings?", "Yes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Reload();
            }
        }

        private void flowLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            flowLayoutPanel1.Focus();
        }

        private void onNewProject(object sender, EventArgs e)
        {
            NewProjectForm npf = new NewProjectForm();
            npf.ShowDialog();

            string NewProjectName = Properties.Settings.Default.NewProjectName;
            string NewProjectLocation = Properties.Settings.Default.NewProjectLocation;
            string NewProjectMap = Properties.Settings.Default.NewProjectMap;

            if (NewProjectName != "" && NewProjectLocation != "")
            {
                Dictionary<string, string> Files = new Dictionary<string, string>();

                Files.Add("description.ext", "data/description.ext");

                Project p = ProjectManager.CreateNewProject(NewProjectLocation, NewProjectName, Files, NewProjectMap);

                if (p != null)
                {
                    Populate(p);
                }
            }
        }

        void Populate(Project project)
        {
            MainForm ide = new MainForm(project);
            FrostbyteCore FrostbyteCore = new FrostbyteCore(ide);

            try
            {
                ide.Show();

                if (FrostbyteCore != null)
                {
                    FrostbyteCore.TreeViewer.PopulateTreeView();
                    SaveOpenProjectInSettings(project.GetLocation());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Hide();
        }

        void SaveOpenProjectInSettings(string path)
        {
            Properties.Settings.Default["CurrentOpenProject"] = path;
            Properties.Settings.Default.Save();
        }

        private void onOpenProject(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Please Select the Frostbyte Project Folder:";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Project project = ProjectManager.GetProject(fbd.SelectedPath);

                if (project != null)
                {
                    string path = fbd.SelectedPath;

                    if (!Properties.Settings.Default.ProjectLocations.Contains(path))
                    {
                        Properties.Settings.Default.ProjectLocations.Add(path);
                        SaveOpenProjectInSettings(path);
                        Properties.Settings.Default.Save();
                    }

                    Populate(project);

                    return;
                }
            }

            MessageBox.Show("Sorry, the project you tried to open does not exist or is invalid", "Invalid Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
