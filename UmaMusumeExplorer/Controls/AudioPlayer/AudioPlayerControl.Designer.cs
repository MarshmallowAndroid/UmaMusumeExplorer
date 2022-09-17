
namespace UmaMusumeExplorer.Controls.AudioPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlayerControl));
            this.fileListView = new System.Windows.Forms.ListView();
            this.nameHeader = new System.Windows.Forms.ColumnHeader();
            this.tracksHeader = new System.Windows.Forms.ColumnHeader();
            this.loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tracksComboBox = new System.Windows.Forms.ComboBox();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.audioTypeComboBox = new System.Windows.Forms.ComboBox();
            this.audioTypeLabel = new System.Windows.Forms.Label();
            this.loadingFileNameLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.amplifyUpDown = new System.Windows.Forms.NumericUpDown();
            this.amplifyLabel = new System.Windows.Forms.Label();
            this.configureLoopButton = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.amplifyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekTrackBar)).BeginInit();
            this.controlsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            resources.ApplyResources(this.fileListView, "fileListView");
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.tracksHeader});
            this.fileListView.FullRowSelect = true;
            this.fileListView.MultiSelect = false;
            this.fileListView.Name = "fileListView";
            this.fileListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemActivate += new System.EventHandler(this.FileListView_ItemActivate);
            // 
            // nameHeader
            // 
            resources.ApplyResources(this.nameHeader, "nameHeader");
            // 
            // tracksHeader
            // 
            resources.ApplyResources(this.tracksHeader, "tracksHeader");
            // 
            // loadingBackgroundWorker
            // 
            this.loadingBackgroundWorker.WorkerReportsProgress = true;
            this.loadingBackgroundWorker.WorkerSupportsCancellation = true;
            this.loadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.loadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.loadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // tracksComboBox
            // 
            resources.ApplyResources(this.tracksComboBox, "tracksComboBox");
            this.tracksComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tracksComboBox.FormattingEnabled = true;
            this.tracksComboBox.Name = "tracksComboBox";
            this.tracksComboBox.SelectedIndexChanged += new System.EventHandler(this.TracksComboBox_SelectedIndexChanged);
            // 
            // loadingProgressBar
            // 
            resources.ApplyResources(this.loadingProgressBar, "loadingProgressBar");
            this.loadingProgressBar.Name = "loadingProgressBar";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.leftPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.rightPanel, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.refreshButton);
            this.leftPanel.Controls.Add(this.audioTypeComboBox);
            this.leftPanel.Controls.Add(this.audioTypeLabel);
            this.leftPanel.Controls.Add(this.loadingFileNameLabel);
            this.leftPanel.Controls.Add(this.loadingProgressBar);
            this.leftPanel.Controls.Add(this.fileListView);
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Name = "leftPanel";
            // 
            // refreshButton
            // 
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // audioTypeComboBox
            // 
            this.audioTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioTypeComboBox.FormattingEnabled = true;
            this.audioTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("audioTypeComboBox.Items"),
            resources.GetString("audioTypeComboBox.Items1"),
            resources.GetString("audioTypeComboBox.Items2"),
            resources.GetString("audioTypeComboBox.Items3"),
            resources.GetString("audioTypeComboBox.Items4"),
            resources.GetString("audioTypeComboBox.Items5")});
            resources.ApplyResources(this.audioTypeComboBox, "audioTypeComboBox");
            this.audioTypeComboBox.Name = "audioTypeComboBox";
            this.audioTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioTypeComboBox_SelectedIndexChanged);
            // 
            // audioTypeLabel
            // 
            resources.ApplyResources(this.audioTypeLabel, "audioTypeLabel");
            this.audioTypeLabel.Name = "audioTypeLabel";
            // 
            // loadingFileNameLabel
            // 
            resources.ApplyResources(this.loadingFileNameLabel, "loadingFileNameLabel");
            this.loadingFileNameLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadingFileNameLabel.Name = "loadingFileNameLabel";
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.amplifyUpDown);
            this.rightPanel.Controls.Add(this.amplifyLabel);
            this.rightPanel.Controls.Add(this.configureLoopButton);
            this.rightPanel.Controls.Add(this.saveButton);
            this.rightPanel.Controls.Add(this.timeLengthLabel);
            this.rightPanel.Controls.Add(this.timeElapsedLabel);
            this.rightPanel.Controls.Add(this.seekTrackBar);
            this.rightPanel.Controls.Add(this.controlsTableLayoutPanel);
            this.rightPanel.Controls.Add(this.tracksComboBox);
            resources.ApplyResources(this.rightPanel, "rightPanel");
            this.rightPanel.Name = "rightPanel";
            // 
            // amplifyUpDown
            // 
            resources.ApplyResources(this.amplifyUpDown, "amplifyUpDown");
            this.amplifyUpDown.DecimalPlaces = 1;
            this.amplifyUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.amplifyUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amplifyUpDown.Name = "amplifyUpDown";
            this.amplifyUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.amplifyUpDown.ValueChanged += new System.EventHandler(this.AmplifyUpDown_ValueChanged);
            // 
            // amplifyLabel
            // 
            resources.ApplyResources(this.amplifyLabel, "amplifyLabel");
            this.amplifyLabel.Name = "amplifyLabel";
            // 
            // configureLoopButton
            // 
            resources.ApplyResources(this.configureLoopButton, "configureLoopButton");
            this.configureLoopButton.Name = "configureLoopButton";
            this.configureLoopButton.UseVisualStyleBackColor = true;
            this.configureLoopButton.Click += new System.EventHandler(this.ConfigureLoopButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // timeLengthLabel
            // 
            resources.ApplyResources(this.timeLengthLabel, "timeLengthLabel");
            this.timeLengthLabel.Name = "timeLengthLabel";
            // 
            // timeElapsedLabel
            // 
            resources.ApplyResources(this.timeElapsedLabel, "timeElapsedLabel");
            this.timeElapsedLabel.Name = "timeElapsedLabel";
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
            // controlsTableLayoutPanel
            // 
            resources.ApplyResources(this.controlsTableLayoutPanel, "controlsTableLayoutPanel");
            this.controlsTableLayoutPanel.Controls.Add(this.prevTrackButton, 1, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.nextTrackButton, 3, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.prevBankButton, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.nextBankButton, 4, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.playButton, 2, 0);
            this.controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            // 
            // prevTrackButton
            // 
            resources.ApplyResources(this.prevTrackButton, "prevTrackButton");
            this.prevTrackButton.Name = "prevTrackButton";
            this.prevTrackButton.UseVisualStyleBackColor = true;
            this.prevTrackButton.Click += new System.EventHandler(this.PrevTrackButton_Click);
            // 
            // nextTrackButton
            // 
            resources.ApplyResources(this.nextTrackButton, "nextTrackButton");
            this.nextTrackButton.Name = "nextTrackButton";
            this.nextTrackButton.UseVisualStyleBackColor = true;
            this.nextTrackButton.Click += new System.EventHandler(this.NextTrackButton_Click);
            // 
            // prevBankButton
            // 
            resources.ApplyResources(this.prevBankButton, "prevBankButton");
            this.prevBankButton.Name = "prevBankButton";
            this.prevBankButton.UseVisualStyleBackColor = true;
            this.prevBankButton.Click += new System.EventHandler(this.PrevBankButton_Click);
            // 
            // nextBankButton
            // 
            resources.ApplyResources(this.nextBankButton, "nextBankButton");
            this.nextBankButton.Name = "nextBankButton";
            this.nextBankButton.UseVisualStyleBackColor = true;
            this.nextBankButton.Click += new System.EventHandler(this.NextBankButton_Click);
            // 
            // playButton
            // 
            resources.ApplyResources(this.playButton, "playButton");
            this.playButton.Name = "playButton";
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // AudioPlayerControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AudioPlayerControl";
            this.Load += new System.EventHandler(this.AudioPlayerControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplifyUpDown)).EndInit();
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
        private System.Windows.Forms.Button configureLoopButton;
        private System.Windows.Forms.Label amplifyLabel;
        private System.Windows.Forms.NumericUpDown amplifyUpDown;
        private System.Windows.Forms.ComboBox audioTypeComboBox;
        private System.Windows.Forms.Label audioTypeLabel;
        private System.Windows.Forms.Button refreshButton;
    }
}
