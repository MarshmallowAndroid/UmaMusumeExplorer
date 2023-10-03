namespace UmaMusumeExplorer.Controls.Common
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
            expandButton = new System.Windows.Forms.Button();
            charaContainerPanel = new System.Windows.Forms.FlowLayoutPanel();
            charaContainerContainerPanel = new System.Windows.Forms.TableLayoutPanel();
            customVoiceControlCheckBox = new System.Windows.Forms.CheckBox();
            muteBgmCheckBox = new System.Windows.Forms.CheckBox();
            exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)songJacketPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).BeginInit();
            charaContainerContainerPanel.SuspendLayout();
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
            // expandButton
            // 
            resources.ApplyResources(expandButton, "expandButton");
            expandButton.Name = "expandButton";
            expandButton.UseVisualStyleBackColor = true;
            expandButton.Click += ExpandButton_Click;
            // 
            // charaContainerPanel
            // 
            resources.ApplyResources(charaContainerPanel, "charaContainerPanel");
            charaContainerPanel.Name = "charaContainerPanel";
            // 
            // charaContainerContainerPanel
            // 
            resources.ApplyResources(charaContainerContainerPanel, "charaContainerContainerPanel");
            charaContainerContainerPanel.Controls.Add(charaContainerPanel, 0, 0);
            charaContainerContainerPanel.Name = "charaContainerContainerPanel";
            // 
            // customVoiceControlCheckBox
            // 
            resources.ApplyResources(customVoiceControlCheckBox, "customVoiceControlCheckBox");
            customVoiceControlCheckBox.Name = "customVoiceControlCheckBox";
            customVoiceControlCheckBox.UseVisualStyleBackColor = true;
            customVoiceControlCheckBox.CheckedChanged += CustomVoiceControlCheckBox_CheckedChanged;
            // 
            // muteBgmCheckBox
            // 
            resources.ApplyResources(muteBgmCheckBox, "muteBgmCheckBox");
            muteBgmCheckBox.Name = "muteBgmCheckBox";
            muteBgmCheckBox.UseVisualStyleBackColor = true;
            muteBgmCheckBox.CheckedChanged += MuteBgmCheckBox_CheckedChanged;
            // 
            // exportButton
            // 
            resources.ApplyResources(exportButton, "exportButton");
            exportButton.Name = "exportButton";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += ExportButton_Click;
            // 
            // PlayerForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(exportButton);
            Controls.Add(muteBgmCheckBox);
            Controls.Add(customVoiceControlCheckBox);
            Controls.Add(charaContainerContainerPanel);
            Controls.Add(expandButton);
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
            charaContainerContainerPanel.ResumeLayout(false);
            charaContainerContainerPanel.PerformLayout();
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
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.FlowLayoutPanel charaContainerPanel;
        private System.Windows.Forms.TableLayoutPanel charaContainerContainerPanel;
        private System.Windows.Forms.CheckBox customVoiceControlCheckBox;
        private System.Windows.Forms.CheckBox muteBgmCheckBox;
        private System.Windows.Forms.Button exportButton;
    }
}