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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            songJacketPictureBox = new Common.HighQualityPictureBox();
            songTitleLabel = new System.Windows.Forms.Label();
            songInfoLabel = new System.Windows.Forms.Label();
            lyricsLabel = new System.Windows.Forms.Label();
            playButton = new System.Windows.Forms.Button();
            stopButton = new System.Windows.Forms.Button();
            setupButton = new System.Windows.Forms.Button();
            seekTrackBar = new System.Windows.Forms.TrackBar();
            volumeTrackbar = new System.Windows.Forms.TrackBar();
            volumeLabel = new System.Windows.Forms.Label();
            currentTimeLabel = new System.Windows.Forms.Label();
            totalTimeLabel = new System.Windows.Forms.Label();
            updateTimer = new System.Windows.Forms.Timer(components);
            playerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            titleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            titleSeparator = new System.Windows.Forms.ToolStripSeparator();
            forceSoloMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            forceAllSingingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            forceMuteSeparator = new System.Windows.Forms.ToolStripSeparator();
            muteBgmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            muteVoicesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportSeparator = new System.Windows.Forms.ToolStripSeparator();
            exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)songJacketPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).BeginInit();
            playerContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // songJacketPictureBox
            // 
            resources.ApplyResources(songJacketPictureBox, "songJacketPictureBox");
            songJacketPictureBox.Name = "songJacketPictureBox";
            songJacketPictureBox.TabStop = false;
            // 
            // songTitleLabel
            // 
            resources.ApplyResources(songTitleLabel, "songTitleLabel");
            songTitleLabel.Name = "songTitleLabel";
            // 
            // songInfoLabel
            // 
            resources.ApplyResources(songInfoLabel, "songInfoLabel");
            songInfoLabel.Name = "songInfoLabel";
            // 
            // lyricsLabel
            // 
            resources.ApplyResources(lyricsLabel, "lyricsLabel");
            lyricsLabel.Name = "lyricsLabel";
            // 
            // playButton
            // 
            resources.ApplyResources(playButton, "playButton");
            playButton.Name = "playButton";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayButton_Click;
            // 
            // stopButton
            // 
            resources.ApplyResources(stopButton, "stopButton");
            stopButton.Name = "stopButton";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Click;
            // 
            // setupButton
            // 
            resources.ApplyResources(setupButton, "setupButton");
            setupButton.Name = "setupButton";
            setupButton.UseVisualStyleBackColor = true;
            setupButton.Click += SetupButton_Click;
            // 
            // seekTrackBar
            // 
            resources.ApplyResources(seekTrackBar, "seekTrackBar");
            seekTrackBar.Maximum = 100;
            seekTrackBar.Name = "seekTrackBar";
            seekTrackBar.TickFrequency = 0;
            seekTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            seekTrackBar.Scroll += SeekTrackBar_Scroll;
            // 
            // volumeTrackbar
            // 
            resources.ApplyResources(volumeTrackbar, "volumeTrackbar");
            volumeTrackbar.Maximum = 100;
            volumeTrackbar.Name = "volumeTrackbar";
            volumeTrackbar.TickFrequency = 50;
            volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeTrackbar.Scroll += VolumeTrackbar_Scroll;
            // 
            // volumeLabel
            // 
            resources.ApplyResources(volumeLabel, "volumeLabel");
            volumeLabel.Name = "volumeLabel";
            // 
            // currentTimeLabel
            // 
            resources.ApplyResources(currentTimeLabel, "currentTimeLabel");
            currentTimeLabel.Name = "currentTimeLabel";
            // 
            // totalTimeLabel
            // 
            resources.ApplyResources(totalTimeLabel, "totalTimeLabel");
            totalTimeLabel.Name = "totalTimeLabel";
            // 
            // updateTimer
            // 
            updateTimer.Interval = 500;
            updateTimer.Tick += UpdateTimer_Tick;
            // 
            // playerContextMenuStrip
            // 
            playerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { titleMenuItem, titleSeparator, forceSoloMenuItem, forceAllSingingMenuItem, forceMuteSeparator, muteBgmMenuItem, muteVoicesMenuItem, exportSeparator, exportMenuItem });
            playerContextMenuStrip.Name = "playerContextMenuStrip";
            resources.ApplyResources(playerContextMenuStrip, "playerContextMenuStrip");
            // 
            // titleMenuItem
            // 
            titleMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(titleMenuItem, "titleMenuItem");
            titleMenuItem.Name = "titleMenuItem";
            // 
            // titleSeparator
            // 
            titleSeparator.Name = "titleSeparator";
            resources.ApplyResources(titleSeparator, "titleSeparator");
            // 
            // forceSoloMenuItem
            // 
            forceSoloMenuItem.CheckOnClick = true;
            forceSoloMenuItem.Name = "forceSoloMenuItem";
            resources.ApplyResources(forceSoloMenuItem, "forceSoloMenuItem");
            forceSoloMenuItem.Click += ForceSoloMenuItem_Click;
            // 
            // forceAllSingingMenuItem
            // 
            forceAllSingingMenuItem.CheckOnClick = true;
            forceAllSingingMenuItem.Name = "forceAllSingingMenuItem";
            resources.ApplyResources(forceAllSingingMenuItem, "forceAllSingingMenuItem");
            forceAllSingingMenuItem.Click += ForceAllSingingMenuItem_Click;
            // 
            // forceMuteSeparator
            // 
            forceMuteSeparator.Name = "forceMuteSeparator";
            resources.ApplyResources(forceMuteSeparator, "forceMuteSeparator");
            // 
            // muteBgmMenuItem
            // 
            muteBgmMenuItem.CheckOnClick = true;
            muteBgmMenuItem.Name = "muteBgmMenuItem";
            resources.ApplyResources(muteBgmMenuItem, "muteBgmMenuItem");
            muteBgmMenuItem.Click += MuteBgmMenuItem_Click;
            // 
            // muteVoicesMenuItem
            // 
            muteVoicesMenuItem.CheckOnClick = true;
            muteVoicesMenuItem.Name = "muteVoicesMenuItem";
            resources.ApplyResources(muteVoicesMenuItem, "muteVoicesMenuItem");
            muteVoicesMenuItem.Click += MuteVoicesMenuItem_Click;
            // 
            // exportSeparator
            // 
            exportSeparator.Name = "exportSeparator";
            resources.ApplyResources(exportSeparator, "exportSeparator");
            // 
            // exportMenuItem
            // 
            exportMenuItem.Name = "exportMenuItem";
            resources.ApplyResources(exportMenuItem, "exportMenuItem");
            exportMenuItem.Click += ExportMenuItem_Click;
            // 
            // PlayerForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ContextMenuStrip = playerContextMenuStrip;
            Controls.Add(totalTimeLabel);
            Controls.Add(currentTimeLabel);
            Controls.Add(volumeLabel);
            Controls.Add(volumeTrackbar);
            Controls.Add(seekTrackBar);
            Controls.Add(setupButton);
            Controls.Add(stopButton);
            Controls.Add(playButton);
            Controls.Add(lyricsLabel);
            Controls.Add(songInfoLabel);
            Controls.Add(songTitleLabel);
            Controls.Add(songJacketPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PlayerForm";
            FormClosing += PlayerForm_FormClosing;
            Load += LiveMusicPlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)songJacketPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).EndInit();
            playerContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Common.HighQualityPictureBox songJacketPictureBox;
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