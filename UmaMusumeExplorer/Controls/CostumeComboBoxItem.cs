using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Assets;

namespace UmaMusumeExplorer.Controls
{
    class CostumeComboBoxItem
    {
        public CostumeComboBoxItem(CardData cardData)
        {
            CardData = cardData;
        }

        public CardData CardData { get; }

        public override string ToString()
        {
            return AssetTables.GetText(TextCategory.MasterCardTitleName, CardData.Id);
        }
    }
}
