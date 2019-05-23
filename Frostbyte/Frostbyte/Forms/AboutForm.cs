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



namespace Frostbyte.Forms
{
    public partial class AboutForm : Form
    {
        private string Authors = @"Programming & Design

Russ 'trdwll' Treadwell
Jack 'OhYea777' Taylor";

        private string Credits = @"Pavel Torgashov - FastColoredTextBox
https://github.com/PavelTorgashov/FastColoredTextBox";

        public AboutForm()
        {
            InitializeComponent();

            authorsBox.Text = Authors;
            creditsBox.Text = Credits;

            string CodeName = Configuration.ReleaseCodeName;
            label1.Text = "Current Version: " + Configuration.version + (CodeName.Length > 0 ? " " + Configuration.ReleaseCodeName : "") + "\nReleased on " + Configuration.ReleaseDate;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("http://www.trdwll.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURL("https://www.github.com/trdwll");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURL("https://www.twitter.com/trdwll");
        }
    }
}
