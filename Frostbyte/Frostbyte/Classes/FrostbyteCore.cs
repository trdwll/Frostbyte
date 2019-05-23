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

using FastColoredTextBoxNS;

namespace Frostbyte.Classes
{
    public class FrostbyteCore
    {
        public Workspace Workspace { get; set; }
        public Tabs Tabs { get; set; }
        public TreeViewer TreeViewer { get; set; }
        public MainForm MainForm { get; set; }
        public TreeView MainTreeView { get; set; }


        /// <summary>
        /// FrostbyteCore constructor
        /// </summary>
        /// <param name="_MainForm"></param>
        public FrostbyteCore(MainForm _MainForm)
        {
            Workspace = new Workspace(_MainForm.GetTabControl(), this);
            Tabs = new Tabs(_MainForm.GetTabControl(), this);
            TreeViewer = new TreeViewer(_MainForm.GetTreeView(), this, ref _MainForm);
            (MainForm = _MainForm).FrostbyteCore = this;
        }
    }
}
