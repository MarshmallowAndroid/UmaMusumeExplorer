namespace UmaMusumeExplorer.Controls
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
            positionIndexLabel = new Label();
            characterPictureBox = new HighQualityPictureBox();
            exCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).BeginInit();
            SuspendLayout();
            // 
            // positionIndexLabel
            // 
            positionIndexLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            positionIndexLabel.Font = new Font("Segoe UI", 15.75F);
            positionIndexLabel.Location = new Point(3, 3);
            positionIndexLabel.Margin = new Padding(3);
            positionIndexLabel.Name = "positionIndexLabel";
            positionIndexLabel.Size = new Size(109, 30);
            positionIndexLabel.TabIndex = 0;
            positionIndexLabel.Text = "0";
            positionIndexLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // characterPictureBox
            // 
            characterPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            characterPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            characterPictureBox.Cursor = Cursors.Hand;
            characterPictureBox.Location = new Point(3, 39);
            characterPictureBox.Name = "characterPictureBox";
            characterPictureBox.Size = new Size(109, 120);
            characterPictureBox.TabIndex = 1;
            characterPictureBox.TabStop = false;
            // 
            // exCheckBox
            // 
            exCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            exCheckBox.Appearance = Appearance.Button;
            exCheckBox.Location = new Point(3, 165);
            exCheckBox.Name = "exCheckBox";
            exCheckBox.Size = new Size(109, 25);
            exCheckBox.TabIndex = 2;
            exCheckBox.Text = "EX";
            exCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            exCheckBox.UseVisualStyleBackColor = true;
            // 
            // CharacterPositionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exCheckBox);
            Controls.Add(characterPictureBox);
            Controls.Add(positionIndexLabel);
            Name = "CharacterPositionControl";
            Size = new Size(115, 193);
            ((System.ComponentModel.ISupportInitialize)characterPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label positionIndexLabel;
        private HighQualityPictureBox characterPictureBox;
        private CheckBox exCheckBox;
    }
}
