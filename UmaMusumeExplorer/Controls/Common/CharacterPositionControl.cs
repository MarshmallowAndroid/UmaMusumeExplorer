﻿using UmaMusumeExplorer.Game;
using Image = System.Drawing.Image;

namespace UmaMusumeExplorer.Controls.Common
{
    partial class CharacterPositionControl : UserControl
    {
        private int characterPosition = 0;
        private int characterId = 0;
        private Image? characterImage;
        private bool disabled = false;

        public CharacterPositionControl(int position, EventHandler clickEventHandler, int width = -1)
        {
            InitializeComponent();

            characterPosition = position;

            positionIndexLabel.Text = (characterPosition + 1).ToString();
            characterPictureBox.BackgroundImage = UnityAssets.GetCharaIcon(0)?.Bitmap;

            characterPictureBox.Click += clickEventHandler;

            if (width > 0)
            {
                Width = width;
                characterPictureBox.Height = (int)(characterPictureBox.Width * 1.1F);
            }
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
    }
}
