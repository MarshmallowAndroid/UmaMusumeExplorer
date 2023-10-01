using System.Net.Security;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class CharacterSelectForm : Form
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;
        private readonly IEnumerable<LivePermissionData> livePermissionData;
        private readonly List<int> allowedCharas = new();
        private readonly List<int> alreadySelected = new();

        public CharacterSelectForm(IEnumerable<LivePermissionData> permissionData, CharacterPosition[] characters)
        {
            InitializeComponent();

            livePermissionData = permissionData;
            foreach (var lpd in livePermissionData)
            {
                allowedCharas.Add(lpd.CharaId);
            }

            foreach (var character in characters)
            {
                alreadySelected.Add(character.CharacterId);
            }

            characterItemsPanel.Filter = (cd) =>
            {
                return allowedCharas.Contains(cd.Id);
            };
            characterItemsPanel.LoadingFinished += (s, e) =>
            {
                foreach (PictureBox charaIcon in characterItemsPanel.Controls)
                {
                    if (charaIcon.Tag as CharaData is not CharaData cd) return;
                    if (alreadySelected.Contains(cd.Id)) charaIcon.BackColor = Color.FromArgb(234, 54, 128);
                }
            };
            characterItemsPanel.ItemClick += (s, e) =>
            {
                if (s is not PictureBox pictureBox) return;
                if (pictureBox.Tag is not CharaData cd) return;
                SelectedCharacter = cd.Id;
                Close();
            };
        }

        public int SelectedCharacter { get; private set; } = 0;

        private void CharacterSelectForm_Load(object sender, EventArgs e)
        {
            characterItemsPanel.Items = charaDatas;
        }
    }
}
