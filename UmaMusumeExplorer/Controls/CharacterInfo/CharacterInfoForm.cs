using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoForm : Form
    {
        public CharacterInfoForm(CharaData chara)
        {
            InitializeComponent();

            cardInfoControl.CharaData = chara;
            voiceLinesControl.CharacterId = chara.Id;
            songsControl.CharaId = chara.Id;

            Text = AssetTables.GetText(TextCategory.MasterCharaName, chara.Id);
        }

        private void CharacterInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            voiceLinesControl.StopAllPlayback();
        }
    }
}
