using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SongsControl : UserControl
    {
        private readonly IEnumerable<LiveData> liveDatas = AssetTables.LiveDatas;

        public SongsControl()
        {
            InitializeComponent();

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
                LiveData liveData = (s as PictureBox).Tag as LiveData;
                LiveManager liveManager = new(liveData);
                if (liveData is not null)
                    ControlHelpers.ShowFormCenter(new PlayerForm(liveManager), this);
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
