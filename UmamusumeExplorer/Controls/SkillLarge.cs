using UmamsumeData;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;

namespace UmamusumeExplorer.Controls
{
    public partial class SkillLarge : UserControl
    {
        public SkillData? skill;
        public SkillData? evolutionSkill;
        public SkillBackground background;

        public SkillLarge()
        {
            InitializeComponent();
        }

        public SkillData? Skill
        {
            get => skill;
            set
            {
                if (value is null) return;

                skill = value;
                UpdateInfo(skill);

                Refresh();
            }
        }

        public SkillData? EvolutionSkill
        {
            get => evolutionSkill;
            set
            {
                if (value is null) return;

                evolutionSkill = value;
                UpdateInfo(evolutionSkill);
                evolutionInfoButton.Visible = true;

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

        private void EvolutionInfoButton_Click(object sender, EventArgs e)
        {
            if (skill is null || evolutionSkill is null) return;
            ControlHelpers.ShowFormDialogCenter(new SkillEvolutionDetailsForm(skill, evolutionSkill), this);
        }

        private void UpdateInfo(SkillData skillData)
        {
            skillNameLabel.Text = AssetTables.GetText(TextCategory.MasterSkillName, skillData.Id);
            skillDescriptionLabel.Text = AssetTables.GetText(TextCategory.MasterSkillExplain, skillData.Id)
                .Replace("\\n", "\n");
            iconPictureBox.BackgroundImage = GameAssets.GetSkillIcon(skillData.IconId)?.Bitmap;
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
