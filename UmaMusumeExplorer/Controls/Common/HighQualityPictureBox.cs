using System.Drawing.Drawing2D;

namespace UmaMusumeExplorer.Controls.Common
{
    internal class HighQualityPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(pe);
        }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaintBackground(pe);
        }
    }
}
