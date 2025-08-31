using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;
using UmamusumeExplorer.Controls;

namespace UmamusumeExplorer.Pages
{
    partial class CharacterInfoControl : UserControl
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;

        public CharacterInfoControl()
        {
            InitializeComponent();

            characterItemsPanel.ItemClick += (s, e) =>
            {
                if (s is not PictureBox pictureBox) return;
                if (pictureBox.Tag is not CharaData charaData) return;

                CharacterInfoForm details = new(charaData);
                ControlHelpers.ShowFormCenter(details, this);
            };
        }

        private void CharacterInfoControl_Load(object sender, EventArgs e)
        {
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
            foreach (HighlightPictureBox hpb in characterItemsPanel.Controls)
            {
                hpb.ShowHighlight = markPlayableCheckBox.Checked;
            }
        }
    }
}
