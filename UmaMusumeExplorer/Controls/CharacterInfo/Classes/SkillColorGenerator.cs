using System.Drawing.Drawing2D;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    internal static class SkillColorGenerator
    {
        public static Brush ColorFromType(SkillBackground rarity, Rectangle colorBounds, out Brush backgroundBrush)
        {
            Color[] colors = { Color.White, Color.LightSteelBlue };
            float[] positions = { 0F, 1F };

            backgroundBrush = new SolidBrush(Color.LightSteelBlue);

            bool duplicateBackground = false;

            switch (rarity)
            {
                case SkillBackground.Rarity2:
                    colors = new[]
                    {
                        Color.LightYellow,
                        Color.Gold
                    };
                    backgroundBrush = new SolidBrush(Color.Gold);
                    break;
                case SkillBackground.Rarity3:
                case SkillBackground.Rarity4:
                case SkillBackground.Rarity5:
                    colors = new[] {
                        Color.LightGreen,
                        Color.DeepSkyBlue,
                        Color.BlueViolet,
                        Color.DeepPink
                    };
                    positions = new[] { 0F, 1 / 3F, 2 / 3F, 1F };
                    duplicateBackground = true;
                    break;
                case SkillBackground.Evolution:
                    colors = new[]
                    {
                        Color.Pink,
                        Color.HotPink
                    };
                    backgroundBrush = new SolidBrush(Color.HotPink);
                    break;
                default:
                    break;
            }

            LinearGradientBrush linearGradientBrush = new(colorBounds, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend colorBlend = new();
            colorBlend.Positions = positions;
            colorBlend.Colors = colors;
            linearGradientBrush.InterpolationColors = colorBlend;

            if (duplicateBackground)
                backgroundBrush = linearGradientBrush;

            return linearGradientBrush;
        }
    }
}
