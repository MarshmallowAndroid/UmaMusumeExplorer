using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Common;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    internal class JukeboxItemsPanel : ItemsPanel<JukeboxMusicData>
    {
        public SongLength CurrentSongLength { get; set; }

        public override bool ProcessItem(JukeboxMusicData jukeboxMusicData, ref Control jacket)
        {
            jacket = new PictureBox()
            {
                BackgroundImage = UnityAssets.GetJacket(jukeboxMusicData.MusicId, 'l').Bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Height = 130,
                Width = 130,
                Tag = jukeboxMusicData
            };

            jacket.Click += (s, e) =>
            {
                JukeboxMusicData jukeBoxData = (s as PictureBox).Tag as JukeboxMusicData;
                if (jukeBoxData is not null)
                    ControlHelpers.ShowFormCenter(new PlayerForm(jukeBoxData, CurrentSongLength), this);
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(jacket, $"{jukeboxMusicData.MusicId}: {AssetTables.GetText(TextCategory.MasterLiveTitle, jukeboxMusicData.MusicId)}");

            return true;
        }
    }
}
