namespace UmaMusumeExplorer.Controls.Jukebox
{
    partial class JukeboxControl
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
            lengthSelectLabel = new System.Windows.Forms.Label();
            shortVersionRadioButton = new System.Windows.Forms.RadioButton();
            gameSizeVersionRadioButton = new System.Windows.Forms.RadioButton();
            jukeboxItemsPanel = new JukeboxItemsPanel();
            SuspendLayout();
            // 
            // lengthSelectLabel
            // 
            lengthSelectLabel.AutoSize = true;
            lengthSelectLabel.Location = new System.Drawing.Point(3, 5);
            lengthSelectLabel.Name = "lengthSelectLabel";
            lengthSelectLabel.Size = new System.Drawing.Size(78, 15);
            lengthSelectLabel.TabIndex = 0;
            lengthSelectLabel.Text = "Length Select";
            // 
            // shortVersionRadioButton
            // 
            shortVersionRadioButton.AutoSize = true;
            shortVersionRadioButton.Location = new System.Drawing.Point(87, 3);
            shortVersionRadioButton.Name = "shortVersionRadioButton";
            shortVersionRadioButton.Size = new System.Drawing.Size(94, 19);
            shortVersionRadioButton.TabIndex = 1;
            shortVersionRadioButton.TabStop = true;
            shortVersionRadioButton.Text = "Short Version";
            shortVersionRadioButton.UseVisualStyleBackColor = true;
            shortVersionRadioButton.CheckedChanged += RadioBuiton_CheckedChanegd;
            // 
            // gameSizeVersionRadioButton
            // 
            gameSizeVersionRadioButton.AutoSize = true;
            gameSizeVersionRadioButton.Location = new System.Drawing.Point(187, 3);
            gameSizeVersionRadioButton.Name = "gameSizeVersionRadioButton";
            gameSizeVersionRadioButton.Size = new System.Drawing.Size(120, 19);
            gameSizeVersionRadioButton.TabIndex = 2;
            gameSizeVersionRadioButton.TabStop = true;
            gameSizeVersionRadioButton.Text = "Game Size Version";
            gameSizeVersionRadioButton.UseVisualStyleBackColor = true;
            gameSizeVersionRadioButton.CheckedChanged += RadioBuiton_CheckedChanegd;
            // 
            // jukeboxItemsPanel
            // 
            jukeboxItemsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            jukeboxItemsPanel.CurrentSongLength = SongLength.ShortVersion;
            jukeboxItemsPanel.Items = null;
            jukeboxItemsPanel.Location = new System.Drawing.Point(3, 28);
            jukeboxItemsPanel.Name = "jukeboxItemsPanel";
            jukeboxItemsPanel.Size = new System.Drawing.Size(815, 497);
            jukeboxItemsPanel.TabIndex = 3;
            // 
            // JukeboxControl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            Controls.Add(jukeboxItemsPanel);
            Controls.Add(gameSizeVersionRadioButton);
            Controls.Add(shortVersionRadioButton);
            Controls.Add(lengthSelectLabel);
            Name = "JukeboxControl";
            Size = new System.Drawing.Size(821, 528);
            Load += LiveMusicPlayerSongSelectControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lengthSelectLabel;
        private System.Windows.Forms.RadioButton shortVersionRadioButton;
        private System.Windows.Forms.RadioButton gameSizeVersionRadioButton;
        private JukeboxItemsPanel jukeboxItemsPanel;
    }
}
