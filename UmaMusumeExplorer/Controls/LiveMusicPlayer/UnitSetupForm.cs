using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class UnitSetupForm : Form
    {
        private readonly int id;
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private CharacterPosition[] characterPositions;

        public UnitSetupForm(int musicId, int singingMembers)
        {
            InitializeComponent();

            id = musicId;
            livePermissionData = LivePermissionDataHelper.GetLivePermissionData(musicId);
            characterPositions = new CharacterPosition[singingMembers];

            Text = AssetTables.GetText(TextCategory.MasterLiveTitle, id) + " " + Text;

            LoadSongConfiguration();
        }

        public CharacterPosition[] CharacterPositions { get; private set; } = null;

        public bool Sfx => sfxCheckBox.Checked;

        public void LoadSongConfiguration()
        {
            SongConfiguration songConfiguration = LiveConfiguration.LoadConfiguration(id);

            CharacterPositionControl[] controls = new CharacterPositionControl[characterPositions.Length];

            int pivot = characterPositions.Length / 2;
            for (int i = 0; i < characterPositions.Length; i++)
            {
                int characterId;
                if (songConfiguration is not null)
                    characterId = songConfiguration.Members[i];
                else
                    characterId = livePermissionData.ElementAt(i).CharaId;

                CharacterPositionControl characterPositionControl = new(i, CharacterPositionPictureBoxClick)
                {
                    CharacterId = characterId,
                    TabIndex = i
                };

                int positionAsIndex = PositionToIndex(i, pivot);
                controls[positionAsIndex] = characterPositionControl;
                characterPositions[positionAsIndex].CharacterId = characterId;
                characterPositions[positionAsIndex].Position = i;
            }

            if (characterPositions.Length == 1)
            {
                Control[] fixedControls = new Control[3];

                fixedControls[0] = new()
                {
                    Width = controls[0].Width,
                    Height = controls[0].Height
                };
                fixedControls[1] = controls[0];
                fixedControls[2] = new()
                {
                    Width = controls[0].Width,
                    Height = controls[0].Height
                };

                singersPanel.Controls.AddRange(fixedControls);
            }
            else
                singersPanel.Controls.AddRange(controls);

            if (songConfiguration is not null)
                sfxCheckBox.Checked = songConfiguration.Sfx;
        }

        public void CharacterPositionPictureBoxClick(object sender, EventArgs e)
        {
            if (sender is not PictureBox characterPositionPixtureBox) return;
            if (characterPositionPixtureBox.Parent is not CharacterPositionControl clickedCharacterPositionControl) return;

            int initialCharacter = clickedCharacterPositionControl.CharacterId;

            CharacterSelectForm characterSelectForm = new(livePermissionData, characterPositions);
            ControlHelpers.ShowFormDialogCenter(characterSelectForm, this);

            int selectedCharacter = characterSelectForm.SelectedCharacter;

            if (selectedCharacter == 0) return;

            foreach (CharacterPositionControl characterPosition in singersPanel.Controls)
            {
                if (characterPosition.CharacterId == selectedCharacter)
                    characterPosition.CharacterId = initialCharacter;
            }

            clickedCharacterPositionControl.CharacterId = selectedCharacter;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            CharacterPositions = characterPositions;

            int pivot = characterPositions.Length / 2;
            int[] members = new int[characterPositions.Length];

            for (int i = 0; i < characterPositions.Length; i++)
            {
                int positionAsIndex = PositionToIndex(i, pivot);
                int characterId = (singersPanel.Controls[positionAsIndex] as CharacterPositionControl).CharacterId;
                members[i] = CharacterPositions[positionAsIndex].CharacterId = characterId;
                CharacterPositions[positionAsIndex].Position = i;
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
