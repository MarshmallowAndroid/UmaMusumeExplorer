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
            skillDescriptionLabel = new System.Windows.Forms.Label();
            skillNameLabel = new System.Windows.Forms.Label();
            iconPictureBox = new Common.HighQualityPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // skillDescriptionLabel
            // 
            skillDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            skillDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            skillDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skillDescriptionLabel.Location = new System.Drawing.Point(120, 39);
            skillDescriptionLabel.Name = "skillDescriptionLabel";
            skillDescriptionLabel.Size = new System.Drawing.Size(372, 75);
            skillDescriptionLabel.TabIndex = 4;
            skillDescriptionLabel.Text = "Skill description";
            // 
            // skillNameLabel
            // 
            skillNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            skillNameLabel.Location = new System.Drawing.Point(120, 18);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new System.Drawing.Size(372, 21);
            skillNameLabel.TabIndex = 7;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconPictureBox.Location = new System.Drawing.Point(18, 18);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(96, 96);
            iconPictureBox.TabIndex = 3;
            iconPictureBox.TabStop = false;
            // 
            // SkillLarge
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(skillDescriptionLabel);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            Name = "SkillLarge";
            Padding = new System.Windows.Forms.Padding(15);
            Size = new System.Drawing.Size(510, 132);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label skillDescriptionLabel;
        private System.Windows.Forms.Label skillNameLabel;
        private Common.HighQualityPictureBox iconPictureBox;
    }
}
