using System.Linq;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    class CharaComboBoxItem
    {
        public CharaComboBoxItem(CharaData chara)
        {
            CharaData = chara;
        }

        public CharaData CharaData { get; }

        public override string ToString()
        {
            return CharaData.Id.ToString() + ": " + AssetTables.GetText(TextCategory.MasterCharaName, CharaData.Id);
        }
    }
}
