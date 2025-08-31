namespace UmamusumeExplorer
{
    partial class SplashForm
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
            titleLabel = new Label();
            loadingLabel = new Label();
            loadingProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.Location = new Point(116, 34);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(352, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Umamusume Explorer";
            // 
            // loadingLabel
            // 
            loadingLabel.Font = new Font("Segoe UI", 15.75F);
            loadingLabel.Location = new Point(12, 79);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(561, 30);
            loadingLabel.TabIndex = 1;
            loadingLabel.Text = "Reading tables...";
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Location = new Point(111, 112);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new Size(363, 23);
            loadingProgressBar.TabIndex = 2;
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 169);
            Controls.Add(loadingProgressBar);
            Controls.Add(loadingLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashForm";
            Load += SplashForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
    }
}