using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    internal class CircleControl : Label
    {
        public CircleControl() : base()
        {   
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle clip = e.ClipRectangle;
            clip.Width -= 1;
            clip.Height -= 1;

            e.Graphics.FillEllipse(new SolidBrush(ForeColor), clip);

            base.OnPaint(e);
        }
    }
}
