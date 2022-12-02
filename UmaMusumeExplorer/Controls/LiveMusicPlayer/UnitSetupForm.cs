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

namespace UmaMusumeExplorer.Controls.Jukebox
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

            livePermissionData = AssetTables.LivePermissionDatas.Where(lpd => lpd.MusicId == musicId);
            if (!livePermissionData.Any())
            {
                livePermissionData = new List<LivePermissionData>();

                var matches = UmaDataHelper.GetGameAssetDataRows(ga => ga.BaseName.StartsWith($"snd_bgm_live_{musicId}_chara_") && ga.BaseName.EndsWith(".awb"));

                foreach (var audioAsset in matches)
                {
                    int charaId = int.Parse(audioAsset.BaseName.Remove(0, $"snd_bgm_live_{musicId}_chara_".Length)[..4]);

                    (livePermissionData as List<LivePermissionData>).Add(new LivePermissionData() { MusicId = musicId, CharaId = charaId });
                }
            }

            characterPositions = new CharacterPositionControl[singingMembers];

            SongConfiguration songConfiguration = LiveConfiguration.LoadConfiguration(musicId);

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

            singersPanel.Controls.AddRange(characterPositions);
        }

        public CharacterPositionControl[] CharacterPositions { get; private set; } = null;

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
                members[PositionToIndex(i, pivot)] = characterPositions[i].CharacterId;
            }

            SongConfiguration songConfiguration = new(id, members);
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
