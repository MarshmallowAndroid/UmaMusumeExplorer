namespace UmaMusumeExplorer.Controls.FileBrowser
{
    partial class FileBrowserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBrowserControl));
            this.fileTreeView = new System.Windows.Forms.TreeView();
            this.treeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.extractButton = new System.Windows.Forms.Button();
            this.extractListView = new System.Windows.Forms.ListView();
            this.nameHeader = new System.Windows.Forms.ColumnHeader();
            this.sizeHeader = new System.Windows.Forms.ColumnHeader();
            this.extractListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalFileSizeLabel = new System.Windows.Forms.Label();
            this.totalFileCountLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.treeViewContextMenuStrip.SuspendLayout();
            this.extractListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTreeView
            // 
            resources.ApplyResources(this.fileTreeView, "fileTreeView");
            this.fileTreeView.ContextMenuStrip = this.treeViewContextMenuStrip;
            this.fileTreeView.ImageList = this.treeViewImageList;
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.PathSeparator = "/";
            this.fileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FileTreeView_BeforeExpand);
            // 
            // treeViewContextMenuStrip
            // 
            this.treeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFileLocationToolStripMenuItem});
            this.treeViewContextMenuStrip.Name = "treeViewContextMenuStrip";
            resources.ApplyResources(this.treeViewContextMenuStrip, "treeViewContextMenuStrip");
            this.treeViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TreeViewContextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            resources.ApplyResources(this.openFileLocationToolStripMenuItem, "openFileLocationToolStripMenuItem");
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.OpenFileLocationToolStripMenuItem_Click);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "FolderIcon.ico");
            this.treeViewImageList.Images.SetKeyName(1, "FileIcon.ico");
            // 
            // extractButton
            // 
            resources.ApplyResources(this.extractButton, "extractButton");
            this.extractButton.Name = "extractButton";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // extractListView
            // 
            resources.ApplyResources(this.extractListView, "extractListView");
            this.extractListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.sizeHeader});
            this.extractListView.ContextMenuStrip = this.extractListContextMenuStrip;
            this.extractListView.FullRowSelect = true;
            this.extractListView.Name = "extractListView";
            this.extractListView.UseCompatibleStateImageBehavior = false;
            this.extractListView.View = System.Windows.Forms.View.Details;
            // 
            // nameHeader
            // 
            resources.ApplyResources(this.nameHeader, "nameHeader");
            // 
            // sizeHeader
            // 
            resources.ApplyResources(this.sizeHeader, "sizeHeader");
            // 
            // extractListContextMenuStrip
            // 
            this.extractListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.extractListContextMenuStrip.Name = "extractListContextMenuStrip";
            resources.ApplyResources(this.extractListContextMenuStrip, "extractListContextMenuStrip");
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // totalFileSizeLabel
            // 
            resources.ApplyResources(this.totalFileSizeLabel, "totalFileSizeLabel");
            this.totalFileSizeLabel.Name = "totalFileSizeLabel";
            // 
            // totalFileCountLabel
            // 
            resources.ApplyResources(this.totalFileCountLabel, "totalFileCountLabel");
            this.totalFileCountLabel.Name = "totalFileCountLabel";
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // FileBrowserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.totalFileSizeLabel);
            this.Controls.Add(this.totalFileCountLabel);
            this.Controls.Add(this.extractListView);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.fileTreeView);
            this.Name = "FileBrowserControl";
            this.Load += new System.EventHandler(this.FileBrowserControl_Load);
            this.treeViewContextMenuStrip.ResumeLayout(false);
            this.extractListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.ListView extractListView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.Label totalFileSizeLabel;
        private System.Windows.Forms.Label totalFileCountLabel;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip extractListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}
