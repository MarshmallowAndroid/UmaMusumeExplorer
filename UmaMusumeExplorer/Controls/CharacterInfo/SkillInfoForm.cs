using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;
using static UmaMusumeExplorer.Controls.CharacterInfo.SkillButtonSmall;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SkillInfoForm : Form
    {
        private readonly SkillRarity rarity;

        public SkillInfoForm(int skillId)
        {
            InitializeComponent();

            SkillData skillData = AssetTables.SkillDatas.First(s => s.Id == skillId);
            rarity = (SkillRarity)skillData.Rarity;

            iconPictureBox.BackgroundImage = UnityAssets.GetSkillIcon(skillData.IconId).Bitmap;
            skillNameLabel.Text = AssetTables.SkillNameTextDatas.First(s => s.Index == skillId).Text;
            skillInfoLabel.Text = AssetTables.SkillInfoTextDatas.First(s => s.Index == skillId).Text
                .Replace("\\n", "\n");

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
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
