namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SkillLarge
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
            skillDescriptionLabel = new Label();
            skillNameLabel = new Label();
            iconPictureBox = new UmaMusumeExplorer.Controls.Common.HighQualityPictureBox();
            evolutionInfoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // skillDescriptionLabel
            // 
            skillDescriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            skillDescriptionLabel.BackColor = Color.Transparent;
            skillDescriptionLabel.Font = new Font("Segoe UI", 12F);
            skillDescriptionLabel.Location = new Point(120, 39);
            skillDescriptionLabel.Name = "skillDescriptionLabel";
            skillDescriptionLabel.Size = new Size(372, 75);
            skillDescriptionLabel.TabIndex = 4;
            skillDescriptionLabel.Text = "Skill description";
            // 
            // skillNameLabel
            // 
            skillNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            skillNameLabel.BackColor = Color.Transparent;
            skillNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            skillNameLabel.Location = new Point(120, 18);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new Size(372, 21);
            skillNameLabel.TabIndex = 7;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = Color.Transparent;
            iconPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            iconPictureBox.Location = new Point(18, 18);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(96, 96);
            iconPictureBox.TabIndex = 3;
            iconPictureBox.TabStop = false;
            // 
            // evolutionInfoButton
            // 
            evolutionInfoButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            evolutionInfoButton.Location = new Point(417, 91);
            evolutionInfoButton.Name = "evolutionInfoButton";
            evolutionInfoButton.Size = new Size(75, 23);
            evolutionInfoButton.TabIndex = 8;
            evolutionInfoButton.Text = "Evolution";
            evolutionInfoButton.UseVisualStyleBackColor = true;
            evolutionInfoButton.Visible = false;
            evolutionInfoButton.Click += EvolutionInfoButton_Click;
            // 
            // SkillLarge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(evolutionInfoButton);
            Controls.Add(skillDescriptionLabel);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            Name = "SkillLarge";
            Padding = new Padding(15);
            Size = new Size(510, 132);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label skillDescriptionLabel;
        private System.Windows.Forms.Label skillNameLabel;
        private Common.HighQualityPictureBox iconPictureBox;
        private Button evolutionInfoButton;
    }
}
