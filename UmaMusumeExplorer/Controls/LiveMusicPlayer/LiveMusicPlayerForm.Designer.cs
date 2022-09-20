namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class LiveMusicPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveMusicPlayerForm));
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
            ((System.ComponentModel.ISupportInitialize)(this.songJacketPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackbar)).BeginInit();
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
            // LiveMusicPlayerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.Name = "LiveMusicPlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JukeboxPlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.LiveMusicPlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songJacketPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackbar)).EndInit();
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
    }
}