using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Jukebox;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    public partial class JukeboxControl : UserControl
    {
        private readonly IEnumerable<LiveData> liveDatas = AssetTables.LiveDatas;

        public JukeboxControl()
        {
            InitializeComponent();
        }

        private void Jukebox_Load(object sender, EventArgs e)
        {
            if (!DesignMode) loadingBackgroundWorker.RunWorkerAsync();
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Regex jacketIcon = new(@"\bjacket_icon_[lm]_[0-9]{4}\b");

            List<string> imagePaths = new();
            List<GameAsset> liveAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("live/"));
            foreach (var asset in liveAssetRows)
            {
                if (jacketIcon.IsMatch(asset.BaseName))
                    imagePaths.Add(UmaDataHelper.GetPath(asset));
            }

            IProgress<int> defaultProgress = AssetStudio.Progress.Default;
            AssetStudio.Progress.Default = new LoadingProgress(loadingBackgroundWorker.ReportProgress);

            UnityAssetHelpers.LoadFiles(imagePaths.ToArray());

            List<PictureBox> pictureBoxes = new();
            int itemNumber = 1;
            foreach (var item in liveDatas)
            {
                PictureBox jacket = new()
                {
                    BackgroundImage = UnityAssetHelpers.GetJacket(item.MusicID, 'l').Bitmap,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 130,
                    Width = 130,
                    Tag = item
                };

                jacket.Click += Jacket_Click;

                ToolTip toolTip = new();
                toolTip.SetToolTip(jacket, item.MusicID.ToString());

                pictureBoxes.Add(jacket);

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / liveDatas.Count() * 100.0f));
            }

            AssetStudio.Progress.Default = defaultProgress;

            e.Result = pictureBoxes.ToArray();
        }

        private void Jacket_Click(object sender, EventArgs e)
        {
            LiveData liveData = (sender as PictureBox).Tag as LiveData;
            if (liveData is not null)
                ControlHelpers.ShowFormCenter(new JukeboxPlayerForm(liveData), this);
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
    }
}
