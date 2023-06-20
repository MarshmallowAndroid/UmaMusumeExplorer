namespace UmaMusumeExplorer
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
            titleLabel = new System.Windows.Forms.Label();
            loadingLabel = new System.Windows.Forms.Label();
            loadingProgressBar = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            titleLabel.Location = new System.Drawing.Point(111, 34);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(363, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Uma Musume Explorer";
            // 
            // loadingLabel
            // 
            loadingLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loadingLabel.Location = new System.Drawing.Point(12, 79);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new System.Drawing.Size(561, 30);
            loadingLabel.TabIndex = 1;
            loadingLabel.Text = "Reading tables...";
            loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Location = new System.Drawing.Point(111, 112);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new System.Drawing.Size(363, 23);
            loadingProgressBar.TabIndex = 2;
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(585, 169);
            Controls.Add(loadingProgressBar);
            Controls.Add(loadingLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SplashForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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