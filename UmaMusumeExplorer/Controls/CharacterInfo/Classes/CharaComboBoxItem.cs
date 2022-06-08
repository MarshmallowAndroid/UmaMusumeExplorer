using System.Linq;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    internal class CharaComboBoxItem
    {
        public CharaComboBoxItem(CharaData chara)
        {
            CharaData = chara;
        }

        public CharaData CharaData { get; }

        public override string ToString()
        {
            return CharaData.Id.ToString() + ": " + PersistentData.CharaNameTextDatas.First(td => td.Index == CharaData.Id).Text;
        }
    }
}
