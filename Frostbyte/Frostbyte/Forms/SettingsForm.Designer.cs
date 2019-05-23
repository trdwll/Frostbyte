namespace Frostbyte.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CheckForUpdatesAutomaticallyCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CommentFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.commentBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 293);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CheckForUpdatesAutomaticallyCheckbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(567, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Application";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CheckForUpdatesAutomaticallyCheckbox
            // 
            this.CheckForUpdatesAutomaticallyCheckbox.AutoSize = true;
            this.CheckForUpdatesAutomaticallyCheckbox.Location = new System.Drawing.Point(8, 6);
            this.CheckForUpdatesAutomaticallyCheckbox.Name = "CheckForUpdatesAutomaticallyCheckbox";
            this.CheckForUpdatesAutomaticallyCheckbox.Size = new System.Drawing.Size(151, 17);
            this.CheckForUpdatesAutomaticallyCheckbox.TabIndex = 0;
            this.CheckForUpdatesAutomaticallyCheckbox.Text = "Check for updates on start";
            this.CheckForUpdatesAutomaticallyCheckbox.UseVisualStyleBackColor = true;
            this.CheckForUpdatesAutomaticallyCheckbox.CheckedChanged += new System.EventHandler(this.CheckForUpdatesAutomaticallyCheckbox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CommentFilesCheckbox);
            this.tabPage2.Controls.Add(this.commentBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(567, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Workspace / Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CommentFilesCheckbox
            // 
            this.CommentFilesCheckbox.AutoSize = true;
            this.CommentFilesCheckbox.Location = new System.Drawing.Point(8, 133);
            this.CommentFilesCheckbox.Name = "CommentFilesCheckbox";
            this.CommentFilesCheckbox.Size = new System.Drawing.Size(142, 17);
            this.CommentFilesCheckbox.TabIndex = 1;
            this.CommentFilesCheckbox.Text = "Put this at the top of files";
            this.CommentFilesCheckbox.UseVisualStyleBackColor = true;
            this.CommentFilesCheckbox.CheckedChanged += new System.EventHandler(this.CommentFilesCheckbox_CheckedChanged);
            // 
            // commentBox
            // 
            this.commentBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.commentBox.AutoScrollMinSize = new System.Drawing.Size(346, 98);
            this.commentBox.BackBrush = null;
            this.commentBox.CharHeight = 14;
            this.commentBox.CharWidth = 8;
            this.commentBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commentBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.commentBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commentBox.Enabled = false;
            this.commentBox.IsReplaceMode = false;
            this.commentBox.Location = new System.Drawing.Point(3, 156);
            this.commentBox.Name = "commentBox";
            this.commentBox.Paddings = new System.Windows.Forms.Padding(0);
            this.commentBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.commentBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("commentBox.ServiceColors")));
            this.commentBox.Size = new System.Drawing.Size(561, 108);
            this.commentBox.TabIndex = 0;
            this.commentBox.Text = "/**\r\n * Project Name: {ProjectName} - {FileName}\r\n * Date Created: {DateCreated}\r" +
    "\n * Author: {Author}\r\n * \r\n * Copyright (c) {Year}\r\n */ ";
            this.commentBox.Zoom = 100;
            this.commentBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.onCommentChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(567, 267);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 293);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox CheckForUpdatesAutomaticallyCheckbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private FastColoredTextBoxNS.FastColoredTextBox commentBox;
        public System.Windows.Forms.CheckBox CommentFilesCheckbox;
    }
}