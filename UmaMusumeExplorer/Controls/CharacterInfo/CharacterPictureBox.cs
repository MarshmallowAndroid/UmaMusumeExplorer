using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeExplorer.Controls.Common;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    internal class CharacterPictureBox : HighQualityPictureBox
    {
        private bool showPlayability = false;
        private readonly bool isPlayable;

        public CharacterPictureBox(bool playable)
        {
            isPlayable = playable;
        }

        public bool ShowPlayability
        {
            get => showPlayability;
            set
            {
                if (isPlayable && value)
                    BackColor = Color.LightGreen;
                else
                    BackColor = Color.FromKnownColor(KnownColor.Control);

                showPlayability = value;
            }
        }
    }
}
