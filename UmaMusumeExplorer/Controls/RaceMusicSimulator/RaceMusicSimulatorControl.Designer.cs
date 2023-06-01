
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
            bgmIdComboBox = new System.Windows.Forms.ComboBox();
            loadButton = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            entryTableCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            paddockCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            entryTableCueNameTextBox = new System.Windows.Forms.TextBox();
            paddockCueNameTextBox = new System.Windows.Forms.TextBox();
            entryTableLabel = new System.Windows.Forms.Label();
            paddockLabel = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            firstPatternLengthComboBox = new System.Windows.Forms.ComboBox();
            firstPatternCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            firstPatternCueNameTextBox = new System.Windows.Forms.TextBox();
            firstPatternLengthLabel = new System.Windows.Forms.Label();
            panel = new System.Windows.Forms.Panel();
            amplifyUpDown = new System.Windows.Forms.NumericUpDown();
            amplifyLabel = new System.Windows.Forms.Label();
            stopButton = new System.Windows.Forms.Button();
            togglePlayButton = new System.Windows.Forms.Button();
            playLastSpurtButton = new System.Windows.Forms.Button();
            playRunningButton = new System.Windows.Forms.Button();
            playRaceResultButton = new System.Windows.Forms.Button();
            playEntryTableButton = new System.Windows.Forms.Button();
            playPaddockButton = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            raceResultComboBox = new System.Windows.Forms.ComboBox();
            resultListCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            resultListCueNameTextBox = new System.Windows.Forms.TextBox();
            resultCutInCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            resultCutInCueNameTextBox = new System.Windows.Forms.TextBox();
            resultListLabel = new System.Windows.Forms.Label();
            cutInLabel = new System.Windows.Forms.Label();
            raceResultLabel = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            secondPatternLengthComboBox = new System.Windows.Forms.ComboBox();
            secondPatternCuesheetNameTextBox = new System.Windows.Forms.TextBox();
            secondPatternCueNameTextBox = new System.Windows.Forms.TextBox();
            secondPatternLengthLabel = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amplifyUpDown).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // bgmIdComboBox
            // 
            bgmIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bgmIdComboBox.FormattingEnabled = true;
            resources.ApplyResources(bgmIdComboBox, "bgmIdComboBox");
            bgmIdComboBox.Name = "bgmIdComboBox";
            bgmIdComboBox.SelectedIndexChanged += BgmIdComboBox_SelectedIndexChanged;
            // 
            // loadButton
            // 
            resources.ApplyResources(loadButton, "loadButton");
            loadButton.Name = "loadButton";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += LoadButton_Click;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(entryTableCuesheetNameTextBox);
            groupBox1.Controls.Add(paddockCuesheetNameTextBox);
            groupBox1.Controls.Add(entryTableCueNameTextBox);
            groupBox1.Controls.Add(paddockCueNameTextBox);
            groupBox1.Controls.Add(entryTableLabel);
            groupBox1.Controls.Add(paddockLabel);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // entryTableCuesheetNameTextBox
            // 
            resources.ApplyResources(entryTableCuesheetNameTextBox, "entryTableCuesheetNameTextBox");
            entryTableCuesheetNameTextBox.Name = "entryTableCuesheetNameTextBox";
            entryTableCuesheetNameTextBox.ReadOnly = true;
            // 
            // paddockCuesheetNameTextBox
            // 
            resources.ApplyResources(paddockCuesheetNameTextBox, "paddockCuesheetNameTextBox");
            paddockCuesheetNameTextBox.Name = "paddockCuesheetNameTextBox";
            paddockCuesheetNameTextBox.ReadOnly = true;
            // 
            // entryTableCueNameTextBox
            // 
            resources.ApplyResources(entryTableCueNameTextBox, "entryTableCueNameTextBox");
            entryTableCueNameTextBox.Name = "entryTableCueNameTextBox";
            entryTableCueNameTextBox.ReadOnly = true;
            // 
            // paddockCueNameTextBox
            // 
            resources.ApplyResources(paddockCueNameTextBox, "paddockCueNameTextBox");
            paddockCueNameTextBox.Name = "paddockCueNameTextBox";
            paddockCueNameTextBox.ReadOnly = true;
            // 
            // entryTableLabel
            // 
            resources.ApplyResources(entryTableLabel, "entryTableLabel");
            entryTableLabel.Name = "entryTableLabel";
            // 
            // paddockLabel
            // 
            resources.ApplyResources(paddockLabel, "paddockLabel");
            paddockLabel.Name = "paddockLabel";
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(firstPatternLengthComboBox);
            groupBox3.Controls.Add(firstPatternCuesheetNameTextBox);
            groupBox3.Controls.Add(firstPatternCueNameTextBox);
            groupBox3.Controls.Add(firstPatternLengthLabel);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // firstPatternLengthComboBox
            // 
            firstPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            firstPatternLengthComboBox.FormattingEnabled = true;
            resources.ApplyResources(firstPatternLengthComboBox, "firstPatternLengthComboBox");
            firstPatternLengthComboBox.Name = "firstPatternLengthComboBox";
            firstPatternLengthComboBox.SelectedIndexChanged += FirstPatternLengthComboBox_SelectedIndexChanged;
            // 
            // firstPatternCuesheetNameTextBox
            // 
            resources.ApplyResources(firstPatternCuesheetNameTextBox, "firstPatternCuesheetNameTextBox");
            firstPatternCuesheetNameTextBox.Name = "firstPatternCuesheetNameTextBox";
            firstPatternCuesheetNameTextBox.ReadOnly = true;
            // 
            // firstPatternCueNameTextBox
            // 
            resources.ApplyResources(firstPatternCueNameTextBox, "firstPatternCueNameTextBox");
            firstPatternCueNameTextBox.Name = "firstPatternCueNameTextBox";
            firstPatternCueNameTextBox.ReadOnly = true;
            // 
            // firstPatternLengthLabel
            // 
            resources.ApplyResources(firstPatternLengthLabel, "firstPatternLengthLabel");
            firstPatternLengthLabel.Name = "firstPatternLengthLabel";
            // 
            // panel
            // 
            resources.ApplyResources(panel, "panel");
            panel.Controls.Add(amplifyUpDown);
            panel.Controls.Add(amplifyLabel);
            panel.Controls.Add(stopButton);
            panel.Controls.Add(togglePlayButton);
            panel.Controls.Add(playLastSpurtButton);
            panel.Controls.Add(playRunningButton);
            panel.Controls.Add(playRaceResultButton);
            panel.Controls.Add(playEntryTableButton);
            panel.Controls.Add(playPaddockButton);
            panel.Controls.Add(groupBox1);
            panel.Controls.Add(groupBox2);
            panel.Controls.Add(groupBox4);
            panel.Controls.Add(groupBox3);
            panel.Name = "panel";
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
            // stopButton
            // 
            resources.ApplyResources(stopButton, "stopButton");
            stopButton.Name = "stopButton";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Click;
            // 
            // togglePlayButton
            // 
            resources.ApplyResources(togglePlayButton, "togglePlayButton");
            togglePlayButton.Name = "togglePlayButton";
            togglePlayButton.UseVisualStyleBackColor = true;
            togglePlayButton.Click += TogglePlayButton_Click;
            // 
            // playLastSpurtButton
            // 
            resources.ApplyResources(playLastSpurtButton, "playLastSpurtButton");
            playLastSpurtButton.Name = "playLastSpurtButton";
            playLastSpurtButton.UseVisualStyleBackColor = true;
            playLastSpurtButton.Click += PlayButtons_Click;
            // 
            // playRunningButton
            // 
            resources.ApplyResources(playRunningButton, "playRunningButton");
            playRunningButton.Name = "playRunningButton";
            playRunningButton.UseVisualStyleBackColor = true;
            playRunningButton.Click += PlayButtons_Click;
            // 
            // playRaceResultButton
            // 
            resources.ApplyResources(playRaceResultButton, "playRaceResultButton");
            playRaceResultButton.Name = "playRaceResultButton";
            playRaceResultButton.UseVisualStyleBackColor = true;
            playRaceResultButton.Click += PlayButtons_Click;
            // 
            // playEntryTableButton
            // 
            resources.ApplyResources(playEntryTableButton, "playEntryTableButton");
            playEntryTableButton.Name = "playEntryTableButton";
            playEntryTableButton.UseVisualStyleBackColor = true;
            playEntryTableButton.Click += PlayButtons_Click;
            // 
            // playPaddockButton
            // 
            resources.ApplyResources(playPaddockButton, "playPaddockButton");
            playPaddockButton.Name = "playPaddockButton";
            playPaddockButton.UseVisualStyleBackColor = true;
            playPaddockButton.Click += PlayButtons_Click;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(raceResultComboBox);
            groupBox2.Controls.Add(resultListCuesheetNameTextBox);
            groupBox2.Controls.Add(resultListCueNameTextBox);
            groupBox2.Controls.Add(resultCutInCuesheetNameTextBox);
            groupBox2.Controls.Add(resultCutInCueNameTextBox);
            groupBox2.Controls.Add(resultListLabel);
            groupBox2.Controls.Add(cutInLabel);
            groupBox2.Controls.Add(raceResultLabel);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // raceResultComboBox
            // 
            raceResultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            raceResultComboBox.FormattingEnabled = true;
            raceResultComboBox.Items.AddRange(new object[] { resources.GetString("raceResultComboBox.Items"), resources.GetString("raceResultComboBox.Items1"), resources.GetString("raceResultComboBox.Items2") });
            resources.ApplyResources(raceResultComboBox, "raceResultComboBox");
            raceResultComboBox.Name = "raceResultComboBox";
            raceResultComboBox.SelectedIndexChanged += RaceResultComboBox_SelectedIndexChanged;
            // 
            // resultListCuesheetNameTextBox
            // 
            resources.ApplyResources(resultListCuesheetNameTextBox, "resultListCuesheetNameTextBox");
            resultListCuesheetNameTextBox.Name = "resultListCuesheetNameTextBox";
            resultListCuesheetNameTextBox.ReadOnly = true;
            // 
            // resultListCueNameTextBox
            // 
            resources.ApplyResources(resultListCueNameTextBox, "resultListCueNameTextBox");
            resultListCueNameTextBox.Name = "resultListCueNameTextBox";
            resultListCueNameTextBox.ReadOnly = true;
            // 
            // resultCutInCuesheetNameTextBox
            // 
            resources.ApplyResources(resultCutInCuesheetNameTextBox, "resultCutInCuesheetNameTextBox");
            resultCutInCuesheetNameTextBox.Name = "resultCutInCuesheetNameTextBox";
            resultCutInCuesheetNameTextBox.ReadOnly = true;
            // 
            // resultCutInCueNameTextBox
            // 
            resources.ApplyResources(resultCutInCueNameTextBox, "resultCutInCueNameTextBox");
            resultCutInCueNameTextBox.Name = "resultCutInCueNameTextBox";
            resultCutInCueNameTextBox.ReadOnly = true;
            // 
            // resultListLabel
            // 
            resources.ApplyResources(resultListLabel, "resultListLabel");
            resultListLabel.Name = "resultListLabel";
            // 
            // cutInLabel
            // 
            resources.ApplyResources(cutInLabel, "cutInLabel");
            cutInLabel.Name = "cutInLabel";
            // 
            // raceResultLabel
            // 
            resources.ApplyResources(raceResultLabel, "raceResultLabel");
            raceResultLabel.Name = "raceResultLabel";
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(secondPatternLengthComboBox);
            groupBox4.Controls.Add(secondPatternCuesheetNameTextBox);
            groupBox4.Controls.Add(secondPatternCueNameTextBox);
            groupBox4.Controls.Add(secondPatternLengthLabel);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            // 
            // secondPatternLengthComboBox
            // 
            secondPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            secondPatternLengthComboBox.FormattingEnabled = true;
            resources.ApplyResources(secondPatternLengthComboBox, "secondPatternLengthComboBox");
            secondPatternLengthComboBox.Name = "secondPatternLengthComboBox";
            secondPatternLengthComboBox.SelectedIndexChanged += SecondPatternLengthComboBox_SelectedIndexChanged;
            // 
            // secondPatternCuesheetNameTextBox
            // 
            resources.ApplyResources(secondPatternCuesheetNameTextBox, "secondPatternCuesheetNameTextBox");
            secondPatternCuesheetNameTextBox.Name = "secondPatternCuesheetNameTextBox";
            secondPatternCuesheetNameTextBox.ReadOnly = true;
            // 
            // secondPatternCueNameTextBox
            // 
            resources.ApplyResources(secondPatternCueNameTextBox, "secondPatternCueNameTextBox");
            secondPatternCueNameTextBox.Name = "secondPatternCueNameTextBox";
            secondPatternCueNameTextBox.ReadOnly = true;
            // 
            // secondPatternLengthLabel
            // 
            resources.ApplyResources(secondPatternLengthLabel, "secondPatternLengthLabel");
            secondPatternLengthLabel.Name = "secondPatternLengthLabel";
            // 
            // RaceMusicSimulatorControl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            Controls.Add(panel);
            Controls.Add(loadButton);
            Controls.Add(bgmIdComboBox);
            Name = "RaceMusicSimulatorControl";
            resources.ApplyResources(this, "$this");
            Load += RaceSimulatorControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amplifyUpDown).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
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
