using AssetStudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    public partial class UnitSetupForm : Form
    {
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private readonly CharacterPositionControl[] characterPositions;

        public UnitSetupForm(IEnumerable<LivePermissionData> permissionData, int singingMembers, IEnumerable<int> characterIds)
        {
            InitializeComponent();

            livePermissionData = permissionData;

            characterPositions = new CharacterPositionControl[singingMembers];

            int pivot = characterPositions.Length / 2;
            for (int i = 0; i < characterPositions.Length; i++)
            {
                CharacterPositionControl characterPositionControl = new CharacterPositionControl(i + 1, livePermissionData, this);

                if (characterIds.Any())
                    characterPositionControl.CharacterId = characterIds.ElementAt(i);
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

            CharacterSelectForm characterSelectForm = new(livePermissionData);
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
