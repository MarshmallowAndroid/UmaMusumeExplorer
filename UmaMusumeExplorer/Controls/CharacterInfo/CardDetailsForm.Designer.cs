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
            this.genderLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.cvNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.genderHintLabel = new System.Windows.Forms.Label();
            this.birthDateHintLabel = new System.Windows.Forms.Label();
            this.belowNameTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.costumeComboBox = new System.Windows.Forms.ComboBox();
            this.costumeHintLabel = new System.Windows.Forms.Label();
            this.statsTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.speedStatusDisplayLabel = new UmaMusumeExplorer.Controls.CharacterInfo.StatusDisplayLabel();
            this.speedHintLabel = new System.Windows.Forms.Label();
            this.staminaHintLabel = new System.Windows.Forms.Label();
            this.powerHintLabel = new System.Windows.Forms.Label();
            this.gutsHintLabel = new System.Windows.Forms.Label();
            this.wisdomHintLabel = new System.Windows.Forms.Label();
            this.staminaStatusDisplayLabel = new UmaMusumeExplorer.Controls.CharacterInfo.StatusDisplayLabel();
            this.powerStatusDisplayLabel = new UmaMusumeExplorer.Controls.CharacterInfo.StatusDisplayLabel();
            this.gutsStatusDisplayLabel = new UmaMusumeExplorer.Controls.CharacterInfo.StatusDisplayLabel();
            this.wisdomStatusDisplayLabel = new UmaMusumeExplorer.Controls.CharacterInfo.StatusDisplayLabel();
            this.aptitudeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.driveInRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.dirtRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.turfRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.fieldAptitudeLabel = new System.Windows.Forms.Label();
            this.distanceAptitudeLabel = new System.Windows.Forms.Label();
            this.runningStyleAptitudeLabel = new System.Windows.Forms.Label();
            this.shortRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.mileRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.middleRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.longRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.escapeRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.leadingRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.insertRankedLabel = new UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel();
            this.growthRateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.speedGrowthLabel = new System.Windows.Forms.Label();
            this.staminaGrowthLabel = new System.Windows.Forms.Label();
            this.powerGrowthLabel = new System.Windows.Forms.Label();
            this.gutsGrowthLabel = new System.Windows.Forms.Label();
            this.wisdomGrowthLabel = new System.Windows.Forms.Label();
            this.growthRateLabel = new System.Windows.Forms.Label();
            this.rarityComboBox = new System.Windows.Forms.ComboBox();
            this.rarityHintLabel = new System.Windows.Forms.Label();
            this.skillsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.skillsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.belowNameTablePanel.SuspendLayout();
            this.statsTablePanel.SuspendLayout();
            this.aptitudeTableLayoutPanel.SuspendLayout();
            this.growthRateTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // genderLabel
            // 
            resources.ApplyResources(this.genderLabel, "genderLabel");
            this.genderLabel.Name = "genderLabel";
            // 
            // birthdayLabel
            // 
            resources.ApplyResources(this.birthdayLabel, "birthdayLabel");
            this.birthdayLabel.Name = "birthdayLabel";
            // 
            // iconPictureBox
            // 
            resources.ApplyResources(this.iconPictureBox, "iconPictureBox");
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.TabStop = false;
            // 
            // cvNameLabel
            // 
            resources.ApplyResources(this.cvNameLabel, "cvNameLabel");
            this.cvNameLabel.Name = "cvNameLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // genderHintLabel
            // 
            resources.ApplyResources(this.genderHintLabel, "genderHintLabel");
            this.genderHintLabel.Name = "genderHintLabel";
            // 
            // birthDateHintLabel
            // 
            resources.ApplyResources(this.birthDateHintLabel, "birthDateHintLabel");
            this.birthDateHintLabel.Name = "birthDateHintLabel";
            // 
            // belowNameTablePanel
            // 
            resources.ApplyResources(this.belowNameTablePanel, "belowNameTablePanel");
            this.belowNameTablePanel.Controls.Add(this.genderHintLabel, 0, 0);
            this.belowNameTablePanel.Controls.Add(this.birthDateHintLabel, 0, 1);
            this.belowNameTablePanel.Controls.Add(this.birthdayLabel, 1, 1);
            this.belowNameTablePanel.Controls.Add(this.genderLabel, 1, 0);
            this.belowNameTablePanel.Name = "belowNameTablePanel";
            // 
            // costumeComboBox
            // 
            this.costumeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.costumeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.costumeComboBox, "costumeComboBox");
            this.costumeComboBox.Name = "costumeComboBox";
            this.costumeComboBox.SelectedIndexChanged += new System.EventHandler(this.CostumeSelectComboBox_SelectedIndexChanged);
            // 
            // costumeHintLabel
            // 
            resources.ApplyResources(this.costumeHintLabel, "costumeHintLabel");
            this.costumeHintLabel.Name = "costumeHintLabel";
            // 
            // statsTablePanel
            // 
            resources.ApplyResources(this.statsTablePanel, "statsTablePanel");
            this.statsTablePanel.Controls.Add(this.speedStatusDisplayLabel, 0, 1);
            this.statsTablePanel.Controls.Add(this.speedHintLabel, 0, 0);
            this.statsTablePanel.Controls.Add(this.staminaHintLabel, 1, 0);
            this.statsTablePanel.Controls.Add(this.powerHintLabel, 2, 0);
            this.statsTablePanel.Controls.Add(this.gutsHintLabel, 3, 0);
            this.statsTablePanel.Controls.Add(this.wisdomHintLabel, 4, 0);
            this.statsTablePanel.Controls.Add(this.staminaStatusDisplayLabel, 1, 1);
            this.statsTablePanel.Controls.Add(this.powerStatusDisplayLabel, 2, 1);
            this.statsTablePanel.Controls.Add(this.gutsStatusDisplayLabel, 3, 1);
            this.statsTablePanel.Controls.Add(this.wisdomStatusDisplayLabel, 4, 1);
            this.statsTablePanel.Name = "statsTablePanel";
            // 
            // speedStatusDisplayLabel
            // 
            resources.ApplyResources(this.speedStatusDisplayLabel, "speedStatusDisplayLabel");
            this.speedStatusDisplayLabel.MaxValue = 1200;
            this.speedStatusDisplayLabel.Name = "speedStatusDisplayLabel";
            this.speedStatusDisplayLabel.Value = 50;
            // 
            // speedHintLabel
            // 
            resources.ApplyResources(this.speedHintLabel, "speedHintLabel");
            this.speedHintLabel.Name = "speedHintLabel";
            // 
            // staminaHintLabel
            // 
            resources.ApplyResources(this.staminaHintLabel, "staminaHintLabel");
            this.staminaHintLabel.Name = "staminaHintLabel";
            // 
            // powerHintLabel
            // 
            resources.ApplyResources(this.powerHintLabel, "powerHintLabel");
            this.powerHintLabel.Name = "powerHintLabel";
            // 
            // gutsHintLabel
            // 
            resources.ApplyResources(this.gutsHintLabel, "gutsHintLabel");
            this.gutsHintLabel.Name = "gutsHintLabel";
            // 
            // wisdomHintLabel
            // 
            resources.ApplyResources(this.wisdomHintLabel, "wisdomHintLabel");
            this.wisdomHintLabel.Name = "wisdomHintLabel";
            // 
            // staminaStatusDisplayLabel
            // 
            resources.ApplyResources(this.staminaStatusDisplayLabel, "staminaStatusDisplayLabel");
            this.staminaStatusDisplayLabel.MaxValue = 1200;
            this.staminaStatusDisplayLabel.Name = "staminaStatusDisplayLabel";
            this.staminaStatusDisplayLabel.Value = 50;
            // 
            // powerStatusDisplayLabel
            // 
            resources.ApplyResources(this.powerStatusDisplayLabel, "powerStatusDisplayLabel");
            this.powerStatusDisplayLabel.MaxValue = 1200;
            this.powerStatusDisplayLabel.Name = "powerStatusDisplayLabel";
            this.powerStatusDisplayLabel.Value = 50;
            // 
            // gutsStatusDisplayLabel
            // 
            resources.ApplyResources(this.gutsStatusDisplayLabel, "gutsStatusDisplayLabel");
            this.gutsStatusDisplayLabel.MaxValue = 1200;
            this.gutsStatusDisplayLabel.Name = "gutsStatusDisplayLabel";
            this.gutsStatusDisplayLabel.Value = 50;
            // 
            // wisdomStatusDisplayLabel
            // 
            resources.ApplyResources(this.wisdomStatusDisplayLabel, "wisdomStatusDisplayLabel");
            this.wisdomStatusDisplayLabel.MaxValue = 1200;
            this.wisdomStatusDisplayLabel.Name = "wisdomStatusDisplayLabel";
            this.wisdomStatusDisplayLabel.Value = 50;
            // 
            // aptitudeTableLayoutPanel
            // 
            resources.ApplyResources(this.aptitudeTableLayoutPanel, "aptitudeTableLayoutPanel");
            this.aptitudeTableLayoutPanel.Controls.Add(this.driveInRankedLabel, 4, 2);
            this.aptitudeTableLayoutPanel.Controls.Add(this.dirtRankedLabel, 2, 0);
            this.aptitudeTableLayoutPanel.Controls.Add(this.turfRankedLabel, 1, 0);
            this.aptitudeTableLayoutPanel.Controls.Add(this.fieldAptitudeLabel, 0, 0);
            this.aptitudeTableLayoutPanel.Controls.Add(this.distanceAptitudeLabel, 0, 1);
            this.aptitudeTableLayoutPanel.Controls.Add(this.runningStyleAptitudeLabel, 0, 2);
            this.aptitudeTableLayoutPanel.Controls.Add(this.shortRankedLabel, 1, 1);
            this.aptitudeTableLayoutPanel.Controls.Add(this.mileRankedLabel, 2, 1);
            this.aptitudeTableLayoutPanel.Controls.Add(this.middleRankedLabel, 3, 1);
            this.aptitudeTableLayoutPanel.Controls.Add(this.longRankedLabel, 4, 1);
            this.aptitudeTableLayoutPanel.Controls.Add(this.escapeRankedLabel, 1, 2);
            this.aptitudeTableLayoutPanel.Controls.Add(this.leadingRankedLabel, 2, 2);
            this.aptitudeTableLayoutPanel.Controls.Add(this.insertRankedLabel, 3, 2);
            this.aptitudeTableLayoutPanel.Name = "aptitudeTableLayoutPanel";
            // 
            // driveInRankedLabel
            // 
            this.driveInRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.driveInRankedLabel, "driveInRankedLabel");
            this.driveInRankedLabel.Name = "driveInRankedLabel";
            this.driveInRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // dirtRankedLabel
            // 
            this.dirtRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.dirtRankedLabel, "dirtRankedLabel");
            this.dirtRankedLabel.Name = "dirtRankedLabel";
            this.dirtRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // turfRankedLabel
            // 
            this.turfRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.turfRankedLabel, "turfRankedLabel");
            this.turfRankedLabel.Name = "turfRankedLabel";
            this.turfRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // fieldAptitudeLabel
            // 
            resources.ApplyResources(this.fieldAptitudeLabel, "fieldAptitudeLabel");
            this.fieldAptitudeLabel.Name = "fieldAptitudeLabel";
            // 
            // distanceAptitudeLabel
            // 
            resources.ApplyResources(this.distanceAptitudeLabel, "distanceAptitudeLabel");
            this.distanceAptitudeLabel.Name = "distanceAptitudeLabel";
            // 
            // runningStyleAptitudeLabel
            // 
            resources.ApplyResources(this.runningStyleAptitudeLabel, "runningStyleAptitudeLabel");
            this.runningStyleAptitudeLabel.Name = "runningStyleAptitudeLabel";
            // 
            // shortRankedLabel
            // 
            this.shortRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.shortRankedLabel, "shortRankedLabel");
            this.shortRankedLabel.Name = "shortRankedLabel";
            this.shortRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // mileRankedLabel
            // 
            this.mileRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.mileRankedLabel, "mileRankedLabel");
            this.mileRankedLabel.Name = "mileRankedLabel";
            this.mileRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // middleRankedLabel
            // 
            this.middleRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.middleRankedLabel, "middleRankedLabel");
            this.middleRankedLabel.Name = "middleRankedLabel";
            this.middleRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // longRankedLabel
            // 
            this.longRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.longRankedLabel, "longRankedLabel");
            this.longRankedLabel.Name = "longRankedLabel";
            this.longRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // escapeRankedLabel
            // 
            this.escapeRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.escapeRankedLabel, "escapeRankedLabel");
            this.escapeRankedLabel.Name = "escapeRankedLabel";
            this.escapeRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // leadingRankedLabel
            // 
            this.leadingRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.leadingRankedLabel, "leadingRankedLabel");
            this.leadingRankedLabel.Name = "leadingRankedLabel";
            this.leadingRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // insertRankedLabel
            // 
            this.insertRankedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.insertRankedLabel, "insertRankedLabel");
            this.insertRankedLabel.Name = "insertRankedLabel";
            this.insertRankedLabel.Rank = UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel.RankedLabelRank.Unknown;
            // 
            // growthRateTableLayoutPanel
            // 
            resources.ApplyResources(this.growthRateTableLayoutPanel, "growthRateTableLayoutPanel");
            this.growthRateTableLayoutPanel.Controls.Add(this.speedGrowthLabel, 0, 0);
            this.growthRateTableLayoutPanel.Controls.Add(this.staminaGrowthLabel, 1, 0);
            this.growthRateTableLayoutPanel.Controls.Add(this.powerGrowthLabel, 2, 0);
            this.growthRateTableLayoutPanel.Controls.Add(this.gutsGrowthLabel, 3, 0);
            this.growthRateTableLayoutPanel.Controls.Add(this.wisdomGrowthLabel, 4, 0);
            this.growthRateTableLayoutPanel.Name = "growthRateTableLayoutPanel";
            // 
            // speedGrowthLabel
            // 
            resources.ApplyResources(this.speedGrowthLabel, "speedGrowthLabel");
            this.speedGrowthLabel.Name = "speedGrowthLabel";
            // 
            // staminaGrowthLabel
            // 
            resources.ApplyResources(this.staminaGrowthLabel, "staminaGrowthLabel");
            this.staminaGrowthLabel.Name = "staminaGrowthLabel";
            // 
            // powerGrowthLabel
            // 
            resources.ApplyResources(this.powerGrowthLabel, "powerGrowthLabel");
            this.powerGrowthLabel.Name = "powerGrowthLabel";
            // 
            // gutsGrowthLabel
            // 
            resources.ApplyResources(this.gutsGrowthLabel, "gutsGrowthLabel");
            this.gutsGrowthLabel.Name = "gutsGrowthLabel";
            // 
            // wisdomGrowthLabel
            // 
            resources.ApplyResources(this.wisdomGrowthLabel, "wisdomGrowthLabel");
            this.wisdomGrowthLabel.Name = "wisdomGrowthLabel";
            // 
            // growthRateLabel
            // 
            resources.ApplyResources(this.growthRateLabel, "growthRateLabel");
            this.growthRateLabel.Name = "growthRateLabel";
            // 
            // rarityComboBox
            // 
            this.rarityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rarityComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.rarityComboBox, "rarityComboBox");
            this.rarityComboBox.Name = "rarityComboBox";
            this.rarityComboBox.SelectedIndexChanged += new System.EventHandler(this.RarityComboBox_SelectedIndexChanged);
            // 
            // rarityHintLabel
            // 
            resources.ApplyResources(this.rarityHintLabel, "rarityHintLabel");
            this.rarityHintLabel.Name = "rarityHintLabel";
            // 
            // skillsTableLayoutPanel
            // 
            resources.ApplyResources(this.skillsTableLayoutPanel, "skillsTableLayoutPanel");
            this.skillsTableLayoutPanel.Name = "skillsTableLayoutPanel";
            // 
            // skillsLabel
            // 
            resources.ApplyResources(this.skillsLabel, "skillsLabel");
            this.skillsLabel.Name = "skillsLabel";
            // 
            // CardDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skillsTableLayoutPanel);
            this.Controls.Add(this.skillsLabel);
            this.Controls.Add(this.growthRateLabel);
            this.Controls.Add(this.aptitudeTableLayoutPanel);
            this.Controls.Add(this.growthRateTableLayoutPanel);
            this.Controls.Add(this.statsTablePanel);
            this.Controls.Add(this.rarityHintLabel);
            this.Controls.Add(this.rarityComboBox);
            this.Controls.Add(this.costumeHintLabel);
            this.Controls.Add(this.costumeComboBox);
            this.Controls.Add(this.cvNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.belowNameTablePanel);
            this.Controls.Add(this.iconPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CardDetailsForm";
            this.Load += new System.EventHandler(this.CardDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.belowNameTablePanel.ResumeLayout(false);
            this.belowNameTablePanel.PerformLayout();
            this.statsTablePanel.ResumeLayout(false);
            this.statsTablePanel.PerformLayout();
            this.aptitudeTableLayoutPanel.ResumeLayout(false);
            this.aptitudeTableLayoutPanel.PerformLayout();
            this.growthRateTableLayoutPanel.ResumeLayout(false);
            this.growthRateTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label cvNameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label genderHintLabel;
        private System.Windows.Forms.Label birthDateHintLabel;
        private System.Windows.Forms.TableLayoutPanel belowNameTablePanel;
        private System.Windows.Forms.ComboBox costumeComboBox;
        private System.Windows.Forms.Label costumeHintLabel;
        private System.Windows.Forms.TableLayoutPanel statsTablePanel;
        private System.Windows.Forms.Label speedHintLabel;
        private System.Windows.Forms.Label staminaHintLabel;
        private System.Windows.Forms.Label powerHintLabel;
        private System.Windows.Forms.Label gutsHintLabel;
        private System.Windows.Forms.Label wisdomHintLabel;
        private System.Windows.Forms.TableLayoutPanel aptitudeTableLayoutPanel;
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
        private System.Windows.Forms.TableLayoutPanel growthRateTableLayoutPanel;
        private System.Windows.Forms.Label speedGrowthLabel;
        private System.Windows.Forms.Label staminaGrowthLabel;
        private System.Windows.Forms.Label powerGrowthLabel;
        private System.Windows.Forms.Label gutsGrowthLabel;
        private System.Windows.Forms.Label wisdomGrowthLabel;
        private System.Windows.Forms.Label growthRateLabel;
        private System.Windows.Forms.ComboBox rarityComboBox;
        private System.Windows.Forms.Label rarityHintLabel;
        private System.Windows.Forms.TableLayoutPanel skillsTableLayoutPanel;
        private System.Windows.Forms.Label skillsLabel;
    }
}