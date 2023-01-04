using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    partial class JukeboxControl : UserControl
    {
        private readonly IEnumerable<JukeboxMusicData> jukeboxMusicDatas = AssetTables.JukeboxMusicDatas.OrderBy(l => l.Sort);

        private SongLength currentSongLength;

        public JukeboxControl()
        {
            InitializeComponent();

            shortVersionRadioButton.Checked = true;
            shortVersionRadioButton.Tag = SongLength.ShortVersion;
            gameSizeVersionRadioButton.Tag = SongLength.GameSizeVersion;
        }

        private void LiveMusicPlayerSongSelectControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode) loadingBackgroundWorker.RunWorkerAsync();
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IProgress<int> defaultProgress = AssetStudio.Progress.Default;
            AssetStudio.Progress.Default = new LoadingProgress(loadingBackgroundWorker.ReportProgress);

            List<PictureBox> pictureBoxes = new();
            int itemNumber = 1;
            foreach (var jukeboxMusicData in jukeboxMusicDatas)
            {
                PictureBox jacket = new()
                {
                    BackgroundImage = UnityAssets.GetJacket(jukeboxMusicData.MusicId, 'l').Bitmap,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 130,
                    Width = 130,
                    Tag = jukeboxMusicData
                };

                jacket.Click += Jacket_Click;

                ToolTip toolTip = new();
                toolTip.SetToolTip(jacket, $"{jukeboxMusicData.MusicId}: {AssetTables.GetText(AssetTables.LiveNameTextDatas, jukeboxMusicData.MusicId)}");

                pictureBoxes.Add(jacket);

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / jukeboxMusicDatas.Count() * 100.0F));
            }

            AssetStudio.Progress.Default = defaultProgress;

            e.Result = pictureBoxes.ToArray();
        }

        private void Jacket_Click(object sender, EventArgs e)
        {
            JukeboxMusicData liveData = (sender as PictureBox).Tag as JukeboxMusicData;
            if (liveData is not null)
                ControlHelpers.ShowFormCenter(new PlayerForm(liveData, currentSongLength), this);
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;

            jacketPanel.Controls.AddRange((Control[])e.Result);
        }

        private void RadioBuiton_CheckedChanegd(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Tag is not null)
            {
                if (radioButton.Checked)
                    currentSongLength = (SongLength)radioButton.Tag;
            }
        }
    }
}
