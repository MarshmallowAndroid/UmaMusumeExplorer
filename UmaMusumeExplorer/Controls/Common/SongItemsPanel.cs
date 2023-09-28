using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Common
{
    internal class SongItemsPanel : ItemsPanel<LiveData>
    {
        public override bool ProcessItem(LiveData liveData, ref Control? jacket)
        {
            if (liveData.HasLive == 0) return false;

            jacket = new PictureBox()
            {
                BackgroundImage = UnityAssets.GetJacket(liveData.MusicId, 'l').Bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Height = 130,
                Width = 130,
                Tag = liveData
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(jacket, $"{liveData.MusicId}: {AssetTables.GetText(TextCategory.MasterLiveTitle, liveData.MusicId)}");

            return true;
        }
    }
}
