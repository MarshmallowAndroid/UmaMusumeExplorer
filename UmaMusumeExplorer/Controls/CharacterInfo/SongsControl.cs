using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Common;
using UmaMusumeExplorer.Controls.Common.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
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

                if (livePermissionData.FirstOrDefault(lpd => lpd.CharaId == CharaId) is not null)
                    return true;
                else
                    return false;
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
