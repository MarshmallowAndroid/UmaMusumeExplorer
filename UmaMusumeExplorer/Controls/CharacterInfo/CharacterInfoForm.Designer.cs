namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterInfoForm));
            characterInfoTabControl = new System.Windows.Forms.TabControl();
            characterInfoTabPage = new System.Windows.Forms.TabPage();
            cardInfoControl = new CardInfoControl();
            songsTabPage = new System.Windows.Forms.TabPage();
            characterInfoTabControl.SuspendLayout();
            characterInfoTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // characterInfoTabControl
            // 
            resources.ApplyResources(characterInfoTabControl, "characterInfoTabControl");
            characterInfoTabControl.Controls.Add(characterInfoTabPage);
            characterInfoTabControl.Controls.Add(songsTabPage);
            characterInfoTabControl.Name = "characterInfoTabControl";
            characterInfoTabControl.SelectedIndex = 0;
            // 
            // characterInfoTabPage
            // 
            characterInfoTabPage.Controls.Add(cardInfoControl);
            resources.ApplyResources(characterInfoTabPage, "characterInfoTabPage");
            characterInfoTabPage.Name = "characterInfoTabPage";
            characterInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // cardInfoControl
            // 
            resources.ApplyResources(cardInfoControl, "cardInfoControl");
            cardInfoControl.CharaData = null;
            cardInfoControl.Name = "cardInfoControl";
            // 
            // songsTabPage
            // 
            resources.ApplyResources(songsTabPage, "songsTabPage");
            songsTabPage.Name = "songsTabPage";
            songsTabPage.UseVisualStyleBackColor = true;
            // 
            // CharacterInfoForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            Controls.Add(characterInfoTabControl);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CharacterInfoForm";
            characterInfoTabControl.ResumeLayout(false);
            characterInfoTabPage.ResumeLayout(false);
            characterInfoTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl characterInfoTabControl;
        private System.Windows.Forms.TabPage characterInfoTabPage;
        private System.Windows.Forms.TabPage songsTabPage;
        private CardInfoControl cardInfoControl;
    }
}