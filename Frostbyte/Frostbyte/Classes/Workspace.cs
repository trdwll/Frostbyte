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
using System.Drawing;

using FastColoredTextBoxNS;

namespace Frostbyte.Classes
{
   public class Workspace
    {
        public TabControl MainTabControl { get; set; }

        public FrostbyteCore FrostbyteCore { get; set; }

        /// <summary>
        /// Workspace constructor
        /// </summary>
        /// <param name="_MainTabControl"></param>
        /// <param name="_FrostByteCore"></param>
        public Workspace(TabControl _MainTabControl, FrostbyteCore _FrostByteCore)
        {
            MainTabControl = _MainTabControl;
            FrostbyteCore = _FrostByteCore;
        }


        /// <summary>
        /// Create a new Workspace
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>Returns a FastColoredTextBox</returns>
        public FastColoredTextBox CreateWorkspace(string FilePath = "")
        {
            FastColoredTextBox Editor = new FastColoredTextBox
            {
                Dock = DockStyle.Fill,

                WordWrapAutoIndent = false,
                AllowDrop = true,

                AllowMacroRecording = false,
                AutoCompleteBrackets = true,
                AutoCompleteBracketsList = new[] { '{', '}', '(', ')', '[', ']', '"', '"', '\'', '\'' },
                CaretColor = Color.Navy,
                CurrentLineColor = Color.Yellow,

                LeftPadding = 15,
                LineInterval = 3,
                LineNumberColor = Color.DimGray,
                BookmarkColor = Color.Olive,

                FindEndOfFoldingBlockStrategy = FindEndOfFoldingBlockStrategy.Strategy2,

                DelayedEventsInterval = 100,

                SelectionColor = Color.FromArgb(80, 0, 128, 128),
                ServiceLinesColor = Color.DarkGray,
                ShowFoldingLines = true,

                Tag = FilePath
            };

            Editor.TextChanged += FrostbyteCore.MainForm.Editor_TextChanged;
            Editor.TextChangedDelayed += FrostbyteCore.MainForm.Editor_TextChangedDelayed;
            Editor.KeyUp += FrostbyteCore.MainForm.Editor_KeyUp;
            Editor.DragEnter += FrostbyteCore.MainForm.Editor_DragEnter;
            Editor.DragDrop += FrostbyteCore.MainForm.Editor_DragDrop;

            return Editor;
        }

        /// <summary>
        /// Get the active workspace that the client is currently selected
        /// </summary>
        /// <returns>Returns the selected Tab</returns>
        public FastColoredTextBox GetActiveWorkspace()
        {
            return (MainTabControl.SelectedTab != null && MainTabControl.SelectedTab.Controls.Count > 0 ? MainTabControl.SelectedTab.Controls[0] as FastColoredTextBox : null);
        }

    }
}
