namespace UmaMusumeExplorer.Controls.Jukebox
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
            playButton = new System.Windows.Forms.Button();
            stopButton = new System.Windows.Forms.Button();
            seekTrackBar = new System.Windows.Forms.TrackBar();
            volumeTrackbar = new System.Windows.Forms.TrackBar();
            volumeLabel = new System.Windows.Forms.Label();
            currentTimeLabel = new System.Windows.Forms.Label();
            totalTimeLabel = new System.Windows.Forms.Label();
            updateTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)songJacketPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).BeginInit();
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
            // PlayerForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(totalTimeLabel);
            Controls.Add(currentTimeLabel);
            Controls.Add(volumeLabel);
            Controls.Add(volumeTrackbar);
            Controls.Add(seekTrackBar);
            Controls.Add(stopButton);
            Controls.Add(playButton);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Common.HighQualityPictureBox songJacketPictureBox;
        private System.Windows.Forms.Label songTitleLabel;
        private System.Windows.Forms.Label songInfoLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TrackBar seekTrackBar;
        private System.Windows.Forms.TrackBar volumeTrackbar;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Timer updateTimer;
    }
}