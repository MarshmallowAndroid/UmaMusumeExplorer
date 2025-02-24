using UmaMusumeExplorer.Controls.CharacterInfo.Classes;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CardInfoControl
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
            iconPictureBox = new UmaMusumeExplorer.Controls.Common.HighQualityPictureBox();
            skillsTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            belowNameTablePanel = new DoubleBufferedTableLayoutPanel();
            genderHintLabel = new Label();
            birthDateHintLabel = new Label();
            birthdayLabel = new Label();
            genderLabel = new Label();
            skillsLabel = new Label();
            nameLabel = new Label();
            growthRateLabel = new Label();
            cvNameLabel = new Label();
            aptitudeTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            driveInRankedLabel = new RankedLabel();
            dirtRankedLabel = new RankedLabel();
            turfRankedLabel = new RankedLabel();
            fieldAptitudeLabel = new Label();
            distanceAptitudeLabel = new Label();
            runningStyleAptitudeLabel = new Label();
            shortRankedLabel = new RankedLabel();
            mileRankedLabel = new RankedLabel();
            middleRankedLabel = new RankedLabel();
            longRankedLabel = new RankedLabel();
            escapeRankedLabel = new RankedLabel();
            leadingRankedLabel = new RankedLabel();
            insertRankedLabel = new RankedLabel();
            costumeComboBox = new ComboBox();
            growthRateTableLayoutPanel = new DoubleBufferedTableLayoutPanel();
            speedGrowthLabel = new Label();
            staminaGrowthLabel = new Label();
            powerGrowthLabel = new Label();
            gutsGrowthLabel = new Label();
            wisdomGrowthLabel = new Label();
            costumeHintLabel = new Label();
            statsTablePanel = new DoubleBufferedTableLayoutPanel();
            speedStatusDisplayLabel = new StatusDisplayLabel();
            speedHintLabel = new Label();
            staminaHintLabel = new Label();
            powerHintLabel = new Label();
            gutsHintLabel = new Label();
            wisdomHintLabel = new Label();
            staminaStatusDisplayLabel = new StatusDisplayLabel();
            powerStatusDisplayLabel = new StatusDisplayLabel();
            gutsStatusDisplayLabel = new StatusDisplayLabel();
            wisdomStatusDisplayLabel = new StatusDisplayLabel();
            rarityComboBox = new ComboBox();
            rarityHintLabel = new Label();
            levelHintLabel = new Label();
            levelComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            belowNameTablePanel.SuspendLayout();
            aptitudeTableLayoutPanel.SuspendLayout();
            growthRateTableLayoutPanel.SuspendLayout();
            statsTablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.ImeMode = ImeMode.NoControl;
            iconPictureBox.Location = new Point(2, 2);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(137, 150);
            iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox.TabIndex = 17;
            iconPictureBox.TabStop = false;
            // 
            // skillsTableLayoutPanel
            // 
            skillsTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            skillsTableLayoutPanel.AutoScroll = true;
            skillsTableLayoutPanel.ColumnCount = 2;
            skillsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            skillsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            skillsTableLayoutPanel.Location = new Point(2, 510);
            skillsTableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            skillsTableLayoutPanel.Name = "skillsTableLayoutPanel";
            skillsTableLayoutPanel.RowCount = 4;
            skillsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            skillsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            skillsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            skillsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            skillsTableLayoutPanel.Size = new Size(563, 261);
            skillsTableLayoutPanel.TabIndex = 14;
            // 
            // belowNameTablePanel
            // 
            belowNameTablePanel.ColumnCount = 2;
            belowNameTablePanel.ColumnStyles.Add(new ColumnStyle());
            belowNameTablePanel.ColumnStyles.Add(new ColumnStyle());
            belowNameTablePanel.Controls.Add(genderHintLabel, 0, 0);
            belowNameTablePanel.Controls.Add(birthDateHintLabel, 0, 1);
            belowNameTablePanel.Controls.Add(birthdayLabel, 1, 1);
            belowNameTablePanel.Controls.Add(genderLabel, 1, 0);
            belowNameTablePanel.Location = new Point(145, 79);
            belowNameTablePanel.Margin = new Padding(3, 4, 3, 4);
            belowNameTablePanel.Name = "belowNameTablePanel";
            belowNameTablePanel.RowCount = 2;
            belowNameTablePanel.RowStyles.Add(new RowStyle());
            belowNameTablePanel.RowStyles.Add(new RowStyle());
            belowNameTablePanel.Size = new Size(407, 73);
            belowNameTablePanel.TabIndex = 2;
            // 
            // genderHintLabel
            // 
            genderHintLabel.AutoSize = true;
            genderHintLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            genderHintLabel.ImeMode = ImeMode.NoControl;
            genderHintLabel.Location = new Point(3, 0);
            genderHintLabel.Name = "genderHintLabel";
            genderHintLabel.Size = new Size(65, 21);
            genderHintLabel.TabIndex = 0;
            genderHintLabel.Text = "Gender";
            // 
            // birthDateHintLabel
            // 
            birthDateHintLabel.AutoSize = true;
            birthDateHintLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            birthDateHintLabel.ImeMode = ImeMode.NoControl;
            birthDateHintLabel.Location = new Point(3, 21);
            birthDateHintLabel.Name = "birthDateHintLabel";
            birthDateHintLabel.Size = new Size(85, 21);
            birthDateHintLabel.TabIndex = 2;
            birthDateHintLabel.Text = "Birth date";
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Font = new Font("Segoe UI", 12F);
            birthdayLabel.ImeMode = ImeMode.NoControl;
            birthdayLabel.Location = new Point(94, 21);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new Size(78, 21);
            birthdayLabel.TabIndex = 3;
            birthdayLabel.Text = "??/??/????";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Font = new Font("Segoe UI", 12F);
            genderLabel.ImeMode = ImeMode.NoControl;
            genderLabel.Location = new Point(94, 0);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(31, 21);
            genderLabel.TabIndex = 1;
            genderLabel.Text = "???";
            // 
            // skillsLabel
            // 
            skillsLabel.AutoSize = true;
            skillsLabel.ImeMode = ImeMode.NoControl;
            skillsLabel.Location = new Point(2, 491);
            skillsLabel.Margin = new Padding(3, 9, 3, 0);
            skillsLabel.Name = "skillsLabel";
            skillsLabel.Size = new Size(33, 15);
            skillsLabel.TabIndex = 13;
            skillsLabel.Text = "Skills";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            nameLabel.ImeMode = ImeMode.NoControl;
            nameLabel.Location = new Point(145, 2);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(104, 37);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "？？？";
            // 
            // growthRateLabel
            // 
            growthRateLabel.AutoSize = true;
            growthRateLabel.ImeMode = ImeMode.NoControl;
            growthRateLabel.Location = new Point(2, 424);
            growthRateLabel.Margin = new Padding(3, 9, 3, 0);
            growthRateLabel.Name = "growthRateLabel";
            growthRateLabel.Size = new Size(69, 15);
            growthRateLabel.TabIndex = 11;
            growthRateLabel.Text = "Growth rate";
            // 
            // cvNameLabel
            // 
            cvNameLabel.AutoSize = true;
            cvNameLabel.Font = new Font("Segoe UI", 14.25F);
            cvNameLabel.ImeMode = ImeMode.NoControl;
            cvNameLabel.Location = new Point(145, 39);
            cvNameLabel.Name = "cvNameLabel";
            cvNameLabel.Size = new Size(100, 25);
            cvNameLabel.TabIndex = 1;
            cvNameLabel.Text = "CV.？？？";
            // 
            // aptitudeTableLayoutPanel
            // 
            aptitudeTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            aptitudeTableLayoutPanel.ColumnCount = 5;
            aptitudeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            aptitudeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            aptitudeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            aptitudeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            aptitudeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
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
            aptitudeTableLayoutPanel.Location = new Point(2, 293);
            aptitudeTableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            aptitudeTableLayoutPanel.Name = "aptitudeTableLayoutPanel";
            aptitudeTableLayoutPanel.RowCount = 3;
            aptitudeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            aptitudeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            aptitudeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            aptitudeTableLayoutPanel.Size = new Size(563, 118);
            aptitudeTableLayoutPanel.TabIndex = 10;
            // 
            // driveInRankedLabel
            // 
            driveInRankedLabel.Anchor = AnchorStyles.None;
            driveInRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            driveInRankedLabel.Location = new Point(451, 83);
            driveInRankedLabel.Margin = new Padding(3, 5, 3, 5);
            driveInRankedLabel.Name = "driveInRankedLabel";
            driveInRankedLabel.Rank = Rank.Unknown;
            driveInRankedLabel.Size = new Size(109, 30);
            driveInRankedLabel.TabIndex = 12;
            driveInRankedLabel.Text = "Drive-in";
            // 
            // dirtRankedLabel
            // 
            dirtRankedLabel.Anchor = AnchorStyles.None;
            dirtRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            dirtRankedLabel.Location = new Point(227, 5);
            dirtRankedLabel.Margin = new Padding(3, 5, 3, 5);
            dirtRankedLabel.Name = "dirtRankedLabel";
            dirtRankedLabel.Rank = Rank.Unknown;
            dirtRankedLabel.Size = new Size(106, 29);
            dirtRankedLabel.TabIndex = 2;
            dirtRankedLabel.Text = "Dirt";
            // 
            // turfRankedLabel
            // 
            turfRankedLabel.Anchor = AnchorStyles.None;
            turfRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            turfRankedLabel.Location = new Point(115, 5);
            turfRankedLabel.Margin = new Padding(3, 5, 3, 5);
            turfRankedLabel.Name = "turfRankedLabel";
            turfRankedLabel.Rank = Rank.Unknown;
            turfRankedLabel.Size = new Size(106, 29);
            turfRankedLabel.TabIndex = 1;
            turfRankedLabel.Text = "Turf";
            // 
            // fieldAptitudeLabel
            // 
            fieldAptitudeLabel.Anchor = AnchorStyles.Left;
            fieldAptitudeLabel.AutoSize = true;
            fieldAptitudeLabel.ImeMode = ImeMode.NoControl;
            fieldAptitudeLabel.Location = new Point(3, 12);
            fieldAptitudeLabel.Name = "fieldAptitudeLabel";
            fieldAptitudeLabel.Size = new Size(79, 15);
            fieldAptitudeLabel.TabIndex = 0;
            fieldAptitudeLabel.Text = "Field aptitude";
            // 
            // distanceAptitudeLabel
            // 
            distanceAptitudeLabel.Anchor = AnchorStyles.Left;
            distanceAptitudeLabel.AutoSize = true;
            distanceAptitudeLabel.ImeMode = ImeMode.NoControl;
            distanceAptitudeLabel.Location = new Point(3, 51);
            distanceAptitudeLabel.Name = "distanceAptitudeLabel";
            distanceAptitudeLabel.Size = new Size(99, 15);
            distanceAptitudeLabel.TabIndex = 3;
            distanceAptitudeLabel.Text = "Distance aptitude";
            // 
            // runningStyleAptitudeLabel
            // 
            runningStyleAptitudeLabel.Anchor = AnchorStyles.Left;
            runningStyleAptitudeLabel.AutoSize = true;
            runningStyleAptitudeLabel.ImeMode = ImeMode.NoControl;
            runningStyleAptitudeLabel.Location = new Point(3, 83);
            runningStyleAptitudeLabel.Name = "runningStyleAptitudeLabel";
            runningStyleAptitudeLabel.Size = new Size(82, 30);
            runningStyleAptitudeLabel.TabIndex = 8;
            runningStyleAptitudeLabel.Text = "Running style aptitude";
            // 
            // shortRankedLabel
            // 
            shortRankedLabel.Anchor = AnchorStyles.None;
            shortRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            shortRankedLabel.Location = new Point(115, 44);
            shortRankedLabel.Margin = new Padding(3, 5, 3, 5);
            shortRankedLabel.Name = "shortRankedLabel";
            shortRankedLabel.Rank = Rank.Unknown;
            shortRankedLabel.Size = new Size(106, 29);
            shortRankedLabel.TabIndex = 4;
            shortRankedLabel.Text = "Short";
            // 
            // mileRankedLabel
            // 
            mileRankedLabel.Anchor = AnchorStyles.None;
            mileRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            mileRankedLabel.Location = new Point(227, 44);
            mileRankedLabel.Margin = new Padding(3, 5, 3, 5);
            mileRankedLabel.Name = "mileRankedLabel";
            mileRankedLabel.Rank = Rank.Unknown;
            mileRankedLabel.Size = new Size(106, 29);
            mileRankedLabel.TabIndex = 5;
            mileRankedLabel.Text = "Mile";
            // 
            // middleRankedLabel
            // 
            middleRankedLabel.Anchor = AnchorStyles.None;
            middleRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            middleRankedLabel.Location = new Point(339, 44);
            middleRankedLabel.Margin = new Padding(3, 5, 3, 5);
            middleRankedLabel.Name = "middleRankedLabel";
            middleRankedLabel.Rank = Rank.Unknown;
            middleRankedLabel.Size = new Size(106, 29);
            middleRankedLabel.TabIndex = 6;
            middleRankedLabel.Text = "Middle";
            // 
            // longRankedLabel
            // 
            longRankedLabel.Anchor = AnchorStyles.None;
            longRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            longRankedLabel.Location = new Point(451, 44);
            longRankedLabel.Margin = new Padding(3, 5, 3, 5);
            longRankedLabel.Name = "longRankedLabel";
            longRankedLabel.Rank = Rank.Unknown;
            longRankedLabel.Size = new Size(109, 29);
            longRankedLabel.TabIndex = 7;
            longRankedLabel.Text = "Long";
            // 
            // escapeRankedLabel
            // 
            escapeRankedLabel.Anchor = AnchorStyles.None;
            escapeRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            escapeRankedLabel.Location = new Point(115, 83);
            escapeRankedLabel.Margin = new Padding(3, 5, 3, 5);
            escapeRankedLabel.Name = "escapeRankedLabel";
            escapeRankedLabel.Rank = Rank.Unknown;
            escapeRankedLabel.Size = new Size(106, 30);
            escapeRankedLabel.TabIndex = 9;
            escapeRankedLabel.Text = "Escape";
            // 
            // leadingRankedLabel
            // 
            leadingRankedLabel.Anchor = AnchorStyles.None;
            leadingRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            leadingRankedLabel.Location = new Point(227, 83);
            leadingRankedLabel.Margin = new Padding(3, 5, 3, 5);
            leadingRankedLabel.Name = "leadingRankedLabel";
            leadingRankedLabel.Rank = Rank.Unknown;
            leadingRankedLabel.Size = new Size(106, 30);
            leadingRankedLabel.TabIndex = 10;
            leadingRankedLabel.Text = "Leading";
            // 
            // insertRankedLabel
            // 
            insertRankedLabel.Anchor = AnchorStyles.None;
            insertRankedLabel.BorderStyle = BorderStyle.FixedSingle;
            insertRankedLabel.Location = new Point(339, 83);
            insertRankedLabel.Margin = new Padding(3, 5, 3, 5);
            insertRankedLabel.Name = "insertRankedLabel";
            insertRankedLabel.Rank = Rank.Unknown;
            insertRankedLabel.Size = new Size(106, 30);
            insertRankedLabel.TabIndex = 11;
            insertRankedLabel.Text = "Insert";
            // 
            // costumeComboBox
            // 
            costumeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            costumeComboBox.FormattingEnabled = true;
            costumeComboBox.Location = new Point(63, 160);
            costumeComboBox.Margin = new Padding(3, 4, 3, 4);
            costumeComboBox.Name = "costumeComboBox";
            costumeComboBox.Size = new Size(190, 23);
            costumeComboBox.TabIndex = 4;
            costumeComboBox.SelectedIndexChanged += CostumeSelectComboBox_SelectedIndexChanged;
            // 
            // growthRateTableLayoutPanel
            // 
            growthRateTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            growthRateTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            growthRateTableLayoutPanel.ColumnCount = 5;
            growthRateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            growthRateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            growthRateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            growthRateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            growthRateTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            growthRateTableLayoutPanel.Controls.Add(speedGrowthLabel, 0, 0);
            growthRateTableLayoutPanel.Controls.Add(staminaGrowthLabel, 1, 0);
            growthRateTableLayoutPanel.Controls.Add(powerGrowthLabel, 2, 0);
            growthRateTableLayoutPanel.Controls.Add(gutsGrowthLabel, 3, 0);
            growthRateTableLayoutPanel.Controls.Add(wisdomGrowthLabel, 4, 0);
            growthRateTableLayoutPanel.Location = new Point(2, 443);
            growthRateTableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            growthRateTableLayoutPanel.Name = "growthRateTableLayoutPanel";
            growthRateTableLayoutPanel.RowCount = 1;
            growthRateTableLayoutPanel.RowStyles.Add(new RowStyle());
            growthRateTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            growthRateTableLayoutPanel.Size = new Size(563, 35);
            growthRateTableLayoutPanel.TabIndex = 12;
            // 
            // speedGrowthLabel
            // 
            speedGrowthLabel.Anchor = AnchorStyles.None;
            speedGrowthLabel.AutoSize = true;
            speedGrowthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            speedGrowthLabel.ImeMode = ImeMode.NoControl;
            speedGrowthLabel.Location = new Point(40, 7);
            speedGrowthLabel.Name = "speedGrowthLabel";
            speedGrowthLabel.Size = new Size(33, 21);
            speedGrowthLabel.TabIndex = 0;
            speedGrowthLabel.Text = "0%";
            // 
            // staminaGrowthLabel
            // 
            staminaGrowthLabel.Anchor = AnchorStyles.None;
            staminaGrowthLabel.AutoSize = true;
            staminaGrowthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            staminaGrowthLabel.ImeMode = ImeMode.NoControl;
            staminaGrowthLabel.Location = new Point(152, 7);
            staminaGrowthLabel.Name = "staminaGrowthLabel";
            staminaGrowthLabel.Size = new Size(33, 21);
            staminaGrowthLabel.TabIndex = 1;
            staminaGrowthLabel.Text = "0%";
            // 
            // powerGrowthLabel
            // 
            powerGrowthLabel.Anchor = AnchorStyles.None;
            powerGrowthLabel.AutoSize = true;
            powerGrowthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            powerGrowthLabel.ImeMode = ImeMode.NoControl;
            powerGrowthLabel.Location = new Point(264, 7);
            powerGrowthLabel.Name = "powerGrowthLabel";
            powerGrowthLabel.Size = new Size(33, 21);
            powerGrowthLabel.TabIndex = 2;
            powerGrowthLabel.Text = "0%";
            // 
            // gutsGrowthLabel
            // 
            gutsGrowthLabel.Anchor = AnchorStyles.None;
            gutsGrowthLabel.AutoSize = true;
            gutsGrowthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gutsGrowthLabel.ImeMode = ImeMode.NoControl;
            gutsGrowthLabel.Location = new Point(376, 7);
            gutsGrowthLabel.Name = "gutsGrowthLabel";
            gutsGrowthLabel.Size = new Size(33, 21);
            gutsGrowthLabel.TabIndex = 3;
            gutsGrowthLabel.Text = "0%";
            // 
            // wisdomGrowthLabel
            // 
            wisdomGrowthLabel.Anchor = AnchorStyles.None;
            wisdomGrowthLabel.AutoSize = true;
            wisdomGrowthLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            wisdomGrowthLabel.ImeMode = ImeMode.NoControl;
            wisdomGrowthLabel.Location = new Point(489, 7);
            wisdomGrowthLabel.Name = "wisdomGrowthLabel";
            wisdomGrowthLabel.Size = new Size(33, 21);
            wisdomGrowthLabel.TabIndex = 4;
            wisdomGrowthLabel.Text = "0%";
            // 
            // costumeHintLabel
            // 
            costumeHintLabel.AutoSize = true;
            costumeHintLabel.ImeMode = ImeMode.NoControl;
            costumeHintLabel.Location = new Point(2, 163);
            costumeHintLabel.Name = "costumeHintLabel";
            costumeHintLabel.Size = new Size(55, 15);
            costumeHintLabel.TabIndex = 3;
            costumeHintLabel.Text = "Costume";
            // 
            // statsTablePanel
            // 
            statsTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statsTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            statsTablePanel.ColumnCount = 5;
            statsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
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
            statsTablePanel.Location = new Point(2, 191);
            statsTablePanel.Margin = new Padding(3, 4, 3, 4);
            statsTablePanel.Name = "statsTablePanel";
            statsTablePanel.RowCount = 2;
            statsTablePanel.RowStyles.Add(new RowStyle());
            statsTablePanel.RowStyles.Add(new RowStyle());
            statsTablePanel.Size = new Size(563, 94);
            statsTablePanel.TabIndex = 9;
            // 
            // speedStatusDisplayLabel
            // 
            speedStatusDisplayLabel.Anchor = AnchorStyles.None;
            speedStatusDisplayLabel.AutoSize = true;
            speedStatusDisplayLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            speedStatusDisplayLabel.Location = new Point(13, 25);
            speedStatusDisplayLabel.Margin = new Padding(3, 5, 3, 5);
            speedStatusDisplayLabel.MaxValue = 1200;
            speedStatusDisplayLabel.Name = "speedStatusDisplayLabel";
            speedStatusDisplayLabel.Size = new Size(86, 60);
            speedStatusDisplayLabel.TabIndex = 1;
            speedStatusDisplayLabel.Value = 50;
            // 
            // speedHintLabel
            // 
            speedHintLabel.Anchor = AnchorStyles.None;
            speedHintLabel.AutoSize = true;
            speedHintLabel.ImeMode = ImeMode.NoControl;
            speedHintLabel.Location = new Point(37, 1);
            speedHintLabel.Name = "speedHintLabel";
            speedHintLabel.Size = new Size(39, 15);
            speedHintLabel.TabIndex = 0;
            speedHintLabel.Text = "Speed";
            // 
            // staminaHintLabel
            // 
            staminaHintLabel.Anchor = AnchorStyles.None;
            staminaHintLabel.AutoSize = true;
            staminaHintLabel.ImeMode = ImeMode.NoControl;
            staminaHintLabel.Location = new Point(143, 1);
            staminaHintLabel.Name = "staminaHintLabel";
            staminaHintLabel.Size = new Size(50, 15);
            staminaHintLabel.TabIndex = 2;
            staminaHintLabel.Text = "Stamina";
            // 
            // powerHintLabel
            // 
            powerHintLabel.Anchor = AnchorStyles.None;
            powerHintLabel.AutoSize = true;
            powerHintLabel.ImeMode = ImeMode.NoControl;
            powerHintLabel.Location = new Point(260, 1);
            powerHintLabel.Name = "powerHintLabel";
            powerHintLabel.Size = new Size(40, 15);
            powerHintLabel.TabIndex = 4;
            powerHintLabel.Text = "Power";
            // 
            // gutsHintLabel
            // 
            gutsHintLabel.Anchor = AnchorStyles.None;
            gutsHintLabel.AutoSize = true;
            gutsHintLabel.ImeMode = ImeMode.NoControl;
            gutsHintLabel.Location = new Point(377, 1);
            gutsHintLabel.Name = "gutsHintLabel";
            gutsHintLabel.Size = new Size(31, 15);
            gutsHintLabel.TabIndex = 6;
            gutsHintLabel.Text = "Guts";
            // 
            // wisdomHintLabel
            // 
            wisdomHintLabel.Anchor = AnchorStyles.None;
            wisdomHintLabel.AutoSize = true;
            wisdomHintLabel.ImeMode = ImeMode.NoControl;
            wisdomHintLabel.Location = new Point(480, 1);
            wisdomHintLabel.Name = "wisdomHintLabel";
            wisdomHintLabel.Size = new Size(51, 15);
            wisdomHintLabel.TabIndex = 8;
            wisdomHintLabel.Text = "Wisdom";
            // 
            // staminaStatusDisplayLabel
            // 
            staminaStatusDisplayLabel.Anchor = AnchorStyles.None;
            staminaStatusDisplayLabel.AutoSize = true;
            staminaStatusDisplayLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            staminaStatusDisplayLabel.Location = new Point(125, 25);
            staminaStatusDisplayLabel.Margin = new Padding(3, 5, 3, 5);
            staminaStatusDisplayLabel.MaxValue = 1200;
            staminaStatusDisplayLabel.Name = "staminaStatusDisplayLabel";
            staminaStatusDisplayLabel.Size = new Size(86, 60);
            staminaStatusDisplayLabel.TabIndex = 3;
            staminaStatusDisplayLabel.Value = 50;
            // 
            // powerStatusDisplayLabel
            // 
            powerStatusDisplayLabel.Anchor = AnchorStyles.None;
            powerStatusDisplayLabel.AutoSize = true;
            powerStatusDisplayLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            powerStatusDisplayLabel.Location = new Point(237, 25);
            powerStatusDisplayLabel.Margin = new Padding(3, 5, 3, 5);
            powerStatusDisplayLabel.MaxValue = 1200;
            powerStatusDisplayLabel.Name = "powerStatusDisplayLabel";
            powerStatusDisplayLabel.Size = new Size(86, 60);
            powerStatusDisplayLabel.TabIndex = 5;
            powerStatusDisplayLabel.Value = 50;
            // 
            // gutsStatusDisplayLabel
            // 
            gutsStatusDisplayLabel.Anchor = AnchorStyles.None;
            gutsStatusDisplayLabel.AutoSize = true;
            gutsStatusDisplayLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gutsStatusDisplayLabel.Location = new Point(349, 25);
            gutsStatusDisplayLabel.Margin = new Padding(3, 5, 3, 5);
            gutsStatusDisplayLabel.MaxValue = 1200;
            gutsStatusDisplayLabel.Name = "gutsStatusDisplayLabel";
            gutsStatusDisplayLabel.Size = new Size(86, 60);
            gutsStatusDisplayLabel.TabIndex = 7;
            gutsStatusDisplayLabel.Value = 50;
            // 
            // wisdomStatusDisplayLabel
            // 
            wisdomStatusDisplayLabel.Anchor = AnchorStyles.None;
            wisdomStatusDisplayLabel.AutoSize = true;
            wisdomStatusDisplayLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wisdomStatusDisplayLabel.Location = new Point(462, 25);
            wisdomStatusDisplayLabel.Margin = new Padding(3, 5, 3, 5);
            wisdomStatusDisplayLabel.MaxValue = 1200;
            wisdomStatusDisplayLabel.Name = "wisdomStatusDisplayLabel";
            wisdomStatusDisplayLabel.Size = new Size(86, 60);
            wisdomStatusDisplayLabel.TabIndex = 9;
            wisdomStatusDisplayLabel.Value = 50;
            // 
            // rarityComboBox
            // 
            rarityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rarityComboBox.FormattingEnabled = true;
            rarityComboBox.Location = new Point(302, 160);
            rarityComboBox.Margin = new Padding(3, 4, 3, 4);
            rarityComboBox.Name = "rarityComboBox";
            rarityComboBox.Size = new Size(133, 23);
            rarityComboBox.TabIndex = 6;
            rarityComboBox.SelectedIndexChanged += RarityOrLevelComboBox_SelectedIndexChanged;
            // 
            // rarityHintLabel
            // 
            rarityHintLabel.AutoSize = true;
            rarityHintLabel.ImeMode = ImeMode.NoControl;
            rarityHintLabel.Location = new Point(259, 163);
            rarityHintLabel.Name = "rarityHintLabel";
            rarityHintLabel.Size = new Size(37, 15);
            rarityHintLabel.TabIndex = 5;
            rarityHintLabel.Text = "Rarity";
            // 
            // levelHintLabel
            // 
            levelHintLabel.AutoSize = true;
            levelHintLabel.ImeMode = ImeMode.NoControl;
            levelHintLabel.Location = new Point(441, 163);
            levelHintLabel.Name = "levelHintLabel";
            levelHintLabel.Size = new Size(34, 15);
            levelHintLabel.TabIndex = 7;
            levelHintLabel.Text = "Level";
            // 
            // levelComboBox
            // 
            levelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            levelComboBox.FormattingEnabled = true;
            levelComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            levelComboBox.Location = new Point(481, 160);
            levelComboBox.Margin = new Padding(3, 4, 3, 4);
            levelComboBox.Name = "levelComboBox";
            levelComboBox.Size = new Size(84, 23);
            levelComboBox.TabIndex = 8;
            levelComboBox.SelectedIndexChanged += RarityOrLevelComboBox_SelectedIndexChanged;
            // 
            // CardInfoControl
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(iconPictureBox);
            Controls.Add(skillsTableLayoutPanel);
            Controls.Add(belowNameTablePanel);
            Controls.Add(skillsLabel);
            Controls.Add(nameLabel);
            Controls.Add(growthRateLabel);
            Controls.Add(cvNameLabel);
            Controls.Add(aptitudeTableLayoutPanel);
            Controls.Add(costumeComboBox);
            Controls.Add(growthRateTableLayoutPanel);
            Controls.Add(costumeHintLabel);
            Controls.Add(statsTablePanel);
            Controls.Add(levelComboBox);
            Controls.Add(rarityComboBox);
            Controls.Add(levelHintLabel);
            Controls.Add(rarityHintLabel);
            Name = "CardInfoControl";
            Size = new Size(568, 775);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            belowNameTablePanel.ResumeLayout(false);
            belowNameTablePanel.PerformLayout();
            aptitudeTableLayoutPanel.ResumeLayout(false);
            aptitudeTableLayoutPanel.PerformLayout();
            growthRateTableLayoutPanel.ResumeLayout(false);
            growthRateTableLayoutPanel.PerformLayout();
            statsTablePanel.ResumeLayout(false);
            statsTablePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Common.HighQualityPictureBox iconPictureBox;
        private DoubleBufferedTableLayoutPanel skillsTableLayoutPanel;
        private DoubleBufferedTableLayoutPanel belowNameTablePanel;
        private System.Windows.Forms.Label genderHintLabel;
        private System.Windows.Forms.Label birthDateHintLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label skillsLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label growthRateLabel;
        private System.Windows.Forms.Label cvNameLabel;
        private DoubleBufferedTableLayoutPanel aptitudeTableLayoutPanel;
        private RankedLabel driveInRankedLabel;
        private RankedLabel dirtRankedLabel;
        private RankedLabel turfRankedLabel;
        private System.Windows.Forms.Label fieldAptitudeLabel;
        private System.Windows.Forms.Label distanceAptitudeLabel;
        private System.Windows.Forms.Label runningStyleAptitudeLabel;
        private RankedLabel shortRankedLabel;
        private RankedLabel mileRankedLabel;
        private RankedLabel middleRankedLabel;
        private RankedLabel longRankedLabel;
        private RankedLabel escapeRankedLabel;
        private RankedLabel leadingRankedLabel;
        private RankedLabel insertRankedLabel;
        private System.Windows.Forms.ComboBox costumeComboBox;
        private DoubleBufferedTableLayoutPanel growthRateTableLayoutPanel;
        private System.Windows.Forms.Label speedGrowthLabel;
        private System.Windows.Forms.Label staminaGrowthLabel;
        private System.Windows.Forms.Label powerGrowthLabel;
        private System.Windows.Forms.Label gutsGrowthLabel;
        private System.Windows.Forms.Label wisdomGrowthLabel;
        private System.Windows.Forms.Label costumeHintLabel;
        private DoubleBufferedTableLayoutPanel statsTablePanel;
        private StatusDisplayLabel speedStatusDisplayLabel;
        private System.Windows.Forms.Label speedHintLabel;
        private System.Windows.Forms.Label staminaHintLabel;
        private System.Windows.Forms.Label powerHintLabel;
        private System.Windows.Forms.Label gutsHintLabel;
        private System.Windows.Forms.Label wisdomHintLabel;
        private StatusDisplayLabel staminaStatusDisplayLabel;
        private StatusDisplayLabel powerStatusDisplayLabel;
        private StatusDisplayLabel gutsStatusDisplayLabel;
        private StatusDisplayLabel wisdomStatusDisplayLabel;
        private System.Windows.Forms.ComboBox rarityComboBox;
        private System.Windows.Forms.Label rarityHintLabel;
        private System.Windows.Forms.Label levelHintLabel;
        private System.Windows.Forms.ComboBox levelComboBox;
    }
}
