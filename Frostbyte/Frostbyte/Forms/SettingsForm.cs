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
using FastColoredTextBoxNS;

namespace Frostbyte.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            // Load styling for controls from settings
            CommentFilesCheckbox.Checked = Configuration.s_TopFileComment.Length > 0;
            commentBox.Text = CommentFilesCheckbox.Checked ? Configuration.s_TopFileComment : commentBox.Text;
            CheckForUpdatesAutomaticallyCheckbox.Checked = Configuration.s_CheckForUpdatesAutomatically;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // on form closing set the settings and save them

            Properties.Settings.Default.Save();

            Configuration.s_CheckForUpdatesAutomatically = CheckForUpdatesAutomaticallyCheckbox.Checked;
            Configuration.s_TopFileComment = Properties.Settings.Default.TopFileComment;
        }

        private void CheckForUpdatesAutomaticallyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["CheckForUpdatesAutomatically"] = CheckForUpdatesAutomaticallyCheckbox.Checked;
        }

        private void CommentFilesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CommentFilesCheckbox.Checked)
            {
                Properties.Settings.Default["TopFileComment"] = commentBox.Text;

                commentBox.Enabled = true;
            }
            else
            {
                Properties.Settings.Default["TopFileComment"] = "";

                commentBox.Enabled = false;
            }
        }

        private void onCommentChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default["TopFileComment"] = commentBox.Text;
        }
    }
}
