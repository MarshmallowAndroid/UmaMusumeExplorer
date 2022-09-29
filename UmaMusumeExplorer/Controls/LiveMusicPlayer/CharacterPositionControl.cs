using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Jukebox;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterPositionControl : UserControl
    {
        private readonly IEnumerable<LivePermissionData> livePermissionData;

        private int characterIndex = 0;
        private int characterId = 0;

        public CharacterPositionControl(int index, IEnumerable<LivePermissionData> permissionData, UnitSetupForm unitSetupForm)
        {
            InitializeComponent();

            characterIndex = index;
            livePermissionData = permissionData;

            positionIndexLabel.Text = characterIndex.ToString();
            characterPictureBox.BackgroundImage = UnityAssetHelpers.GetCharaIcon(0).Bitmap;

            characterPictureBox.Click += unitSetupForm.CharacterPositionPictureBoxClick;
        }

        public int PositionIndex
        {
            get { return characterIndex; }
            set
            {
                characterIndex = value;
                positionIndexLabel.Text = value.ToString();

                Update();
            }
        }

        public int CharacterId
        {
            get { return characterId; }
            set
            {
                characterId = value;
                characterPictureBox.BackgroundImage = UnityAssetHelpers.GetCharaIcon(characterId).Bitmap;

                Update();
            }
        }
    }
}
