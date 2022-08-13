namespace UmaMusumeExplorer.Controls.Jukebox
{
    partial class JukeboxPlayerForm
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
            this.songJacketPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.songJacketPictureBox.Location = new System.Drawing.Point(145, 12);
            this.songJacketPictureBox.Name = "songJacketPictureBox";
            this.songJacketPictureBox.Size = new System.Drawing.Size(256, 256);
            this.songJacketPictureBox.TabIndex = 0;
            this.songJacketPictureBox.TabStop = false;
            // 
            // songTitleLabel
            // 
            this.songTitleLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.songTitleLabel.Location = new System.Drawing.Point(12, 271);
            this.songTitleLabel.Name = "songTitleLabel";
            this.songTitleLabel.Size = new System.Drawing.Size(523, 74);
            this.songTitleLabel.TabIndex = 1;
            this.songTitleLabel.Text = "？？？";
            this.songTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // songInfoLabel
            // 
            this.songInfoLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songInfoLabel.Location = new System.Drawing.Point(12, 345);
            this.songInfoLabel.Name = "songInfoLabel";
            this.songInfoLabel.Size = new System.Drawing.Size(523, 110);
            this.songInfoLabel.TabIndex = 1;
            this.songInfoLabel.Text = "？？？";
            this.songInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lyricsLabel
            // 
            this.lyricsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lyricsLabel.Location = new System.Drawing.Point(12, 455);
            this.lyricsLabel.Name = "lyricsLabel";
            this.lyricsLabel.Size = new System.Drawing.Size(523, 58);
            this.lyricsLabel.TabIndex = 1;
            this.lyricsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playButton.Location = new System.Drawing.Point(181, 593);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(185, 51);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopButton.Location = new System.Drawing.Point(465, 593);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(70, 51);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // setupButton
            // 
            this.setupButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setupButton.Location = new System.Drawing.Point(12, 593);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(70, 51);
            this.setupButton.TabIndex = 2;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            // 
            // seekTrackBar
            // 
            this.seekTrackBar.Location = new System.Drawing.Point(12, 542);
            this.seekTrackBar.Maximum = 100;
            this.seekTrackBar.Name = "seekTrackBar";
            this.seekTrackBar.Size = new System.Drawing.Size(523, 45);
            this.seekTrackBar.TabIndex = 3;
            this.seekTrackBar.TickFrequency = 0;
            this.seekTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.seekTrackBar.Scroll += new System.EventHandler(this.SeekTrackBar_Scroll);
            // 
            // volumeTrackbar
            // 
            this.volumeTrackbar.Location = new System.Drawing.Point(150, 650);
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.Size = new System.Drawing.Size(247, 45);
            this.volumeTrackbar.TabIndex = 3;
            this.volumeTrackbar.TickFrequency = 50;
            this.volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeTrackbar.Scroll += new System.EventHandler(this.VolumeTrackbar_Scroll);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(254, 698);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(23, 15);
            this.volumeLabel.TabIndex = 4;
            this.volumeLabel.Text = "0%";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentTimeLabel.Location = new System.Drawing.Point(12, 513);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(70, 34);
            this.currentTimeLabel.TabIndex = 5;
            this.currentTimeLabel.Text = "0:00";
            this.currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalTimeLabel.Location = new System.Drawing.Point(465, 513);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(70, 34);
            this.totalTimeLabel.TabIndex = 5;
            this.totalTimeLabel.Text = "0:00";
            this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // JukeboxPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 722);
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
            this.Name = "JukeboxPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Jukebox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JukeboxPlayerForm_FormClosing);
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