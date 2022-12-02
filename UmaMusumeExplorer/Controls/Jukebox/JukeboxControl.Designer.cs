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
            this.loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.jacketPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lengthSelectLabel = new System.Windows.Forms.Label();
            this.shortVersionRadioButton = new System.Windows.Forms.RadioButton();
            this.gameSizeVersionRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // loadingBackgroundWorker
            // 
            this.loadingBackgroundWorker.WorkerReportsProgress = true;
            this.loadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.loadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.loadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingProgressBar.Location = new System.Drawing.Point(194, 253);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(433, 23);
            this.loadingProgressBar.TabIndex = 4;
            // 
            // jacketPanel
            // 
            this.jacketPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jacketPanel.AutoScroll = true;
            this.jacketPanel.Location = new System.Drawing.Point(3, 28);
            this.jacketPanel.Name = "jacketPanel";
            this.jacketPanel.Size = new System.Drawing.Size(815, 497);
            this.jacketPanel.TabIndex = 3;
            // 
            // lengthSelectLabel
            // 
            this.lengthSelectLabel.AutoSize = true;
            this.lengthSelectLabel.Location = new System.Drawing.Point(3, 5);
            this.lengthSelectLabel.Name = "lengthSelectLabel";
            this.lengthSelectLabel.Size = new System.Drawing.Size(78, 15);
            this.lengthSelectLabel.TabIndex = 0;
            this.lengthSelectLabel.Text = "Length Select";
            // 
            // shortVersionRadioButton
            // 
            this.shortVersionRadioButton.AutoSize = true;
            this.shortVersionRadioButton.Location = new System.Drawing.Point(87, 3);
            this.shortVersionRadioButton.Name = "shortVersionRadioButton";
            this.shortVersionRadioButton.Size = new System.Drawing.Size(94, 19);
            this.shortVersionRadioButton.TabIndex = 1;
            this.shortVersionRadioButton.TabStop = true;
            this.shortVersionRadioButton.Text = "Short Version";
            this.shortVersionRadioButton.UseVisualStyleBackColor = true;
            this.shortVersionRadioButton.CheckedChanged += new System.EventHandler(this.RadioBuiton_CheckedChanegd);
            // 
            // gameSizeVersionRadioButton
            // 
            this.gameSizeVersionRadioButton.AutoSize = true;
            this.gameSizeVersionRadioButton.Location = new System.Drawing.Point(187, 3);
            this.gameSizeVersionRadioButton.Name = "gameSizeVersionRadioButton";
            this.gameSizeVersionRadioButton.Size = new System.Drawing.Size(120, 19);
            this.gameSizeVersionRadioButton.TabIndex = 2;
            this.gameSizeVersionRadioButton.TabStop = true;
            this.gameSizeVersionRadioButton.Text = "Game Size Version";
            this.gameSizeVersionRadioButton.UseVisualStyleBackColor = true;
            this.gameSizeVersionRadioButton.CheckedChanged += new System.EventHandler(this.RadioBuiton_CheckedChanegd);
            // 
            // JukeboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameSizeVersionRadioButton);
            this.Controls.Add(this.shortVersionRadioButton);
            this.Controls.Add(this.lengthSelectLabel);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.jacketPanel);
            this.Name = "JukeboxControl";
            this.Size = new System.Drawing.Size(821, 528);
            this.Load += new System.EventHandler(this.LiveMusicPlayerSongSelectControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.FlowLayoutPanel jacketPanel;
        private System.Windows.Forms.Label lengthSelectLabel;
        private System.Windows.Forms.RadioButton shortVersionRadioButton;
        private System.Windows.Forms.RadioButton gameSizeVersionRadioButton;
    }
}
