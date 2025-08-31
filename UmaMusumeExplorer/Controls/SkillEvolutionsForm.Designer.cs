namespace UmaMusumeExplorer.Controls
{
    partial class SkillEvolutionsForm
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
            toEvolveSkill = new SkillLarge();
            evolvedSkill1 = new SkillLarge();
            toEvolveHintLabel = new Label();
            evolvedHintLabel = new Label();
            closeButton = new Button();
            evolvedSkill2 = new SkillLarge();
            SuspendLayout();
            // 
            // toEvolveSkill
            // 
            toEvolveSkill.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            toEvolveSkill.Background = SkillBackground.Rarity2;
            toEvolveSkill.Location = new Point(12, 27);
            toEvolveSkill.Name = "toEvolveSkill";
            toEvolveSkill.Padding = new Padding(15);
            toEvolveSkill.Size = new Size(593, 132);
            toEvolveSkill.Skill = null;
            toEvolveSkill.TabIndex = 0;
            // 
            // evolvedSkill1
            // 
            evolvedSkill1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            evolvedSkill1.Background = SkillBackground.Evolution;
            evolvedSkill1.Location = new Point(12, 195);
            evolvedSkill1.Name = "evolvedSkill1";
            evolvedSkill1.Padding = new Padding(15);
            evolvedSkill1.Size = new Size(593, 132);
            evolvedSkill1.Skill = null;
            evolvedSkill1.TabIndex = 0;
            // 
            // toEvolveHintLabel
            // 
            toEvolveHintLabel.AutoSize = true;
            toEvolveHintLabel.Location = new Point(12, 9);
            toEvolveHintLabel.Name = "toEvolveHintLabel";
            toEvolveHintLabel.Size = new Size(49, 15);
            toEvolveHintLabel.TabIndex = 1;
            toEvolveHintLabel.Text = "Original";
            // 
            // evolvedHintLabel
            // 
            evolvedHintLabel.AutoSize = true;
            evolvedHintLabel.Location = new Point(12, 177);
            evolvedHintLabel.Margin = new Padding(3, 15, 3, 0);
            evolvedHintLabel.Name = "evolvedHintLabel";
            evolvedHintLabel.Size = new Size(48, 15);
            evolvedHintLabel.TabIndex = 1;
            evolvedHintLabel.Text = "Evolved";
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom;
            closeButton.Location = new Point(271, 503);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // evolvedSkill2
            // 
            evolvedSkill2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            evolvedSkill2.Background = SkillBackground.Evolution;
            evolvedSkill2.Location = new Point(12, 333);
            evolvedSkill2.Name = "evolvedSkill2";
            evolvedSkill2.Padding = new Padding(15);
            evolvedSkill2.Size = new Size(593, 132);
            evolvedSkill2.Skill = null;
            evolvedSkill2.TabIndex = 0;
            // 
            // SkillEvolutionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 538);
            Controls.Add(closeButton);
            Controls.Add(evolvedHintLabel);
            Controls.Add(toEvolveHintLabel);
            Controls.Add(evolvedSkill2);
            Controls.Add(evolvedSkill1);
            Controls.Add(toEvolveSkill);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SkillEvolutionsForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Evolution Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SkillLarge toEvolveSkill;
        private SkillLarge evolvedSkill1;
        private System.Windows.Forms.Label toEvolveHintLabel;
        private System.Windows.Forms.Label evolvedHintLabel;
        private System.Windows.Forms.Button closeButton;
        private SkillLarge evolvedSkill2;
    }
}