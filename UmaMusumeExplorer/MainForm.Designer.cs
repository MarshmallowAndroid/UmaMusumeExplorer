
namespace UmaMusumeExplorer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl = new TabControl();
            fileBrowserTabPage = new TabPage();
            fileBrowserControl = new Controls.FileBrowser.FileBrowserControl();
            audioPlayerTabPage = new TabPage();
            audioPlayerControl = new Controls.AudioPlayer.AudioPlayerControl();
            liveMusicPlayerTabPage = new TabPage();
            liveMusicPlayerControl = new Controls.LiveMusicPlayer.LiveMusicPlayerControl();
            jukeboxTabPage = new TabPage();
            jukeboxControl = new Controls.Jukebox.JukeboxControl();
            characterInfoTabPage = new TabPage();
            characterInfoControl = new Controls.CharacterInfo.CharacterInfoControl();
            supportCardsTabPage = new TabPage();
            supportCardInfoControl = new Controls.SupportCardInfo.SupportCardInfoControl();
            raceMusicTabPage = new TabPage();
            raceMusicPlayerControl = new Controls.RaceMusicPlayer.RaceMusicPlayerControl();
            tabControl.SuspendLayout();
            fileBrowserTabPage.SuspendLayout();
            audioPlayerTabPage.SuspendLayout();
            liveMusicPlayerTabPage.SuspendLayout();
            jukeboxTabPage.SuspendLayout();
            characterInfoTabPage.SuspendLayout();
            supportCardsTabPage.SuspendLayout();
            raceMusicTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Controls.Add(fileBrowserTabPage);
            tabControl.Controls.Add(audioPlayerTabPage);
            tabControl.Controls.Add(liveMusicPlayerTabPage);
            tabControl.Controls.Add(jukeboxTabPage);
            tabControl.Controls.Add(characterInfoTabPage);
            tabControl.Controls.Add(supportCardsTabPage);
            tabControl.Controls.Add(raceMusicTabPage);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            // 
            // fileBrowserTabPage
            // 
            fileBrowserTabPage.Controls.Add(fileBrowserControl);
            resources.ApplyResources(fileBrowserTabPage, "fileBrowserTabPage");
            fileBrowserTabPage.Name = "fileBrowserTabPage";
            fileBrowserTabPage.UseVisualStyleBackColor = true;
            // 
            // fileBrowserControl
            // 
            resources.ApplyResources(fileBrowserControl, "fileBrowserControl");
            fileBrowserControl.Name = "fileBrowserControl";
            // 
            // audioPlayerTabPage
            // 
            audioPlayerTabPage.Controls.Add(audioPlayerControl);
            resources.ApplyResources(audioPlayerTabPage, "audioPlayerTabPage");
            audioPlayerTabPage.Name = "audioPlayerTabPage";
            audioPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // audioPlayerControl
            // 
            resources.ApplyResources(audioPlayerControl, "audioPlayerControl");
            audioPlayerControl.Name = "audioPlayerControl";
            // 
            // liveMusicPlayerTabPage
            // 
            liveMusicPlayerTabPage.Controls.Add(liveMusicPlayerControl);
            resources.ApplyResources(liveMusicPlayerTabPage, "liveMusicPlayerTabPage");
            liveMusicPlayerTabPage.Name = "liveMusicPlayerTabPage";
            liveMusicPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // liveMusicPlayerControl
            // 
            resources.ApplyResources(liveMusicPlayerControl, "liveMusicPlayerControl");
            liveMusicPlayerControl.Name = "liveMusicPlayerControl";
            // 
            // jukeboxTabPage
            // 
            jukeboxTabPage.Controls.Add(jukeboxControl);
            resources.ApplyResources(jukeboxTabPage, "jukeboxTabPage");
            jukeboxTabPage.Name = "jukeboxTabPage";
            jukeboxTabPage.UseVisualStyleBackColor = true;
            // 
            // jukeboxControl
            // 
            resources.ApplyResources(jukeboxControl, "jukeboxControl");
            jukeboxControl.Name = "jukeboxControl";
            // 
            // characterInfoTabPage
            // 
            characterInfoTabPage.Controls.Add(characterInfoControl);
            resources.ApplyResources(characterInfoTabPage, "characterInfoTabPage");
            characterInfoTabPage.Name = "characterInfoTabPage";
            characterInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // characterInfoControl
            // 
            resources.ApplyResources(characterInfoControl, "characterInfoControl");
            characterInfoControl.Name = "characterInfoControl";
            // 
            // supportCardsTabPage
            // 
            supportCardsTabPage.Controls.Add(supportCardInfoControl);
            resources.ApplyResources(supportCardsTabPage, "supportCardsTabPage");
            supportCardsTabPage.Name = "supportCardsTabPage";
            supportCardsTabPage.UseVisualStyleBackColor = true;
            // 
            // supportCardInfoControl
            // 
            resources.ApplyResources(supportCardInfoControl, "supportCardInfoControl");
            supportCardInfoControl.Name = "supportCardInfoControl";
            // 
            // raceMusicTabPage
            // 
            raceMusicTabPage.Controls.Add(raceMusicPlayerControl);
            resources.ApplyResources(raceMusicTabPage, "raceMusicTabPage");
            raceMusicTabPage.Name = "raceMusicTabPage";
            raceMusicTabPage.UseVisualStyleBackColor = true;
            // 
            // raceMusicPlayerControl
            // 
            resources.ApplyResources(raceMusicPlayerControl, "raceMusicPlayerControl");
            raceMusicPlayerControl.Name = "raceMusicPlayerControl";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabControl);
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            tabControl.ResumeLayout(false);
            fileBrowserTabPage.ResumeLayout(false);
            audioPlayerTabPage.ResumeLayout(false);
            liveMusicPlayerTabPage.ResumeLayout(false);
            jukeboxTabPage.ResumeLayout(false);
            characterInfoTabPage.ResumeLayout(false);
            supportCardsTabPage.ResumeLayout(false);
            raceMusicTabPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl;
        private TabPage raceMusicTabPage;
        private Controls.RaceMusicPlayer.RaceMusicPlayerControl raceMusicPlayerControl;
        private TabPage audioPlayerTabPage;
        private Controls.AudioPlayer.AudioPlayerControl audioPlayerControl;
        private TabPage characterInfoTabPage;
        private Controls.CharacterInfo.CharacterInfoControl characterInfoControl;
        private TabPage fileBrowserTabPage;
        private Controls.FileBrowser.FileBrowserControl fileBrowserControl;
        private TabPage liveMusicPlayerTabPage;
        private Controls.LiveMusicPlayer.LiveMusicPlayerControl liveMusicPlayerControl;
        private TabPage jukeboxTabPage;
        private Controls.Jukebox.JukeboxControl jukeboxControl;
        private TabPage supportCardsTabPage;
        private Controls.SupportCardInfo.SupportCardInfoControl supportCardInfoControl;
    }
}

