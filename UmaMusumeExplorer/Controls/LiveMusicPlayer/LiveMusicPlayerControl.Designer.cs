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
            songItemsPanel = new Common.SongItemsPanel();
            linkLabelDownload = new LinkLabel();
            SuspendLayout();
            // 
            // songItemsPanel
            // 
            songItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            songItemsPanel.Indeterminate = false;
            songItemsPanel.Items = null;
            songItemsPanel.Location = new Point(3, 18);
            songItemsPanel.Name = "songItemsPanel";
            songItemsPanel.Size = new Size(815, 507);
            songItemsPanel.TabIndex = 0;
            // 
            // linkLabelDownload
            // 
            linkLabelDownload.AutoSize = true;
            linkLabelDownload.Location = new Point(3, 0);
            linkLabelDownload.Name = "linkLabelDownload";
            linkLabelDownload.Size = new Size(143, 15);
            linkLabelDownload.TabIndex = 2;
            linkLabelDownload.TabStop = true;
            linkLabelDownload.Text = "Live audio data download";
            linkLabelDownload.LinkClicked += LinkLabelDownload_LinkClicked;
            // 
            // LiveMusicPlayerControl
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(linkLabelDownload);
            Controls.Add(songItemsPanel);
            Name = "LiveMusicPlayerControl";
            Size = new Size(821, 528);
            Load += LiveMusicPlayerSongSelectControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Common.SongItemsPanel songItemsPanel;
        private LinkLabel linkLabelDownload;
    }
}
