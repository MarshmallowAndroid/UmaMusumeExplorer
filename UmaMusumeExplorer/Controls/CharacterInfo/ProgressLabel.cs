using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    internal class ProgressLabel : Label
    {
        private float progress;

        public float Progress
        {
            get => progress;
            set
            {
                progress = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.Clear(BackColor);
            Rectangle drawRectangle = e.ClipRectangle;
            drawRectangle.Width = (int)(drawRectangle.Width * progress);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), drawRectangle);

            base.OnPaint(e);
        }
    }
}
