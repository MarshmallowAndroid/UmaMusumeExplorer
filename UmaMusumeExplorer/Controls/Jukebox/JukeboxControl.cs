using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    partial class JukeboxControl : UserControl
    {
        private readonly IEnumerable<JukeboxMusicData> jukeboxMusicDatas = AssetTables.JukeboxMusicDatas?.OrderBy(l => l.Sort);

        public JukeboxControl()
        {
            InitializeComponent();

            shortVersionRadioButton.Checked = true;
            shortVersionRadioButton.Tag = SongLength.ShortVersion;
            gameSizeVersionRadioButton.Tag = SongLength.GameSizeVersion;
        }

        private void LiveMusicPlayerSongSelectControl_Load(object sender, EventArgs e)
        {
            if (jukeboxMusicDatas is not null) jukeboxItemsPanel.Items = jukeboxMusicDatas;
        }

        private void RadioBuiton_CheckedChanegd(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Tag is not null)
            {
                if (radioButton.Checked)
                    jukeboxItemsPanel.CurrentSongLength = (SongLength)radioButton.Tag;
            }
        }
    }
}
