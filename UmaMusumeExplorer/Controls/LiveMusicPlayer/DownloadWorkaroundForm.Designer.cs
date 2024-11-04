namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class DownloadWorkaroundForm
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
            labelTitle = new Label();
            labelStep1 = new Label();
            buttonModifyDatabase = new Button();
            labelStep2 = new Label();
            buttonCacheFiles = new Button();
            labelStep3 = new Label();
            labelStep4 = new Label();
            progressBarCache = new ProgressBar();
            buttonRevert = new Button();
            labelStep5 = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(284, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Workaround for downloading live audio resources";
            // 
            // labelStep1
            // 
            labelStep1.AutoSize = true;
            labelStep1.Location = new Point(12, 24);
            labelStep1.Name = "labelStep1";
            labelStep1.Size = new Size(478, 15);
            labelStep1.TabIndex = 1;
            labelStep1.Text = "1. Click the button below to temporarily allow the game to download live audio resources";
            // 
            // buttonModifyDatabase
            // 
            buttonModifyDatabase.Location = new Point(12, 42);
            buttonModifyDatabase.Name = "buttonModifyDatabase";
            buttonModifyDatabase.Size = new Size(537, 25);
            buttonModifyDatabase.TabIndex = 2;
            buttonModifyDatabase.Text = "Allow live audio to be downloaded";
            buttonModifyDatabase.UseVisualStyleBackColor = true;
            buttonModifyDatabase.Click += ButtonModifyDatabase_Click;
            // 
            // labelStep2
            // 
            labelStep2.AutoSize = true;
            labelStep2.Location = new Point(12, 70);
            labelStep2.Name = "labelStep2";
            labelStep2.Size = new Size(258, 15);
            labelStep2.TabIndex = 3;
            labelStep2.Text = "2. Launch the game and download all resources";
            // 
            // buttonCacheFiles
            // 
            buttonCacheFiles.Location = new Point(12, 103);
            buttonCacheFiles.Name = "buttonCacheFiles";
            buttonCacheFiles.Size = new Size(537, 25);
            buttonCacheFiles.TabIndex = 5;
            buttonCacheFiles.Text = "Cache live audio resources";
            buttonCacheFiles.UseVisualStyleBackColor = true;
            buttonCacheFiles.Click += ButtonCacheFiles_Click;
            // 
            // labelStep3
            // 
            labelStep3.AutoSize = true;
            labelStep3.Location = new Point(12, 85);
            labelStep3.Name = "labelStep3";
            labelStep3.Size = new Size(486, 15);
            labelStep3.TabIndex = 4;
            labelStep3.Text = "3. Close the game, then click the button below to begin caching the downloaded resources\r\n";
            // 
            // labelStep4
            // 
            labelStep4.AutoSize = true;
            labelStep4.Location = new Point(12, 160);
            labelStep4.MaximumSize = new Size(787, 0);
            labelStep4.Name = "labelStep4";
            labelStep4.Size = new Size(492, 15);
            labelStep4.TabIndex = 7;
            labelStep4.Text = "4. After caching is complete, click the button below to revert the changes made to the game";
            // 
            // progressBarCache
            // 
            progressBarCache.Location = new Point(12, 134);
            progressBarCache.Name = "progressBarCache";
            progressBarCache.Size = new Size(536, 23);
            progressBarCache.TabIndex = 6;
            // 
            // buttonRevert
            // 
            buttonRevert.Location = new Point(12, 178);
            buttonRevert.Name = "buttonRevert";
            buttonRevert.Size = new Size(537, 25);
            buttonRevert.TabIndex = 8;
            buttonRevert.Text = "Revert changes";
            buttonRevert.UseVisualStyleBackColor = true;
            buttonRevert.Click += ButtonRevert_Click;
            // 
            // labelStep5
            // 
            labelStep5.AutoSize = true;
            labelStep5.Location = new Point(12, 206);
            labelStep5.MaximumSize = new Size(787, 0);
            labelStep5.Name = "labelStep5";
            labelStep5.Size = new Size(115, 15);
            labelStep5.TabIndex = 9;
            labelStep5.Text = "5. Close this window";
            // 
            // DownloadWorkaroundForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 230);
            Controls.Add(progressBarCache);
            Controls.Add(buttonRevert);
            Controls.Add(buttonCacheFiles);
            Controls.Add(buttonModifyDatabase);
            Controls.Add(labelStep5);
            Controls.Add(labelStep4);
            Controls.Add(labelStep3);
            Controls.Add(labelStep2);
            Controls.Add(labelStep1);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DownloadWorkaroundForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Download Workaround";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelStep1;
        private Button buttonModifyDatabase;
        private Label labelStep2;
        private Button buttonCacheFiles;
        private Label labelStep3;
        private Label labelStep4;
        private ProgressBar progressBarCache;
        private Button buttonRevert;
        private Label labelStep5;
    }
}