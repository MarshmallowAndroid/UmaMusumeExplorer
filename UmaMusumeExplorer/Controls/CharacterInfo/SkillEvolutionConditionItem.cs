using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
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
