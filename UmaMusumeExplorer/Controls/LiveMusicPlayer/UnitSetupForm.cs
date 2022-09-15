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

        public UnitSetupForm(IEnumerable<LivePermissionData> permissionData, int singingMembers)
        {
            InitializeComponent();

            livePermissionData = permissionData;         

            CharacterPositions = new CharacterPositionControl[singingMembers];

            int pivot = CharacterPositions.Length / 2;
            for (int i = 0; i < CharacterPositions.Length; i++)
            {
                CharacterPositionControl characterPositionControl = new CharacterPositionControl(i + 1, livePermissionData, this);
                characterPositionControl.CharacterID = livePermissionData.ElementAt(i).CharaId;
                CharacterPositions[PositionToIndex(i, pivot)] = characterPositionControl;
            }

            singersPanel.Controls.AddRange(CharacterPositions.ToArray());
        }

        public CharacterPositionControl[] CharacterPositions { get; private set; }

        public void CharacterPositionPictureBoxClick(object sender, EventArgs e)
        {
            PictureBox characterPositionPixtureBox = sender as PictureBox;
            CharacterPositionControl characterPositionControl = characterPositionPixtureBox.Parent as CharacterPositionControl;

            int initialCharacter = characterPositionControl.CharacterID;

            CharacterSelectForm characterSelectForm = new(livePermissionData);
            ControlHelpers.ShowFormDialogCenter(characterSelectForm, this);

            int selectedCharacter = characterSelectForm.SelectedCharacter;

            if (selectedCharacter == 0) return;

            foreach (var characterPosition in CharacterPositions)
            {
                if (characterPosition.CharacterID == selectedCharacter)
                {
                    characterPosition.CharacterID = initialCharacter;
                }
            }

            characterPositionControl.CharacterID = selectedCharacter;
        }

        private void UnitSetupForm_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

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
