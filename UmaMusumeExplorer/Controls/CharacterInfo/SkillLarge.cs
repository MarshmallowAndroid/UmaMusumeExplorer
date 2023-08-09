using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SkillLarge : UserControl
    {
        public SkillData skill;
        public SkillBackground background;

        public SkillLarge()
        {
            InitializeComponent();
        }

        public SkillData Skill
        {
            get => skill;
            set
            {
                if (value is null) return;

                skill = value;

                skillNameLabel.Text = AssetTables.GetText(TextCategory.MasterSkillName, skill.Id);
                skillDescriptionLabel.Text = AssetTables.GetText(TextCategory.MasterSkillExplain, skill.Id)
                    .Replace("\\n", "\n");
                iconPictureBox.BackgroundImage = UnityAssets.GetSkillIcon(skill.IconId).Bitmap;

                Refresh();
            }
        }

        public SkillBackground Background
        {
            get => background;
            set
            {
                background = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brush = SkillColorGenerator.ColorFromType(Background, ClientRectangle, out Brush backgroundBrush);

            Rectangle paddedRectangle = ClientRectangle;
            paddedRectangle.X += 2;
            paddedRectangle.Y += 2;
            paddedRectangle.Width -= 4;
            paddedRectangle.Height -= 4;

            e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);
            e.Graphics.FillRectangle(brush, paddedRectangle);
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(127, 255, 255, 255)),
                paddedRectangle);

            base.OnPaint(e);
        }
    }
}
