using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    internal static class RarityColorGenerator
    {
        public static Brush ColorFromRarity(SkillRarity rarity, Rectangle colorBounds)
        {
            Color[] colors = { Color.White, Color.LightSteelBlue };
            float[] positions = { 0F, 1F };

            switch (rarity)
            {
                case SkillRarity.Rarity2:
                    colors = new[]
                    {
                        Color.LightYellow,
                        Color.Gold
                    };
                    break;
                case SkillRarity.Rarity3:
                case SkillRarity.Rarity4:
                case SkillRarity.Rarity5:
                    colors = new[] {
                        Color.LightGreen,
                        Color.DeepSkyBlue,
                        Color.BlueViolet,
                        Color.DeepPink
                    };
                    positions = new[] { 0F, 1 / 3F, 2 / 3F, 1F };
                    break;
                default:
                    break;
            }

            LinearGradientBrush linearGradientBrush = new(colorBounds, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend colorBlend = new();
            colorBlend.Positions = positions;
            colorBlend.Colors = colors;
            linearGradientBrush.InterpolationColors = colorBlend;

            return linearGradientBrush;
        }
    }
}
