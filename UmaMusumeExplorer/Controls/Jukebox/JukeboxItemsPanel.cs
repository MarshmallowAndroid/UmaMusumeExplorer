﻿using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Common;
using UmaMusumeExplorer.Controls.Common.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    internal class JukeboxItemsPanel : ItemsPanel<JukeboxMusicData>
    {
        public SongLength CurrentSongLength { get; set; }

        public override bool ProcessItem(JukeboxMusicData jukeboxMusicData, ref Control? jacket)
        {
            jacket = new PictureBox()
            {
                BackgroundImage = UnityAssets.GetJacket(jukeboxMusicData.MusicId, 'l')?.Bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Height = 130,
                Width = 130,
                Tag = jukeboxMusicData
            };

            jacket.Click += (s, e) =>
            {
                if (s is not PictureBox pictureBox) return;
                if (pictureBox.Tag is not JukeboxMusicData jukeBoxData) return;
                if (jukeBoxData is not null)
                {
                    MusicManager liveManager = new(jukeBoxData, CurrentSongLength);
                    ControlHelpers.ShowFormCenter(new PlayerForm(liveManager), this);
                }
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(jacket, $"{jukeboxMusicData.MusicId}: {AssetTables.GetText(TextCategory.MasterLiveTitle, jukeboxMusicData.MusicId)}");

            return true;
        }
    }
}
