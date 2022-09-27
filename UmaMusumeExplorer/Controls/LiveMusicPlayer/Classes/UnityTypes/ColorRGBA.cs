using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes.UnityTypes
{
    internal class ColorRGBA
    {
        public ColorRGBA()
        {
        }

        public ColorRGBA(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public float R { get; set; }

        public float G { get; set; }

        public float B { get; set; }

        public float A { get; set; }

        public System.Drawing.Color ToColor()
        {
            int r = (int)Math.Clamp(255 * R, 0, 255);
            int g = (int)Math.Clamp(255 * G, 0, 255);
            int b = (int)Math.Clamp(255 * B, 0, 255);
            int a = 255;

            return System.Drawing.Color.FromArgb(a, r, g, b);
        }
    }
}
