using UmamsumeData;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;
using UmamusumeExplorer.Controls;
using UmamusumeExplorer.Music;

namespace UmamusumeExplorer.Controls
{
    internal class JukeboxItemsPanel : ItemsPanel<JukeboxMusicData>
    {
        public SongLength CurrentSongLength { get; set; }

        public override bool ProcessItem(JukeboxMusicData jukeboxMusicData, ref Control? jacket)
        {
            jacket = new PictureBox()
            {
                BackgroundImage = GameAssets.GetJacket(jukeboxMusicData.MusicId, 'l')?.Bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Height = 128,
                Width = 128,
                Tag = jukeboxMusicData
            };

            jacket.Click += (s, e) =>
            {
                if (s is not PictureBox pictureBox) return;
                if (pictureBox.Tag is not JukeboxMusicData jukeBoxData) return;
                if (jukeBoxData is not null)
                {
                    MusicManager jukeBoxManager = new(jukeBoxData);

                    if (jukeBoxManager.SetupJukeBoxMusic(CurrentSongLength))
                        ControlHelpers.ShowFormCenter(new PlayerForm(jukeBoxManager), this);
                }
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(jacket, $"{jukeboxMusicData.MusicId}: {AssetTables.GetText(TextCategory.MasterLiveTitle, jukeboxMusicData.MusicId)}");

            return true;
        }
    }
}
