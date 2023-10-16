using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.Common
{
    internal class HighlightPictureBox : HighQualityPictureBox
    {
        private bool highlight = false;
        private readonly bool marked;
        private System.Drawing.Image? image;

        public HighlightPictureBox(bool isMarked)
        {
            marked = isMarked;
            image = Image;
        }

        public bool ShowHighlight
        {
            get => highlight;
            set
            {
                if (marked && value)
                {
                    BackColor = Color.LightGreen;
                    Image = null;
                }
                else
                {
                    BackColor = Color.FromKnownColor(KnownColor.Transparent);
                    Image = image;
                }

                highlight = value;
            }
        }
    }
}
