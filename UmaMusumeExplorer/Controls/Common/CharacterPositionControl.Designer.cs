namespace UmaMusumeExplorer.Controls.Common
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
            positionIndexLabel = new System.Windows.Forms.Label();
            characterPictureBox = new Common.HighQualityPictureBox();
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).BeginInit();
            SuspendLayout();
            // 
            // positionIndexLabel
            // 
            positionIndexLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            positionIndexLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            positionIndexLabel.Location = new System.Drawing.Point(3, 3);
            positionIndexLabel.Margin = new System.Windows.Forms.Padding(3);
            positionIndexLabel.Name = "positionIndexLabel";
            positionIndexLabel.Size = new System.Drawing.Size(120, 30);
            positionIndexLabel.TabIndex = 0;
            positionIndexLabel.Text = "0";
            positionIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // characterPictureBox
            // 
            characterPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            characterPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            characterPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            characterPictureBox.Location = new System.Drawing.Point(3, 39);
            characterPictureBox.Name = "characterPictureBox";
            characterPictureBox.Size = new System.Drawing.Size(120, 120);
            characterPictureBox.TabIndex = 1;
            characterPictureBox.TabStop = false;
            // 
            // CharacterPositionControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(characterPictureBox);
            Controls.Add(positionIndexLabel);
            Name = "CharacterPositionControl";
            Size = new System.Drawing.Size(126, 162);
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label positionIndexLabel;
        private Common.HighQualityPictureBox characterPictureBox;
    }
}
