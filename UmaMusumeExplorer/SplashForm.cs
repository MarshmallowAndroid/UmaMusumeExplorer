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

        public event EventHandler? OnLoadSuccess;

        public void ShowLoadAndClose()
        {
            loadThread = new(() =>
            {
                try
                {
                    AssetTables.UpdateProgress += UpdateProgress;
                    AssetTables.Initialize();
                    AssetTables.UpdateProgress -= UpdateProgress;
                    Invoke(() => Close());
                    OnLoadSuccess?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading tables. Please launch the game and allow itself to repair.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
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
