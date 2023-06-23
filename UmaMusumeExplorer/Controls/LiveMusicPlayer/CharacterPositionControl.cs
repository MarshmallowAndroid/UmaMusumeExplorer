using System.Windows.Forms;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterPositionControl : UserControl
    {
        private int characterPosition = 0;
        private int characterId = 0;

        public CharacterPositionControl(int position, UnitSetupForm unitSetupForm)
        {
            InitializeComponent();

            characterPosition = position;

            positionIndexLabel.Text = characterPosition.ToString();
            characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(0).Bitmap;

            characterPictureBox.Click += unitSetupForm.CharacterPositionPictureBoxClick;
        }

        public int PositionIndex
        {
            get { return characterPosition; }
            set
            {
                characterPosition = value;
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
