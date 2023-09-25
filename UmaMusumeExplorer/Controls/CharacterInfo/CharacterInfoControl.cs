using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoControl : UserControl
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;

        public CharacterInfoControl()
        {
            InitializeComponent();

            characterItemsPanel.ItemClick += (s, e) =>
            {
                PictureBox charaIcon = s as PictureBox;
                CharaData chara = charaIcon.Tag as CharaData;

                CharacterInfoForm details = new(chara);
                ControlHelpers.ShowFormCenter(details, this);
            };
        }

        private void CharacterInfoControl_Load(object sender, EventArgs e)
        {
            if (charaDatas is null) return;

            characterItemsPanel.Items = charaDatas;

            foreach (var item in charaDatas)
            {
                charaListComboBox.Items.Add(new CharaComboBoxItem(item));
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (charaListComboBox.SelectedItem is CharaComboBoxItem item) ControlHelpers.ShowFormCenter(new CharacterInfoForm(item.CharaData), this);
        }

        private void ShowPlayableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CharacterPictureBox cpb in characterItemsPanel.Controls)
            {
                cpb.ShowPlayability = showPlayableCheckBox.Checked;
            }
        }
    }
}
