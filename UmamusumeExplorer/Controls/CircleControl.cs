using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;

namespace UmamusumeExplorer.Controls
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
