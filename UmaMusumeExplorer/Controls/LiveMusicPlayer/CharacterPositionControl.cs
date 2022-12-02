using System.Windows.Forms;
using UmaMusumeExplorer.Controls.Jukebox;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterPositionControl : UserControl
    {
        private int characterIndex = 0;
        private int characterId = 0;

        public CharacterPositionControl(int index, UnitSetupForm unitSetupForm)
        {
            InitializeComponent();

            characterIndex = index;

            positionIndexLabel.Text = characterIndex.ToString();
            characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(0).Bitmap;

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
                characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(characterId).Bitmap;

                Update();
            }
        }
    }
}
