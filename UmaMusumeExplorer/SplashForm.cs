using System;
using System.Threading;
using System.Windows.Forms;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer
{
    public partial class SplashForm : Form
    {
        Thread loadThread;

        public SplashForm()
        {
            InitializeComponent();

            AssetTables.UpdateProgress += UpdateProgress;
        }

        public void ShowLoadAndClose()
        {
            loadThread = new(new ThreadStart(() =>
            {
                AssetTables.Initialize();
                AssetTables.UpdateProgress -= UpdateProgress;
                Invoke(() => Close());
            }));
            ShowDialog();
        }

        private void UpdateProgress(int progress, string name)
        {
            Invoke(() =>
            {
                loadingProgressBar.Value = progress;
                loadingLabel.Text = $"Loading {name}...";
            });
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            loadThread.Start();
        }
    }
}
