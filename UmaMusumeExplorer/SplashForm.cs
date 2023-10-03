using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer
{
    public partial class SplashForm : Form
    {
        private Thread? loadThread;

        public SplashForm()
        {
            InitializeComponent();
        }

        public void ShowLoadAndClose()
        {
            loadThread = new(() =>
            {
                AssetTables.UpdateProgress += UpdateProgress;
                AssetTables.Initialize();
                AssetTables.UpdateProgress -= UpdateProgress;
                Invoke(() => Close());
            });
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
            loadThread?.Start();
        }
    }
}
