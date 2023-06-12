namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSelectForm));
            characterItemsPanel = new Common.CharacterItemsPanel();
            SuspendLayout();
            // 
            // characterItemsPanel
            // 
            resources.ApplyResources(characterItemsPanel, "characterItemsPanel");
            characterItemsPanel.Items = null;
            characterItemsPanel.Name = "characterItemsPanel";
            // 
            // CharacterSelectForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(characterItemsPanel);
            Name = "CharacterSelectForm";
            Load += CharacterSelectForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Common.CharacterItemsPanel characterItemsPanel;
    }
}