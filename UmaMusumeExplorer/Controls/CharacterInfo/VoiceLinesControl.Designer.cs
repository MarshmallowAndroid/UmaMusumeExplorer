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
            cardPictureBox = new UmaMusumeExplorer.Controls.Common.HighQualityPictureBox();
            costumeHintLabel = new Label();
            costumeComboBox = new ComboBox();
            categoryHintLabel = new Label();
            categoryComboBox = new ComboBox();
            exportAllButton = new Button();
            exportSelectedButton = new Button();
            loadingProgressBar = new ProgressBar();
            voiceLineListPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cardPictureBox
            // 
            cardPictureBox.Location = new Point(3, 3);
            cardPictureBox.Name = "cardPictureBox";
            cardPictureBox.Size = new Size(73, 81);
            cardPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cardPictureBox.TabIndex = 1;
            cardPictureBox.TabStop = false;
            // 
            // costumeHintLabel
            // 
            costumeHintLabel.AutoSize = true;
            costumeHintLabel.Location = new Point(82, 6);
            costumeHintLabel.Name = "costumeHintLabel";
            costumeHintLabel.Size = new Size(55, 15);
            costumeHintLabel.TabIndex = 2;
            costumeHintLabel.Text = "Costume";
            // 
            // costumeComboBox
            // 
            costumeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            costumeComboBox.FormattingEnabled = true;
            costumeComboBox.Items.AddRange(new object[] { "All" });
            costumeComboBox.Location = new Point(143, 3);
            costumeComboBox.Name = "costumeComboBox";
            costumeComboBox.Size = new Size(189, 23);
            costumeComboBox.TabIndex = 3;
            costumeComboBox.SelectedIndexChanged += CostumeComboBox_SelectedIndexChanged;
            // 
            // categoryHintLabel
            // 
            categoryHintLabel.AutoSize = true;
            categoryHintLabel.Location = new Point(82, 35);
            categoryHintLabel.Name = "categoryHintLabel";
            categoryHintLabel.Size = new Size(55, 15);
            categoryHintLabel.TabIndex = 2;
            categoryHintLabel.Text = "Category";
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Items.AddRange(new object[] { "All", "Home", "Training", "Race", "Miscellaneous" });
            categoryComboBox.Location = new Point(143, 32);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(189, 23);
            categoryComboBox.TabIndex = 3;
            categoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            // 
            // exportAllButton
            // 
            exportAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportAllButton.Location = new Point(473, 57);
            exportAllButton.Name = "exportAllButton";
            exportAllButton.Size = new Size(114, 27);
            exportAllButton.TabIndex = 4;
            exportAllButton.Text = "Export all";
            exportAllButton.UseVisualStyleBackColor = true;
            exportAllButton.Click += ExportAllButton_Click;
            // 
            // exportSelectedButton
            // 
            exportSelectedButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportSelectedButton.Location = new Point(473, 24);
            exportSelectedButton.Name = "exportSelectedButton";
            exportSelectedButton.Size = new Size(114, 27);
            exportSelectedButton.TabIndex = 4;
            exportSelectedButton.Text = "Export selected";
            exportSelectedButton.UseVisualStyleBackColor = true;
            exportSelectedButton.Click += ExportSelectedButton_Click;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            loadingProgressBar.Location = new Point(82, 61);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new Size(385, 23);
            loadingProgressBar.TabIndex = 5;
            loadingProgressBar.Visible = false;
            // 
            // voiceLineListPanel
            // 
            voiceLineListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            voiceLineListPanel.AutoScroll = true;
            voiceLineListPanel.Location = new Point(3, 90);
            voiceLineListPanel.Name = "voiceLineListPanel";
            voiceLineListPanel.Size = new Size(584, 688);
            voiceLineListPanel.TabIndex = 0;
            // 
            // VoiceLinesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Size = new Size(590, 781);
            Load += VoiceLinesControl_Load;
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Common.HighQualityPictureBox cardPictureBox;
        private System.Windows.Forms.Label costumeHintLabel;
        private System.Windows.Forms.ComboBox costumeComboBox;
        private System.Windows.Forms.Label categoryHintLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button exportAllButton;
        private System.Windows.Forms.Button exportSelectedButton;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.FlowLayoutPanel voiceLineListPanel;
    }
}
