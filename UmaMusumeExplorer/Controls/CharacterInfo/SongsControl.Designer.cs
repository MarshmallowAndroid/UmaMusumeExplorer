namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SongsControl
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
            songItemsPanel = new Common.SongItemsPanel();
            SuspendLayout();
            // 
            // songItemsPanel
            // 
            songItemsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            songItemsPanel.Items = null;
            songItemsPanel.Location = new System.Drawing.Point(3, 3);
            songItemsPanel.Name = "songItemsPanel";
            songItemsPanel.Size = new System.Drawing.Size(444, 545);
            songItemsPanel.TabIndex = 0;
            // 
            // SongsControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(songItemsPanel);
            Name = "SongsControl";
            Size = new System.Drawing.Size(450, 551);
            Load += SongsControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Common.SongItemsPanel songItemsPanel;
    }
}
