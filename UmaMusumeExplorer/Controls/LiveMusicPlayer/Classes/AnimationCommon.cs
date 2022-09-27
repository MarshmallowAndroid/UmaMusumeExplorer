using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    public static class AnimationCommon
    {
        public delegate float EasingFunction(float progress);

        public static int AnimateValue(int from, int to, float progress, EasingFunction easingFunction)
        {
            progress = Math.Clamp(progress, 0.0f, 1.0f);

            float ease = easingFunction(progress);

            int difference = to - from;
            return from + MultiplyProgress(ease, difference);
        }

        public static Color AnimateColor(Color from, Color to, float progress, EasingFunction easingFunction)
        {
            progress = Math.Clamp(progress, 0.0f, 1.0f);

            float ease = easingFunction(progress);

            int differenceR = to.R - from.R;
            int differenceG = to.G - from.G;
            int differenceB = to.B - from.B;

            int newR = from.R + MultiplyProgress(ease, differenceR);
            int newG = from.G + MultiplyProgress(ease, differenceG);
            int newB = from.B + MultiplyProgress(ease, differenceB);

            return Color.FromArgb(newR, newG, newB);
        }

        private static int MultiplyProgress(float progress, int value)
        {
            if (value < 0)
            {
                value = (int)Math.Floor(progress * value);
            }
            else
            {
                value = (int)Math.Ceiling(progress * value);
            }

            return value;
        }
    }
}
