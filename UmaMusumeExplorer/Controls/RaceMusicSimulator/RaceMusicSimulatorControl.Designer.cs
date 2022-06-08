
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
            this.bgmIDComboBox = new System.Windows.Forms.ComboBox();
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
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgmIDComboBox
            // 
            this.bgmIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bgmIDComboBox.FormattingEnabled = true;
            this.bgmIDComboBox.Location = new System.Drawing.Point(3, 3);
            this.bgmIDComboBox.Name = "bgmIDComboBox";
            this.bgmIDComboBox.Size = new System.Drawing.Size(77, 23);
            this.bgmIDComboBox.TabIndex = 0;
            this.bgmIDComboBox.SelectedIndexChanged += new System.EventHandler(this.BgmIDComboBox_SelectedIndexChanged);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(86, 3);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.entryTableCuesheetNameTextBox);
            this.groupBox1.Controls.Add(this.paddockCuesheetNameTextBox);
            this.groupBox1.Controls.Add(this.entryTableCueNameTextBox);
            this.groupBox1.Controls.Add(this.paddockCueNameTextBox);
            this.groupBox1.Controls.Add(this.entryTableLabel);
            this.groupBox1.Controls.Add(this.paddockLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intro";
            // 
            // entryTableCuesheetNameTextBox
            // 
            this.entryTableCuesheetNameTextBox.Location = new System.Drawing.Point(6, 81);
            this.entryTableCuesheetNameTextBox.Name = "entryTableCuesheetNameTextBox";
            this.entryTableCuesheetNameTextBox.ReadOnly = true;
            this.entryTableCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.entryTableCuesheetNameTextBox.TabIndex = 1;
            // 
            // paddockCuesheetNameTextBox
            // 
            this.paddockCuesheetNameTextBox.Location = new System.Drawing.Point(6, 37);
            this.paddockCuesheetNameTextBox.Name = "paddockCuesheetNameTextBox";
            this.paddockCuesheetNameTextBox.ReadOnly = true;
            this.paddockCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.paddockCuesheetNameTextBox.TabIndex = 1;
            // 
            // entryTableCueNameTextBox
            // 
            this.entryTableCueNameTextBox.Location = new System.Drawing.Point(114, 81);
            this.entryTableCueNameTextBox.Name = "entryTableCueNameTextBox";
            this.entryTableCueNameTextBox.ReadOnly = true;
            this.entryTableCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.entryTableCueNameTextBox.TabIndex = 1;
            // 
            // paddockCueNameTextBox
            // 
            this.paddockCueNameTextBox.Location = new System.Drawing.Point(114, 37);
            this.paddockCueNameTextBox.Name = "paddockCueNameTextBox";
            this.paddockCueNameTextBox.ReadOnly = true;
            this.paddockCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.paddockCueNameTextBox.TabIndex = 1;
            // 
            // entryTableLabel
            // 
            this.entryTableLabel.AutoSize = true;
            this.entryTableLabel.Location = new System.Drawing.Point(6, 63);
            this.entryTableLabel.Name = "entryTableLabel";
            this.entryTableLabel.Size = new System.Drawing.Size(64, 15);
            this.entryTableLabel.TabIndex = 0;
            this.entryTableLabel.Text = "Entry Table";
            // 
            // paddockLabel
            // 
            this.paddockLabel.AutoSize = true;
            this.paddockLabel.Location = new System.Drawing.Point(6, 19);
            this.paddockLabel.Name = "paddockLabel";
            this.paddockLabel.Size = new System.Drawing.Size(53, 15);
            this.paddockLabel.TabIndex = 0;
            this.paddockLabel.Text = "Paddock";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.firstPatternLengthComboBox);
            this.groupBox3.Controls.Add(this.firstPatternCuesheetNameTextBox);
            this.groupBox3.Controls.Add(this.firstPatternCueNameTextBox);
            this.groupBox3.Controls.Add(this.firstPatternLengthLabel);
            this.groupBox3.Location = new System.Drawing.Point(337, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 96);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "First Pattern (Running)";
            // 
            // firstPatternLengthComboBox
            // 
            this.firstPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstPatternLengthComboBox.FormattingEnabled = true;
            this.firstPatternLengthComboBox.Location = new System.Drawing.Point(56, 22);
            this.firstPatternLengthComboBox.Name = "firstPatternLengthComboBox";
            this.firstPatternLengthComboBox.Size = new System.Drawing.Size(121, 23);
            this.firstPatternLengthComboBox.TabIndex = 2;
            this.firstPatternLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstPatternLengthComboBox_SelectedIndexChanged);
            // 
            // firstPatternCuesheetNameTextBox
            // 
            this.firstPatternCuesheetNameTextBox.Location = new System.Drawing.Point(6, 51);
            this.firstPatternCuesheetNameTextBox.Name = "firstPatternCuesheetNameTextBox";
            this.firstPatternCuesheetNameTextBox.ReadOnly = true;
            this.firstPatternCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.firstPatternCuesheetNameTextBox.TabIndex = 1;
            // 
            // firstPatternCueNameTextBox
            // 
            this.firstPatternCueNameTextBox.Location = new System.Drawing.Point(114, 51);
            this.firstPatternCueNameTextBox.Name = "firstPatternCueNameTextBox";
            this.firstPatternCueNameTextBox.ReadOnly = true;
            this.firstPatternCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.firstPatternCueNameTextBox.TabIndex = 1;
            // 
            // firstPatternLengthLabel
            // 
            this.firstPatternLengthLabel.AutoSize = true;
            this.firstPatternLengthLabel.Location = new System.Drawing.Point(6, 25);
            this.firstPatternLengthLabel.Name = "firstPatternLengthLabel";
            this.firstPatternLengthLabel.Size = new System.Drawing.Size(44, 15);
            this.firstPatternLengthLabel.TabIndex = 0;
            this.firstPatternLengthLabel.Text = "Length";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.playLastSpurtButton);
            this.panel.Controls.Add(this.playRunningButton);
            this.panel.Controls.Add(this.playRaceResultButton);
            this.panel.Controls.Add(this.playEntryTableButton);
            this.panel.Controls.Add(this.playPaddockButton);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.groupBox2);
            this.panel.Controls.Add(this.groupBox4);
            this.panel.Controls.Add(this.groupBox3);
            this.panel.Location = new System.Drawing.Point(3, 32);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(694, 437);
            this.panel.TabIndex = 4;
            // 
            // playLastSpurtButton
            // 
            this.playLastSpurtButton.Location = new System.Drawing.Point(467, 236);
            this.playLastSpurtButton.Name = "playLastSpurtButton";
            this.playLastSpurtButton.Size = new System.Drawing.Size(124, 23);
            this.playLastSpurtButton.TabIndex = 4;
            this.playLastSpurtButton.Text = "Play Last Spurt";
            this.playLastSpurtButton.UseVisualStyleBackColor = true;
            this.playLastSpurtButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playRunningButton
            // 
            this.playRunningButton.Location = new System.Drawing.Point(337, 236);
            this.playRunningButton.Name = "playRunningButton";
            this.playRunningButton.Size = new System.Drawing.Size(124, 23);
            this.playRunningButton.TabIndex = 4;
            this.playRunningButton.Text = "Play Running";
            this.playRunningButton.UseVisualStyleBackColor = true;
            this.playRunningButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playRaceResultButton
            // 
            this.playRaceResultButton.Location = new System.Drawing.Point(337, 265);
            this.playRaceResultButton.Name = "playRaceResultButton";
            this.playRaceResultButton.Size = new System.Drawing.Size(124, 23);
            this.playRaceResultButton.TabIndex = 4;
            this.playRaceResultButton.Text = "Play Race Result";
            this.playRaceResultButton.UseVisualStyleBackColor = true;
            this.playRaceResultButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playEntryTableButton
            // 
            this.playEntryTableButton.Location = new System.Drawing.Point(467, 207);
            this.playEntryTableButton.Name = "playEntryTableButton";
            this.playEntryTableButton.Size = new System.Drawing.Size(124, 23);
            this.playEntryTableButton.TabIndex = 4;
            this.playEntryTableButton.Text = "Play Entry Table";
            this.playEntryTableButton.UseVisualStyleBackColor = true;
            this.playEntryTableButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // playPaddockButton
            // 
            this.playPaddockButton.Location = new System.Drawing.Point(337, 207);
            this.playPaddockButton.Name = "playPaddockButton";
            this.playPaddockButton.Size = new System.Drawing.Size(124, 23);
            this.playPaddockButton.TabIndex = 4;
            this.playPaddockButton.Text = "Play Paddock";
            this.playPaddockButton.UseVisualStyleBackColor = true;
            this.playPaddockButton.Click += new System.EventHandler(this.PlayButtons_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.raceResultComboBox);
            this.groupBox2.Controls.Add(this.resultListCuesheetNameTextBox);
            this.groupBox2.Controls.Add(this.resultListCueNameTextBox);
            this.groupBox2.Controls.Add(this.resultCutInCuesheetNameTextBox);
            this.groupBox2.Controls.Add(this.resultCutInCueNameTextBox);
            this.groupBox2.Controls.Add(this.resultListLabel);
            this.groupBox2.Controls.Add(this.cutInLabel);
            this.groupBox2.Controls.Add(this.raceResultLabel);
            this.groupBox2.Location = new System.Drawing.Point(3, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 170);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // raceResultComboBox
            // 
            this.raceResultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceResultComboBox.FormattingEnabled = true;
            this.raceResultComboBox.Items.AddRange(new object[] {
            "1st Place",
            "Normal",
            "Lose"});
            this.raceResultComboBox.Location = new System.Drawing.Point(80, 22);
            this.raceResultComboBox.Name = "raceResultComboBox";
            this.raceResultComboBox.Size = new System.Drawing.Size(121, 23);
            this.raceResultComboBox.TabIndex = 2;
            this.raceResultComboBox.SelectedIndexChanged += new System.EventHandler(this.RaceResultComboBox_SelectedIndexChanged);
            // 
            // resultListCuesheetNameTextBox
            // 
            this.resultListCuesheetNameTextBox.Location = new System.Drawing.Point(6, 125);
            this.resultListCuesheetNameTextBox.Name = "resultListCuesheetNameTextBox";
            this.resultListCuesheetNameTextBox.ReadOnly = true;
            this.resultListCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.resultListCuesheetNameTextBox.TabIndex = 1;
            // 
            // resultListCueNameTextBox
            // 
            this.resultListCueNameTextBox.Location = new System.Drawing.Point(114, 125);
            this.resultListCueNameTextBox.Name = "resultListCueNameTextBox";
            this.resultListCueNameTextBox.ReadOnly = true;
            this.resultListCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.resultListCueNameTextBox.TabIndex = 1;
            // 
            // resultCutInCuesheetNameTextBox
            // 
            this.resultCutInCuesheetNameTextBox.Location = new System.Drawing.Point(6, 81);
            this.resultCutInCuesheetNameTextBox.Name = "resultCutInCuesheetNameTextBox";
            this.resultCutInCuesheetNameTextBox.ReadOnly = true;
            this.resultCutInCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.resultCutInCuesheetNameTextBox.TabIndex = 1;
            // 
            // resultCutInCueNameTextBox
            // 
            this.resultCutInCueNameTextBox.Location = new System.Drawing.Point(114, 81);
            this.resultCutInCueNameTextBox.Name = "resultCutInCueNameTextBox";
            this.resultCutInCueNameTextBox.ReadOnly = true;
            this.resultCutInCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.resultCutInCueNameTextBox.TabIndex = 1;
            // 
            // resultListLabel
            // 
            this.resultListLabel.AutoSize = true;
            this.resultListLabel.Location = new System.Drawing.Point(7, 107);
            this.resultListLabel.Name = "resultListLabel";
            this.resultListLabel.Size = new System.Drawing.Size(60, 15);
            this.resultListLabel.TabIndex = 0;
            this.resultListLabel.Text = "Result List";
            // 
            // cutInLabel
            // 
            this.cutInLabel.AutoSize = true;
            this.cutInLabel.Location = new System.Drawing.Point(6, 63);
            this.cutInLabel.Name = "cutInLabel";
            this.cutInLabel.Size = new System.Drawing.Size(39, 15);
            this.cutInLabel.TabIndex = 0;
            this.cutInLabel.Text = "Cut In";
            // 
            // raceResultLabel
            // 
            this.raceResultLabel.AutoSize = true;
            this.raceResultLabel.Location = new System.Drawing.Point(6, 25);
            this.raceResultLabel.Name = "raceResultLabel";
            this.raceResultLabel.Size = new System.Drawing.Size(67, 15);
            this.raceResultLabel.TabIndex = 0;
            this.raceResultLabel.Text = "Race Result";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.secondPatternLengthComboBox);
            this.groupBox4.Controls.Add(this.secondPatternCuesheetNameTextBox);
            this.groupBox4.Controls.Add(this.secondPatternCueNameTextBox);
            this.groupBox4.Controls.Add(this.secondPatternLengthLabel);
            this.groupBox4.Location = new System.Drawing.Point(337, 105);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 96);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Second Pattern (Last Spurt)";
            // 
            // secondPatternLengthComboBox
            // 
            this.secondPatternLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondPatternLengthComboBox.FormattingEnabled = true;
            this.secondPatternLengthComboBox.Location = new System.Drawing.Point(56, 22);
            this.secondPatternLengthComboBox.Name = "secondPatternLengthComboBox";
            this.secondPatternLengthComboBox.Size = new System.Drawing.Size(121, 23);
            this.secondPatternLengthComboBox.TabIndex = 2;
            this.secondPatternLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondPatternLengthComboBox_SelectedIndexChanged);
            // 
            // secondPatternCuesheetNameTextBox
            // 
            this.secondPatternCuesheetNameTextBox.Location = new System.Drawing.Point(6, 51);
            this.secondPatternCuesheetNameTextBox.Name = "secondPatternCuesheetNameTextBox";
            this.secondPatternCuesheetNameTextBox.ReadOnly = true;
            this.secondPatternCuesheetNameTextBox.Size = new System.Drawing.Size(102, 23);
            this.secondPatternCuesheetNameTextBox.TabIndex = 1;
            // 
            // secondPatternCueNameTextBox
            // 
            this.secondPatternCueNameTextBox.Location = new System.Drawing.Point(114, 51);
            this.secondPatternCueNameTextBox.Name = "secondPatternCueNameTextBox";
            this.secondPatternCueNameTextBox.ReadOnly = true;
            this.secondPatternCueNameTextBox.Size = new System.Drawing.Size(208, 23);
            this.secondPatternCueNameTextBox.TabIndex = 1;
            // 
            // secondPatternLengthLabel
            // 
            this.secondPatternLengthLabel.AutoSize = true;
            this.secondPatternLengthLabel.Location = new System.Drawing.Point(6, 25);
            this.secondPatternLengthLabel.Name = "secondPatternLengthLabel";
            this.secondPatternLengthLabel.Size = new System.Drawing.Size(44, 15);
            this.secondPatternLengthLabel.TabIndex = 0;
            this.secondPatternLengthLabel.Text = "Length";
            // 
            // RaceMusicSimulatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.bgmIDComboBox);
            this.Name = "RaceMusicSimulatorControl";
            this.Size = new System.Drawing.Size(700, 472);
            this.Load += new System.EventHandler(this.RaceSimulatorControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox bgmIDComboBox;
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
    }
}
