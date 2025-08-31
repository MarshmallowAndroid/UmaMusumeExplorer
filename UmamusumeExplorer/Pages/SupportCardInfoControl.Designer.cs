namespace UmamusumeExplorer.Pages
{
    partial class SupportCardInfoControl
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
            supportCardItemsPanel = new Controls.SupportCardItemsPanel();
            markLimitedCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // supportCardItemsPanel
            // 
            supportCardItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supportCardItemsPanel.Indeterminate = false;
            supportCardItemsPanel.Items = null;
            supportCardItemsPanel.Location = new Point(3, 28);
            supportCardItemsPanel.Name = "supportCardItemsPanel";
            supportCardItemsPanel.Size = new Size(732, 306);
            supportCardItemsPanel.TabIndex = 0;
            // 
            // markLimitedCheckBox
            // 
            markLimitedCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            markLimitedCheckBox.AutoSize = true;
            markLimitedCheckBox.Location = new Point(612, 3);
            markLimitedCheckBox.Name = "markLimitedCheckBox";
            markLimitedCheckBox.Size = new Size(123, 19);
            markLimitedCheckBox.TabIndex = 1;
            markLimitedCheckBox.Text = "Mark special cards";
            markLimitedCheckBox.UseVisualStyleBackColor = true;
            markLimitedCheckBox.CheckedChanged += MarkLimitedCheckBox_CheckedChanged;
            // 
            // SupportCardInfoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(markLimitedCheckBox);
            Controls.Add(supportCardItemsPanel);
            Name = "SupportCardInfoControl";
            Size = new Size(738, 337);
            Load += SupportCardInfoControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.SupportCardItemsPanel supportCardItemsPanel;
        private CheckBox markLimitedCheckBox;
    }
}
