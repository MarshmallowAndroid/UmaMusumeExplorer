namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterPositionControl
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
            this.positionIndexLabel = new System.Windows.Forms.Label();
            this.characterPictureBox = new Common.HighQualityPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // positionIndexLabel
            // 
            this.positionIndexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionIndexLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.positionIndexLabel.Location = new System.Drawing.Point(3, 3);
            this.positionIndexLabel.Margin = new System.Windows.Forms.Padding(3);
            this.positionIndexLabel.Name = "positionIndexLabel";
            this.positionIndexLabel.Size = new System.Drawing.Size(120, 47);
            this.positionIndexLabel.TabIndex = 0;
            this.positionIndexLabel.Text = "0";
            this.positionIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // characterPictureBox
            // 
            this.characterPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.characterPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.characterPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.characterPictureBox.Location = new System.Drawing.Point(3, 89);
            this.characterPictureBox.Name = "characterPictureBox";
            this.characterPictureBox.Size = new System.Drawing.Size(120, 120);
            this.characterPictureBox.TabIndex = 1;
            this.characterPictureBox.TabStop = false;
            // 
            // CharacterPositionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.characterPictureBox);
            this.Controls.Add(this.positionIndexLabel);
            this.Name = "CharacterPositionControl";
            this.Size = new System.Drawing.Size(126, 212);
            ((System.ComponentModel.ISupportInitialize)(this.characterPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label positionIndexLabel;
        private Common.HighQualityPictureBox characterPictureBox;
    }
}
