namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class LiveMusicPlayerControl
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
            loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            loadingProgressBar = new System.Windows.Forms.ProgressBar();
            jacketPanel = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // loadingBackgroundWorker
            // 
            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            loadingProgressBar.Location = new System.Drawing.Point(194, 253);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new System.Drawing.Size(433, 23);
            loadingProgressBar.TabIndex = 1;
            // 
            // jacketPanel
            // 
            jacketPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            jacketPanel.AutoScroll = true;
            jacketPanel.Location = new System.Drawing.Point(3, 3);
            jacketPanel.Name = "jacketPanel";
            jacketPanel.Size = new System.Drawing.Size(815, 522);
            jacketPanel.TabIndex = 0;
            // 
            // LiveMusicPlayerControl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            Controls.Add(loadingProgressBar);
            Controls.Add(jacketPanel);
            Name = "LiveMusicPlayerControl";
            Size = new System.Drawing.Size(821, 528);
            Load += LiveMusicPlayerSongSelectControl_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.FlowLayoutPanel jacketPanel;
    }
}
