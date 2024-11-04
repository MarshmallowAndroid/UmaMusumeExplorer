using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Common;
using UmaMusumeExplorer.Controls.Common.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class LiveMusicPlayerControl : UserControl
    {
        private readonly IEnumerable<LiveData>? liveDatas = AssetTables.LiveDatas?.OrderBy(l => l.Sort);

        public LiveMusicPlayerControl()
        {
            InitializeComponent();

            songItemsPanel.ItemClick += (s, e) =>
            {
                if (s is not PictureBox pictureBox) return;
                if (pictureBox.Tag is not LiveData liveData) return;

                if (liveData is not null)
                {
                    MusicManager liveManager = new(liveData);

                    if (liveManager.SetupLive(this))
                        ControlHelpers.ShowFormCenter(new PlayerForm(liveManager), this);
                }
            };
        }

        private void LiveMusicPlayerSongSelectControl_Load(object sender, EventArgs e)
        {
            songItemsPanel.Items = liveDatas;
        }

        private void LinkLabelDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlHelpers.ShowFormCenter(new DownloadWorkaroundForm(), this);
        }
    }
}
