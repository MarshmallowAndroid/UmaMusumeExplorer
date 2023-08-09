using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class SkillEvolutionDetailsForm : Form
    {
        private readonly IEnumerable<SkillUpgradeCondition> skillUpgradeConditions = AssetTables.SkillUpgradeConditions;
        private readonly int evolutionSkillId;

        public SkillEvolutionDetailsForm(SkillData skill, SkillData evolutionSkill)
        {
            InitializeComponent();

            toEvolveSkill.Skill = skill;
            evolvedSkill.Skill = evolutionSkill;

            evolutionSkillId = evolutionSkill.Id;
        }

        private void SkillEvolutionDetailsForm_Load(object sender, EventArgs e)
        {
            IEnumerable<SkillUpgradeCondition> matchingConditions = skillUpgradeConditions.Where(s => s.DescriptionId == evolutionSkillId);

            int previousNum = matchingConditions.First().Num;
            List<SkillUpgradeCondition> currentConditions = new();
            foreach (var condition in matchingConditions)
            {
                if (condition.Num != previousNum)
                {
                    AddConditions(currentConditions);
                    currentConditions.Clear();
                }

                currentConditions.Add(condition);
                previousNum = condition.Num;
            }

            AddConditions(currentConditions);
        }

        private void AddConditions(IEnumerable<SkillUpgradeCondition> currentConditions)
        {
            SkillEvolutionConditionContainer conditionMultiple = new(currentConditions);
            conditionMultiple.Width = evolveConditionsPanel.Width - conditionMultiple.Margin.Horizontal - SystemInformation.VerticalScrollBarWidth;
            evolveConditionsPanel.Controls.Add(conditionMultiple);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
