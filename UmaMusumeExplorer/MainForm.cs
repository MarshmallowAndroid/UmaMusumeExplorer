using UmaMusumeExplorer.Controls;

namespace UmaMusumeExplorer
{
    partial class MainForm : Form
    {
        public MainForm()
        {
            new SplashForm().ShowLoadAndClose();

            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlHelpers.CloseAllForms();
        }
    }
}
