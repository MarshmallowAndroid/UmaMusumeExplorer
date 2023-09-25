using System;
using System.Windows.Forms;
using System.Drawing;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterPositionControl : UserControl
    {
        private int characterPosition = 0;
        private int characterId = 0;
        private Image characterImage;
        private bool disabled = false;

        public CharacterPositionControl(int position, EventHandler clickEventHandler)
        {
            InitializeComponent();

            characterPosition = position;

            positionIndexLabel.Text = characterPosition.ToString();
            characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(0).Bitmap;

            characterPictureBox.Click += clickEventHandler;
        }

        public int Position
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
                characterPictureBox.BackgroundImage = characterImage = UnityAssets.GetCharaIcon(characterId).Bitmap;

                Update();
            }
        }

        public float FontSize
        {
            get => positionIndexLabel.Font.Size;
            set
            {
                positionIndexLabel.Font = new Font(positionIndexLabel.Font.Name, value);
            }
        }

        public bool Disabled
        {
            get => disabled;
            set
            {
                disabled = value;

                characterPictureBox.BackgroundImage = disabled ? null : characterImage;
            }
        }
    }
}
