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
            voiceLinesTabPage = new System.Windows.Forms.TabPage();
            voiceLinesControl = new VoiceLinesControl();
            songsTabPage = new System.Windows.Forms.TabPage();
            songsControl = new SongsControl();
            characterInfoTabControl.SuspendLayout();
            characterInfoTabPage.SuspendLayout();
            voiceLinesTabPage.SuspendLayout();
            songsTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // characterInfoTabControl
            // 
            resources.ApplyResources(characterInfoTabControl, "characterInfoTabControl");
            characterInfoTabControl.Controls.Add(characterInfoTabPage);
            characterInfoTabControl.Controls.Add(voiceLinesTabPage);
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
            cardInfoControl.CharaData = null;
            resources.ApplyResources(cardInfoControl, "cardInfoControl");
            cardInfoControl.Name = "cardInfoControl";
            // 
            // voiceLinesTabPage
            // 
            voiceLinesTabPage.Controls.Add(voiceLinesControl);
            resources.ApplyResources(voiceLinesTabPage, "voiceLinesTabPage");
            voiceLinesTabPage.Name = "voiceLinesTabPage";
            voiceLinesTabPage.UseVisualStyleBackColor = true;
            // 
            // voiceLinesControl
            // 
            voiceLinesControl.CharacterId = 0;
            resources.ApplyResources(voiceLinesControl, "voiceLinesControl");
            voiceLinesControl.Name = "voiceLinesControl";
            // 
            // songsTabPage
            // 
            songsTabPage.Controls.Add(songsControl);
            resources.ApplyResources(songsTabPage, "songsTabPage");
            songsTabPage.Name = "songsTabPage";
            songsTabPage.UseVisualStyleBackColor = true;
            // 
            // songsControl
            // 
            songsControl.CharaId = 0;
            resources.ApplyResources(songsControl, "songsControl");
            songsControl.Name = "songsControl";
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
            FormClosing += CharacterInfoForm_FormClosing;
            characterInfoTabControl.ResumeLayout(false);
            characterInfoTabPage.ResumeLayout(false);
            voiceLinesTabPage.ResumeLayout(false);
            songsTabPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl characterInfoTabControl;
        private System.Windows.Forms.TabPage characterInfoTabPage;
        private System.Windows.Forms.TabPage songsTabPage;
        private CardInfoControl cardInfoControl;
        private SongsControl songsControl;
        private System.Windows.Forms.TabPage voiceLinesTabPage;
        private VoiceLinesControl voiceLinesControl;
    }
}