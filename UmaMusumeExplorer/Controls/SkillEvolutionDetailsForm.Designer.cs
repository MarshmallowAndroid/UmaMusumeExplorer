namespace UmaMusumeExplorer.Controls
{
    partial class SkillEvolutionDetailsForm
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
            evolvedSkill = new SkillLarge();
            toEvolveHintLabel = new Label();
            evolvedHintLabel = new Label();
            closeButton = new Button();
            evolveConditionsHintLabel = new Label();
            evolveConditionsPanel = new FlowLayoutPanel();
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
            // evolvedSkill
            // 
            evolvedSkill.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            evolvedSkill.Background = SkillBackground.Evolution;
            evolvedSkill.Location = new Point(12, 195);
            evolvedSkill.Name = "evolvedSkill";
            evolvedSkill.Padding = new Padding(15);
            evolvedSkill.Size = new Size(593, 132);
            evolvedSkill.Skill = null;
            evolvedSkill.TabIndex = 0;
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
            closeButton.Location = new Point(271, 714);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // evolveConditionsHintLabel
            // 
            evolveConditionsHintLabel.AutoSize = true;
            evolveConditionsHintLabel.Location = new Point(12, 345);
            evolveConditionsHintLabel.Margin = new Padding(3, 15, 3, 0);
            evolveConditionsHintLabel.Name = "evolveConditionsHintLabel";
            evolveConditionsHintLabel.Size = new Size(102, 15);
            evolveConditionsHintLabel.TabIndex = 1;
            evolveConditionsHintLabel.Text = "Evolve Conditions";
            // 
            // evolveConditionsPanel
            // 
            evolveConditionsPanel.AutoScroll = true;
            evolveConditionsPanel.Location = new Point(12, 363);
            evolveConditionsPanel.Name = "evolveConditionsPanel";
            evolveConditionsPanel.Size = new Size(593, 345);
            evolveConditionsPanel.TabIndex = 3;
            // 
            // SkillEvolutionDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 749);
            Controls.Add(evolveConditionsPanel);
            Controls.Add(closeButton);
            Controls.Add(evolveConditionsHintLabel);
            Controls.Add(evolvedHintLabel);
            Controls.Add(toEvolveHintLabel);
            Controls.Add(evolvedSkill);
            Controls.Add(toEvolveSkill);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SkillEvolutionDetailsForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Evolution Details";
            Load += SkillEvolutionDetailsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SkillLarge toEvolveSkill;
        private SkillLarge evolvedSkill;
        private System.Windows.Forms.Label toEvolveHintLabel;
        private System.Windows.Forms.Label evolvedHintLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label evolveConditionsHintLabel;
        private System.Windows.Forms.FlowLayoutPanel evolveConditionsPanel;
    }
}