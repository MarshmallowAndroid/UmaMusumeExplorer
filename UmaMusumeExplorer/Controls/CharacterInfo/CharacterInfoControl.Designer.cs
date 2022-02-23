
namespace PlayerGui.Controls.CharacterInfo
{
    partial class CharacterInfoControl
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
            this.characterSelectComboBox = new System.Windows.Forms.ComboBox();
            this.characterSelectLabel = new System.Windows.Forms.Label();
            this.informationGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.characterVoiceNameLabel = new System.Windows.Forms.Label();
            this.characterNameLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.informationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // characterSelectComboBox
            // 
            this.characterSelectComboBox.FormattingEnabled = true;
            this.characterSelectComboBox.Location = new System.Drawing.Point(67, 3);
            this.characterSelectComboBox.Name = "characterSelectComboBox";
            this.characterSelectComboBox.Size = new System.Drawing.Size(194, 23);
            this.characterSelectComboBox.TabIndex = 0;
            this.characterSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.CharacterSelectComboBox_SelectedIndexChanged);
            // 
            // characterSelectLabel
            // 
            this.characterSelectLabel.AutoSize = true;
            this.characterSelectLabel.Location = new System.Drawing.Point(3, 6);
            this.characterSelectLabel.Name = "characterSelectLabel";
            this.characterSelectLabel.Size = new System.Drawing.Size(58, 15);
            this.characterSelectLabel.TabIndex = 1;
            this.characterSelectLabel.Text = "Character";
            // 
            // informationGroupBox
            // 
            this.informationGroupBox.Controls.Add(this.pictureBox1);
            this.informationGroupBox.Controls.Add(this.characterVoiceNameLabel);
            this.informationGroupBox.Controls.Add(this.characterNameLabel);
            this.informationGroupBox.Location = new System.Drawing.Point(3, 32);
            this.informationGroupBox.Name = "informationGroupBox";
            this.informationGroupBox.Size = new System.Drawing.Size(655, 319);
            this.informationGroupBox.TabIndex = 2;
            this.informationGroupBox.TabStop = false;
            this.informationGroupBox.Text = "Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // characterVoiceNameLabel
            // 
            this.characterVoiceNameLabel.AutoSize = true;
            this.characterVoiceNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.characterVoiceNameLabel.Location = new System.Drawing.Point(125, 59);
            this.characterVoiceNameLabel.Name = "characterVoiceNameLabel";
            this.characterVoiceNameLabel.Size = new System.Drawing.Size(100, 25);
            this.characterVoiceNameLabel.TabIndex = 0;
            this.characterVoiceNameLabel.Text = "CV.？？？";
            // 
            // characterNameLabel
            // 
            this.characterNameLabel.AutoSize = true;
            this.characterNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.characterNameLabel.Location = new System.Drawing.Point(125, 22);
            this.characterNameLabel.Name = "characterNameLabel";
            this.characterNameLabel.Size = new System.Drawing.Size(104, 37);
            this.characterNameLabel.TabIndex = 0;
            this.characterNameLabel.Text = "？？？";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(267, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // CharacterInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.informationGroupBox);
            this.Controls.Add(this.characterSelectLabel);
            this.Controls.Add(this.characterSelectComboBox);
            this.Name = "CharacterInfoControl";
            this.Size = new System.Drawing.Size(829, 552);
            this.Load += new System.EventHandler(this.CharacterInfoControl_Load);
            this.informationGroupBox.ResumeLayout(false);
            this.informationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox characterSelectComboBox;
        private System.Windows.Forms.Label characterSelectLabel;
        private System.Windows.Forms.GroupBox informationGroupBox;
        private System.Windows.Forms.Label characterNameLabel;
        private System.Windows.Forms.Label characterVoiceNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
