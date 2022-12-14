using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    internal class DoubleBufferedTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferedTableLayoutPanel()
        {
            DoubleBuffered = true;
        }
    }
}
