namespace UmaMusumeExplorer.Controls
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
            iconPictureBox = new UmaMusumeExplorer.Controls.HighQualityPictureBox();
            skillNameLabel = new Label();
            skillDescriptionLabel = new Label();
            closeButton = new Button();
            skillPointHint = new Label();
            skillPointNeededLabel = new Label();
            evolutionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = Color.Transparent;
            iconPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            iconPictureBox.Location = new Point(18, 18);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(96, 96);
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            // 
            // skillNameLabel
            // 
            skillNameLabel.BackColor = Color.Transparent;
            skillNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            skillNameLabel.Location = new Point(120, 18);
            skillNameLabel.Name = "skillNameLabel";
            skillNameLabel.Size = new Size(384, 21);
            skillNameLabel.TabIndex = 0;
            skillNameLabel.Text = "Skill name";
            skillNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // skillDescriptionLabel
            // 
            skillDescriptionLabel.BackColor = Color.Transparent;
            skillDescriptionLabel.Font = new Font("Segoe UI", 12F);
            skillDescriptionLabel.Location = new Point(120, 39);
            skillDescriptionLabel.Name = "skillDescriptionLabel";
            skillDescriptionLabel.Size = new Size(384, 104);
            skillDescriptionLabel.TabIndex = 1;
            skillDescriptionLabel.Text = "Skill description";
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom;
            closeButton.Location = new Point(263, 186);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // skillPointHint
            // 
            skillPointHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            skillPointHint.AutoSize = true;
            skillPointHint.BackColor = Color.White;
            skillPointHint.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            skillPointHint.Location = new Point(475, 18);
            skillPointHint.Name = "skillPointHint";
            skillPointHint.Size = new Size(63, 21);
            skillPointHint.TabIndex = 2;
            skillPointHint.Text = "Skill Pt";
            skillPointHint.TextAlign = ContentAlignment.MiddleLeft;
            skillPointHint.Visible = false;
            // 
            // skillPointNeededLabel
            // 
            skillPointNeededLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            skillPointNeededLabel.BackColor = Color.Transparent;
            skillPointNeededLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            skillPointNeededLabel.Location = new Point(544, 18);
            skillPointNeededLabel.Name = "skillPointNeededLabel";
            skillPointNeededLabel.Size = new Size(39, 21);
            skillPointNeededLabel.TabIndex = 3;
            skillPointNeededLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // evolutionButton
            // 
            evolutionButton.Location = new Point(18, 120);
            evolutionButton.Name = "evolutionButton";
            evolutionButton.Size = new Size(96, 23);
            evolutionButton.TabIndex = 4;
            evolutionButton.Text = "Evolution";
            evolutionButton.UseVisualStyleBackColor = true;
            evolutionButton.Visible = false;
            // 
            // SkillInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 221);
            Controls.Add(evolutionButton);
            Controls.Add(closeButton);
            Controls.Add(skillDescriptionLabel);
            Controls.Add(skillPointNeededLabel);
            Controls.Add(skillPointHint);
            Controls.Add(skillNameLabel);
            Controls.Add(iconPictureBox);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SkillInfoForm";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.Manual;
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
        private HighQualityPictureBox iconPictureBox;
        private System.Windows.Forms.Label skillPointHint;
        private System.Windows.Forms.Label skillPointNeededLabel;
        private System.Windows.Forms.Button evolutionButton;
    }
}