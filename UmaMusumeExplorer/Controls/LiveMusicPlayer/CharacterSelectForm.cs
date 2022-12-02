using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterSelectForm : Form
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private readonly List<int> allowedCharas = new();
        private readonly List<int> alreadySelected = new();

        public CharacterSelectForm(IEnumerable<LivePermissionData> permissionData, CharacterPositionControl[] characters)
        {
            InitializeComponent();

            livePermissionData = permissionData;
            foreach (var lpd in livePermissionData)
            {
                allowedCharas.Add(lpd.CharaId);
            }

            foreach (var character in characters)
            {
                alreadySelected.Add(character.CharacterId);
            }
        }

        public int SelectedCharacter { get; private set; } = 0;

        private void CharaIcon_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            SelectedCharacter = (pictureBox.Tag as CharaData).Id;

            Close();
        }

        private void CharacterSelectForm_Load(object sender, EventArgs e)
        {
            List<Control> pictureBoxes = new();
            foreach (var charaData in charaDatas)
            {
                if (!allowedCharas.Contains(charaData.Id)) continue;

                PictureBox charaIcon = new()
                {
                    BackgroundImage = UnityAssets.GetCharaIcon(charaData.Id).Bitmap,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 100,
                    Width = 100,
                    Tag = charaData
                };

                if (alreadySelected.Contains(charaData.Id)) charaIcon.BackColor = Color.FromArgb(234, 54, 128);

                charaIcon.Click += CharaIcon_Click; ;
                pictureBoxes.Add(charaIcon);
            }

            flowLayoutPanel.Controls.AddRange(pictureBoxes.ToArray());
        }
    }
}
