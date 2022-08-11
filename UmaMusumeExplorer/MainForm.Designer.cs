
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
            this.audioPlayerControl1 = new UmaMusumeExplorer.Controls.AudioPlayer.AudioPlayerControl();
            this.characterInfoTabPage = new System.Windows.Forms.TabPage();
            this.characterInfoControl = new UmaMusumeExplorer.Controls.CharacterInfo.CharacterInfoControl();
            this.raceMusicTabPage = new System.Windows.Forms.TabPage();
            this.raceSimulatorControl1 = new UmaMusumeExplorer.Controls.RaceMusicSimulator.RaceMusicSimulatorControl();
            this.jukeboxTabPage = new System.Windows.Forms.TabPage();
            this.jukebox = new UmaMusumeExplorer.Controls.LiveMusicPlayer.JukeboxControl();
            this.tabControl.SuspendLayout();
            this.fileBrowserTabPage.SuspendLayout();
            this.audioPlayerTabPage.SuspendLayout();
            this.characterInfoTabPage.SuspendLayout();
            this.raceMusicTabPage.SuspendLayout();
            this.jukeboxTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.fileBrowserTabPage);
            this.tabControl.Controls.Add(this.jukeboxTabPage);
            this.tabControl.Controls.Add(this.audioPlayerTabPage);
            this.tabControl.Controls.Add(this.characterInfoTabPage);
            this.tabControl.Controls.Add(this.raceMusicTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(996, 668);
            this.tabControl.TabIndex = 5;
            // 
            // fileBrowserTabPage
            // 
            this.fileBrowserTabPage.Controls.Add(this.fileBrowserControl);
            this.fileBrowserTabPage.Location = new System.Drawing.Point(4, 24);
            this.fileBrowserTabPage.Name = "fileBrowserTabPage";
            this.fileBrowserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileBrowserTabPage.Size = new System.Drawing.Size(988, 640);
            this.fileBrowserTabPage.TabIndex = 4;
            this.fileBrowserTabPage.Text = "File Browser";
            this.fileBrowserTabPage.UseVisualStyleBackColor = true;
            // 
            // fileBrowserControl
            // 
            this.fileBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowserControl.Location = new System.Drawing.Point(3, 3);
            this.fileBrowserControl.Name = "fileBrowserControl";
            this.fileBrowserControl.Size = new System.Drawing.Size(982, 634);
            this.fileBrowserControl.TabIndex = 0;
            // 
            // audioPlayerTabPage
            // 
            this.audioPlayerTabPage.Controls.Add(this.audioPlayerControl1);
            this.audioPlayerTabPage.Location = new System.Drawing.Point(4, 24);
            this.audioPlayerTabPage.Name = "audioPlayerTabPage";
            this.audioPlayerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.audioPlayerTabPage.Size = new System.Drawing.Size(988, 640);
            this.audioPlayerTabPage.TabIndex = 2;
            this.audioPlayerTabPage.Text = "Audio Player";
            this.audioPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // audioPlayerControl1
            // 
            this.audioPlayerControl1.BackColor = System.Drawing.SystemColors.Control;
            this.audioPlayerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioPlayerControl1.Location = new System.Drawing.Point(3, 3);
            this.audioPlayerControl1.Name = "audioPlayerControl1";
            this.audioPlayerControl1.Size = new System.Drawing.Size(982, 634);
            this.audioPlayerControl1.TabIndex = 0;
            // 
            // characterInfoTabPage
            // 
            this.characterInfoTabPage.Controls.Add(this.characterInfoControl);
            this.characterInfoTabPage.Location = new System.Drawing.Point(4, 24);
            this.characterInfoTabPage.Name = "characterInfoTabPage";
            this.characterInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.characterInfoTabPage.Size = new System.Drawing.Size(988, 640);
            this.characterInfoTabPage.TabIndex = 3;
            this.characterInfoTabPage.Text = "Character Info";
            this.characterInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // characterInfoControl
            // 
            this.characterInfoControl.BackColor = System.Drawing.SystemColors.Control;
            this.characterInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterInfoControl.Location = new System.Drawing.Point(3, 3);
            this.characterInfoControl.Name = "characterInfoControl";
            this.characterInfoControl.Size = new System.Drawing.Size(982, 634);
            this.characterInfoControl.TabIndex = 0;
            // 
            // raceMusicTabPage
            // 
            this.raceMusicTabPage.Controls.Add(this.raceSimulatorControl1);
            this.raceMusicTabPage.Location = new System.Drawing.Point(4, 24);
            this.raceMusicTabPage.Name = "raceMusicTabPage";
            this.raceMusicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.raceMusicTabPage.Size = new System.Drawing.Size(988, 640);
            this.raceMusicTabPage.TabIndex = 1;
            this.raceMusicTabPage.Text = "Race Music Simulator";
            this.raceMusicTabPage.UseVisualStyleBackColor = true;
            // 
            // raceSimulatorControl1
            // 
            this.raceSimulatorControl1.BackColor = System.Drawing.SystemColors.Control;
            this.raceSimulatorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raceSimulatorControl1.Location = new System.Drawing.Point(3, 3);
            this.raceSimulatorControl1.Name = "raceSimulatorControl1";
            this.raceSimulatorControl1.Size = new System.Drawing.Size(982, 634);
            this.raceSimulatorControl1.TabIndex = 0;
            // 
            // jukeboxTabPage
            // 
            this.jukeboxTabPage.Controls.Add(this.jukebox);
            this.jukeboxTabPage.Location = new System.Drawing.Point(4, 24);
            this.jukeboxTabPage.Name = "jukeboxTabPage";
            this.jukeboxTabPage.Size = new System.Drawing.Size(988, 640);
            this.jukeboxTabPage.TabIndex = 5;
            this.jukeboxTabPage.Text = "Jukebox";
            this.jukeboxTabPage.UseVisualStyleBackColor = true;
            // 
            // jukebox
            // 
            this.jukebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jukebox.Location = new System.Drawing.Point(0, 0);
            this.jukebox.Name = "jukebox";
            this.jukebox.Size = new System.Drawing.Size(988, 640);
            this.jukebox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 692);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uma Musume Explorer";
            this.tabControl.ResumeLayout(false);
            this.fileBrowserTabPage.ResumeLayout(false);
            this.audioPlayerTabPage.ResumeLayout(false);
            this.characterInfoTabPage.ResumeLayout(false);
            this.raceMusicTabPage.ResumeLayout(false);
            this.jukeboxTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage raceMusicTabPage;
        private UmaMusumeExplorer.Controls.RaceMusicSimulator.RaceMusicSimulatorControl raceSimulatorControl1;
        private System.Windows.Forms.TabPage audioPlayerTabPage;
        private UmaMusumeExplorer.Controls.AudioPlayer.AudioPlayerControl audioPlayerControl1;
        private System.Windows.Forms.TabPage characterInfoTabPage;
        private Controls.CharacterInfo.CharacterInfoControl characterInfoControl;
        private System.Windows.Forms.TabPage fileBrowserTabPage;
        private Controls.FileBrowser.FileBrowserControl fileBrowserControl;
        private System.Windows.Forms.TabPage jukeboxTabPage;
        private Controls.LiveMusicPlayer.JukeboxControl jukebox;
    }
}

