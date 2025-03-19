namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SupportCardsControl
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
            supportCardItemsPanel = new UmaMusumeExplorer.Controls.SupportCardInfo.SupportCardItemsPanel();
            SuspendLayout();
            // 
            // supportCardItemsPanel
            // 
            supportCardItemsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supportCardItemsPanel.Indeterminate = false;
            supportCardItemsPanel.Items = null;
            supportCardItemsPanel.Location = new Point(3, 3);
            supportCardItemsPanel.Name = "supportCardItemsPanel";
            supportCardItemsPanel.Size = new Size(432, 605);
            supportCardItemsPanel.TabIndex = 0;
            // 
            // SupportCardsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(supportCardItemsPanel);
            Name = "SupportCardsControl";
            Size = new Size(438, 611);
            Load += SupportCardsControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private SupportCardInfo.SupportCardItemsPanel supportCardItemsPanel;
    }
}
