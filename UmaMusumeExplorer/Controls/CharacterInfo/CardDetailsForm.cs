using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeFiles.Tables;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CardDetailsForm : Form
    {
        private readonly CharaData charaData;

        public CardDetailsForm(CharaData chara)
        {
            InitializeComponent();

            charaData = chara;
        }

        private void CardDetailsForm_Load(object sender, EventArgs e)
        {
            int id = charaData.Id;

            nameLabel.Text = PersistentData.CharaNameTextDatas.First(td => td.Index == id).Text;

            string katakana = PersistentData.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text;

            if (!katakana.Equals(nameLabel.Text))
                nameLabel.Text += $"（{PersistentData.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text}）";
            nameLabel.BackColor = ColorFromHexString(charaData.UIColorMain);
            if (GetBrightness(nameLabel.BackColor) > 144)
                nameLabel.ForeColor = Color.Black;
            else
                nameLabel.ForeColor = Color.White;

            cvNameLabel.Text = "CV. " + PersistentData.CharaVoiceNameTextDatas.Where(td => td.Index == id).First().Text;
            cvNameLabel.BackColor = ColorFromHexString(charaData.UIColorSub);
            if (GetBrightness(cvNameLabel.BackColor) > 128)
                cvNameLabel.ForeColor = Color.Black;
            else
                cvNameLabel.ForeColor = Color.White;

            genderLabel.Text = charaData.Sex == 1 ? "Male" : "Female";
            birthdayLabel.Text = $"{charaData.BirthDay}/{charaData.BirthMonth}/{charaData.BirthYear} ({DateTime.Now.Year - charaData.BirthYear} years)";

            iconPictureBox.Image = UnityTextureHelpers.GetCharaIcon(id);
        }

        private Color ColorFromHexString(string hexString)
        {
            byte a = 0xFF;
            byte r = Convert.FromHexString(hexString[..2])[0];
            byte g = Convert.FromHexString(hexString[2..4])[0];
            byte b = Convert.FromHexString(hexString[4..6])[0];

            return Color.FromArgb(a, r, g, b);
        }

        private static byte GetBrightness(Color color)
        {
            return (byte)((color.R + color.R + color.B + color.G + color.G) / 6);
        }

    }
}
