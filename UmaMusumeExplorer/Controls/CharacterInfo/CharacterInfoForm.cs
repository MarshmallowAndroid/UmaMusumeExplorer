using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;
using static UmaMusumeExplorer.Controls.CharacterInfo.RankedLabel;
using static UmaMusumeExplorer.Controls.CharacterInfo.SkillButtonSmall;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoForm : Form
    {
        private readonly CharaData charaData;

        public CharacterInfoForm(CharaData chara)
        {
            InitializeComponent();

            charaData = chara;
            cardInfoControl.CharaData = chara;

            Text = AssetTables.GetText(AssetTables.CharaNameTextDatas, chara.Id);
        }
    }
}
