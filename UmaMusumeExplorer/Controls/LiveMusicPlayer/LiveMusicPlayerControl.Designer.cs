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
            this.loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.jacketPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // loadingBackgroundWorker
            // 
            this.loadingBackgroundWorker.WorkerReportsProgress = true;
            this.loadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.loadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.loadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingProgressBar.Location = new System.Drawing.Point(194, 253);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(433, 23);
            this.loadingProgressBar.TabIndex = 1;
            // 
            // jacketPanel
            // 
            this.jacketPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jacketPanel.AutoScroll = true;
            this.jacketPanel.Location = new System.Drawing.Point(3, 3);
            this.jacketPanel.Name = "jacketPanel";
            this.jacketPanel.Size = new System.Drawing.Size(815, 522);
            this.jacketPanel.TabIndex = 0;
            // 
            // LiveMusicPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.jacketPanel);
            this.Name = "LiveMusicPlayerControl";
            this.Size = new System.Drawing.Size(821, 528);
            this.Load += new System.EventHandler(this.LiveMusicPlayerSongSelectControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.FlowLayoutPanel jacketPanel;
    }
}
