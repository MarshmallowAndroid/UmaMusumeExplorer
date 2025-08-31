using System.Data;
using UmamsumeData.Tables;

namespace UmamusumeExplorer.Controls
{
    public partial class SkillEvolutionsForm : Form
    {
        public SkillEvolutionsForm(SkillData skill, IEnumerable<SkillData> evolutionSkills)
        {
            InitializeComponent();

            toEvolveSkill.Skill = skill;

            evolvedSkill1.Skill = skill;
            evolvedSkill1.EvolutionSkill = evolutionSkills.First();

            SkillData? evolutionSkill2 = evolutionSkills.ElementAtOrDefault(1);
            if (evolutionSkill2 is not null)
            {
                evolvedSkill2.Skill = skill;
                evolvedSkill2.EvolutionSkill = evolutionSkill2;
            }
            else
                evolvedSkill2.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
