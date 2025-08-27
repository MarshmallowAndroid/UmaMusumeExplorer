using System.Data;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CardInfoControl : UserControl
    {
        private readonly IEnumerable<SkillData> skillDatas = AssetTables.SkillDatas;

        private CharaData? charaData;
        private PinnedBitmap? iconPinnedBitmap;

        private string charaName = "";
        private string charaNameEnglish = "";
        private bool showEnglishName = false;

        public CardInfoControl()
        {
            InitializeComponent();
        }

        public CharaData? CharaData
        {
            get
            {
                return charaData;
            }

            set
            {
                if (value is null) return;

                charaData = value;
                LoadCharaData();
            }
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {
            if (charaData is null) return;

            if (string.IsNullOrEmpty(charaNameEnglish)) return;

            showEnglishName = !showEnglishName;

            string name = charaName;
            if (showEnglishName)
                name = charaNameEnglish;

            if (ParentForm is not null)
                ParentForm.Text = name;
            nameLabel.Text = name;
        }

        private void CostumeSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (costumeComboBox.SelectedItem is not CostumeComboBoxItem selectedItem) return;
            CardData cardData = selectedItem.CardData;

            rarityComboBox.Items.Clear();
            foreach (var rarityData in AssetTables.CardRarityDatas.Where(crd => crd.CardId == cardData.Id))
            {
                rarityComboBox.Items.Add(new RarityComboBoxItem(rarityData));
            }

            if (rarityComboBox.Items.Count > 0)
                rarityComboBox.SelectedIndex = 0;
            else
            {
                iconPinnedBitmap?.Dispose();
                iconPinnedBitmap = UnityAssets.GetCharaIcon(cardData.CharaId);
                iconPictureBox.Image = iconPinnedBitmap?.Bitmap;

                UpdateStats(cardData, new CardRarityData(), levelComboBox.SelectedIndex + 1);
            }

            levelComboBox.SelectedIndex = 0;
        }

        private void RarityOrLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateIconAndStats();
        }

        private void SkillButton_Click(object? sender, EventArgs e)
        {
            if (sender is not SkillSmall skillSmall) return;
            ControlHelpers.ShowFormDialogCenter(new SkillInfoForm(skillSmall.Skill, skillSmall.EvolveSkill), this);
        }

        private void LoadCharaData()
        {
            if (charaData is null) return;

            int id = charaData.Id;
            charaName = AssetTables.GetText(TextCategory.MasterCharaName, id);
            charaNameEnglish = AssetTables.GetText(TextCategory.CharaName_En, charaData.Id);

            nameLabel.Text = charaName;

            string furigana = AssetTables.GetText(TextCategory.MasterCharaFurigana, id);

            if (furigana != nameLabel.Text)
                nameLabel.Text += $"（{AssetTables.GetText(TextCategory.MasterCharaFurigana, id)}）";
            nameLabel.BackColor = ColorFromHexString(charaData.UIColorMain);
            if (GetBrightness(nameLabel.BackColor) > 128)
                nameLabel.ForeColor = Color.Black;
            else
                nameLabel.ForeColor = Color.White;

            cvNameLabel.Text = "CV. " + AssetTables.GetText(TextCategory.MasterCharaCv, id);
            cvNameLabel.BackColor = ColorFromHexString(charaData.UIColorSub);
            if (GetBrightness(cvNameLabel.BackColor) > 128)
                cvNameLabel.ForeColor = Color.Black;
            else
                cvNameLabel.ForeColor = Color.White;

            genderLabel.Text = charaData.Sex == 1 ? "Male" : "Female";
            birthdayLabel.Text = $"{charaData.BirthYear}/{charaData.BirthMonth}/{charaData.BirthDay} ({DateTime.Now.Year - charaData.BirthYear} years)";

            iconPinnedBitmap = UnityAssets.GetCharaIcon(id);
            iconPictureBox.Image = iconPinnedBitmap?.Bitmap;

            foreach (var item in AssetTables.CardDatas.Where(cd => cd.CharaId == charaData.Id))
            {
                costumeComboBox.Items.Add(new CostumeComboBoxItem(item));
            }

            if (costumeComboBox.Items.Count > 0)
                costumeComboBox.SelectedIndex = 0;
        }

        private void UpdateStats(CardData cardData, CardRarityData cardRarityData, int level)
        {
            speedStatusDisplayLabel.Value = cardRarityData.Speed;
            staminaStatusDisplayLabel.Value = cardRarityData.Stamina;
            powerStatusDisplayLabel.Value = cardRarityData.Pow;
            gutsStatusDisplayLabel.Value = cardRarityData.Guts;
            witStatusDisplayLabel.Value = cardRarityData.Wiz;

            turfRankedLabel.Rank = (Rank)cardRarityData.ProperGroundTurf;
            dirtRankedLabel.Rank = (Rank)cardRarityData.ProperGroundDirt;

            sprintRankedLabel.Rank = (Rank)cardRarityData.ProperDistanceShort;
            mileRankedLabel.Rank = (Rank)cardRarityData.ProperDistanceMile;
            mediumRankedLabel.Rank = (Rank)cardRarityData.ProperDistanceMiddle;
            longRankedLabel.Rank = (Rank)cardRarityData.ProperDistanceLong;

            frontRankedLabel.Rank = (Rank)cardRarityData.ProperRunningStyleNige;
            paceRankedLabel.Rank = (Rank)cardRarityData.ProperRunningStyleSenko;
            lateRankedLabel.Rank = (Rank)cardRarityData.ProperRunningStyleSashi;
            endRankedLabel.Rank = (Rank)cardRarityData.ProperRunningStyleOikomi;

            speedGrowthLabel.Text = cardData.TalentSpeed.ToString() + "%";
            staminaGrowthLabel.Text = cardData.TalentStamina.ToString() + "%";
            powerGrowthLabel.Text = cardData.TalentPow.ToString() + "%";
            gutsGrowthLabel.Text = cardData.TalentGuts.ToString() + "%";
            wisdomGrowthLabel.Text = cardData.TalentWiz.ToString() + "%";

            skillsTableLayoutPanel.Controls.Clear();

            SkillSet? uniqueSkillSet = AssetTables.SkillSets.FirstOrDefault(s => s.Id == cardRarityData.SkillSet);
            if (uniqueSkillSet is not null)
            {
                IEnumerable<AvailableSkillSet> availableSkillSet = AssetTables.AvailableSkillSets
                    .Where(a => a.AvailableSkillSetId == cardData.AvailableSkillSetId && a.NeedRank <= level)
                    .OrderBy(a => a.SkillId);

                skillsTableLayoutPanel.Controls.Add(ButtonFromSkillId(uniqueSkillSet.SkillId1, cardData.Id, uniqueSkillSet.SkillLevel1), 0, 0);

                int currentColumn = 1;
                int currentRow = 0;
                foreach (var availableSkill in availableSkillSet)
                {
                    skillsTableLayoutPanel.Controls.Add(ButtonFromSkillId(availableSkill.SkillId, cardData.Id), currentColumn % 2, currentRow);

                    currentColumn++;
                    if (currentColumn % 2 == 0)
                        currentRow++;
                }
            }
        }

        private void UpdateIconAndStats()
        {
            if (costumeComboBox.SelectedItem is not CostumeComboBoxItem selectedCostumeItem) return;
            if (rarityComboBox.SelectedItem is not RarityComboBoxItem selectedRarityItem) return;

            CardData cardData = selectedCostumeItem.CardData;
            CardRarityData rarityData = selectedRarityItem.CardRarityData;

            rarityData ??= new();

            int level = levelComboBox.SelectedIndex + 1;

            iconPinnedBitmap?.Dispose();
            iconPinnedBitmap = UnityAssets.GetCharaIcon(cardData.CharaId, rarityData.RaceDressId, level > 2 ? 2 : 1);
            iconPictureBox.Image = iconPinnedBitmap?.Bitmap;

            UpdateStats(cardData, rarityData, level);
        }

        private SkillSmall ButtonFromSkillId(int skillId, int cardId, int level = 0)
        {
            SkillData skill = skillDatas.First(s => s.Id == skillId);

            IEnumerable<SkillData> sameDispOrder = skillDatas.Where(s => s.DispOrder == skill.DispOrder);
            IEnumerable<SkillUpgradeDescription> evolveSkillDescriptions = AssetTables.SkillUpgradeDescriptions.Where(s => s.CardId == cardId);
            IEnumerable<SkillData> evolveSkills = sameDispOrder.Where(s => evolveSkillDescriptions.Where(es => es.SkillId == s.Id).Any());

            SkillSmall skillSmall = new(skill)
            {
                Dock = DockStyle.Fill,
                Background = (SkillBackground)skill.Rarity,
                SkillLevel = level,
                EvolveSkill = evolveSkills
            };

            skillSmall.SkillClick += SkillButton_Click;

            return skillSmall;
        }

        private static Color ColorFromHexString(string hexString)
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
}
