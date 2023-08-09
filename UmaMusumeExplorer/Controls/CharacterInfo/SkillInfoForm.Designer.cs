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
            skillDescriptionLabel = new System.Windows.Forms.Label();
            closeButton = new System.Windows.Forms.Button();
            skillPointHint = new System.Windows.Forms.Label();
            skillPointNeededLabel = new System.Windows.Forms.Label();
            evolutionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconPictureBox.Location = new System.Drawing.Point(18, 18);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new System.Drawing.Size(96, 96);
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // skillNameLabel
            // 
            skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            skillNameLabel.Location = new System.Drawing.Point(120, 18);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new System.Drawing.Size(384, 21);
            skillNameLabel.TabIndex = 0;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skillDescriptionLabel
            // 
            skillDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            skillDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skillDescriptionLabel.Location = new System.Drawing.Point(120, 39);
            skillDescriptionLabel.Name = "skillDescriptionLabel";
            skillDescriptionLabel.Size = new System.Drawing.Size(384, 75);
            skillDescriptionLabel.TabIndex = 1;
            skillDescriptionLabel.Text = "Skill description";
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(263, 142);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(75, 23);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // skillPointHint
            // 
            skillPointHint.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            skillPointHint.AutoSize = true;
            skillPointHint.BackColor = System.Drawing.Color.White;
            skillPointHint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            skillPointHint.Location = new System.Drawing.Point(475, 18);
            skillPointHint.Name = "skillPointHint";
            skillPointHint.Size = new System.Drawing.Size(63, 21);
            skillPointHint.TabIndex = 2;
            skillPointHint.Text = "Skill Pt";
            skillPointHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            skillPointHint.Visible = false;
            // 
            // skillPointNeededLabel
            // 
            skillPointNeededLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            skillPointNeededLabel.BackColor = System.Drawing.Color.Transparent;
            skillPointNeededLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            skillPointNeededLabel.Location = new System.Drawing.Point(544, 18);
            skillPointNeededLabel.Name = "skillPointNeededLabel";
            skillPointNeededLabel.Size = new System.Drawing.Size(39, 21);
            skillPointNeededLabel.TabIndex = 3;
            skillPointNeededLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // evolutionButton
            // 
            evolutionButton.Location = new System.Drawing.Point(18, 120);
            evolutionButton.Name = "evolutionButton";
            evolutionButton.Size = new System.Drawing.Size(96, 23);
            evolutionButton.TabIndex = 4;
            evolutionButton.Text = "Evolution";
            evolutionButton.UseVisualStyleBackColor = true;
            evolutionButton.Visible = false;
            // 
            // SkillInfoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(601, 177);
            Controls.Add(evolutionButton);
            Controls.Add(closeButton);
            Controls.Add(skillDescriptionLabel);
            Controls.Add(skillPointNeededLabel);
            Controls.Add(skillPointHint);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SkillInfoForm";
            Padding = new System.Windows.Forms.Padding(15);
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            MouseDown += SkillInfoForm_MouseDown;
            MouseMove += SkillInfoForm_MouseMove;
            MouseUp += SkillInfoForm_MouseUp;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label skillNameLabel;
        private System.Windows.Forms.Label skillDescriptionLabel;
        private System.Windows.Forms.Button closeButton;
        private Common.HighQualityPictureBox iconPictureBox;
        private System.Windows.Forms.Label skillPointHint;
        private System.Windows.Forms.Label skillPointNeededLabel;
        private System.Windows.Forms.Button evolutionButton;
    }
}