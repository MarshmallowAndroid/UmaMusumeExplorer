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
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.skillNameLabel = new System.Windows.Forms.Label();
            this.skillInfoLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconPictureBox.Location = new System.Drawing.Point(12, 12);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(96, 96);
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // skillNameLabel
            // 
            this.skillNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.skillNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.skillNameLabel.Location = new System.Drawing.Point(114, 12);
            this.skillNameLabel.Name = "skillNameLabel";
            this.skillNameLabel.Size = new System.Drawing.Size(389, 28);
            this.skillNameLabel.TabIndex = 1;
            this.skillNameLabel.Text = "Skill name";
            this.skillNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skillInfoLabel
            // 
            this.skillInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.skillInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.skillInfoLabel.Location = new System.Drawing.Point(114, 40);
            this.skillInfoLabel.Name = "skillInfoLabel";
            this.skillInfoLabel.Size = new System.Drawing.Size(389, 68);
            this.skillInfoLabel.TabIndex = 1;
            this.skillInfoLabel.Text = "Skill info";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(220, 140);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SkillInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 175);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.skillInfoLabel);
            this.Controls.Add(this.skillNameLabel);
            this.Controls.Add(this.iconPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SkillInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label skillNameLabel;
        private System.Windows.Forms.Label skillInfoLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox iconPictureBox;
    }
}