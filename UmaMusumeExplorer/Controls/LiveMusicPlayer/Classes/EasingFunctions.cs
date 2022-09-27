using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    public static class EasingFunctions
    {
        public static float Linear(float x)
        {
            return x;
        }

        public static float EaseOutExpo(float x)
        {
            return (float)(x == 1f ? 1f : 1f - Math.Pow(2f, -10f * x));
        }

        public static float EaseInOutCubic(float x)
        {
            return (float)(x < 0.5f ? 4f * x * x * x : 1f - Math.Pow(-2f * x + 2f, 3f) / 2.0f);
        }

        public static float EaseInOutQuart(float x)
        {
            return (float)(x < 0.5f ? 8f * x * x * x * x : 1f - Math.Pow(-2f * x + 2f, 4f) / 2f);
        }
    }
}
