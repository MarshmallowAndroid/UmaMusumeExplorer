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
    public partial class SongsControl : UserControl
    {
        public SongsControl()
        {
            InitializeComponent();
        }

        private void SongsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode) loadingBackgroundWorker.RunWorkerAsync();
        }

        private void loadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
