
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
            tabControl = new System.Windows.Forms.TabControl();
            fileBrowserTabPage = new System.Windows.Forms.TabPage();
            fileBrowserControl = new Controls.FileBrowser.FileBrowserControl();
            audioPlayerTabPage = new System.Windows.Forms.TabPage();
            audioPlayerControl = new Controls.AudioPlayer.AudioPlayerControl();
            liveMusicPlayerTabPage = new System.Windows.Forms.TabPage();
            liveMusicPlayerSongSelectControl = new Controls.LiveMusicPlayer.LiveMusicPlayerControl();
            jukeboxTabPage = new System.Windows.Forms.TabPage();
            jukeboxControl = new Controls.Jukebox.JukeboxControl();
            characterInfoTabPage = new System.Windows.Forms.TabPage();
            characterInfoControl = new Controls.CharacterInfo.CharacterInfoControl();
            raceMusicTabPage = new System.Windows.Forms.TabPage();
            raceSimulatorControl = new Controls.RaceMusicSimulator.RaceMusicSimulatorControl();
            tabControl.SuspendLayout();
            fileBrowserTabPage.SuspendLayout();
            audioPlayerTabPage.SuspendLayout();
            liveMusicPlayerTabPage.SuspendLayout();
            jukeboxTabPage.SuspendLayout();
            characterInfoTabPage.SuspendLayout();
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
            liveMusicPlayerTabPage.Controls.Add(liveMusicPlayerSongSelectControl);
            resources.ApplyResources(liveMusicPlayerTabPage, "liveMusicPlayerTabPage");
            liveMusicPlayerTabPage.Name = "liveMusicPlayerTabPage";
            liveMusicPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // liveMusicPlayerSongSelectControl
            // 
            resources.ApplyResources(liveMusicPlayerSongSelectControl, "liveMusicPlayerSongSelectControl");
            liveMusicPlayerSongSelectControl.Name = "liveMusicPlayerSongSelectControl";
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
            // raceMusicTabPage
            // 
            raceMusicTabPage.Controls.Add(raceSimulatorControl);
            resources.ApplyResources(raceMusicTabPage, "raceMusicTabPage");
            raceMusicTabPage.Name = "raceMusicTabPage";
            raceMusicTabPage.UseVisualStyleBackColor = true;
            // 
            // raceSimulatorControl
            // 
            resources.ApplyResources(raceSimulatorControl, "raceSimulatorControl");
            raceSimulatorControl.Name = "raceSimulatorControl";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControl);
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            tabControl.ResumeLayout(false);
            fileBrowserTabPage.ResumeLayout(false);
            audioPlayerTabPage.ResumeLayout(false);
            liveMusicPlayerTabPage.ResumeLayout(false);
            jukeboxTabPage.ResumeLayout(false);
            characterInfoTabPage.ResumeLayout(false);
            raceMusicTabPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage raceMusicTabPage;
        private UmaMusumeExplorer.Controls.RaceMusicSimulator.RaceMusicSimulatorControl raceSimulatorControl;
        private System.Windows.Forms.TabPage audioPlayerTabPage;
        private UmaMusumeExplorer.Controls.AudioPlayer.AudioPlayerControl audioPlayerControl;
        private System.Windows.Forms.TabPage characterInfoTabPage;
        private Controls.CharacterInfo.CharacterInfoControl characterInfoControl;
        private System.Windows.Forms.TabPage fileBrowserTabPage;
        private System.Windows.Forms.TabPage liveMusicPlayerTabPage;
        private Controls.LiveMusicPlayer.LiveMusicPlayerControl liveMusicPlayerSongSelectControl;
        private System.Windows.Forms.TabPage jukeboxTabPage;
        private Controls.Jukebox.JukeboxControl jukeboxControl;
        private Controls.FileBrowser.FileBrowserControl fileBrowserControl;
    }
}

