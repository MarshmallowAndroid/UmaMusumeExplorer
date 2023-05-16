namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SkillInfoForm
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
            iconPictureBox = new Common.HighQualityPictureBox();
            skillNameLabel = new System.Windows.Forms.Label();
            skillInfoLabel = new System.Windows.Forms.Label();
            closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconPictureBox.Location = new System.Drawing.Point(12, 12);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(96, 96);
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // skillNameLabel
            // 
            skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            skillNameLabel.Location = new System.Drawing.Point(114, 12);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new System.Drawing.Size(389, 28);
            skillNameLabel.TabIndex = 1;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skillInfoLabel
            // 
            skillInfoLabel.BackColor = System.Drawing.Color.Transparent;
            skillInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skillInfoLabel.Location = new System.Drawing.Point(114, 40);
            skillInfoLabel.Name = "skillInfoLabel";
            skillInfoLabel.Size = new System.Drawing.Size(389, 68);
            skillInfoLabel.TabIndex = 1;
            skillInfoLabel.Text = "Skill info";
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(220, 140);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(75, 23);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // SkillInfoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(515, 175);
            Controls.Add(closeButton);
            Controls.Add(skillInfoLabel);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SkillInfoForm";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SkillInfoForm";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label skillNameLabel;
        private System.Windows.Forms.Label skillInfoLabel;
        private System.Windows.Forms.Button closeButton;
        private Common.HighQualityPictureBox iconPictureBox;
    }
}