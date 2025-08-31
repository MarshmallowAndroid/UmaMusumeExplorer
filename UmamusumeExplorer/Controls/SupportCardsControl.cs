using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmamsumeData.Tables;
using UmamusumeExplorer.Assets;

namespace UmamusumeExplorer.Controls
{
    public partial class SupportCardsControl : UserControl
    {
        private readonly IEnumerable<SupportCardData> supportCardDatas = AssetTables.SupportCardDatas;

        public SupportCardsControl()
        {
            InitializeComponent();

            supportCardItemsPanel.Indeterminate = true;
            supportCardItemsPanel.Filter = (item) => item.CharaId == CharaId;
        }

        public int CharaId { get; set; }

        private void SupportCardsControl_Load(object sender, EventArgs e)
        {
            supportCardItemsPanel.Items = supportCardDatas;
        }
    }
}
