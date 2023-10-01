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
        private readonly CharacterPosition[] characterPositions;

        public UnitSetupForm(int musicId, int singingMembers)
        {
            InitializeComponent();

            id = musicId;
            livePermissionData = LivePermissionDataHelper.GetLivePermissionData(musicId);
            characterPositions = new CharacterPosition[singingMembers];

            Text = AssetTables.GetText(TextCategory.MasterLiveTitle, id) + " " + Text;

            LoadSongConfiguration();
        }

        public CharacterPosition[]? CharacterPositions { get; private set; } = null;

        public bool Sfx => sfxCheckBox.Checked;

        public void LoadSongConfiguration()
        {
            SongConfiguration? songConfiguration = LiveConfiguration.LoadConfiguration(id);

            CharacterPositionControl[] controls = new CharacterPositionControl[characterPositions.Length];

            int characterCount = characterPositions.Length;
            int pivot = characterCount / 2;
            for (int i = 0; i < characterCount; i++)
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

            if (characterCount <= 2)
            {
                int newCount = characterCount + 2;
                int newPivot = newCount / 2;
                Control[] fixedControls = new Control[newCount];

                for (int i = 0; i < newCount; i++)
                {
                    Control? control = null;
                    if (i < characterCount)
                        control = controls[i];
                    else
                        control = new()
                        {
                            Width = controls[0].Width,
                            Height = controls[0].Height
                        };


                    fixedControls[PositionToIndex(i, newPivot)] = control;
                }

                singersPanel.Controls.AddRange(fixedControls);
            }
            else
                singersPanel.Controls.AddRange(controls);

            if (songConfiguration is not null)
                sfxCheckBox.Checked = songConfiguration.Sfx;
        }

        public void CharacterPositionPictureBoxClick(object? sender, EventArgs e)
        {
            if (sender is not PictureBox characterPositionPixtureBox) return;
            if (characterPositionPixtureBox.Parent is not CharacterPositionControl clickedCharacterPositionControl) return;

            int initialCharacter = clickedCharacterPositionControl.CharacterId;

            CharacterSelectForm characterSelectForm = new(livePermissionData, characterPositions);
            ControlHelpers.ShowFormDialogCenter(characterSelectForm, this);

            int selectedCharacter = characterSelectForm.SelectedCharacter;
            if (selectedCharacter == 0) return;

            foreach (Control control in singersPanel.Controls)
            {
                if (control is not CharacterPositionControl characterPosition) continue;

                if (characterPosition.CharacterId == selectedCharacter)
                    characterPosition.CharacterId = initialCharacter;
            }

            clickedCharacterPositionControl.CharacterId = selectedCharacter;

            UpdateCharacterPositions();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            int pivot = characterPositions.Length / 2;
            int[] members = new int[characterPositions.Length];

            for (int i = 0; i < characterPositions.Length; i++)
            {
                CharacterPosition characterPosition = characterPositions[i];
                members[characterPosition.Position] = characterPosition.CharacterId;
            }

            SongConfiguration songConfiguration = new(id, members, sfxCheckBox.Checked);
            LiveConfiguration.SaveConfiguration(songConfiguration);

            CharacterPositions = characterPositions;

            Close();
        }

        private void UpdateCharacterPositions()
        {
            foreach (Control control in singersPanel.Controls)
            {
                if (control is not CharacterPositionControl characterPositionControl) continue;

                int index = characterPositionControl.Position;
                int characterId = characterPositionControl.CharacterId;
                characterPositions[index].CharacterId = characterId;
                characterPositions[index].Position = index;
            }
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
