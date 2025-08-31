using UmamsumeData;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;

namespace UmamusumeExplorer.Controls
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
