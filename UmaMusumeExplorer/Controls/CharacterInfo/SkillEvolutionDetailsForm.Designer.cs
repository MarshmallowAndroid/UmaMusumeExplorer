namespace UmaMusumeExplorer.Controls.CharacterInfo
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
            toEvolveHintLabel = new System.Windows.Forms.Label();
            evolvedHintLabel = new System.Windows.Forms.Label();
            closeButton = new System.Windows.Forms.Button();
            evolveConditionsHintLabel = new System.Windows.Forms.Label();
            evolveConditionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // toEvolveSkill
            // 
            toEvolveSkill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            toEvolveSkill.Background = Classes.SkillBackground.Rarity2;
            toEvolveSkill.Location = new System.Drawing.Point(12, 27);
            toEvolveSkill.Name = "toEvolveSkill";
            toEvolveSkill.Padding = new System.Windows.Forms.Padding(15);
            toEvolveSkill.Size = new System.Drawing.Size(593, 132);
            toEvolveSkill.Skill = null;
            toEvolveSkill.TabIndex = 0;
            // 
            // evolvedSkill
            // 
            evolvedSkill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            evolvedSkill.Background = Classes.SkillBackground.Evolution;
            evolvedSkill.Location = new System.Drawing.Point(12, 195);
            evolvedSkill.Name = "evolvedSkill";
            evolvedSkill.Padding = new System.Windows.Forms.Padding(15);
            evolvedSkill.Size = new System.Drawing.Size(593, 132);
            evolvedSkill.Skill = null;
            evolvedSkill.TabIndex = 0;
            // 
            // toEvolveHintLabel
            // 
            toEvolveHintLabel.AutoSize = true;
            toEvolveHintLabel.Location = new System.Drawing.Point(12, 9);
            toEvolveHintLabel.Name = "toEvolveHintLabel";
            toEvolveHintLabel.Size = new System.Drawing.Size(56, 15);
            toEvolveHintLabel.TabIndex = 1;
            toEvolveHintLabel.Text = "To evolve";
            // 
            // evolvedHintLabel
            // 
            evolvedHintLabel.AutoSize = true;
            evolvedHintLabel.Location = new System.Drawing.Point(12, 177);
            evolvedHintLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            evolvedHintLabel.Name = "evolvedHintLabel";
            evolvedHintLabel.Size = new System.Drawing.Size(48, 15);
            evolvedHintLabel.TabIndex = 1;
            evolvedHintLabel.Text = "Evolved";
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(271, 714);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // evolveConditionsHintLabel
            // 
            evolveConditionsHintLabel.AutoSize = true;
            evolveConditionsHintLabel.Location = new System.Drawing.Point(12, 345);
            evolveConditionsHintLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            evolveConditionsHintLabel.Name = "evolveConditionsHintLabel";
            evolveConditionsHintLabel.Size = new System.Drawing.Size(102, 15);
            evolveConditionsHintLabel.TabIndex = 1;
            evolveConditionsHintLabel.Text = "Evolve Conditions";
            // 
            // evolveConditionsPanel
            // 
            evolveConditionsPanel.AutoScroll = true;
            evolveConditionsPanel.Location = new System.Drawing.Point(12, 363);
            evolveConditionsPanel.Name = "evolveConditionsPanel";
            evolveConditionsPanel.Size = new System.Drawing.Size(593, 345);
            evolveConditionsPanel.TabIndex = 3;
            // 
            // SkillEvolutionDetailsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(617, 749);
            Controls.Add(evolveConditionsPanel);
            Controls.Add(closeButton);
            Controls.Add(evolveConditionsHintLabel);
            Controls.Add(evolvedHintLabel);
            Controls.Add(toEvolveHintLabel);
            Controls.Add(evolvedSkill);
            Controls.Add(toEvolveSkill);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SkillEvolutionDetailsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
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