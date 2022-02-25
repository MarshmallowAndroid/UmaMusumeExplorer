
namespace PlayerGui.Controls.AudioPlayer
{
    partial class AudioPlayerControl
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
            this.fileListView = new System.Windows.Forms.ListView();
            this.nameHeader = new System.Windows.Forms.ColumnHeader();
            this.tracksHeader = new System.Windows.Forms.ColumnHeader();
            this.loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tracksComboBox = new System.Windows.Forms.ComboBox();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.loadingFileNameLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.timeLengthLabel = new System.Windows.Forms.Label();
            this.timeElapsedLabel = new System.Windows.Forms.Label();
            this.seekTrackBar = new System.Windows.Forms.TrackBar();
            this.controlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.prevTrackButton = new System.Windows.Forms.Button();
            this.nextTrackButton = new System.Windows.Forms.Button();
            this.prevBankButton = new System.Windows.Forms.Button();
            this.nextBankButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).BeginInit();
            this.controlsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.tracksHeader});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.FullRowSelect = true;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.MultiSelect = false;
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(459, 630);
            this.fileListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemActivate += new System.EventHandler(this.FileListView_ItemActivate);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 240;
            // 
            // tracksHeader
            // 
            this.tracksHeader.Text = "Tracks";
            // 
            // loadingBackgroundWorker
            // 
            this.loadingBackgroundWorker.WorkerReportsProgress = true;
            this.loadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.loadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.loadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // tracksComboBox
            // 
            this.tracksComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tracksComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tracksComboBox.FormattingEnabled = true;
            this.tracksComboBox.Location = new System.Drawing.Point(3, 3);
            this.tracksComboBox.Name = "tracksComboBox";
            this.tracksComboBox.Size = new System.Drawing.Size(453, 23);
            this.tracksComboBox.TabIndex = 1;
            this.tracksComboBox.SelectedIndexChanged += new System.EventHandler(this.TracksComboBox_SelectedIndexChanged);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Location = new System.Drawing.Point(38, 300);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(384, 22);
            this.loadingProgressBar.TabIndex = 10;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.leftPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.rightPanel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(930, 636);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.loadingFileNameLabel);
            this.leftPanel.Controls.Add(this.loadingProgressBar);
            this.leftPanel.Controls.Add(this.fileListView);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(459, 630);
            this.leftPanel.TabIndex = 11;
            // 
            // loadingFileNameLabel
            // 
            this.loadingFileNameLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadingFileNameLabel.Location = new System.Drawing.Point(38, 273);
            this.loadingFileNameLabel.Name = "loadingFileNameLabel";
            this.loadingFileNameLabel.Size = new System.Drawing.Size(384, 24);
            this.loadingFileNameLabel.TabIndex = 11;
            this.loadingFileNameLabel.Text = "Loading...";
            this.loadingFileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.saveButton);
            this.rightPanel.Controls.Add(this.timeLengthLabel);
            this.rightPanel.Controls.Add(this.timeElapsedLabel);
            this.rightPanel.Controls.Add(this.seekTrackBar);
            this.rightPanel.Controls.Add(this.controlsTableLayoutPanel);
            this.rightPanel.Controls.Add(this.tracksComboBox);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(468, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(459, 630);
            this.rightPanel.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(3, 604);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save to WAV file...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // timeLengthLabel
            // 
            this.timeLengthLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timeLengthLabel.Location = new System.Drawing.Point(368, 208);
            this.timeLengthLabel.Name = "timeLengthLabel";
            this.timeLengthLabel.Size = new System.Drawing.Size(56, 23);
            this.timeLengthLabel.TabIndex = 0;
            this.timeLengthLabel.Text = "00:00";
            this.timeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timeElapsedLabel.Location = new System.Drawing.Point(34, 208);
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(56, 23);
            this.timeElapsedLabel.TabIndex = 0;
            this.timeElapsedLabel.Text = "00:00";
            this.timeElapsedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seekTrackBar
            // 
            this.seekTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seekTrackBar.Location = new System.Drawing.Point(34, 234);
            this.seekTrackBar.Maximum = 100;
            this.seekTrackBar.Name = "seekTrackBar";
            this.seekTrackBar.Size = new System.Drawing.Size(390, 45);
            this.seekTrackBar.TabIndex = 2;
            this.seekTrackBar.TickFrequency = 0;
            this.seekTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.seekTrackBar.Scroll += new System.EventHandler(this.SeekTrackBar_Scroll);
            // 
            // controlsTableLayoutPanel
            // 
            this.controlsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsTableLayoutPanel.ColumnCount = 5;
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.controlsTableLayoutPanel.Controls.Add(this.prevTrackButton, 1, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.nextTrackButton, 3, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.prevBankButton, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.nextBankButton, 4, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.playButton, 2, 0);
            this.controlsTableLayoutPanel.Location = new System.Drawing.Point(34, 285);
            this.controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            this.controlsTableLayoutPanel.RowCount = 1;
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.controlsTableLayoutPanel.Size = new System.Drawing.Size(390, 67);
            this.controlsTableLayoutPanel.TabIndex = 10;
            // 
            // prevTrackButton
            // 
            this.prevTrackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevTrackButton.Location = new System.Drawing.Point(81, 3);
            this.prevTrackButton.Name = "prevTrackButton";
            this.prevTrackButton.Size = new System.Drawing.Size(72, 61);
            this.prevTrackButton.TabIndex = 4;
            this.prevTrackButton.Text = "Prev. Track";
            this.prevTrackButton.UseVisualStyleBackColor = true;
            this.prevTrackButton.Click += new System.EventHandler(this.PrevTrackButton_Click);
            // 
            // nextTrackButton
            // 
            this.nextTrackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextTrackButton.Location = new System.Drawing.Point(237, 3);
            this.nextTrackButton.Name = "nextTrackButton";
            this.nextTrackButton.Size = new System.Drawing.Size(72, 61);
            this.nextTrackButton.TabIndex = 5;
            this.nextTrackButton.Text = "Next Track";
            this.nextTrackButton.UseVisualStyleBackColor = true;
            this.nextTrackButton.Click += new System.EventHandler(this.NextTrackButton_Click);
            // 
            // prevBankButton
            // 
            this.prevBankButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevBankButton.Location = new System.Drawing.Point(3, 3);
            this.prevBankButton.Name = "prevBankButton";
            this.prevBankButton.Size = new System.Drawing.Size(72, 61);
            this.prevBankButton.TabIndex = 6;
            this.prevBankButton.Text = "Prev. Bank";
            this.prevBankButton.UseVisualStyleBackColor = true;
            this.prevBankButton.Click += new System.EventHandler(this.PrevBankButton_Click);
            // 
            // nextBankButton
            // 
            this.nextBankButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextBankButton.Location = new System.Drawing.Point(315, 3);
            this.nextBankButton.Name = "nextBankButton";
            this.nextBankButton.Size = new System.Drawing.Size(72, 61);
            this.nextBankButton.TabIndex = 7;
            this.nextBankButton.Text = "Next Bank";
            this.nextBankButton.UseVisualStyleBackColor = true;
            this.nextBankButton.Click += new System.EventHandler(this.NextBankButton_Click);
            // 
            // playButton
            // 
            this.playButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playButton.Location = new System.Drawing.Point(159, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(72, 61);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Toggle Play";
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // AudioPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AudioPlayerControl";
            this.Size = new System.Drawing.Size(930, 636);
            this.Load += new System.EventHandler(this.AudioPlayerControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).EndInit();
            this.controlsTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader tracksHeader;
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.ComboBox tracksComboBox;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TableLayoutPanel controlsTableLayoutPanel;
        private System.Windows.Forms.Button prevTrackButton;
        private System.Windows.Forms.Button nextTrackButton;
        private System.Windows.Forms.Button prevBankButton;
        private System.Windows.Forms.Button nextBankButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TrackBar seekTrackBar;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label timeLengthLabel;
        private System.Windows.Forms.Label timeElapsedLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label loadingFileNameLabel;
    }
}
