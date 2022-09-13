using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    public partial class CharacterPositionControl : UserControl
    {
        private int characterIndex = 0;

        public CharacterPositionControl()
        {
            InitializeComponent();

            positionIndexLabel.Text = characterIndex.ToString();
        }

        public int CharacterIndex
        {
            get { return characterIndex; }
            set
            {
                characterIndex = value;
                positionIndexLabel.Text = value.ToString();

                Update();
            }
        }

        private void CharacterPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
