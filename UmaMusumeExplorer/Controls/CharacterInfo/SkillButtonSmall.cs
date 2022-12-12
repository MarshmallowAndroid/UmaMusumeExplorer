using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SkillButtonSmall : UserControl
    {
        private string skillName;
        private int level;
        private SkillRarity rarity;
        private int iconId;

        public SkillButtonSmall()
        {
            InitializeComponent();

            skillName = Name;
            level = 0;
            rarity = SkillRarity.Rarity1;
            iconId = 0;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public string SkillName
        {
            get => skillName;
            set
            {
                skillNameLabel.Text = value;
                skillName = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public int SkillLevel
        {
            get => level;
            set
            {
                if (value > 0)
                    levelLabel.Text = $"Lv{value}";
                else
                    levelLabel.Text = "";

                level = value;

                Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public SkillRarity Rarity
        {
            get => rarity;
            set
            {
                rarity = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public int IconId
        {
            get => iconId;
            set
            {
                iconPictureBox.BackgroundImage = UnityAssets.GetSkillIcon(value).Bitmap;
                iconPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                iconId = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color[] colors = { Color.White, Color.LightSteelBlue };
            float[] positions = { 0F, 1F };

            switch (Rarity)
            {
                case SkillRarity.Rarity2:
                case SkillRarity.Rarity3:
                case SkillRarity.Rarity4:
                    colors = new[]
                    {
                        Color.LightYellow,
                        Color.Gold
                    };
                    break;
                case SkillRarity.Rarity5:
                    colors = new[] {
                        Color.SpringGreen,
                        Color.DeepSkyBlue,
                        Color.BlueViolet,
                        Color.DeepPink
                    };
                    positions = new[] { 0F, 1 / 3F, 2 / 3F, 1F };
                    break;
                default:
                    break;
            }

            LinearGradientBrush linearGradientBrush = new(ClientRectangle, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend colorBlend = new();
            colorBlend.Positions = positions;
            colorBlend.Colors = colors;
            linearGradientBrush.InterpolationColors = colorBlend;

            Rectangle paddedRectangle = ClientRectangle;
            paddedRectangle.X += 2;
            paddedRectangle.Y += 2;
            paddedRectangle.Width -= 4;
            paddedRectangle.Height -= 4;

            e.Graphics.FillRectangle(linearGradientBrush, ClientRectangle);
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(127, 255, 255, 255)),
                paddedRectangle);

            base.OnPaint(e);
        }

        public enum SkillRarity
        {
            Rarity1 = 1,
            Rarity2 = 2,
            Rarity3 = 3,
            Rarity4 = 4,
            Rarity5 = 5
        }
    }
}
