using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoForm : Form
    {
        public CharacterInfoForm(CharaData chara)
        {
            InitializeComponent();

            cardInfoControl.CharaData = chara;
            voiceLinesControl.CharaId = chara.Id;
            songsControl.CharaId = chara.Id;
            supportCardsControl.CharaId = chara.Id;

            Text = AssetTables.GetText(TextCategory.MasterCharaName, chara.Id);
        }

        private void CharacterInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            voiceLinesControl.StopAllPlayback();
        }
    }
}
