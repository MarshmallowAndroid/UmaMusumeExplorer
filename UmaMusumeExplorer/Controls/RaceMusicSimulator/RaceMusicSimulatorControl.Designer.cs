
namespace UmaMusumeExplorer.Controls.RaceMusicSimulator
{
    partial class RaceMusicSimulatorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceMusicSimulatorControl));
            this.bgmIdComboBox = new System.Windows.Forms.ComboBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entryTableCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.paddockCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.entryTableCueNameTextBox = new System.Windows.Forms.TextBox();
            this.paddockCueNameTextBox = new System.Windows.Forms.TextBox();
            this.entryTableLabel = new System.Windows.Forms.Label();
            this.paddockLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.firstPatternLengthComboBox = new System.Windows.Forms.ComboBox();
            this.firstPatternCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.firstPatternCueNameTextBox = new System.Windows.Forms.TextBox();
            this.firstPatternLengthLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.amplifyUpDown = new System.Windows.Forms.NumericUpDown();
            this.amplifyLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.togglePlayButton = new System.Windows.Forms.Button();
            this.playLastSpurtButton = new System.Windows.Forms.Button();
            this.playRunningButton = new System.Windows.Forms.Button();
            this.playRaceResultButton = new System.Windows.Forms.Button();
            this.playEntryTableButton = new System.Windows.Forms.Button();
            this.playPaddockButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.raceResultComboBox = new System.Windows.Forms.ComboBox();
            this.resultListCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.resultListCueNameTextBox = new System.Windows.Forms.TextBox();
            this.resultCutInCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.resultCutInCueNameTextBox = new System.Windows.Forms.TextBox();
            this.resultListLabel = new System.Windows.Forms.Label();
            this.cutInLabel = new System.Windows.Forms.Label();
            this.raceResultLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.secondPatternLengthComboBox = new System.Windows.Forms.ComboBox();
            this.secondPatternCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPatternCueNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPatternLengthLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplifyUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgmIdComboBox
            // 
            this.bgmIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bgmIdComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.bgmIdComboBox, "bgmIdComboBox");
            this.bgmIdComboBox.Name = "bgmIdComboBox";
            this.bgmIdComboBox.SelectedIndexChanged += new System.EventHandler(this.BgmIdComboBox_SelectedIndexChanged);
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Name = "loadButton";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.entryTableCuesheetNameTextBox);
            this.groupBox1.Controls.Add(this.paddockCuesheetNameTextBox);
            this.groupBox1.Controls.Add(this.entryTableCueNameTextBox);
            this.groupBox1.Controls.Add(this.paddockCueNameTextBox);
            this.groupBox1.Controls.Add(this.entryTableLabel);
            this.groupBox1.Controls.Add(this.paddockLabel);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // entryTableCuesheetNameTextBox
            // 
            resources.ApplyResources(this.entryTableCuesheetNameTextBox, "entryTableCuesheetNameTextBox");
            this.entryTableCuesheetNameTextBox.Name = "entryTableCuesheetNameTextBox";
            this.entryTableCuesheetNameTextBox.ReadOnly = true;
            // 
            // paddockCuesheetNameTextBox
            // 
            resources.ApplyResources(this.paddockCuesheetNameTextBox, "paddockCuesheetNameTextBox");
            this.paddockCuesheetNameTextBox.Name = "paddockCuesheetNameTextBox";
            this.paddockCuesheetNameTextBox.ReadOnly = true;
            // 
            // entryTableCueNameTextBox
            // 
            resources.ApplyResources(this.entryTableCueNameTextBox, "entryTableCueNameTextBox");
            this.entryTableCueNameTextBox.Name = "entryTableCueNameTextBox";
            this.entryTableCueNameTextBox.ReadOnly = true;
            // 
            // paddockCueNameTextBox
            // 
            resources.ApplyResources(this.paddockCueNameTextBox, "paddockCueNameTextBox");
            this.paddockCueNameTextBox.Name = "paddockCueNameTextBox";
            this.paddockCueNameTextBox.ReadOnly = true;
            // 
            // entryTableLabel
            // 
            resources.ApplyResources(this.entryTableLabel, "entryTableLabel");
            this.entryTableLabel.Name = "entryTableLabel";
            // 
            // paddockLabel
            // 
            resources.ApplyResources(this.paddockLabel, "paddockLabel");
            this.paddockLabel.Name = "paddockLabel";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.firstPatternLengthComboBox);
            this.groupBox3.Controls.Add(this.firstPatternCuesheetNameTextBox);
            this.groupBox3.Controls.Add(this.firstPatternCueNameTextBox);
            this.groupBox3.Controls.Add(this.firstPatternLengthLabel);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // firstPatternLengthComboBox
            // 
            this.firstPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstPatternLengthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.firstPatternLengthComboBox, "firstPatternLengthComboBox");
            this.firstPatternLengthComboBox.Name = "firstPatternLengthComboBox";
            this.firstPatternLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstPatternLengthComboBox_SelectedIndexChanged);
            // 
            // firstPatternCuesheetNameTextBox
            // 
            resources.ApplyResources(this.firstPatternCuesheetNameTextBox, "firstPatternCuesheetNameTextBox");
            this.firstPatternCuesheetNameTextBox.Name = "firstPatternCuesheetNameTextBox";
            this.firstPatternCuesheetNameTextBox.ReadOnly = true;
            // 
            // firstPatternCueNameTextBox
            // 
            resources.ApplyResources(this.firstPatternCueNameTextBox, "firstPatternCueNameTextBox");
            this.firstPatternCueNameTextBox.Name = "firstPatternCueNameTextBox";
            this.firstPatternCueNameTextBox.ReadOnly = true;
            // 
            // firstPatternLengthLabel
            // 
            resources.ApplyResources(this.firstPatternLengthLabel, "firstPatternLengthLabel");
            this.firstPatternLengthLabel.Name = "firstPatternLengthLabel";
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.Controls.Add(this.amplifyUpDown);
            this.panel.Controls.Add(this.amplifyLabel);
            this.panel.Controls.Add(this.stopButton);
            this.panel.Controls.Add(this.togglePlayButton);
            this.panel.Controls.Add(this.playLastSpurtButton);
            this.panel.Controls.Add(this.playRunningButton);
            this.panel.Controls.Add(this.playRaceResultButton);
            this.panel.Controls.Add(this.playEntryTableButton);
            this.panel.Controls.Add(this.playPaddockButton);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.groupBox2);
            this.panel.Controls.Add(this.groupBox4);
            this.panel.Controls.Add(this.groupBox3);
            this.panel.Name = "panel";
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
            // stopButton
            // 
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.Name = "stopButton";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // togglePlayButton
            // 
            resources.ApplyResources(this.togglePlayButton, "togglePlayButton");
            this.togglePlayButton.Name = "togglePlayButton";
            this.togglePlayButton.UseVisualStyleBackColor = true;
            this.togglePlayButton.Click += new System.EventHandler(this.TogglePlayButton_Click);
            // 
            // playLastSpurtButton
            // 
            resources.ApplyResources(this.playLastSpurtButton, "playLastSpurtButton");
            this.playLastSpurtButton.Name = "playLastSpurtButton";
            this.playLastSpurtButton.UseVisualStyleBackColor = true;
            this.playLastSpurtButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playRunningButton
            // 
            resources.ApplyResources(this.playRunningButton, "playRunningButton");
            this.playRunningButton.Name = "playRunningButton";
            this.playRunningButton.UseVisualStyleBackColor = true;
            this.playRunningButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playRaceResultButton
            // 
            resources.ApplyResources(this.playRaceResultButton, "playRaceResultButton");
            this.playRaceResultButton.Name = "playRaceResultButton";
            this.playRaceResultButton.UseVisualStyleBackColor = true;
            this.playRaceResultButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playEntryTableButton
            // 
            resources.ApplyResources(this.playEntryTableButton, "playEntryTableButton");
            this.playEntryTableButton.Name = "playEntryTableButton";
            this.playEntryTableButton.UseVisualStyleBackColor = true;
            this.playEntryTableButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playPaddockButton
            // 
            resources.ApplyResources(this.playPaddockButton, "playPaddockButton");
            this.playPaddockButton.Name = "playPaddockButton";
            this.playPaddockButton.UseVisualStyleBackColor = true;
            this.playPaddockButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.raceResultComboBox);
            this.groupBox2.Controls.Add(this.resultListCuesheetNameTextBox);
            this.groupBox2.Controls.Add(this.resultListCueNameTextBox);
            this.groupBox2.Controls.Add(this.resultCutInCuesheetNameTextBox);
            this.groupBox2.Controls.Add(this.resultCutInCueNameTextBox);
            this.groupBox2.Controls.Add(this.resultListLabel);
            this.groupBox2.Controls.Add(this.cutInLabel);
            this.groupBox2.Controls.Add(this.raceResultLabel);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // raceResultComboBox
            // 
            this.raceResultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceResultComboBox.FormattingEnabled = true;
            this.raceResultComboBox.Items.AddRange(new object[] {
            resources.GetString("raceResultComboBox.Items"),
            resources.GetString("raceResultComboBox.Items1"),
            resources.GetString("raceResultComboBox.Items2")});
            resources.ApplyResources(this.raceResultComboBox, "raceResultComboBox");
            this.raceResultComboBox.Name = "raceResultComboBox";
            this.raceResultComboBox.SelectedIndexChanged += new System.EventHandler(this.RaceResultComboBox_SelectedIndexChanged);
            // 
            // resultListCuesheetNameTextBox
            // 
            resources.ApplyResources(this.resultListCuesheetNameTextBox, "resultListCuesheetNameTextBox");
            this.resultListCuesheetNameTextBox.Name = "resultListCuesheetNameTextBox";
            this.resultListCuesheetNameTextBox.ReadOnly = true;
            // 
            // resultListCueNameTextBox
            // 
            resources.ApplyResources(this.resultListCueNameTextBox, "resultListCueNameTextBox");
            this.resultListCueNameTextBox.Name = "resultListCueNameTextBox";
            this.resultListCueNameTextBox.ReadOnly = true;
            // 
            // resultCutInCuesheetNameTextBox
            // 
            resources.ApplyResources(this.resultCutInCuesheetNameTextBox, "resultCutInCuesheetNameTextBox");
            this.resultCutInCuesheetNameTextBox.Name = "resultCutInCuesheetNameTextBox";
            this.resultCutInCuesheetNameTextBox.ReadOnly = true;
            // 
            // resultCutInCueNameTextBox
            // 
            resources.ApplyResources(this.resultCutInCueNameTextBox, "resultCutInCueNameTextBox");
            this.resultCutInCueNameTextBox.Name = "resultCutInCueNameTextBox";
            this.resultCutInCueNameTextBox.ReadOnly = true;
            // 
            // resultListLabel
            // 
            resources.ApplyResources(this.resultListLabel, "resultListLabel");
            this.resultListLabel.Name = "resultListLabel";
            // 
            // cutInLabel
            // 
            resources.ApplyResources(this.cutInLabel, "cutInLabel");
            this.cutInLabel.Name = "cutInLabel";
            // 
            // raceResultLabel
            // 
            resources.ApplyResources(this.raceResultLabel, "raceResultLabel");
            this.raceResultLabel.Name = "raceResultLabel";
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.secondPatternLengthComboBox);
            this.groupBox4.Controls.Add(this.secondPatternCuesheetNameTextBox);
            this.groupBox4.Controls.Add(this.secondPatternCueNameTextBox);
            this.groupBox4.Controls.Add(this.secondPatternLengthLabel);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // secondPatternLengthComboBox
            // 
            this.secondPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondPatternLengthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.secondPatternLengthComboBox, "secondPatternLengthComboBox");
            this.secondPatternLengthComboBox.Name = "secondPatternLengthComboBox";
            this.secondPatternLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondPatternLengthComboBox_SelectedIndexChanged);
            // 
            // secondPatternCuesheetNameTextBox
            // 
            resources.ApplyResources(this.secondPatternCuesheetNameTextBox, "secondPatternCuesheetNameTextBox");
            this.secondPatternCuesheetNameTextBox.Name = "secondPatternCuesheetNameTextBox";
            this.secondPatternCuesheetNameTextBox.ReadOnly = true;
            // 
            // secondPatternCueNameTextBox
            // 
            resources.ApplyResources(this.secondPatternCueNameTextBox, "secondPatternCueNameTextBox");
            this.secondPatternCueNameTextBox.Name = "secondPatternCueNameTextBox";
            this.secondPatternCueNameTextBox.ReadOnly = true;
            // 
            // secondPatternLengthLabel
            // 
            resources.ApplyResources(this.secondPatternLengthLabel, "secondPatternLengthLabel");
            this.secondPatternLengthLabel.Name = "secondPatternLengthLabel";
            // 
            // RaceMusicSimulatorControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.bgmIdComboBox);
            this.Name = "RaceMusicSimulatorControl";
            this.Load += new System.EventHandler(this.RaceSimulatorControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplifyUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox bgmIdComboBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label paddockLabel;
        private System.Windows.Forms.TextBox paddockCueNameTextBox;
        private System.Windows.Forms.TextBox paddockCuesheetNameTextBox;
        private System.Windows.Forms.TextBox entryTableCuesheetNameTextBox;
        private System.Windows.Forms.TextBox entryTableCueNameTextBox;
        private System.Windows.Forms.Label entryTableLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox firstPatternCuesheetNameTextBox;
        private System.Windows.Forms.TextBox firstPatternCueNameTextBox;
        private System.Windows.Forms.Label firstPatternLengthLabel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox firstPatternLengthComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox secondPatternLengthComboBox;
        private System.Windows.Forms.TextBox secondPatternCuesheetNameTextBox;
        private System.Windows.Forms.TextBox secondPatternCueNameTextBox;
        private System.Windows.Forms.Label secondPatternLengthLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox raceResultComboBox;
        private System.Windows.Forms.TextBox resultCutInCuesheetNameTextBox;
        private System.Windows.Forms.TextBox resultCutInCueNameTextBox;
        private System.Windows.Forms.Label raceResultLabel;
        private System.Windows.Forms.TextBox resultListCuesheetNameTextBox;
        private System.Windows.Forms.TextBox resultListCueNameTextBox;
        private System.Windows.Forms.Label resultListLabel;
        private System.Windows.Forms.Label cutInLabel;
        private System.Windows.Forms.Button playRaceResultButton;
        private System.Windows.Forms.Button playEntryTableButton;
        private System.Windows.Forms.Button playPaddockButton;
        private System.Windows.Forms.Button playLastSpurtButton;
        private System.Windows.Forms.Button playRunningButton;
        private System.Windows.Forms.Button togglePlayButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.NumericUpDown amplifyUpDown;
        private System.Windows.Forms.Label amplifyLabel;
    }
}
