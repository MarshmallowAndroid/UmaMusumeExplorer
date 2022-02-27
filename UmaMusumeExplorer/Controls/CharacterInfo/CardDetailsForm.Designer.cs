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
            this.genderLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.cvNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.genderHintLabel = new System.Windows.Forms.Label();
            this.birthDateHintLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.costumeSelectComboBox = new System.Windows.Forms.ComboBox();
            this.costumeHintLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.speedHintLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.staminaLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.gutsLabel = new System.Windows.Forms.Label();
            this.wisdomLabel = new System.Windows.Forms.Label();
            this.staminaHintLabel = new System.Windows.Forms.Label();
            this.powerHintLabel = new System.Windows.Forms.Label();
            this.gutsHintLabel = new System.Windows.Forms.Label();
            this.wisdomHintLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.genderLabel.Location = new System.Drawing.Point(94, 0);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(31, 21);
            this.genderLabel.TabIndex = 6;
            this.genderLabel.Text = "???";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.birthdayLabel.Location = new System.Drawing.Point(94, 21);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(78, 21);
            this.birthdayLabel.TabIndex = 7;
            this.birthdayLabel.Text = "??/??/????";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(12, 12);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(120, 120);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 5;
            this.iconPictureBox.TabStop = false;
            // 
            // cvNameLabel
            // 
            this.cvNameLabel.AutoSize = true;
            this.cvNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cvNameLabel.Location = new System.Drawing.Point(138, 49);
            this.cvNameLabel.Name = "cvNameLabel";
            this.cvNameLabel.Size = new System.Drawing.Size(100, 25);
            this.cvNameLabel.TabIndex = 3;
            this.cvNameLabel.Text = "CV.？？？";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(138, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(104, 37);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "？？？";
            // 
            // genderHintLabel
            // 
            this.genderHintLabel.AutoSize = true;
            this.genderHintLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.genderHintLabel.Location = new System.Drawing.Point(3, 0);
            this.genderHintLabel.Name = "genderHintLabel";
            this.genderHintLabel.Size = new System.Drawing.Size(65, 21);
            this.genderHintLabel.TabIndex = 6;
            this.genderHintLabel.Text = "Gender";
            // 
            // birthDateHintLabel
            // 
            this.birthDateHintLabel.AutoSize = true;
            this.birthDateHintLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.birthDateHintLabel.Location = new System.Drawing.Point(3, 21);
            this.birthDateHintLabel.Name = "birthDateHintLabel";
            this.birthDateHintLabel.Size = new System.Drawing.Size(85, 21);
            this.birthDateHintLabel.TabIndex = 7;
            this.birthDateHintLabel.Text = "Birth date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.genderHintLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.birthDateHintLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.birthdayLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.genderLabel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(138, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 55);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // costumeSelectComboBox
            // 
            this.costumeSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.costumeSelectComboBox.FormattingEnabled = true;
            this.costumeSelectComboBox.Location = new System.Drawing.Point(73, 138);
            this.costumeSelectComboBox.Name = "costumeSelectComboBox";
            this.costumeSelectComboBox.Size = new System.Drawing.Size(167, 23);
            this.costumeSelectComboBox.TabIndex = 9;
            this.costumeSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.CostumeSelectComboBox_SelectedIndexChanged);
            // 
            // costumeHintLabel
            // 
            this.costumeHintLabel.AutoSize = true;
            this.costumeHintLabel.Location = new System.Drawing.Point(12, 141);
            this.costumeHintLabel.Name = "costumeHintLabel";
            this.costumeHintLabel.Size = new System.Drawing.Size(55, 15);
            this.costumeHintLabel.TabIndex = 10;
            this.costumeHintLabel.Text = "Costume";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.speedHintLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.speedLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.staminaLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.powerLabel, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.gutsLabel, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.wisdomLabel, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.staminaHintLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.powerHintLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.gutsHintLabel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.wisdomHintLabel, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 197);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(577, 89);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // speedHintLabel
            // 
            this.speedHintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speedHintLabel.AutoSize = true;
            this.speedHintLabel.Location = new System.Drawing.Point(38, 0);
            this.speedHintLabel.Name = "speedHintLabel";
            this.speedHintLabel.Size = new System.Drawing.Size(39, 15);
            this.speedHintLabel.TabIndex = 12;
            this.speedHintLabel.Text = "Speed";
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speedLabel.Location = new System.Drawing.Point(41, 33);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(32, 37);
            this.speedLabel.TabIndex = 12;
            this.speedLabel.Text = "0";
            // 
            // staminaLabel
            // 
            this.staminaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staminaLabel.AutoSize = true;
            this.staminaLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.staminaLabel.Location = new System.Drawing.Point(156, 33);
            this.staminaLabel.Name = "staminaLabel";
            this.staminaLabel.Size = new System.Drawing.Size(32, 37);
            this.staminaLabel.TabIndex = 12;
            this.staminaLabel.Text = "0";
            // 
            // powerLabel
            // 
            this.powerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.powerLabel.AutoSize = true;
            this.powerLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.powerLabel.Location = new System.Drawing.Point(271, 33);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(32, 37);
            this.powerLabel.TabIndex = 12;
            this.powerLabel.Text = "0";
            // 
            // gutsLabel
            // 
            this.gutsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gutsLabel.AutoSize = true;
            this.gutsLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gutsLabel.Location = new System.Drawing.Point(386, 33);
            this.gutsLabel.Name = "gutsLabel";
            this.gutsLabel.Size = new System.Drawing.Size(32, 37);
            this.gutsLabel.TabIndex = 12;
            this.gutsLabel.Text = "0";
            // 
            // wisdomLabel
            // 
            this.wisdomLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wisdomLabel.AutoSize = true;
            this.wisdomLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wisdomLabel.Location = new System.Drawing.Point(502, 33);
            this.wisdomLabel.Name = "wisdomLabel";
            this.wisdomLabel.Size = new System.Drawing.Size(32, 37);
            this.wisdomLabel.TabIndex = 12;
            this.wisdomLabel.Text = "0";
            // 
            // staminaHintLabel
            // 
            this.staminaHintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staminaHintLabel.AutoSize = true;
            this.staminaHintLabel.Location = new System.Drawing.Point(147, 0);
            this.staminaHintLabel.Name = "staminaHintLabel";
            this.staminaHintLabel.Size = new System.Drawing.Size(50, 15);
            this.staminaHintLabel.TabIndex = 12;
            this.staminaHintLabel.Text = "Stamina";
            // 
            // powerHintLabel
            // 
            this.powerHintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.powerHintLabel.AutoSize = true;
            this.powerHintLabel.Location = new System.Drawing.Point(267, 0);
            this.powerHintLabel.Name = "powerHintLabel";
            this.powerHintLabel.Size = new System.Drawing.Size(40, 15);
            this.powerHintLabel.TabIndex = 12;
            this.powerHintLabel.Text = "Power";
            // 
            // gutsHintLabel
            // 
            this.gutsHintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gutsHintLabel.AutoSize = true;
            this.gutsHintLabel.Location = new System.Drawing.Point(387, 0);
            this.gutsHintLabel.Name = "gutsHintLabel";
            this.gutsHintLabel.Size = new System.Drawing.Size(31, 15);
            this.gutsHintLabel.TabIndex = 12;
            this.gutsHintLabel.Text = "Guts";
            // 
            // wisdomHintLabel
            // 
            this.wisdomHintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wisdomHintLabel.AutoSize = true;
            this.wisdomHintLabel.Location = new System.Drawing.Point(493, 0);
            this.wisdomHintLabel.Name = "wisdomHintLabel";
            this.wisdomHintLabel.Size = new System.Drawing.Size(51, 15);
            this.wisdomHintLabel.TabIndex = 12;
            this.wisdomHintLabel.Text = "Wisdom";
            // 
            // CardDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 651);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.costumeHintLabel);
            this.Controls.Add(this.costumeSelectComboBox);
            this.Controls.Add(this.cvNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.iconPictureBox);
            this.Name = "CardDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CardDetailsForm";
            this.Load += new System.EventHandler(this.CardDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox costumeSelectComboBox;
        private System.Windows.Forms.Label costumeHintLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label staminaLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label gutsLabel;
        private System.Windows.Forms.Label wisdomLabel;
        private System.Windows.Forms.Label speedHintLabel;
        private System.Windows.Forms.Label staminaHintLabel;
        private System.Windows.Forms.Label powerHintLabel;
        private System.Windows.Forms.Label gutsHintLabel;
        private System.Windows.Forms.Label wisdomHintLabel;
    }
}