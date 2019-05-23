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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Frostbyte.Classes;
using Frostbyte.Classes.Project;

namespace Frostbyte.Forms
{
    public partial class NewFileForm : Form
    {
        private TreeView TreeView { get; set; }

        public NewFileForm(ref TreeView _TreeView)
        {
            InitializeComponent();

            TreeView = _TreeView;
        }

        void print(string str)
        {
            Console.WriteLine(str);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Project project = ProjectManager.GetProject(Properties.Settings.Default.NewProjectMap);

            MainForm MainForm = new MainForm(project);
            FrostbyteCore FrostbyteCore = new FrostbyteCore(MainForm);

            string NewFileName = txtNewFileName.Text;

            FileType type = FileType.GetByExtension(cbExtension.SelectedItem.ToString().ToLower());

            FrostbyteCore.Tabs.NewFile(NewFileName, type, TreeView);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
