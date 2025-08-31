using System.Text;
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls
{
    class RarityComboBoxItem
    {
        public RarityComboBoxItem(CardRarityData cardRarityData)
        {
            CardRarityData = cardRarityData;
        }

        public CardRarityData CardRarityData { get; }

        public override string ToString()
        {
            StringBuilder starsString = new();
            for (int i = 0; i < CardRarityData.Rarity; i++)
            {
                starsString.Append('★');
            }

            return starsString.ToString();
        }
    }
}
