using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
