namespace UmaMusumeExplorer.Controls
{
    partial class MultipleExportDialog
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
            progressBar = new System.Windows.Forms.ProgressBar();
            currentFileLabel = new System.Windows.Forms.Label();
            cancelButton = new System.Windows.Forms.Button();
            progressLabel = new System.Windows.Forms.Label();
            exportBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(12, 27);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(482, 23);
            progressBar.TabIndex = 1;
            // 
            // currentFileLabel
            // 
            currentFileLabel.AutoSize = true;
            currentFileLabel.Location = new System.Drawing.Point(12, 9);
            currentFileLabel.Name = "currentFileLabel";
            currentFileLabel.Size = new System.Drawing.Size(77, 15);
            currentFileLabel.TabIndex = 2;
            currentFileLabel.Text = "Exporting file";
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(419, 56);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new System.Drawing.Point(12, 60);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new System.Drawing.Size(36, 15);
            progressLabel.TabIndex = 2;
            progressLabel.Text = "0 of 0";
            // 
            // exportBackgroundWorker
            // 
            exportBackgroundWorker.WorkerReportsProgress = true;
            exportBackgroundWorker.WorkerSupportsCancellation = true;
            exportBackgroundWorker.DoWork += ExportBackgroundWorker_DoWork;
            exportBackgroundWorker.ProgressChanged += ExportBackgroundWorker_ProgressChanged;
            exportBackgroundWorker.RunWorkerCompleted += ExportBackgroundWorker_RunWorkerCompleted;
            // 
            // MultipleExportDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(506, 91);
            Controls.Add(cancelButton);
            Controls.Add(progressLabel);
            Controls.Add(currentFileLabel);
            Controls.Add(progressBar);
            Name = "MultipleExportDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Exporting...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label progressLabel;
        private System.ComponentModel.BackgroundWorker exportBackgroundWorker;
    }
}