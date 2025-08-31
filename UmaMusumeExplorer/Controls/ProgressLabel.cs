using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;

namespace UmaMusumeExplorer.Controls
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
