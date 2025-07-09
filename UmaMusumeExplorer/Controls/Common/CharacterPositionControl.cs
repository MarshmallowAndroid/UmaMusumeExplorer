using UmaMusumeExplorer.Game;
using Image = System.Drawing.Image;

namespace UmaMusumeExplorer.Controls.Common
{
    partial class CharacterPositionControl : UserControl
    {
        private int characterPosition = 0;
        private int characterId = 0;
        private Image? characterImage;
        private bool disabled = false;
        private bool showEx = false;

        public CharacterPositionControl(int position, EventHandler clickEventHandler, EventHandler? exCheckEventHandler, int width = -1)
        {
            InitializeComponent();

            characterPosition = position;

            positionIndexLabel.Text = (characterPosition + 1).ToString();
            characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(0)?.Bitmap;

            float ratio = (float)characterPictureBox.Height / characterPictureBox.Width;

            characterPictureBox.Click += clickEventHandler;
            exCheckBox.CheckedChanged += exCheckEventHandler;

            if (width > 0)
            {
                Width = width;
            }

            characterPictureBox.Height = (int)(characterPictureBox.Width * ratio);
            exCheckBox.Top = characterPictureBox.Top + characterPictureBox.Height + 6;

            exCheckBox.Visible = showEx;
        }

        public int Position
        {
            get { return characterPosition; }
            set
            {
                characterPosition = value;
                positionIndexLabel.Text = (value + 1).ToString();

                Update();
            }
        }

        public int CharacterId
        {
            get { return characterId; }
            set
            {
                characterId = value;
                characterPictureBox.BackgroundImage = characterImage = UnityAssets.GetCharaIcon(characterId)?.Bitmap;

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

        public bool ShowEx
        {
            get => showEx;
            set
            {
                showEx = value;
                exCheckBox.Visible = showEx;
            }
        }

        public bool ExChecked
        {
            get => exCheckBox.Checked;
            set => exCheckBox.Checked = value;
        }
    }
}
