using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Assets;

namespace UmaMusumeExplorer.Controls
{
    public partial class SkillEvolutionConditionContainer : UserControl
    {
        private readonly IEnumerable<SkillUpgradeCondition> conditions;
        private readonly int defaultHeight;

        public SkillEvolutionConditionContainer(IEnumerable<SkillUpgradeCondition> upgradeConditions)
        {
            InitializeComponent();

            SkillUpgradeCondition firstCondition = upgradeConditions.First();

            conditionNumberLabel.Text = $"Condition {firstCondition.Num}";
            conditions = upgradeConditions;

            defaultHeight = conditionNumberLabel.Top + conditionNumberLabel.Height + conditionNumberLabel.Margin.Vertical;
            Height = defaultHeight;

            if (upgradeConditions.Count() == 1)
            {
                conditionDescription.Text = AssetTables.GetText(TextCategory.SkillUpgrade1, firstCondition.Id);
                conditionsPanel.Height = 0;
            }
        }

        private void SkillEvolutionConditionMultiple_Load(object sender, EventArgs e)
        {
            if (conditions.Count() > 1)
            {
                conditionsPanel.Height = 0;
                foreach (var condition in conditions)
                {
                    SkillEvolutionConditionItem conditionSingle = new(condition);
                    conditionSingle.Width = conditionsPanel.Width - conditionSingle.Margin.Horizontal;
                    conditionsPanel.Controls.Add(conditionSingle);

                    conditionsPanel.Height += conditionSingle.Height + conditionSingle.Margin.Vertical;
                }

                Height += conditionsPanel.Height + conditionsPanel.Margin.Bottom;
            }
        }
    }
}
