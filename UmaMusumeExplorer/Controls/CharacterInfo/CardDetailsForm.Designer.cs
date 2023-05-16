namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CardDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardDetailsForm));
            genderLabel = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            iconPictureBox = new Common.HighQualityPictureBox();
            cvNameLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            genderHintLabel = new System.Windows.Forms.Label();
            birthDateHintLabel = new System.Windows.Forms.Label();
            belowNameTablePanel = new DoubleBufferedTableLayoutPanel();
            costumeComboBox = new System.Windows.Forms.ComboBox();
            costumeHintLabel = new System.Windows.Forms.Label();
            statsTablePanel = new DoubleBufferedTableLayoutPanel();
            speedStatusDisplayLabel = new StatusDisplayLabel();
            speedHintLabel = new System.Windows.Forms.Label();
            staminaHintLabel = new System.Windows.Forms.Label();
            powerHintLabel = new System.Windows.Forms.Label();
            gutsHintLabel = new System.Windows.Forms.Label();
            wisdomHintLabel = new System.Windows.Forms.Label();
            staminaStatusDisplayLabel = new StatusDisplayLabel();
            powerStatusDisplayLabel = new StatusDisplayLabel();
            gutsStatusDisplayLabel = new StatusDisplayLabel();
            wisdomStatusDisplayLabel = new StatusDisplayLabel();
            aptitudeTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            driveInRankedLabel = new RankedLabel();
            dirtRankedLabel = new RankedLabel();
            turfRankedLabel = new RankedLabel();
            fieldAptitudeLabel = new System.Windows.Forms.Label();
            distanceAptitudeLabel = new System.Windows.Forms.Label();
            runningStyleAptitudeLabel = new System.Windows.Forms.Label();
            shortRankedLabel = new RankedLabel();
            mileRankedLabel = new RankedLabel();
            middleRankedLabel = new RankedLabel();
            longRankedLabel = new RankedLabel();
            escapeRankedLabel = new RankedLabel();
            leadingRankedLabel = new RankedLabel();
            insertRankedLabel = new RankedLabel();
            growthRateTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            speedGrowthLabel = new System.Windows.Forms.Label();
            staminaGrowthLabel = new System.Windows.Forms.Label();
            powerGrowthLabel = new System.Windows.Forms.Label();
            gutsGrowthLabel = new System.Windows.Forms.Label();
            wisdomGrowthLabel = new System.Windows.Forms.Label();
            growthRateLabel = new System.Windows.Forms.Label();
            rarityComboBox = new System.Windows.Forms.ComboBox();
            rarityHintLabel = new System.Windows.Forms.Label();
            skillsTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            skillsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            belowNameTablePanel.SuspendLayout();
            statsTablePanel.SuspendLayout();
            aptitudeTableLayoutPanel.SuspendLayout();
            growthRateTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // genderLabel
            // 
            resources.ApplyResources(genderLabel, "genderLabel");
            genderLabel.Name = "genderLabel";
            // 
            // birthdayLabel
            // 
            resources.ApplyResources(birthdayLabel, "birthdayLabel");
            birthdayLabel.Name = "birthdayLabel";
            // 
            // iconPictureBox
            // 
            resources.ApplyResources(iconPictureBox, "iconPictureBox");
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.TabStop = false;
            // 
            // cvNameLabel
            // 
            resources.ApplyResources(cvNameLabel, "cvNameLabel");
            cvNameLabel.Name = "cvNameLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.Name = "nameLabel";
            // 
            // genderHintLabel
            // 
            resources.ApplyResources(genderHintLabel, "genderHintLabel");
            genderHintLabel.Name = "genderHintLabel";
            // 
            // birthDateHintLabel
            // 
            resources.ApplyResources(birthDateHintLabel, "birthDateHintLabel");
            birthDateHintLabel.Name = "birthDateHintLabel";
            // 
            // belowNameTablePanel
            // 
            resources.ApplyResources(belowNameTablePanel, "belowNameTablePanel");
            belowNameTablePanel.Controls.Add(genderHintLabel, 0, 0);
            belowNameTablePanel.Controls.Add(birthDateHintLabel, 0, 1);
            belowNameTablePanel.Controls.Add(birthdayLabel, 1, 1);
            belowNameTablePanel.Controls.Add(genderLabel, 1, 0);
            belowNameTablePanel.Name = "belowNameTablePanel";
            // 
            // costumeComboBox
            // 
            costumeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            costumeComboBox.FormattingEnabled = true;
            resources.ApplyResources(costumeComboBox, "costumeComboBox");
            costumeComboBox.Name = "costumeComboBox";
            costumeComboBox.SelectedIndexChanged += CostumeSelectComboBox_SelectedIndexChanged;
            // 
            // costumeHintLabel
            // 
            resources.ApplyResources(costumeHintLabel, "costumeHintLabel");
            costumeHintLabel.Name = "costumeHintLabel";
            // 
            // statsTablePanel
            // 
            resources.ApplyResources(statsTablePanel, "statsTablePanel");
            statsTablePanel.Controls.Add(speedStatusDisplayLabel, 0, 1);
            statsTablePanel.Controls.Add(speedHintLabel, 0, 0);
            statsTablePanel.Controls.Add(staminaHintLabel, 1, 0);
            statsTablePanel.Controls.Add(powerHintLabel, 2, 0);
            statsTablePanel.Controls.Add(gutsHintLabel, 3, 0);
            statsTablePanel.Controls.Add(wisdomHintLabel, 4, 0);
            statsTablePanel.Controls.Add(staminaStatusDisplayLabel, 1, 1);
            statsTablePanel.Controls.Add(powerStatusDisplayLabel, 2, 1);
            statsTablePanel.Controls.Add(gutsStatusDisplayLabel, 3, 1);
            statsTablePanel.Controls.Add(wisdomStatusDisplayLabel, 4, 1);
            statsTablePanel.Name = "statsTablePanel";
            // 
            // speedStatusDisplayLabel
            // 
            resources.ApplyResources(speedStatusDisplayLabel, "speedStatusDisplayLabel");
            speedStatusDisplayLabel.MaxValue = 1200;
            speedStatusDisplayLabel.Name = "speedStatusDisplayLabel";
            speedStatusDisplayLabel.Value = 50;
            // 
            // speedHintLabel
            // 
            resources.ApplyResources(speedHintLabel, "speedHintLabel");
            speedHintLabel.Name = "speedHintLabel";
            // 
            // staminaHintLabel
            // 
            resources.ApplyResources(staminaHintLabel, "staminaHintLabel");
            staminaHintLabel.Name = "staminaHintLabel";
            // 
            // powerHintLabel
            // 
            resources.ApplyResources(powerHintLabel, "powerHintLabel");
            powerHintLabel.Name = "powerHintLabel";
            // 
            // gutsHintLabel
            // 
            resources.ApplyResources(gutsHintLabel, "gutsHintLabel");
            gutsHintLabel.Name = "gutsHintLabel";
            // 
            // wisdomHintLabel
            // 
            resources.ApplyResources(wisdomHintLabel, "wisdomHintLabel");
            wisdomHintLabel.Name = "wisdomHintLabel";
            // 
            // staminaStatusDisplayLabel
            // 
            resources.ApplyResources(staminaStatusDisplayLabel, "staminaStatusDisplayLabel");
            staminaStatusDisplayLabel.MaxValue = 1200;
            staminaStatusDisplayLabel.Name = "staminaStatusDisplayLabel";
            staminaStatusDisplayLabel.Value = 50;
            // 
            // powerStatusDisplayLabel
            // 
            resources.ApplyResources(powerStatusDisplayLabel, "powerStatusDisplayLabel");
            powerStatusDisplayLabel.MaxValue = 1200;
            powerStatusDisplayLabel.Name = "powerStatusDisplayLabel";
            powerStatusDisplayLabel.Value = 50;
            // 
            // gutsStatusDisplayLabel
            // 
            resources.ApplyResources(gutsStatusDisplayLabel, "gutsStatusDisplayLabel");
            gutsStatusDisplayLabel.MaxValue = 1200;
            gutsStatusDisplayLabel.Name = "gutsStatusDisplayLabel";
            gutsStatusDisplayLabel.Value = 50;
            // 
            // wisdomStatusDisplayLabel
            // 
            resources.ApplyResources(wisdomStatusDisplayLabel, "wisdomStatusDisplayLabel");
            wisdomStatusDisplayLabel.MaxValue = 1200;
            wisdomStatusDisplayLabel.Name = "wisdomStatusDisplayLabel";
            wisdomStatusDisplayLabel.Value = 50;
            // 
            // aptitudeTableLayoutPanel
            // 
            resources.ApplyResources(aptitudeTableLayoutPanel, "aptitudeTableLayoutPanel");
            aptitudeTableLayoutPanel.Controls.Add(driveInRankedLabel, 4, 2);
            aptitudeTableLayoutPanel.Controls.Add(dirtRankedLabel, 2, 0);
            aptitudeTableLayoutPanel.Controls.Add(turfRankedLabel, 1, 0);
            aptitudeTableLayoutPanel.Controls.Add(fieldAptitudeLabel, 0, 0);
            aptitudeTableLayoutPanel.Controls.Add(distanceAptitudeLabel, 0, 1);
            aptitudeTableLayoutPanel.Controls.Add(runningStyleAptitudeLabel, 0, 2);
            aptitudeTableLayoutPanel.Controls.Add(shortRankedLabel, 1, 1);
            aptitudeTableLayoutPanel.Controls.Add(mileRankedLabel, 2, 1);
            aptitudeTableLayoutPanel.Controls.Add(middleRankedLabel, 3, 1);
            aptitudeTableLayoutPanel.Controls.Add(longRankedLabel, 4, 1);
            aptitudeTableLayoutPanel.Controls.Add(escapeRankedLabel, 1, 2);
            aptitudeTableLayoutPanel.Controls.Add(leadingRankedLabel, 2, 2);
            aptitudeTableLayoutPanel.Controls.Add(insertRankedLabel, 3, 2);
            aptitudeTableLayoutPanel.Name = "aptitudeTableLayoutPanel";
            // 
            // driveInRankedLabel
            // 
            driveInRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(driveInRankedLabel, "driveInRankedLabel");
            driveInRankedLabel.Name = "driveInRankedLabel";
            driveInRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // dirtRankedLabel
            // 
            dirtRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(dirtRankedLabel, "dirtRankedLabel");
            dirtRankedLabel.Name = "dirtRankedLabel";
            dirtRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // turfRankedLabel
            // 
            turfRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(turfRankedLabel, "turfRankedLabel");
            turfRankedLabel.Name = "turfRankedLabel";
            turfRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // fieldAptitudeLabel
            // 
            resources.ApplyResources(fieldAptitudeLabel, "fieldAptitudeLabel");
            fieldAptitudeLabel.Name = "fieldAptitudeLabel";
            // 
            // distanceAptitudeLabel
            // 
            resources.ApplyResources(distanceAptitudeLabel, "distanceAptitudeLabel");
            distanceAptitudeLabel.Name = "distanceAptitudeLabel";
            // 
            // runningStyleAptitudeLabel
            // 
            resources.ApplyResources(runningStyleAptitudeLabel, "runningStyleAptitudeLabel");
            runningStyleAptitudeLabel.Name = "runningStyleAptitudeLabel";
            // 
            // shortRankedLabel
            // 
            shortRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(shortRankedLabel, "shortRankedLabel");
            shortRankedLabel.Name = "shortRankedLabel";
            shortRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // mileRankedLabel
            // 
            mileRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(mileRankedLabel, "mileRankedLabel");
            mileRankedLabel.Name = "mileRankedLabel";
            mileRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // middleRankedLabel
            // 
            middleRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(middleRankedLabel, "middleRankedLabel");
            middleRankedLabel.Name = "middleRankedLabel";
            middleRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // longRankedLabel
            // 
            longRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(longRankedLabel, "longRankedLabel");
            longRankedLabel.Name = "longRankedLabel";
            longRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // escapeRankedLabel
            // 
            escapeRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(escapeRankedLabel, "escapeRankedLabel");
            escapeRankedLabel.Name = "escapeRankedLabel";
            escapeRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // leadingRankedLabel
            // 
            leadingRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(leadingRankedLabel, "leadingRankedLabel");
            leadingRankedLabel.Name = "leadingRankedLabel";
            leadingRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // insertRankedLabel
            // 
            insertRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(insertRankedLabel, "insertRankedLabel");
            insertRankedLabel.Name = "insertRankedLabel";
            insertRankedLabel.Rank = RankedLabel.RankedLabelRank.Unknown;
            // 
            // growthRateTableLayoutPanel
            // 
            resources.ApplyResources(growthRateTableLayoutPanel, "growthRateTableLayoutPanel");
            growthRateTableLayoutPanel.Controls.Add(speedGrowthLabel, 0, 0);
            growthRateTableLayoutPanel.Controls.Add(staminaGrowthLabel, 1, 0);
            growthRateTableLayoutPanel.Controls.Add(powerGrowthLabel, 2, 0);
            growthRateTableLayoutPanel.Controls.Add(gutsGrowthLabel, 3, 0);
            growthRateTableLayoutPanel.Controls.Add(wisdomGrowthLabel, 4, 0);
            growthRateTableLayoutPanel.Name = "growthRateTableLayoutPanel";
            // 
            // speedGrowthLabel
            // 
            resources.ApplyResources(speedGrowthLabel, "speedGrowthLabel");
            speedGrowthLabel.Name = "speedGrowthLabel";
            // 
            // staminaGrowthLabel
            // 
            resources.ApplyResources(staminaGrowthLabel, "staminaGrowthLabel");
            staminaGrowthLabel.Name = "staminaGrowthLabel";
            // 
            // powerGrowthLabel
            // 
            resources.ApplyResources(powerGrowthLabel, "powerGrowthLabel");
            powerGrowthLabel.Name = "powerGrowthLabel";
            // 
            // gutsGrowthLabel
            // 
            resources.ApplyResources(gutsGrowthLabel, "gutsGrowthLabel");
            gutsGrowthLabel.Name = "gutsGrowthLabel";
            // 
            // wisdomGrowthLabel
            // 
            resources.ApplyResources(wisdomGrowthLabel, "wisdomGrowthLabel");
            wisdomGrowthLabel.Name = "wisdomGrowthLabel";
            // 
            // growthRateLabel
            // 
            resources.ApplyResources(growthRateLabel, "growthRateLabel");
            growthRateLabel.Name = "growthRateLabel";
            // 
            // rarityComboBox
            // 
            rarityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rarityComboBox.FormattingEnabled = true;
            resources.ApplyResources(rarityComboBox, "rarityComboBox");
            rarityComboBox.Name = "rarityComboBox";
            rarityComboBox.SelectedIndexChanged += RarityComboBox_SelectedIndexChanged;
            // 
            // rarityHintLabel
            // 
            resources.ApplyResources(rarityHintLabel, "rarityHintLabel");
            rarityHintLabel.Name = "rarityHintLabel";
            // 
            // skillsTableLayoutPanel
            // 
            resources.ApplyResources(skillsTableLayoutPanel, "skillsTableLayoutPanel");
            skillsTableLayoutPanel.Name = "skillsTableLayoutPanel";
            // 
            // skillsLabel
            // 
            resources.ApplyResources(skillsLabel, "skillsLabel");
            skillsLabel.Name = "skillsLabel";
            // 
            // CardDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(skillsTableLayoutPanel);
            Controls.Add(skillsLabel);
            Controls.Add(growthRateLabel);
            Controls.Add(aptitudeTableLayoutPanel);
            Controls.Add(growthRateTableLayoutPanel);
            Controls.Add(statsTablePanel);
            Controls.Add(rarityHintLabel);
            Controls.Add(rarityComboBox);
            Controls.Add(costumeHintLabel);
            Controls.Add(costumeComboBox);
            Controls.Add(cvNameLabel);
            Controls.Add(nameLabel);
            Controls.Add(belowNameTablePanel);
            Controls.Add(iconPictureBox);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CardDetailsForm";
            Load += CardDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            belowNameTablePanel.ResumeLayout(false);
            belowNameTablePanel.PerformLayout();
            statsTablePanel.ResumeLayout(false);
            statsTablePanel.PerformLayout();
            aptitudeTableLayoutPanel.ResumeLayout(false);
            aptitudeTableLayoutPanel.PerformLayout();
            growthRateTableLayoutPanel.ResumeLayout(false);
            growthRateTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private Common.HighQualityPictureBox iconPictureBox;
        private System.Windows.Forms.Label cvNameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label genderHintLabel;
        private System.Windows.Forms.Label birthDateHintLabel;
        private DoubleBufferedTableLayoutPanel belowNameTablePanel;
        private System.Windows.Forms.ComboBox costumeComboBox;
        private System.Windows.Forms.Label costumeHintLabel;
        private DoubleBufferedTableLayoutPanel statsTablePanel;
        private System.Windows.Forms.Label speedHintLabel;
        private System.Windows.Forms.Label staminaHintLabel;
        private System.Windows.Forms.Label powerHintLabel;
        private System.Windows.Forms.Label gutsHintLabel;
        private System.Windows.Forms.Label wisdomHintLabel;
        private DoubleBufferedTableLayoutPanel aptitudeTableLayoutPanel;
        private StatusDisplayLabel speedStatusDisplayLabel;
        private StatusDisplayLabel staminaStatusDisplayLabel;
        private StatusDisplayLabel powerStatusDisplayLabel;
        private StatusDisplayLabel gutsStatusDisplayLabel;
        private StatusDisplayLabel wisdomStatusDisplayLabel;
        private System.Windows.Forms.Label fieldAptitudeLabel;
        private System.Windows.Forms.Label distanceAptitudeLabel;
        private System.Windows.Forms.Label runningStyleAptitudeLabel;
        private RankedLabel driveInRankedLabel;
        private RankedLabel dirtRankedLabel;
        private RankedLabel turfRankedLabel;
        private RankedLabel shortRankedLabel;
        private RankedLabel mileRankedLabel;
        private RankedLabel middleRankedLabel;
        private RankedLabel longRankedLabel;
        private RankedLabel escapeRankedLabel;
        private RankedLabel leadingRankedLabel;
        private RankedLabel insertRankedLabel;
        private DoubleBufferedTableLayoutPanel growthRateTableLayoutPanel;
        private System.Windows.Forms.Label speedGrowthLabel;
        private System.Windows.Forms.Label staminaGrowthLabel;
        private System.Windows.Forms.Label powerGrowthLabel;
        private System.Windows.Forms.Label gutsGrowthLabel;
        private System.Windows.Forms.Label wisdomGrowthLabel;
        private System.Windows.Forms.Label growthRateLabel;
        private System.Windows.Forms.ComboBox rarityComboBox;
        private System.Windows.Forms.Label rarityHintLabel;
        private DoubleBufferedTableLayoutPanel skillsTableLayoutPanel;
        private System.Windows.Forms.Label skillsLabel;
    }
}