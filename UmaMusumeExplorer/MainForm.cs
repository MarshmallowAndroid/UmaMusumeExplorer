using System.Windows.Forms;
using UmaMusumeExplorer.Controls;

namespace UmaMusumeExplorer
{
    partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlHelpers.CloseAllForms();
        }
    }
}
