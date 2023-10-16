namespace UmaMusumeExplorer.Controls.SupportCardInfo
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
            supportCardItemsPanel = new SupportCardItemsPanel();
            markLimitedCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // supportCardItemsPanel
            // 
            supportCardItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supportCardItemsPanel.Items = null;
            supportCardItemsPanel.Location = new System.Drawing.Point(3, 28);
            supportCardItemsPanel.Name = "supportCardItemsPanel";
            supportCardItemsPanel.Size = new System.Drawing.Size(732, 306);
            supportCardItemsPanel.TabIndex = 0;
            // 
            // markLimitedCheckBox
            // 
            markLimitedCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            markLimitedCheckBox.AutoSize = true;
            markLimitedCheckBox.Location = new System.Drawing.Point(611, 3);
            markLimitedCheckBox.Name = "markLimitedCheckBox";
            markLimitedCheckBox.Size = new System.Drawing.Size(124, 19);
            markLimitedCheckBox.TabIndex = 1;
            markLimitedCheckBox.Text = "Mark limited cards";
            markLimitedCheckBox.UseVisualStyleBackColor = true;
            markLimitedCheckBox.CheckedChanged += MarkLimitedCheckBox_CheckedChanged;
            // 
            // SupportCardInfoControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(markLimitedCheckBox);
            Controls.Add(supportCardItemsPanel);
            Name = "SupportCardInfoControl";
            Size = new System.Drawing.Size(738, 337);
            Load += SupportCardInfoControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SupportCardItemsPanel supportCardItemsPanel;
        private CheckBox markLimitedCheckBox;
    }
}
