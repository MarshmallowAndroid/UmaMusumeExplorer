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
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // fileTreeView
            // 
            this.fileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileTreeView.CheckBoxes = true;
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
            // treeViewImageList
            // 
            this.treeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "FolderIcon.ico");
            this.treeViewImageList.Images.SetKeyName(1, "FileIcon.ico");
            // 
            // FileBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileTreeView);
            this.Name = "FileBrowserControl";
            this.Size = new System.Drawing.Size(705, 567);
            this.Load += new System.EventHandler(this.FileBrowserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.ImageList treeViewImageList;
    }
}
