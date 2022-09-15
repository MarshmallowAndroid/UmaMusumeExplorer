using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeData;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    public partial class CharacterSelectForm : Form
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private readonly List<int> allowedCharas = new();

        public CharacterSelectForm(IEnumerable<LivePermissionData> permissionData)
        {
            InitializeComponent();

            livePermissionData = permissionData;
            foreach (var lpd in livePermissionData)
            {
                allowedCharas.Add(lpd.CharaId);
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
            foreach (var item in charaDatas)
            {
                if (!allowedCharas.Contains(item.Id)) continue;

                PictureBox charaIcon = new()
                {
                    BackgroundImage = UnityAssetHelpers.GetCharaIcon(item.Id).Bitmap,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 100,
                    Width = 100,
                    Tag = item
                };

                charaIcon.Click += CharaIcon_Click; ;
                pictureBoxes.Add(charaIcon);
            }

            flowLayoutPanel1.Controls.AddRange(pictureBoxes.ToArray());
        }
    }
}
