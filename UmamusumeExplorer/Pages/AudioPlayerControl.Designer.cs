
namespace UmamusumeExplorer.Pages
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlayerControl));
            fileListView = new ListView();
            nameHeader = new ColumnHeader();
            tracksHeader = new ColumnHeader();
            multiSelectContextMenuStrip = new ContextMenuStrip(components);
            exportSelectedToolStripMenuItem = new ToolStripMenuItem();
            loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            tracksComboBox = new ComboBox();
            loadingProgressBar = new ProgressBar();
            tableLayoutPanel = new TableLayoutPanel();
            leftPanel = new Panel();
            searchBox = new TextBox();
            filterButton = new Button();
            refreshButton = new Button();
            audioTypeComboBox = new ComboBox();
            searchLabel = new Label();
            audioTypeLabel = new Label();
            loadingFileNameLabel = new Label();
            rightPanel = new Panel();
            amplifyUpDown = new NumericUpDown();
            amplifyLabel = new Label();
            configureLoopButton = new Button();
            exportButton = new Button();
            timeLengthLabel = new Label();
            timeElapsedLabel = new Label();
            seekTrackBar = new TrackBar();
            controlsTableLayoutPanel = new TableLayoutPanel();
            prevTrackButton = new Button();
            nextTrackButton = new Button();
            prevBankButton = new Button();
            nextBankButton = new Button();
            playButton = new Button();
            updateTimer = new System.Windows.Forms.Timer(components);
            multiSelectContextMenuStrip.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amplifyUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).BeginInit();
            controlsTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // fileListView
            // 
            resources.ApplyResources(fileListView, "fileListView");
            fileListView.Columns.AddRange(new ColumnHeader[] { nameHeader, tracksHeader });
            fileListView.ContextMenuStrip = multiSelectContextMenuStrip;
            fileListView.FullRowSelect = true;
            fileListView.Name = "fileListView";
            fileListView.Sorting = SortOrder.Ascending;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            fileListView.ItemActivate += FileListView_ItemActivate;
            fileListView.KeyDown += FileListView_KeyDown;
            fileListView.Resize += FileListView_Resize;
            // 
            // nameHeader
            // 
            resources.ApplyResources(nameHeader, "nameHeader");
            // 
            // tracksHeader
            // 
            resources.ApplyResources(tracksHeader, "tracksHeader");
            // 
            // multiSelectContextMenuStrip
            // 
            multiSelectContextMenuStrip.Items.AddRange(new ToolStripItem[] { exportSelectedToolStripMenuItem });
            multiSelectContextMenuStrip.Name = "multiSelectContextMenuStrip";
            resources.ApplyResources(multiSelectContextMenuStrip, "multiSelectContextMenuStrip");
            // 
            // exportSelectedToolStripMenuItem
            // 
            exportSelectedToolStripMenuItem.Name = "exportSelectedToolStripMenuItem";
            resources.ApplyResources(exportSelectedToolStripMenuItem, "exportSelectedToolStripMenuItem");
            exportSelectedToolStripMenuItem.Click += ExportToolStripMenuItem_Click;
            // 
            // loadingBackgroundWorker
            // 
            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.WorkerSupportsCancellation = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
            // 
            // tracksComboBox
            // 
            resources.ApplyResources(tracksComboBox, "tracksComboBox");
            tracksComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tracksComboBox.FormattingEnabled = true;
            tracksComboBox.Name = "tracksComboBox";
            tracksComboBox.SelectedIndexChanged += TracksComboBox_SelectedIndexChanged;
            // 
            // loadingProgressBar
            // 
            resources.ApplyResources(loadingProgressBar, "loadingProgressBar");
            loadingProgressBar.Name = "loadingProgressBar";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(leftPanel, 0, 0);
            tableLayoutPanel.Controls.Add(rightPanel, 1, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(searchBox);
            leftPanel.Controls.Add(filterButton);
            leftPanel.Controls.Add(refreshButton);
            leftPanel.Controls.Add(audioTypeComboBox);
            leftPanel.Controls.Add(searchLabel);
            leftPanel.Controls.Add(audioTypeLabel);
            leftPanel.Controls.Add(loadingFileNameLabel);
            leftPanel.Controls.Add(loadingProgressBar);
            leftPanel.Controls.Add(fileListView);
            resources.ApplyResources(leftPanel, "leftPanel");
            leftPanel.Name = "leftPanel";
            // 
            // searchBox
            // 
            resources.ApplyResources(searchBox, "searchBox");
            searchBox.Name = "searchBox";
            // 
            // filterButton
            // 
            resources.ApplyResources(filterButton, "filterButton");
            filterButton.Name = "filterButton";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += FilterButton_Click;
            // 
            // refreshButton
            // 
            resources.ApplyResources(refreshButton, "refreshButton");
            refreshButton.Name = "refreshButton";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // audioTypeComboBox
            // 
            audioTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            audioTypeComboBox.FormattingEnabled = true;
            audioTypeComboBox.Items.AddRange(new object[] { resources.GetString("audioTypeComboBox.Items"), resources.GetString("audioTypeComboBox.Items1"), resources.GetString("audioTypeComboBox.Items2"), resources.GetString("audioTypeComboBox.Items3"), resources.GetString("audioTypeComboBox.Items4"), resources.GetString("audioTypeComboBox.Items5") });
            resources.ApplyResources(audioTypeComboBox, "audioTypeComboBox");
            audioTypeComboBox.Name = "audioTypeComboBox";
            audioTypeComboBox.SelectedIndexChanged += AudioTypeComboBox_SelectedIndexChanged;
            // 
            // searchLabel
            // 
            resources.ApplyResources(searchLabel, "searchLabel");
            searchLabel.Name = "searchLabel";
            // 
            // audioTypeLabel
            // 
            resources.ApplyResources(audioTypeLabel, "audioTypeLabel");
            audioTypeLabel.Name = "audioTypeLabel";
            // 
            // loadingFileNameLabel
            // 
            resources.ApplyResources(loadingFileNameLabel, "loadingFileNameLabel");
            loadingFileNameLabel.BackColor = SystemColors.ControlLightLight;
            loadingFileNameLabel.Name = "loadingFileNameLabel";
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(amplifyUpDown);
            rightPanel.Controls.Add(amplifyLabel);
            rightPanel.Controls.Add(configureLoopButton);
            rightPanel.Controls.Add(exportButton);
            rightPanel.Controls.Add(timeLengthLabel);
            rightPanel.Controls.Add(timeElapsedLabel);
            rightPanel.Controls.Add(seekTrackBar);
            rightPanel.Controls.Add(controlsTableLayoutPanel);
            rightPanel.Controls.Add(tracksComboBox);
            resources.ApplyResources(rightPanel, "rightPanel");
            rightPanel.Name = "rightPanel";
            // 
            // amplifyUpDown
            // 
            resources.ApplyResources(amplifyUpDown, "amplifyUpDown");
            amplifyUpDown.DecimalPlaces = 1;
            amplifyUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            amplifyUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            amplifyUpDown.Name = "amplifyUpDown";
            amplifyUpDown.Value = new decimal(new int[] { 40, 0, 0, 65536 });
            amplifyUpDown.ValueChanged += AmplifyUpDown_ValueChanged;
            // 
            // amplifyLabel
            // 
            resources.ApplyResources(amplifyLabel, "amplifyLabel");
            amplifyLabel.Name = "amplifyLabel";
            // 
            // configureLoopButton
            // 
            resources.ApplyResources(configureLoopButton, "configureLoopButton");
            configureLoopButton.Name = "configureLoopButton";
            configureLoopButton.UseVisualStyleBackColor = true;
            configureLoopButton.Click += ConfigureLoopButton_Click;
            // 
            // exportButton
            // 
            resources.ApplyResources(exportButton, "exportButton");
            exportButton.Name = "exportButton";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += ExportButton_Click;
            // 
            // timeLengthLabel
            // 
            resources.ApplyResources(timeLengthLabel, "timeLengthLabel");
            timeLengthLabel.Name = "timeLengthLabel";
            // 
            // timeElapsedLabel
            // 
            resources.ApplyResources(timeElapsedLabel, "timeElapsedLabel");
            timeElapsedLabel.Name = "timeElapsedLabel";
            // 
            // seekTrackBar
            // 
            resources.ApplyResources(seekTrackBar, "seekTrackBar");
            seekTrackBar.Maximum = 100;
            seekTrackBar.Name = "seekTrackBar";
            seekTrackBar.TickFrequency = 0;
            seekTrackBar.TickStyle = TickStyle.Both;
            seekTrackBar.Scroll += SeekTrackBar_Scroll;
            // 
            // controlsTableLayoutPanel
            // 
            resources.ApplyResources(controlsTableLayoutPanel, "controlsTableLayoutPanel");
            controlsTableLayoutPanel.Controls.Add(prevTrackButton, 1, 0);
            controlsTableLayoutPanel.Controls.Add(nextTrackButton, 3, 0);
            controlsTableLayoutPanel.Controls.Add(prevBankButton, 0, 0);
            controlsTableLayoutPanel.Controls.Add(nextBankButton, 4, 0);
            controlsTableLayoutPanel.Controls.Add(playButton, 2, 0);
            controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            // 
            // prevTrackButton
            // 
            resources.ApplyResources(prevTrackButton, "prevTrackButton");
            prevTrackButton.Image = Properties.Resources.PrevIcon;
            prevTrackButton.Name = "prevTrackButton";
            prevTrackButton.UseVisualStyleBackColor = true;
            prevTrackButton.Click += PrevTrackButton_Click;
            // 
            // nextTrackButton
            // 
            resources.ApplyResources(nextTrackButton, "nextTrackButton");
            nextTrackButton.Image = Properties.Resources.NextIcon;
            nextTrackButton.Name = "nextTrackButton";
            nextTrackButton.UseVisualStyleBackColor = true;
            nextTrackButton.Click += NextTrackButton_Click;
            // 
            // prevBankButton
            // 
            resources.ApplyResources(prevBankButton, "prevBankButton");
            prevBankButton.Image = Properties.Resources.PrevBankIcon;
            prevBankButton.Name = "prevBankButton";
            prevBankButton.UseVisualStyleBackColor = true;
            prevBankButton.Click += PrevBankButton_Click;
            // 
            // nextBankButton
            // 
            resources.ApplyResources(nextBankButton, "nextBankButton");
            nextBankButton.Image = Properties.Resources.NextBankIcon;
            nextBankButton.Name = "nextBankButton";
            nextBankButton.UseVisualStyleBackColor = true;
            nextBankButton.Click += NextBankButton_Click;
            // 
            // playButton
            // 
            resources.ApplyResources(playButton, "playButton");
            playButton.Image = Properties.Resources.PlayIcon;
            playButton.Name = "playButton";
            playButton.Click += PlayButton_Click;
            // 
            // updateTimer
            // 
            updateTimer.Tick += UpdateTimer_Tick;
            // 
            // AudioPlayerControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "AudioPlayerControl";
            Load += AudioPlayerControl_Load;
            multiSelectContextMenuStrip.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amplifyUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)seekTrackBar).EndInit();
            controlsTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label loadingFileNameLabel;
        private System.Windows.Forms.Button configureLoopButton;
        private System.Windows.Forms.Label amplifyLabel;
        private System.Windows.Forms.NumericUpDown amplifyUpDown;
        private System.Windows.Forms.ComboBox audioTypeComboBox;
        private System.Windows.Forms.Label audioTypeLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ContextMenuStrip multiSelectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem;
    }
}
