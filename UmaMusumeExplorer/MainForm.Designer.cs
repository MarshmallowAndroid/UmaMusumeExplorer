
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.fileBrowserTabPage = new System.Windows.Forms.TabPage();
            this.fileBrowserControl = new UmaMusumeExplorer.Controls.FileBrowser.FileBrowserControl();
            this.audioPlayerTabPage = new System.Windows.Forms.TabPage();
            this.audioPlayerControl = new UmaMusumeExplorer.Controls.AudioPlayer.AudioPlayerControl();
            this.liveMusicPlayerTabPage = new System.Windows.Forms.TabPage();
            this.liveMusicPlayerSongSelectControl = new UmaMusumeExplorer.Controls.LiveMusicPlayer.LiveMusicPlayerControl();
            this.jukeboxTabPage = new System.Windows.Forms.TabPage();
            this.jukeboxControl = new UmaMusumeExplorer.Controls.Jukebox.JukeboxControl();
            this.characterInfoTabPage = new System.Windows.Forms.TabPage();
            this.characterInfoControl = new UmaMusumeExplorer.Controls.CharacterInfo.CharacterInfoControl();
            this.raceMusicTabPage = new System.Windows.Forms.TabPage();
            this.raceSimulatorControl = new UmaMusumeExplorer.Controls.RaceMusicSimulator.RaceMusicSimulatorControl();
            this.tabControl.SuspendLayout();
            this.fileBrowserTabPage.SuspendLayout();
            this.audioPlayerTabPage.SuspendLayout();
            this.liveMusicPlayerTabPage.SuspendLayout();
            this.jukeboxTabPage.SuspendLayout();
            this.characterInfoTabPage.SuspendLayout();
            this.raceMusicTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.fileBrowserTabPage);
            this.tabControl.Controls.Add(this.audioPlayerTabPage);
            this.tabControl.Controls.Add(this.liveMusicPlayerTabPage);
            this.tabControl.Controls.Add(this.jukeboxTabPage);
            this.tabControl.Controls.Add(this.characterInfoTabPage);
            this.tabControl.Controls.Add(this.raceMusicTabPage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // fileBrowserTabPage
            // 
            this.fileBrowserTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.fileBrowserTabPage.Controls.Add(this.fileBrowserControl);
            resources.ApplyResources(this.fileBrowserTabPage, "fileBrowserTabPage");
            this.fileBrowserTabPage.Name = "fileBrowserTabPage";
            // 
            // fileBrowserControl
            // 
            resources.ApplyResources(this.fileBrowserControl, "fileBrowserControl");
            this.fileBrowserControl.Name = "fileBrowserControl";
            // 
            // audioPlayerTabPage
            // 
            this.audioPlayerTabPage.Controls.Add(this.audioPlayerControl);
            resources.ApplyResources(this.audioPlayerTabPage, "audioPlayerTabPage");
            this.audioPlayerTabPage.Name = "audioPlayerTabPage";
            // 
            // audioPlayerControl
            // 
            resources.ApplyResources(this.audioPlayerControl, "audioPlayerControl");
            this.audioPlayerControl.Name = "audioPlayerControl";
            // 
            // liveMusicPlayerTabPage
            // 
            this.liveMusicPlayerTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.liveMusicPlayerTabPage.Controls.Add(this.liveMusicPlayerSongSelectControl);
            resources.ApplyResources(this.liveMusicPlayerTabPage, "liveMusicPlayerTabPage");
            this.liveMusicPlayerTabPage.Name = "liveMusicPlayerTabPage";
            // 
            // liveMusicPlayerSongSelectControl
            // 
            resources.ApplyResources(this.liveMusicPlayerSongSelectControl, "liveMusicPlayerSongSelectControl");
            this.liveMusicPlayerSongSelectControl.Name = "liveMusicPlayerSongSelectControl";
            // 
            // jukeboxTabPage
            // 
            this.jukeboxTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.jukeboxTabPage.Controls.Add(this.jukeboxControl);
            resources.ApplyResources(this.jukeboxTabPage, "jukeboxTabPage");
            this.jukeboxTabPage.Name = "jukeboxTabPage";
            // 
            // jukeboxControl
            // 
            this.jukeboxControl.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.jukeboxControl, "jukeboxControl");
            this.jukeboxControl.Name = "jukeboxControl";
            // 
            // characterInfoTabPage
            // 
            this.characterInfoTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.characterInfoTabPage.Controls.Add(this.characterInfoControl);
            resources.ApplyResources(this.characterInfoTabPage, "characterInfoTabPage");
            this.characterInfoTabPage.Name = "characterInfoTabPage";
            // 
            // characterInfoControl
            // 
            resources.ApplyResources(this.characterInfoControl, "characterInfoControl");
            this.characterInfoControl.Name = "characterInfoControl";
            // 
            // raceMusicTabPage
            // 
            this.raceMusicTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.raceMusicTabPage.Controls.Add(this.raceSimulatorControl);
            resources.ApplyResources(this.raceMusicTabPage, "raceMusicTabPage");
            this.raceMusicTabPage.Name = "raceMusicTabPage";
            // 
            // raceSimulatorControl
            // 
            this.raceSimulatorControl.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.raceSimulatorControl, "raceSimulatorControl");
            this.raceSimulatorControl.Name = "raceSimulatorControl";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.fileBrowserTabPage.ResumeLayout(false);
            this.audioPlayerTabPage.ResumeLayout(false);
            this.liveMusicPlayerTabPage.ResumeLayout(false);
            this.jukeboxTabPage.ResumeLayout(false);
            this.characterInfoTabPage.ResumeLayout(false);
            this.raceMusicTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Controls.FileBrowser.FileBrowserControl fileBrowserControl;
        private System.Windows.Forms.TabPage jukeboxTabPage;
        private Controls.Jukebox.JukeboxControl jukeboxControl;
    }
}

