namespace Frostbyte
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.newProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.newFile = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.openProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.openFileMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.closeFileMenuItem = new System.Windows.Forms.MenuItem();
            this.closeAllMenuItem = new System.Windows.Forms.MenuItem();
            this.closeProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.editMenuItem = new System.Windows.Forms.MenuItem();
            this.undoMenuItem = new System.Windows.Forms.MenuItem();
            this.redoMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.cutMenuItem = new System.Windows.Forms.MenuItem();
            this.copyMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteMenuItem = new System.Windows.Forms.MenuItem();
            this.deleteMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.selectallMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.findreplaceMenuItem = new System.Windows.Forms.MenuItem();
            this.selectionMenuItem = new System.Windows.Forms.MenuItem();
            this.commentMenuItem = new System.Windows.Forms.MenuItem();
            this.uncommentMenuItem = new System.Windows.Forms.MenuItem();
            this.uppercaseMenuItem = new System.Windows.Forms.MenuItem();
            this.lowercaseMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.hierarchy = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.projectMenuItem = new System.Windows.Forms.MenuItem();
            this.buildProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.toolsMenuItem = new System.Windows.Forms.MenuItem();
            this.colorPickerMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.issueMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.updaterMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.aboutMenuItem = new System.Windows.Forms.MenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newFileToolStrip = new System.Windows.Forms.ToolStripButton();
            this.closeFileToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.viewMenuItem,
            this.projectMenuItem,
            this.toolsMenuItem,
            this.helpMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem12,
            this.menuItem3,
            this.menuItem4,
            this.menuItem6,
            this.menuItem11,
            this.closeFileMenuItem,
            this.closeAllMenuItem,
            this.closeProjectMenuItem,
            this.menuItem10,
            this.exitMenuItem});
            this.fileMenuItem.Text = "File";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newProjectMenuItem,
            this.newFile});
            this.menuItem7.Text = "New";
            // 
            // newProjectMenuItem
            // 
            this.newProjectMenuItem.Index = 0;
            this.newProjectMenuItem.Text = "Project";
            this.newProjectMenuItem.Click += new System.EventHandler(this.onNewProject);
            // 
            // newFile
            // 
            this.newFile.Index = 1;
            this.newFile.Text = "File";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openProjectMenuItem,
            this.openFileMenuItem});
            this.menuItem8.Text = "Open";
            // 
            // openProjectMenuItem
            // 
            this.openProjectMenuItem.Index = 0;
            this.openProjectMenuItem.Text = "Project";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Index = 1;
            this.openFileMenuItem.Text = "File";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItem3.Text = "Save";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.menuItem4.Text = "Save All";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "Save Project";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 6;
            this.menuItem11.Text = "-";
            // 
            // closeFileMenuItem
            // 
            this.closeFileMenuItem.Index = 7;
            this.closeFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.closeFileMenuItem.Text = "Close";
            this.closeFileMenuItem.Click += new System.EventHandler(this.onClose);
            // 
            // closeAllMenuItem
            // 
            this.closeAllMenuItem.Index = 8;
            this.closeAllMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftW;
            this.closeAllMenuItem.Text = "Close All";
            this.closeAllMenuItem.Click += new System.EventHandler(this.onCloseAll);
            // 
            // closeProjectMenuItem
            // 
            this.closeProjectMenuItem.Index = 9;
            this.closeProjectMenuItem.Text = "Close Project";
            this.closeProjectMenuItem.Click += new System.EventHandler(this.onProjectClose);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 10;
            this.menuItem10.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 11;
            this.exitMenuItem.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.onFormExit);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Index = 1;
            this.editMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.undoMenuItem,
            this.redoMenuItem,
            this.menuItem5,
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem,
            this.deleteMenuItem,
            this.menuItem15,
            this.selectallMenuItem,
            this.menuItem17,
            this.findreplaceMenuItem,
            this.selectionMenuItem});
            this.editMenuItem.Text = "Edit";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Index = 0;
            this.undoMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.undoMenuItem.Text = "Undo";
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Index = 1;
            this.redoMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.redoMenuItem.Text = "Redo";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Index = 3;
            this.cutMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.cutMenuItem.Text = "Cut";
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Index = 4;
            this.copyMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.copyMenuItem.Text = "Copy";
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Index = 5;
            this.pasteMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.pasteMenuItem.Text = "Paste";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Index = 6;
            this.deleteMenuItem.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.deleteMenuItem.Text = "Delete";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 7;
            this.menuItem15.Text = "-";
            // 
            // selectallMenuItem
            // 
            this.selectallMenuItem.Index = 8;
            this.selectallMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.selectallMenuItem.Text = "Select All";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 9;
            this.menuItem17.Text = "-";
            // 
            // findreplaceMenuItem
            // 
            this.findreplaceMenuItem.Index = 10;
            this.findreplaceMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.findreplaceMenuItem.Text = "Find and Replace";
            // 
            // selectionMenuItem
            // 
            this.selectionMenuItem.Index = 11;
            this.selectionMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.commentMenuItem,
            this.uncommentMenuItem,
            this.uppercaseMenuItem,
            this.lowercaseMenuItem});
            this.selectionMenuItem.Text = "Selection";
            // 
            // commentMenuItem
            // 
            this.commentMenuItem.Index = 0;
            this.commentMenuItem.Text = "Comment";
            // 
            // uncommentMenuItem
            // 
            this.uncommentMenuItem.Index = 1;
            this.uncommentMenuItem.Text = "Uncomment";
            // 
            // uppercaseMenuItem
            // 
            this.uppercaseMenuItem.Index = 2;
            this.uppercaseMenuItem.Text = "UPPERCASE";
            // 
            // lowercaseMenuItem
            // 
            this.lowercaseMenuItem.Index = 3;
            this.lowercaseMenuItem.Text = "lowercase";
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.Index = 2;
            this.viewMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.hierarchy,
            this.menuItem9,
            this.menuItem13});
            this.viewMenuItem.Text = "View";
            // 
            // hierarchy
            // 
            this.hierarchy.Checked = true;
            this.hierarchy.Index = 0;
            this.hierarchy.Text = "Hierarchy";
            this.hierarchy.Click += new System.EventHandler(this.hierarchy_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "Settings";
            this.menuItem13.Click += new System.EventHandler(this.onViewSettings);
            // 
            // projectMenuItem
            // 
            this.projectMenuItem.Index = 3;
            this.projectMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.buildProjectMenuItem});
            this.projectMenuItem.Text = "Project";
            // 
            // buildProjectMenuItem
            // 
            this.buildProjectMenuItem.Index = 0;
            this.buildProjectMenuItem.Text = "Build Project";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.Index = 4;
            this.toolsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.colorPickerMenuItem});
            this.toolsMenuItem.Text = "Tools";
            // 
            // colorPickerMenuItem
            // 
            this.colorPickerMenuItem.Index = 0;
            this.colorPickerMenuItem.Text = "Color Picker";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 5;
            this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.issueMenuItem,
            this.menuItem1,
            this.updaterMenuItem,
            this.menuItem2,
            this.aboutMenuItem});
            this.helpMenuItem.Text = "Help";
            // 
            // issueMenuItem
            // 
            this.issueMenuItem.Index = 0;
            this.issueMenuItem.Text = "Post an Issue";
            this.issueMenuItem.Click += new System.EventHandler(this.issueMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // updaterMenuItem
            // 
            this.updaterMenuItem.Index = 2;
            this.updaterMenuItem.Text = "Check For Updates";
            this.updaterMenuItem.Click += new System.EventHandler(this.updaterMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Index = 4;
            this.aboutMenuItem.Text = "About Frostbyte";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 652);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(154, 17);
            this.toolStripStatusLabel1.Text = "No Project Opened";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel5.Text = ":::";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(178, 17);
            this.toolStripStatusLabel2.Text = "Current Length: null";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 652);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(260, 652);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.onNodeLabelEdit);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.onNodeClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onTreeViewMouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "opened_folder.png");
            this.imageList1.Images.SetKeyName(2, "file.png");
            this.imageList1.Images.SetKeyName(3, "xml-48.png");
            this.imageList1.Images.SetKeyName(4, "txt-48.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStrip,
            this.closeFileToolStrip,
            this.toolStripButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(958, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newFileToolStrip
            // 
            this.newFileToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("newFileToolStrip.Image")));
            this.newFileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileToolStrip.Name = "newFileToolStrip";
            this.newFileToolStrip.Size = new System.Drawing.Size(23, 22);
            this.newFileToolStrip.Text = "New File";
            this.newFileToolStrip.Click += new System.EventHandler(this.newFileToolStrip_Click);
            // 
            // closeFileToolStrip
            // 
            this.closeFileToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeFileToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("closeFileToolStrip.Image")));
            this.closeFileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeFileToolStrip.Name = "closeFileToolStrip";
            this.closeFileToolStrip.Size = new System.Drawing.Size(23, 22);
            this.closeFileToolStrip.Text = "Close File";
            this.closeFileToolStrip.Click += new System.EventHandler(this.closeFileToolStrip_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Save File";
            this.toolStripButton3.Click += new System.EventHandler(this.saveFile);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Save All Files";
            this.toolStripButton1.Click += new System.EventHandler(this.saveAll);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(3, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 627);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 674);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(678, 485);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frostbyte IDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClose);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem fileMenuItem;
        private System.Windows.Forms.MenuItem editMenuItem;
        private System.Windows.Forms.MenuItem viewMenuItem;
        private System.Windows.Forms.MenuItem projectMenuItem;
        private System.Windows.Forms.MenuItem toolsMenuItem;
        private System.Windows.Forms.MenuItem helpMenuItem;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem newProjectMenuItem;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem openProjectMenuItem;
        private System.Windows.Forms.MenuItem openFileMenuItem;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem closeFileMenuItem;
        private System.Windows.Forms.MenuItem closeAllMenuItem;
        private System.Windows.Forms.MenuItem closeProjectMenuItem;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.MenuItem issueMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem updaterMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem aboutMenuItem;
        private System.Windows.Forms.MenuItem undoMenuItem;
        private System.Windows.Forms.MenuItem redoMenuItem;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem cutMenuItem;
        private System.Windows.Forms.MenuItem copyMenuItem;
        private System.Windows.Forms.MenuItem pasteMenuItem;
        private System.Windows.Forms.MenuItem deleteMenuItem;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem selectallMenuItem;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem findreplaceMenuItem;
        private System.Windows.Forms.MenuItem selectionMenuItem;
        private System.Windows.Forms.MenuItem commentMenuItem;
        private System.Windows.Forms.MenuItem uncommentMenuItem;
        private System.Windows.Forms.MenuItem uppercaseMenuItem;
        private System.Windows.Forms.MenuItem lowercaseMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newFileToolStrip;
        private System.Windows.Forms.ToolStripButton closeFileToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.MenuItem buildProjectMenuItem;
        private System.Windows.Forms.MenuItem colorPickerMenuItem;
        private System.Windows.Forms.MenuItem hierarchy;
        private System.Windows.Forms.MenuItem newFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem13;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
