namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SkillButtonSmall
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
            levelLabel = new System.Windows.Forms.Label();
            skillNameLabel = new System.Windows.Forms.Label();
            iconPictureBox = new Common.HighQualityPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // levelLabel
            // 
            levelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            levelLabel.BackColor = System.Drawing.Color.Transparent;
            levelLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            levelLabel.Location = new System.Drawing.Point(272, 4);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(40, 43);
            levelLabel.TabIndex = 4;
            levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skillNameLabel
            // 
            skillNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skillNameLabel.Location = new System.Drawing.Point(47, 4);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new System.Drawing.Size(218, 43);
            skillNameLabel.TabIndex = 3;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            iconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            iconPictureBox.Location = new System.Drawing.Point(7, 8);
            iconPictureBox.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(30, 35);
            iconPictureBox.TabIndex = 2;
            iconPictureBox.TabStop = false;
            // 
            // SkillButtonSmall
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            Controls.Add(levelLabel);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            Cursor = System.Windows.Forms.Cursors.Hand;
            DoubleBuffered = true;
            Name = "SkillButtonSmall";
            Size = new System.Drawing.Size(315, 51);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label skillNameLabel;
        private Common.HighQualityPictureBox iconPictureBox;
    }
}
