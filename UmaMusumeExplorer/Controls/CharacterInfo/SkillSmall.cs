using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SkillSmall : UserControl
    {
        private int skillLevel;
        private SkillBackground rarity;
        private SkillData? evolveSkill;

        public SkillSmall(SkillData skill)
        {
            InitializeComponent();

            skillNameLabel.Text = AssetTables.GetText(TextCategory.MasterSkillName, skill.Id);
            iconPictureBox.Image = UnityAssets.GetSkillIcon(skill.IconId)?.Bitmap;

            Skill = skill;

            skillLevel = 0;
            rarity = SkillBackground.Rarity1;
            evolveSkill = null;

            Click += OnSkillClicked;
            iconPictureBox.Click += OnSkillClicked;
            skillNameLabel.Click += OnSkillClicked;
            levelLabel.Click += OnSkillClicked;
        }

        public SkillData Skill { get; }

        public int SkillLevel
        {
            get => skillLevel;
            set
            {
                if (value > 0)
                    levelLabel.Text = $"Lv{value}";
                else
                    levelLabel.Text = "";

                skillLevel = value;

                Invalidate();
            }
        }

        public SkillBackground Background
        {
            get => rarity;
            set
            {
                rarity = value;
                Invalidate();
            }
        }

        public SkillData? EvolveSkill
        {
            get => evolveSkill;
            set
            {
                evolutionCircle.Visible = value is not null;
                evolveSkill = value;
                Invalidate();
            }
        }

        public event EventHandler? SkillClick;

        private void OnSkillClicked(object? sender, EventArgs e)
        {
            SkillClick?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush mainBrush = SkillColorGenerator.ColorFromType(rarity, ClientRectangle, out Brush backgroundBrush);

            Rectangle paddedRectangle = ClientRectangle;
            paddedRectangle.X += 2;
            paddedRectangle.Y += 2;
            paddedRectangle.Width -= 4;
            paddedRectangle.Height -= 4;

            e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);
            e.Graphics.FillRectangle(mainBrush, paddedRectangle);
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(127, 255, 255, 255)),
                paddedRectangle);

            base.OnPaint(e);
        }
    }
}
