
namespace PlayerGui
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.audioPlayerTabPage = new System.Windows.Forms.TabPage();
            this.audioPlayerControl1 = new PlayerGui.Controls.AudioPlayer.AudioPlayerControl();
            this.raceMusicTabPage = new System.Windows.Forms.TabPage();
            this.raceSimulatorControl1 = new PlayerGui.Controls.RaceMusicSimulator.RaceMusicSimulatorControl();
            this.characterInfoTabPage = new System.Windows.Forms.TabPage();
            this.characterInfoControl1 = new PlayerGui.Controls.CharacterInfo.CharacterInfoControl();
            this.tabControl.SuspendLayout();
            this.audioPlayerTabPage.SuspendLayout();
            this.raceMusicTabPage.SuspendLayout();
            this.characterInfoTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.audioPlayerTabPage);
            this.tabControl.Controls.Add(this.raceMusicTabPage);
            this.tabControl.Controls.Add(this.characterInfoTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(987, 668);
            this.tabControl.TabIndex = 5;
            // 
            // audioPlayerTabPage
            // 
            this.audioPlayerTabPage.Controls.Add(this.audioPlayerControl1);
            this.audioPlayerTabPage.Location = new System.Drawing.Point(4, 24);
            this.audioPlayerTabPage.Name = "audioPlayerTabPage";
            this.audioPlayerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.audioPlayerTabPage.Size = new System.Drawing.Size(979, 640);
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
            this.audioPlayerControl1.Size = new System.Drawing.Size(973, 634);
            this.audioPlayerControl1.TabIndex = 0;
            // 
            // raceMusicTabPage
            // 
            this.raceMusicTabPage.Controls.Add(this.raceSimulatorControl1);
            this.raceMusicTabPage.Location = new System.Drawing.Point(4, 24);
            this.raceMusicTabPage.Name = "raceMusicTabPage";
            this.raceMusicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.raceMusicTabPage.Size = new System.Drawing.Size(979, 640);
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
            this.raceSimulatorControl1.Size = new System.Drawing.Size(973, 634);
            this.raceSimulatorControl1.TabIndex = 0;
            // 
            // characterInfoTabPage
            // 
            this.characterInfoTabPage.Controls.Add(this.characterInfoControl1);
            this.characterInfoTabPage.Location = new System.Drawing.Point(4, 24);
            this.characterInfoTabPage.Name = "characterInfoTabPage";
            this.characterInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.characterInfoTabPage.Size = new System.Drawing.Size(979, 640);
            this.characterInfoTabPage.TabIndex = 3;
            this.characterInfoTabPage.Text = "Character Info";
            this.characterInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // characterInfoControl1
            // 
            this.characterInfoControl1.BackColor = System.Drawing.SystemColors.Control;
            this.characterInfoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterInfoControl1.Location = new System.Drawing.Point(3, 3);
            this.characterInfoControl1.Name = "characterInfoControl1";
            this.characterInfoControl1.Size = new System.Drawing.Size(973, 634);
            this.characterInfoControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 692);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Uma Musume Basic Reader";
            this.tabControl.ResumeLayout(false);
            this.audioPlayerTabPage.ResumeLayout(false);
            this.raceMusicTabPage.ResumeLayout(false);
            this.characterInfoTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage raceMusicTabPage;
        private PlayerGui.Controls.RaceMusicSimulator.RaceMusicSimulatorControl raceSimulatorControl1;
        private System.Windows.Forms.TabPage audioPlayerTabPage;
        private PlayerGui.Controls.AudioPlayer.AudioPlayerControl audioPlayerControl1;
        private System.Windows.Forms.TabPage characterInfoTabPage;
        private Controls.CharacterInfo.CharacterInfoControl characterInfoControl1;
    }
}

