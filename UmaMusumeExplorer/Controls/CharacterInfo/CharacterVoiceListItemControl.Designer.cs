namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterVoiceListItemControl
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
            playButton = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            checkBox = new System.Windows.Forms.CheckBox();
            voiceLineTextLabel = new ProgressLabel();
            SuspendLayout();
            // 
            // playButton
            // 
            playButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            playButton.Location = new System.Drawing.Point(325, 25);
            playButton.Name = "playButton";
            playButton.Size = new System.Drawing.Size(45, 45);
            playButton.TabIndex = 1;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(24, 3);
            idLabel.Margin = new System.Windows.Forms.Padding(3);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(18, 15);
            idLabel.TabIndex = 2;
            idLabel.Text = "ID";
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new System.Drawing.Point(3, 4);
            checkBox.Name = "checkBox";
            checkBox.Size = new System.Drawing.Size(15, 14);
            checkBox.TabIndex = 3;
            checkBox.UseVisualStyleBackColor = true;
            // 
            // voiceLineTextLabel
            // 
            voiceLineTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            voiceLineTextLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            voiceLineTextLabel.Location = new System.Drawing.Point(3, 24);
            voiceLineTextLabel.Margin = new System.Windows.Forms.Padding(3);
            voiceLineTextLabel.Name = "voiceLineTextLabel";
            voiceLineTextLabel.Progress = 0F;
            voiceLineTextLabel.Size = new System.Drawing.Size(316, 68);
            voiceLineTextLabel.TabIndex = 4;
            voiceLineTextLabel.Text = "Voice line";
            voiceLineTextLabel.Click += VoiceLineTextLabel_DoubleClick;
            // 
            // CharacterVoiceListItemControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(voiceLineTextLabel);
            Controls.Add(checkBox);
            Controls.Add(idLabel);
            Controls.Add(playButton);
            Name = "CharacterVoiceListItemControl";
            Size = new System.Drawing.Size(373, 95);
            Click += ClickHit;
            DoubleClick += ClickHit;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.CheckBox checkBox;
        private ProgressLabel voiceLineTextLabel;
    }
}
