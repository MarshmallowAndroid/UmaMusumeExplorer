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
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CardDetailsForm : Form
    {
        private readonly CharaData charaData;

        private PinnedBitmap iconPinnedBitmap;

        public CardDetailsForm(CharaData chara)
        {
            InitializeComponent();

            charaData = chara;
        }

        private void CardDetailsForm_Load(object sender, EventArgs e)
        {
            int id = charaData.Id;
            string charaName = AssetTables.CharaNameTextDatas.First(td => td.Index == id).Text;

            Text = charaName;
            nameLabel.Text = charaName;

            string katakana = AssetTables.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text;

            if (!katakana.Equals(nameLabel.Text))
                nameLabel.Text += $"（{AssetTables.CharaNameKatakanaTextDatas.Where(td => td.Index == id).First().Text}）";
            nameLabel.BackColor = ColorFromHexString(charaData.UIColorMain);
            if (GetBrightness(nameLabel.BackColor) > 128)
                nameLabel.ForeColor = Color.Black;
            else
                nameLabel.ForeColor = Color.White;

            cvNameLabel.Text = "CV. " + AssetTables.CharaVoiceNameTextDatas.Where(td => td.Index == id).First().Text;
            cvNameLabel.BackColor = ColorFromHexString(charaData.UIColorSub);
            if (GetBrightness(cvNameLabel.BackColor) > 128)
                cvNameLabel.ForeColor = Color.Black;
            else
                cvNameLabel.ForeColor = Color.White;

            genderLabel.Text = charaData.Sex == 1 ? "Male" : "Female";
            birthdayLabel.Text = $"{charaData.BirthDay}/{charaData.BirthMonth}/{charaData.BirthYear} ({DateTime.Now.Year - charaData.BirthYear} years)";

            iconPinnedBitmap = UnityAssetHelpers.GetCharaIcon(id);
            iconPictureBox.Image = iconPinnedBitmap.Bitmap;

            foreach (var item in AssetTables.CardDatas.Where(cd => cd.CharaId == charaData.Id))
            {
                costumeComboBox.Items.Add(new CostumeComboBoxItem(item));
            }

            if (costumeComboBox.Items.Count > 0)
                costumeComboBox.SelectedIndex = 0;
        }

        private void CostumeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardData cardData = (costumeComboBox.SelectedItem as CostumeComboBoxItem).CardData;

            rarityComboBox.Items.Clear();
            foreach (var rarityData in AssetTables.CardRarityDatas.Where(crd => crd.CardId == cardData.Id))
            {
                rarityComboBox.Items.Add(new RarityComboBoxItem(rarityData));
            }

            if (rarityComboBox.Items.Count > 0)
                rarityComboBox.SelectedIndex = 0;
            else
            {
                iconPinnedBitmap.Dispose();
                iconPinnedBitmap = UnityAssetHelpers.GetCharaIcon(cardData.CharaId);
                iconPictureBox.Image = iconPinnedBitmap.Bitmap;

                UpdateStats(cardData, new CardRarityData());
            }
        }

        private void RarityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardData cardData = (costumeComboBox.SelectedItem as CostumeComboBoxItem).CardData;
            CardRarityData rarityData = (rarityComboBox.SelectedItem as RarityComboBoxItem).CardRarityData;

            if (rarityData is null) rarityData = new();

            iconPinnedBitmap.Dispose();
            iconPinnedBitmap = UnityAssetHelpers.GetCharaIcon(cardData.CharaId, rarityData.RaceDressId);
            iconPictureBox.Image = iconPinnedBitmap.Bitmap;

            UpdateStats(cardData, rarityData);
        }

        private void UpdateStats(CardData cardData, CardRarityData rarityData)
        {
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
            return (byte)((color.R + color.R + color.G + color.G + color.B + color.B) / 6);
        }
    }

    class CostumeComboBoxItem
    {
        public CostumeComboBoxItem(CardData cardData)
        {
            CardData = cardData;
        }

        public CardData CardData { get; }

        public override string ToString()
        {
            return AssetTables.CharaCostumeNameTextDatas.First(td => td.Index == CardData.Id).Text;
        }
    }

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
