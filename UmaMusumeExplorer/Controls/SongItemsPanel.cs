using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Assets;

namespace UmaMusumeExplorer.Controls
{
    internal class SongItemsPanel : ItemsPanel<LiveData>
    {
        public override bool ProcessItem(LiveData liveData, ref Control? jacket)
        {
            if (liveData.HasLive == 0) return false;

            jacket = new PictureBox()
            {
                BackgroundImage = GameAssets.GetJacket(liveData.MusicId, 'l')?.Bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Height = 128,
                Width = 128,
                Tag = liveData
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(jacket, $"{liveData.MusicId}: {AssetTables.GetText(TextCategory.MasterLiveTitle, liveData.MusicId)}");

            return true;
        }
    }
}
