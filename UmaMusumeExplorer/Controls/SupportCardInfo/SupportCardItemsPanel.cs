using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo;
using UmaMusumeExplorer.Controls.Common;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.SupportCardInfo
{
    internal class SupportCardItemsPanel : ItemsPanel<SupportCardData>
    {
        public override bool ProcessItem(SupportCardData supportCardData, ref Control? supportCardPictureBox)
        {
            bool limited = !AssetTables.GachaAvailables.Any(ga => ga.CardType == 2 && ga.CardId == supportCardData.Id);
            supportCardPictureBox = new HighlightPictureBox(limited)
            {
                BackgroundImage = UnityAssets.GetSupportCardIcon(supportCardData.Id)?.Bitmap,
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand,
                Height = 166,
                Width = 127,
                Tag = supportCardData
            };

            ToolTip toolTip = new();
            toolTip.SetToolTip(supportCardPictureBox, $"{supportCardData.Id}: {AssetTables.GetText(TextCategory.MasterSupportCardTitleName, supportCardData.Id)}");

            return true;
        }
    }
}
