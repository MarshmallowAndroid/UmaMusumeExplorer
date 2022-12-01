namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class PlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.songJacketPictureBox = new System.Windows.Forms.PictureBox();
            this.songTitleLabel = new System.Windows.Forms.Label();
            this.songInfoLabel = new System.Windows.Forms.Label();
            this.lyricsLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.setupButton = new System.Windows.Forms.Button();
            this.seekTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeTrackbar = new System.Windows.Forms.TrackBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.playerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.titleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.forceSoloMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceAllSingingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceMuteSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.muteBgmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteVoicesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.songJacketPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackbar)).BeginInit();
            this.playerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // songJacketPictureBox
            // 
            resources.ApplyResources(this.songJacketPictureBox, "songJacketPictureBox");
            this.songJacketPictureBox.Name = "songJacketPictureBox";
            this.songJacketPictureBox.TabStop = false;
            // 
            // songTitleLabel
            // 
            resources.ApplyResources(this.songTitleLabel, "songTitleLabel");
            this.songTitleLabel.Name = "songTitleLabel";
            // 
            // songInfoLabel
            // 
            resources.ApplyResources(this.songInfoLabel, "songInfoLabel");
            this.songInfoLabel.Name = "songInfoLabel";
            // 
            // lyricsLabel
            // 
            resources.ApplyResources(this.lyricsLabel, "lyricsLabel");
            this.lyricsLabel.Name = "lyricsLabel";
            // 
            // playButton
            // 
            resources.ApplyResources(this.playButton, "playButton");
            this.playButton.Name = "playButton";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // stopButton
            // 
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.Name = "stopButton";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // setupButton
            // 
            resources.ApplyResources(this.setupButton, "setupButton");
            this.setupButton.Name = "setupButton";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // seekTrackBar
            // 
            resources.ApplyResources(this.seekTrackBar, "seekTrackBar");
            this.seekTrackBar.Maximum = 100;
            this.seekTrackBar.Name = "seekTrackBar";
            this.seekTrackBar.TickFrequency = 0;
            this.seekTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.seekTrackBar.Scroll += new System.EventHandler(this.SeekTrackBar_Scroll);
            // 
            // volumeTrackbar
            // 
            resources.ApplyResources(this.volumeTrackbar, "volumeTrackbar");
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.TickFrequency = 50;
            this.volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeTrackbar.Scroll += new System.EventHandler(this.VolumeTrackbar_Scroll);
            // 
            // volumeLabel
            // 
            resources.ApplyResources(this.volumeLabel, "volumeLabel");
            this.volumeLabel.Name = "volumeLabel";
            // 
            // currentTimeLabel
            // 
            resources.ApplyResources(this.currentTimeLabel, "currentTimeLabel");
            this.currentTimeLabel.Name = "currentTimeLabel";
            // 
            // totalTimeLabel
            // 
            resources.ApplyResources(this.totalTimeLabel, "totalTimeLabel");
            this.totalTimeLabel.Name = "totalTimeLabel";
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // playerContextMenuStrip
            // 
            this.playerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleMenuItem,
            this.titleSeparator,
            this.forceSoloMenuItem,
            this.forceAllSingingMenuItem,
            this.forceMuteSeparator,
            this.muteBgmMenuItem,
            this.muteVoicesMenuItem,
            this.exportSeparator,
            this.exportMenuItem});
            this.playerContextMenuStrip.Name = "playerContextMenuStrip";
            resources.ApplyResources(this.playerContextMenuStrip, "playerContextMenuStrip");
            // 
            // titleMenuItem
            // 
            this.titleMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.titleMenuItem, "titleMenuItem");
            this.titleMenuItem.Name = "titleMenuItem";
            // 
            // titleSeparator
            // 
            this.titleSeparator.Name = "titleSeparator";
            resources.ApplyResources(this.titleSeparator, "titleSeparator");
            // 
            // forceSoloMenuItem
            // 
            this.forceSoloMenuItem.CheckOnClick = true;
            this.forceSoloMenuItem.Name = "forceSoloMenuItem";
            resources.ApplyResources(this.forceSoloMenuItem, "forceSoloMenuItem");
            this.forceSoloMenuItem.Click += new System.EventHandler(this.ForceSoloMenuItem_Click);
            // 
            // forceAllSingingMenuItem
            // 
            this.forceAllSingingMenuItem.CheckOnClick = true;
            this.forceAllSingingMenuItem.Name = "forceAllSingingMenuItem";
            resources.ApplyResources(this.forceAllSingingMenuItem, "forceAllSingingMenuItem");
            this.forceAllSingingMenuItem.Click += new System.EventHandler(this.ForceAllSingingMenuItem_Click);
            // 
            // forceMuteSeparator
            // 
            this.forceMuteSeparator.Name = "forceMuteSeparator";
            resources.ApplyResources(this.forceMuteSeparator, "forceMuteSeparator");
            // 
            // muteBgmMenuItem
            // 
            this.muteBgmMenuItem.CheckOnClick = true;
            this.muteBgmMenuItem.Name = "muteBgmMenuItem";
            resources.ApplyResources(this.muteBgmMenuItem, "muteBgmMenuItem");
            this.muteBgmMenuItem.Click += new System.EventHandler(this.MuteBgmMenuItem_Click);
            // 
            // muteVoicesMenuItem
            // 
            this.muteVoicesMenuItem.CheckOnClick = true;
            this.muteVoicesMenuItem.Name = "muteVoicesMenuItem";
            resources.ApplyResources(this.muteVoicesMenuItem, "muteVoicesMenuItem");
            this.muteVoicesMenuItem.Click += new System.EventHandler(this.MuteVoicesMenuItem_Click);
            // 
            // exportSeparator
            // 
            this.exportSeparator.Name = "exportSeparator";
            resources.ApplyResources(this.exportSeparator, "exportSeparator");
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            resources.ApplyResources(this.exportMenuItem, "exportMenuItem");
            this.exportMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // PlayerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.playerContextMenuStrip;
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeTrackbar);
            this.Controls.Add(this.seekTrackBar);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.lyricsLabel);
            this.Controls.Add(this.songInfoLabel);
            this.Controls.Add(this.songTitleLabel);
            this.Controls.Add(this.songJacketPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.LiveMusicPlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songJacketPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackbar)).EndInit();
            this.playerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox songJacketPictureBox;
        private System.Windows.Forms.Label songTitleLabel;
        private System.Windows.Forms.Label songInfoLabel;
        private System.Windows.Forms.Label lyricsLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.TrackBar seekTrackBar;
        private System.Windows.Forms.TrackBar volumeTrackbar;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ContextMenuStrip playerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem titleMenuItem;
        private System.Windows.Forms.ToolStripSeparator titleSeparator;
        private System.Windows.Forms.ToolStripMenuItem forceSoloMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteBgmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteVoicesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceAllSingingMenuItem;
        private System.Windows.Forms.ToolStripSeparator forceMuteSeparator;
        private System.Windows.Forms.ToolStripSeparator exportSeparator;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
    }
}