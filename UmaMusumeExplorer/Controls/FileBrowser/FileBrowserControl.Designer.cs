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
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.extractButton = new System.Windows.Forms.Button();
            this.extractListView = new System.Windows.Forms.ListView();
            this.nameHeader = new System.Windows.Forms.ColumnHeader();
            this.sizeHeader = new System.Windows.Forms.ColumnHeader();
            this.totalFileSizeLabel = new System.Windows.Forms.Label();
            this.totalFileCountLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.treeViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTreeView
            // 
            this.fileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileTreeView.ContextMenuStrip = this.treeViewContextMenuStrip;
            this.fileTreeView.ImageIndex = 0;
            this.fileTreeView.ImageList = this.treeViewImageList;
            this.fileTreeView.Location = new System.Drawing.Point(3, 3);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.PathSeparator = "/";
            this.fileTreeView.SelectedImageIndex = 0;
            this.fileTreeView.Size = new System.Drawing.Size(434, 561);
            this.fileTreeView.TabIndex = 0;
            this.fileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FileTreeView_BeforeExpand);
            // 
            // treeViewContextMenuStrip
            // 
            this.treeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.treeViewContextMenuStrip.Name = "treeViewContextMenuStrip";
            this.treeViewContextMenuStrip.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
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
            this.extractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.extractButton.Location = new System.Drawing.Point(524, 518);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(75, 23);
            this.extractButton.TabIndex = 1;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // extractListView
            // 
            this.extractListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.sizeHeader});
            this.extractListView.FullRowSelect = true;
            this.extractListView.Location = new System.Drawing.Point(443, 3);
            this.extractListView.Name = "extractListView";
            this.extractListView.Size = new System.Drawing.Size(404, 473);
            this.extractListView.TabIndex = 2;
            this.extractListView.UseCompatibleStateImageBehavior = false;
            this.extractListView.View = System.Windows.Forms.View.Details;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 325;
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "Size";
            this.sizeHeader.Width = 75;
            // 
            // totalFileSizeLabel
            // 
            this.totalFileSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalFileSizeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalFileSizeLabel.Location = new System.Drawing.Point(629, 479);
            this.totalFileSizeLabel.Name = "totalFileSizeLabel";
            this.totalFileSizeLabel.Size = new System.Drawing.Size(218, 36);
            this.totalFileSizeLabel.TabIndex = 3;
            this.totalFileSizeLabel.Text = "0 B";
            this.totalFileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalFileCountLabel
            // 
            this.totalFileCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalFileCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalFileCountLabel.Location = new System.Drawing.Point(443, 479);
            this.totalFileCountLabel.Name = "totalFileCountLabel";
            this.totalFileCountLabel.Size = new System.Drawing.Size(100, 36);
            this.totalFileCountLabel.TabIndex = 3;
            this.totalFileCountLabel.Text = "0 files";
            this.totalFileCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(443, 518);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(443, 547);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(404, 17);
            this.progressBar1.TabIndex = 5;
            // 
            // FileBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.totalFileSizeLabel);
            this.Controls.Add(this.totalFileCountLabel);
            this.Controls.Add(this.extractListView);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.fileTreeView);
            this.Name = "FileBrowserControl";
            this.Size = new System.Drawing.Size(850, 567);
            this.Load += new System.EventHandler(this.FileBrowserControl_Load);
            this.treeViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
