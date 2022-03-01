using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
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
            string charaName = PersistentData.CharaNameTextDatas.First(td => td.Index == id).Text;

            Text = charaName;
            nameLabel.Text = charaName;

            string katakana = PersistentData.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text;

            if (!katakana.Equals(nameLabel.Text))
                nameLabel.Text += $"（{PersistentData.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text}）";
            nameLabel.BackColor = ColorFromHexString(charaData.UIColorMain);
            if (GetBrightness(nameLabel.BackColor) > 128)
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

            foreach (var item in PersistentData.CardDatas.Where(cd => cd.CharaId == charaData.Id))
            {
                costumeSelectComboBox.Items.Add(new CostumeSelectComboBoxItem(item));
            }

            if (costumeSelectComboBox.Items.Count > 0)
                costumeSelectComboBox.SelectedIndex = 0;
        }

        private void CostumeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            CardData cardData = (comboBox.SelectedItem as CostumeSelectComboBoxItem).CardData;
            CardRarityData rarityData = PersistentData.CardRarityDatas.First(crd => crd.CardId == cardData.Id);

            speedStatusDisplayLabel.Value = rarityData.Speed;
            staminaStatusDisplayLabel.Value = rarityData.Stamina;
            powerStatusDisplayLabel.Value = rarityData.Pow;
            gutsStatusDisplayLabel.Value = rarityData.Guts;
            wisdomStatusDisplayLabel.Value = rarityData.Wiz;

            turfRankedLabel.Rank = (RankedLabelRank)rarityData.ProperGroundTurf;
            dirtRankedLabel.Rank = (RankedLabelRank)rarityData.ProperGroundDirt;

            shortRankedLabel.Rank = (RankedLabelRank)rarityData.ProperDistanceShort;
            mileRankedLabel.Rank = (RankedLabelRank)rarityData.ProperDistanceMile;
            middleRankedLabel.Rank = (RankedLabelRank)rarityData.ProperDistanceMiddle;
            longRankedLabel.Rank = (RankedLabelRank)rarityData.ProperDistanceLong;

            escapeRankedLabel.Rank = (RankedLabelRank)rarityData.ProperRunningStyleNige;
            leadingRankedLabel.Rank = (RankedLabelRank)rarityData.ProperRunningStyleSenko;
            insertRankedLabel.Rank = (RankedLabelRank)rarityData.ProperRunningStyleSashi;
            driveInRankedLabel.Rank = (RankedLabelRank)rarityData.ProperRunningStyleOikomi;

            speedGrowthLabel.Text = cardData.TalentSpeed.ToString() + "%";
            staminaGrowthLabel.Text = cardData.TalentStamina.ToString() + "%";
            powerGrowthLabel.Text = cardData.TalentPow.ToString() + "%";
            gutsGrowthLabel.Text = cardData.TalentGuts.ToString() + "%";
            wisdomGrowthLabel.Text = cardData.TalentWiz.ToString() + "%";

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

    class CostumeSelectComboBoxItem
    {
        public CostumeSelectComboBoxItem(CardData cardData)
        {
            CardData = cardData;
        }

        public CardData CardData { get; }

        public override string ToString()
        {
            return PersistentData.CharaCostumeNameTextDatas.First(td => td.Index == CardData.Id).Text;
        }
    }
}
