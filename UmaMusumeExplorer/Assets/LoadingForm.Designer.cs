namespace UmaMusumeExplorer.Controls
{
    partial class LoadingForm
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
            loadingProgressBar = new ProgressBar();
            loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Location = new Point(12, 60);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new Size(497, 25);
            loadingProgressBar.TabIndex = 0;
            // 
            // loadingBackgroundWorker
            // 
            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(132, 15);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "Loading AssetBundles...";
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 97);
            Controls.Add(statusLabel);
            Controls.Add(loadingProgressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Loading...";
            Load += LoadingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar loadingProgressBar;
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private Label statusLabel;
    }
}