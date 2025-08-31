using UmamsumeData;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;

namespace UmamusumeExplorer.Controls
{
    public partial class SkillEvolutionConditionItem : UserControl
    {
        public SkillEvolutionConditionItem(SkillUpgradeCondition condition)
        {
            InitializeComponent();

            conditionLabel.Text = AssetTables.GetText(TextCategory.SkillUpgrade1, condition.Id);
        }
    }
}
