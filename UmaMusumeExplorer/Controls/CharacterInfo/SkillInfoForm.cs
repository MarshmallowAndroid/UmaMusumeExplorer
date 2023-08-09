using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Controls.CharacterInfo;
using UmaMusumeExplorer.Game;
using UmaMusumeData;

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
            skillNameLabel.Text = AssetTables.GetText(AssetTables.SkillNameTextDatas, skillId);
            skillNameLabel.Text = AssetTables.GetText(TextCategory.MasterSkillName, skill.Id);
            skillDescriptionLabel.Text = AssetTables.GetText(TextCategory.MasterSkillExplain, skill.Id)
                .Replace("\\n", "\n");

            FormBorderStyle = FormBorderStyle.FixedSingle;

            int frameBorder = SystemInformation.BorderSize.Height;

            Size newSize = Size;
            newSize.Height -= SystemInformation.CaptionHeight + ((SystemInformation.FrameBorderSize.Height + SystemInformation.VerticalResizeBorderThickness - 1) * 2);
            newSize.Width -= (SystemInformation.FrameBorderSize.Width + SystemInformation.HorizontalResizeBorderThickness - 1) * 2;

            Size = newSize;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = ClientRectangle;

            Brush colorBrush = RarityColorGenerator.ColorFromRarity(rarity, rectangle);

            Rectangle paddedRectangle = rectangle;
            paddedRectangle.X += 4;
            paddedRectangle.Y += 4;
            paddedRectangle.Width -= 10;
            paddedRectangle.Height -= 10;

            GraphicsPath path = new();
            int diameter = 12;
            Rectangle arc = new(paddedRectangle.Location, new Size(diameter, diameter));
            path.AddArc(arc, 180, 90);
            arc.X = paddedRectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = paddedRectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = paddedRectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.FillRectangle(colorBrush, rectangle);
            //e.Graphics.FillRectangle(
            //    new SolidBrush(Color.FromArgb(127, 255, 255, 255)),
            //    paddedRectangle);
            e.Graphics.FillPath(
                new SolidBrush(Color.FromArgb(127, 255, 255, 255)),
                //new SolidBrush(Color.FromArgb(255, 24, 24, 24)),
                path);
            //e.Graphics.FillPath(linearGradientBrush, path);

            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 131:
                    //if (m.WParam.ToInt32() != 0)
                    {
                        NCCALCSIZE_PARAMS ncp = Marshal.PtrToStructure<NCCALCSIZE_PARAMS>(m.LParam);

                        //ncp.rgrc[0].Top += SystemInformation.CaptionHeight + y;
                        //ncp.rgrc[0].Left += x;
                        //ncp.rgrc[0].bottom -= y;
                        //ncp.rgrc[0].Right -= x;

                        ncp.rgrc[0].top += 1;
                        ncp.rgrc[0].left += 1;
                        //ncp.rgrc[0].bottom -= 1;
                        //ncp.rgrc[0].right -= 1;

                        Marshal.StructureToPtr(ncp, m.LParam, true);

                        m.Result = 0;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        struct NCCALCSIZE_PARAMS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public RECT[] rgrc;
            public nint lppos;
        }
    }
}
