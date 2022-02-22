using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeFiles;
using UmaMusumeFiles.Tables;

namespace PlayerGui.Controls.CharacterInfo
{
    public partial class CharacterInfoControl : UserControl
    {
        private readonly List<CharaData> charaDatas;
        private readonly List<TextData> charaNameTextData;
        private readonly List<TextData> charaNameKatakanaTextData;
        private readonly List<TextData> charaVoiceNameTextData;

        public CharacterInfoControl()
        {
            InitializeComponent();

            charaDatas = UmaFileHelper.GetInfoDatabaseRows<CharaData>();
            charaNameTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 170);
            charaNameKatakanaTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 182);
            charaVoiceNameTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 7);
            foreach (var item in charaDatas)
            {
                string charaName = charaNameTextData.Where(td => td.Index == item.Id).First().Text;
                characterSelectComboBox.Items.Add(new CharaComboBoxItem(item, charaName));
            }
        }

        private void CharacterSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            CharaComboBoxItem selectedCharacter = comboBox.SelectedItem as CharaComboBoxItem;

            characterNameLabel.Text = selectedCharacter.Name;
            string katakana = charaNameKatakanaTextData.Where(td => td.Index == selectedCharacter.Id).First().Text;
            if (!katakana.Equals(characterNameLabel.Text))
                characterNameLabel.Text += $"（{charaNameKatakanaTextData.Where(td => td.Index == selectedCharacter.Id).First().Text}）";
            characterNameLabel.BackColor = ColorFromHexString(selectedCharacter.CharaData.UIColorMain);
            if (GetBrightness(characterNameLabel.BackColor) > 144)
                characterNameLabel.ForeColor = Color.Black;
            else
                characterNameLabel.ForeColor = Color.White;

            characterVoiceNameLabel.Text = "CV: " + charaVoiceNameTextData.Where(td => td.Index == selectedCharacter.Id).First().Text;
            characterVoiceNameLabel.BackColor = ColorFromHexString(selectedCharacter.CharaData.UIColorSub);
            if (GetBrightness(characterVoiceNameLabel.BackColor) > 128)
                characterVoiceNameLabel.ForeColor = Color.Black;
            else
                characterVoiceNameLabel.ForeColor = Color.White;
        }
        
        private byte GetBrightness(Color color)
        {
            return (byte)((color.R + color.R + color.B + color.G + color.G) / 6);
        }

        private Color ColorFromHexString(string hexString)
        {
            byte a = 0xFF;
            byte r = Convert.FromHexString(hexString[..2])[0];
            byte g = Convert.FromHexString(hexString[2..4])[0];
            byte b = Convert.FromHexString(hexString[4..6])[0];

            return Color.FromArgb(a, r, g, b);
        }
    }

    public class CharaComboBoxItem
    {
        public CharaComboBoxItem(CharaData charaData, string charaName)
        {
            CharaData = charaData;
            Id = charaData.Id;
            Name = charaName;
        }

        public CharaData CharaData { get; }

        public int Id { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
