using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class UnitSetupForm : Form
    {
        private readonly int id;
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private readonly CharacterPositionControl[] characterPositions;

        public UnitSetupForm(int musicId, int singingMembers)
        {
            InitializeComponent();

            id = musicId;
            livePermissionData = LivePermissionDataHelper.GetLivePermissionData(musicId);
            characterPositions = new CharacterPositionControl[singingMembers];

            LoadSongConfiguration();
        }

        public CharacterPositionControl[] CharacterPositions { get; private set; } = null;

        public bool Sfx => sfxCheckBox.Checked;

        public void LoadSongConfiguration()
        {
            SongConfiguration songConfiguration = LiveConfiguration.LoadConfiguration(id);

            int pivot = characterPositions.Length / 2;
            for (int i = 0; i < characterPositions.Length; i++)
            {
                CharacterPositionControl characterPositionControl = new(i + 1, this)
                {
                    TabIndex = i
                };

                if (songConfiguration is not null)
                    characterPositionControl.CharacterId = songConfiguration.Members[i];
                else
                    characterPositionControl.CharacterId = livePermissionData.ElementAt(i).CharaId;

                characterPositions[PositionToIndex(i, pivot)] = characterPositionControl;
            }

            if (characterPositions.Length == 1)
            {
                Control[] fixedControls = new Control[3];

                fixedControls[0] = new()
                {
                    Width = characterPositions[0].Width,
                    Height = characterPositions[0].Height
                };
                fixedControls[1] = characterPositions[0];
                fixedControls[2] = new()
                {
                    Width = characterPositions[0].Width,
                    Height = characterPositions[0].Height
                };

                singersPanel.Controls.AddRange(fixedControls);
            }
            else
                singersPanel.Controls.AddRange(characterPositions);

            if (songConfiguration is not null)
                sfxCheckBox.Checked = songConfiguration.Sfx;
        }

        public void CharacterPositionPictureBoxClick(object sender, EventArgs e)
        {
            PictureBox characterPositionPixtureBox = sender as PictureBox;
            CharacterPositionControl characterPositionControl = characterPositionPixtureBox.Parent as CharacterPositionControl;

            int initialCharacter = characterPositionControl.CharacterId;

            CharacterSelectForm characterSelectForm = new(livePermissionData, characterPositions);
            ControlHelpers.ShowFormDialogCenter(characterSelectForm, this);

            int selectedCharacter = characterSelectForm.SelectedCharacter;

            if (selectedCharacter == 0) return;

            foreach (var characterPosition in characterPositions)
            {
                if (characterPosition.CharacterId == selectedCharacter)
                {
                    characterPosition.CharacterId = initialCharacter;
                }
            }

            characterPositionControl.CharacterId = selectedCharacter;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            CharacterPositions = characterPositions;

            int pivot = characterPositions.Length / 2;
            int[] members = new int[characterPositions.Length];
            for (int i = 0; i < characterPositions.Length; i++)
            {
                members[i] = characterPositions[PositionToIndex(i, pivot)].CharacterId;
            }

            SongConfiguration songConfiguration = new(id, members, sfxCheckBox.Checked);
            LiveConfiguration.SaveConfiguration(songConfiguration);

            Close();
        }

        private static int PositionToIndex(int position, int pivot)
        {
            if (position == 0) return pivot;

            int divide;
            if (position % 2 == 0)
            {
                divide = position / 2;
                return pivot + divide;
            }
            else
            {
                divide = (position + 1) / 2;
                return pivot - divide;
            }
        }
    }
}
