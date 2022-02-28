namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class StatusDisplayLabel
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusMaxValueLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.statusRankLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.statusMaxValueLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.statusValueLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.statusRankLabel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(104, 56);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // statusMaxValueLabel
            // 
            this.statusMaxValueLabel.AutoSize = true;
            this.statusMaxValueLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusMaxValueLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusMaxValueLabel.Location = new System.Drawing.Point(52, 28);
            this.statusMaxValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusMaxValueLabel.Name = "statusMaxValueLabel";
            this.statusMaxValueLabel.Size = new System.Drawing.Size(52, 17);
            this.statusMaxValueLabel.TabIndex = 1;
            this.statusMaxValueLabel.Text = "/1200";
            // 
            // statusValueLabel
            // 
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusValueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusValueLabel.Location = new System.Drawing.Point(52, 7);
            this.statusValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(52, 21);
            this.statusValueLabel.TabIndex = 1;
            this.statusValueLabel.Text = "1000";
            // 
            // statusRankLabel
            // 
            this.statusRankLabel.AutoSize = true;
            this.statusRankLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusRankLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusRankLabel.Location = new System.Drawing.Point(0, 0);
            this.statusRankLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusRankLabel.Name = "statusRankLabel";
            this.tableLayoutPanel.SetRowSpan(this.statusRankLabel, 2);
            this.statusRankLabel.Size = new System.Drawing.Size(52, 56);
            this.statusRankLabel.TabIndex = 1;
            this.statusRankLabel.Text = "SS+";
            this.statusRankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusDisplayLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "StatusDisplayLabel";
            this.Size = new System.Drawing.Size(104, 56);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.Label statusRankLabel;
        private System.Windows.Forms.Label statusMaxValueLabel;
    }
}
