using System.Linq;
using UmaMusumeFiles.Tables;
using UmaMusumeExplorer.Controls;

namespace PlayerGui.Controls.CharacterInfo
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
