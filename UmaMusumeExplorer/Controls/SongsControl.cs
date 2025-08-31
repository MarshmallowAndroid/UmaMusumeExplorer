using UmaMusumeData.Tables;
using UmaMusumeExplorer.Assets;
using UmaMusumeExplorer.Controls;
using UmaMusumeExplorer.Music;
using UmaMusumeExplorer.Utility;

namespace UmaMusumeExplorer.Controls
{
    public partial class SongsControl : UserControl
    {
        private readonly IEnumerable<LiveData> liveDatas = AssetTables.LiveDatas;

        public SongsControl()
        {
            InitializeComponent();

            songItemsPanel.Indeterminate = true;
            songItemsPanel.Filter = (item) =>
            {
                IEnumerable<LivePermissionData> livePermissionData = LivePermissionDataHelper.GetLivePermissionData(item.MusicId);
                return livePermissionData.FirstOrDefault(lpd => lpd.CharaId == CharaId) is not null;
            };
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

        public int CharaId { get; set; }

        private void SongsControl_Load(object sender, EventArgs e)
        {
            if (liveDatas is not null)
                songItemsPanel.Items = liveDatas;
        }
    }
}
