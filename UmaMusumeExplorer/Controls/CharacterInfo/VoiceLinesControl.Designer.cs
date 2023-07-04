namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class VoiceLinesControl
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
            voiceLineListPanel = new System.Windows.Forms.FlowLayoutPanel();
            cardPictureBox = new Common.HighQualityPictureBox();
            costumeHintLabel = new System.Windows.Forms.Label();
            costumeComboBox = new System.Windows.Forms.ComboBox();
            categoryHintLabel = new System.Windows.Forms.Label();
            categoryComboBox = new System.Windows.Forms.ComboBox();
            exportAllButton = new System.Windows.Forms.Button();
            exportSelectedButton = new System.Windows.Forms.Button();
            loadingProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).BeginInit();
            SuspendLayout();
            // 
            // voiceLineListPanel
            // 
            voiceLineListPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            voiceLineListPanel.AutoScroll = true;
            voiceLineListPanel.Location = new System.Drawing.Point(3, 90);
            voiceLineListPanel.Name = "voiceLineListPanel";
            voiceLineListPanel.Size = new System.Drawing.Size(584, 688);
            voiceLineListPanel.TabIndex = 0;
            // 
            // cardPictureBox
            // 
            cardPictureBox.Location = new System.Drawing.Point(3, 3);
            cardPictureBox.Name = "cardPictureBox";
            cardPictureBox.Size = new System.Drawing.Size(81, 81);
            cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            cardPictureBox.TabIndex = 1;
            cardPictureBox.TabStop = false;
            // 
            // costumeHintLabel
            // 
            costumeHintLabel.AutoSize = true;
            costumeHintLabel.Location = new System.Drawing.Point(90, 6);
            costumeHintLabel.Name = "costumeHintLabel";
            costumeHintLabel.Size = new System.Drawing.Size(55, 15);
            costumeHintLabel.TabIndex = 2;
            costumeHintLabel.Text = "Costume";
            // 
            // costumeComboBox
            // 
            costumeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            costumeComboBox.FormattingEnabled = true;
            costumeComboBox.Items.AddRange(new object[] { "All" });
            costumeComboBox.Location = new System.Drawing.Point(151, 3);
            costumeComboBox.Name = "costumeComboBox";
            costumeComboBox.Size = new System.Drawing.Size(189, 23);
            costumeComboBox.TabIndex = 3;
            costumeComboBox.SelectedIndexChanged += CostumeComboBox_SelectedIndexChanged;
            // 
            // categoryHintLabel
            // 
            categoryHintLabel.AutoSize = true;
            categoryHintLabel.Location = new System.Drawing.Point(90, 35);
            categoryHintLabel.Name = "categoryHintLabel";
            categoryHintLabel.Size = new System.Drawing.Size(55, 15);
            categoryHintLabel.TabIndex = 2;
            categoryHintLabel.Text = "Category";
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Items.AddRange(new object[] { "All", "Home", "Training", "Race", "Miscellaneous" });
            categoryComboBox.Location = new System.Drawing.Point(151, 32);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new System.Drawing.Size(189, 23);
            categoryComboBox.TabIndex = 3;
            categoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            // 
            // exportAllButton
            // 
            exportAllButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            exportAllButton.Location = new System.Drawing.Point(473, 57);
            exportAllButton.Name = "exportAllButton";
            exportAllButton.Size = new System.Drawing.Size(114, 27);
            exportAllButton.TabIndex = 4;
            exportAllButton.Text = "Export all";
            exportAllButton.UseVisualStyleBackColor = true;
            exportAllButton.Click += ExportAllButton_Click;
            // 
            // exportSelectedButton
            // 
            exportSelectedButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            exportSelectedButton.Location = new System.Drawing.Point(473, 24);
            exportSelectedButton.Name = "exportSelectedButton";
            exportSelectedButton.Size = new System.Drawing.Size(114, 27);
            exportSelectedButton.TabIndex = 4;
            exportSelectedButton.Text = "Export selected";
            exportSelectedButton.UseVisualStyleBackColor = true;
            exportSelectedButton.Click += ExportSelectedButton_Click;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingProgressBar.Location = new System.Drawing.Point(90, 61);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new System.Drawing.Size(377, 23);
            loadingProgressBar.TabIndex = 5;
            loadingProgressBar.Visible = false;
            // 
            // VoiceLinesControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(loadingProgressBar);
            Controls.Add(exportSelectedButton);
            Controls.Add(exportAllButton);
            Controls.Add(categoryComboBox);
            Controls.Add(categoryHintLabel);
            Controls.Add(costumeComboBox);
            Controls.Add(costumeHintLabel);
            Controls.Add(cardPictureBox);
            Controls.Add(voiceLineListPanel);
            Name = "VoiceLinesControl";
            Size = new System.Drawing.Size(590, 781);
            Load += VoiceLinesControl_Load;
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel voiceLineListPanel;
        private Common.HighQualityPictureBox cardPictureBox;
        private System.Windows.Forms.Label costumeHintLabel;
        private System.Windows.Forms.ComboBox costumeComboBox;
        private System.Windows.Forms.Label categoryHintLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button exportAllButton;
        private System.Windows.Forms.Button exportSelectedButton;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
    }
}
