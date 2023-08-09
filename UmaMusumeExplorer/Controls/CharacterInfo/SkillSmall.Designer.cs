namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SkillSmall
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
            evolutionCircle = new CircleControl();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // levelLabel
            // 
            levelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            levelLabel.BackColor = System.Drawing.Color.Transparent;
            levelLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            levelLabel.Location = new System.Drawing.Point(271, 8);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(41, 35);
            levelLabel.TabIndex = 4;
            levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skillNameLabel
            // 
            skillNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skillNameLabel.Location = new System.Drawing.Point(52, 8);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new System.Drawing.Size(213, 35);
            skillNameLabel.TabIndex = 3;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox
            // 
            iconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            iconPictureBox.Location = new System.Drawing.Point(7, 8);
            iconPictureBox.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(35, 35);
            iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            iconPictureBox.TabIndex = 2;
            iconPictureBox.TabStop = false;
            // 
            // evolutionCircle
            // 
            evolutionCircle.ForeColor = System.Drawing.Color.FromArgb(255, 116, 187);
            evolutionCircle.Location = new System.Drawing.Point(35, 5);
            evolutionCircle.Name = "evolutionCircle";
            evolutionCircle.Size = new System.Drawing.Size(10, 10);
            evolutionCircle.TabIndex = 5;
            evolutionCircle.Visible = false;
            // 
            // SkillSmall
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            Controls.Add(evolutionCircle);
            Controls.Add(levelLabel);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            Cursor = System.Windows.Forms.Cursors.Hand;
            DoubleBuffered = true;
            Name = "SkillSmall";
            Size = new System.Drawing.Size(315, 51);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label skillNameLabel;
        private Common.HighQualityPictureBox iconPictureBox;
        private CircleControl evolutionCircle;
    }
}
