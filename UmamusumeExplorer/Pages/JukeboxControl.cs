using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;
using UmamusumeExplorer.Music;

namespace UmamusumeExplorer.Pages
{
    partial class JukeboxControl : UserControl
    {
        private readonly IEnumerable<JukeboxMusicData>? jukeboxMusicDatas = AssetTables.JukeboxMusicDatas?.OrderBy(l => l.Sort);

        public JukeboxControl()
        {
            InitializeComponent();

            shortVersionRadioButton.Checked = true;
            shortVersionRadioButton.Tag = SongLength.ShortVersion;
            gameSizeVersionRadioButton.Tag = SongLength.GameSizeVersion;
        }

        private void LiveMusicPlayerSongSelectControl_Load(object sender, EventArgs e)
        {
            jukeboxItemsPanel.Items = jukeboxMusicDatas;
        }

        private void RadioBuiton_CheckedChanegd(object sender, EventArgs e)
        {
            if (sender is not RadioButton radioButton) return;
            if (radioButton.Tag is not null)
            {
                if (radioButton.Checked)
                    jukeboxItemsPanel.CurrentSongLength = (SongLength)radioButton.Tag;
            }
        }
    }
}
