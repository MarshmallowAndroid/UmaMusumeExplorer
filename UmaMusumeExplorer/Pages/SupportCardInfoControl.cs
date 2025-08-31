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
using UmaMusumeExplorer.Assets;
using UmaMusumeExplorer.Controls;

namespace UmaMusumeExplorer.Pages
{
    public partial class SupportCardInfoControl : UserControl
    {
        private readonly IEnumerable<SupportCardData> supportCardDatas = AssetTables.SupportCardDatas;

        public SupportCardInfoControl()
        {
            InitializeComponent();
        }

        private void SupportCardInfoControl_Load(object sender, EventArgs e)
        {
            supportCardItemsPanel.Items = supportCardDatas;
        }

        private void MarkLimitedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (HighlightPictureBox hpb in supportCardItemsPanel.Controls)
            {
                hpb.ShowHighlight = markLimitedCheckBox.Checked;
            }
        }
    }
}
