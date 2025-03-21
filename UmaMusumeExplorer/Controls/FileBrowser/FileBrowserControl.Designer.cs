﻿namespace UmaMusumeExplorer.Controls.FileBrowser
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBrowserControl));
            fileTreeView = new TreeView();
            treeViewContextMenuStrip = new ContextMenuStrip(components);
            addToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            openFileLocationToolStripMenuItem = new ToolStripMenuItem();
            treeViewImageList = new ImageList(components);
            extractButton = new Button();
            extractListView = new ListView();
            nameHeader = new ColumnHeader();
            sizeHeader = new ColumnHeader();
            extractListContextMenuStrip = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            totalFileSizeLabel = new Label();
            totalFileCountLabel = new Label();
            clearButton = new Button();
            progressBar = new ProgressBar();
            searchTextBox = new TextBox();
            searchButton = new Button();
            treeViewContextMenuStrip.SuspendLayout();
            extractListContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // fileTreeView
            // 
            resources.ApplyResources(fileTreeView, "fileTreeView");
            fileTreeView.ContextMenuStrip = treeViewContextMenuStrip;
            fileTreeView.ImageList = treeViewImageList;
            fileTreeView.Name = "fileTreeView";
            fileTreeView.PathSeparator = "/";
            fileTreeView.BeforeExpand += FileTreeView_BeforeExpand;
            // 
            // treeViewContextMenuStrip
            // 
            treeViewContextMenuStrip.ImageScalingSize = new Size(20, 20);
            treeViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, toolStripSeparator1, openFileLocationToolStripMenuItem });
            treeViewContextMenuStrip.Name = "treeViewContextMenuStrip";
            resources.ApplyResources(treeViewContextMenuStrip, "treeViewContextMenuStrip");
            treeViewContextMenuStrip.Opening += TreeViewContextMenuStrip_Opening;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(addToolStripMenuItem, "addToolStripMenuItem");
            addToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // openFileLocationToolStripMenuItem
            // 
            openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            resources.ApplyResources(openFileLocationToolStripMenuItem, "openFileLocationToolStripMenuItem");
            openFileLocationToolStripMenuItem.Click += OpenFileLocationToolStripMenuItem_Click;
            // 
            // treeViewImageList
            // 
            treeViewImageList.ColorDepth = ColorDepth.Depth32Bit;
            treeViewImageList.ImageStream = (ImageListStreamer)resources.GetObject("treeViewImageList.ImageStream");
            treeViewImageList.TransparentColor = Color.Transparent;
            treeViewImageList.Images.SetKeyName(0, "FolderIcon.ico");
            treeViewImageList.Images.SetKeyName(1, "FileIcon.ico");
            // 
            // extractButton
            // 
            resources.ApplyResources(extractButton, "extractButton");
            extractButton.Name = "extractButton";
            extractButton.UseVisualStyleBackColor = true;
            extractButton.Click += ExtractButton_Click;
            // 
            // extractListView
            // 
            resources.ApplyResources(extractListView, "extractListView");
            extractListView.Columns.AddRange(new ColumnHeader[] { nameHeader, sizeHeader });
            extractListView.ContextMenuStrip = extractListContextMenuStrip;
            extractListView.FullRowSelect = true;
            extractListView.Name = "extractListView";
            extractListView.UseCompatibleStateImageBehavior = false;
            extractListView.View = View.Details;
            extractListView.Resize += ExtractListView_Resize;
            // 
            // nameHeader
            // 
            resources.ApplyResources(nameHeader, "nameHeader");
            // 
            // sizeHeader
            // 
            resources.ApplyResources(sizeHeader, "sizeHeader");
            // 
            // extractListContextMenuStrip
            // 
            extractListContextMenuStrip.ImageScalingSize = new Size(20, 20);
            extractListContextMenuStrip.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem });
            extractListContextMenuStrip.Name = "extractListContextMenuStrip";
            resources.ApplyResources(extractListContextMenuStrip, "extractListContextMenuStrip");
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(removeToolStripMenuItem, "removeToolStripMenuItem");
            removeToolStripMenuItem.Click += RemoveToolStripMenuItem_Click;
            // 
            // totalFileSizeLabel
            // 
            resources.ApplyResources(totalFileSizeLabel, "totalFileSizeLabel");
            totalFileSizeLabel.Name = "totalFileSizeLabel";
            // 
            // totalFileCountLabel
            // 
            resources.ApplyResources(totalFileCountLabel, "totalFileCountLabel");
            totalFileCountLabel.Name = "totalFileCountLabel";
            // 
            // clearButton
            // 
            resources.ApplyResources(clearButton, "clearButton");
            clearButton.Name = "clearButton";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // progressBar
            // 
            resources.ApplyResources(progressBar, "progressBar");
            progressBar.Name = "progressBar";
            // 
            // searchTextBox
            // 
            resources.ApplyResources(searchTextBox, "searchTextBox");
            searchTextBox.Name = "searchTextBox";
            // 
            // searchButton
            // 
            resources.ApplyResources(searchButton, "searchButton");
            searchButton.Name = "searchButton";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // FileBrowserControl
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Controls.Add(progressBar);
            Controls.Add(clearButton);
            Controls.Add(totalFileSizeLabel);
            Controls.Add(totalFileCountLabel);
            Controls.Add(extractListView);
            Controls.Add(extractButton);
            Controls.Add(fileTreeView);
            Name = "FileBrowserControl";
            resources.ApplyResources(this, "$this");
            Load += FileBrowserControl_Load;
            treeViewContextMenuStrip.ResumeLayout(false);
            extractListContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip extractListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}
