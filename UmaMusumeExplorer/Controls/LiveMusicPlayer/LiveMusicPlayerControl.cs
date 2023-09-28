using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class LiveMusicPlayerControl : UserControl
    {
        private readonly IEnumerable<LiveData> liveDatas = AssetTables.LiveDatas?.OrderBy(l => l.Sort);

        public LiveMusicPlayerControl()
        {
            InitializeComponent();

            songItemsPanel.ItemClick += (s, e) =>
            {
                LiveData liveData = (s as PictureBox).Tag as LiveData;
                if (liveData is not null)
                {
                    LiveManager liveManager = new(liveData);

                    if (liveManager.Setup(this))
                        ControlHelpers.ShowFormCenter(new PlayerForm(liveManager), this);
                }
            };
        }

        private void LiveMusicPlayerSongSelectControl_Load(object sender, EventArgs e)
        {
            if (liveDatas is not null)
                songItemsPanel.Items = liveDatas;
        }
    }
}
