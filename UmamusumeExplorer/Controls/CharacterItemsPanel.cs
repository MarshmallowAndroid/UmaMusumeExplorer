using UmamsumeData;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;
using UmamusumeExplorer.Controls;

namespace UmamusumeExplorer.Controls
{
    internal class CharacterItemsPanel : ItemsPanel<CharaData>
    {
        public override bool ProcessItem(CharaData charaData, ref Control? characterPictureBox)
        {
            bool playable = AssetTables.CardDatas.Any(cd => cd.CharaId == charaData.Id);
            characterPictureBox = new HighlightPictureBox(playable)
            {
                BackgroundImage = GameAssets.GetCharaIcon(charaData.Id)?.Bitmap,
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand,
                Height = 108,
                Width = 98,
                Tag = charaData
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(characterPictureBox, $"{charaData.Id}: {AssetTables.GetText(TextCategory.MasterCharaName, charaData.Id)}");

            return true;
        }
    }
}
