using UmaMusumeExplorer.Assets;

namespace UmaMusumeExplorer
{
    public partial class SplashForm : Form
    {
        private Thread? loadThread;
        private bool loadSuccess = false;

        public SplashForm()
        {
            InitializeComponent();
        }

        public bool LoadAndClose()
        {
            loadThread = new(() =>
            {
                try
                {
                    AssetTables.UpdateProgress += UpdateProgress;
                    AssetTables.Initialize();
                    AssetTables.UpdateProgress -= UpdateProgress;
                    Invoke(() => Close());
                    loadSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error reading tables. Please launch the game and allow itself to repair.\n\nMessage:\n{e.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            });
            ShowDialog();

            return loadSuccess;
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
