using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls
{
    public partial class LoadingForm : Form
    {
        private readonly AssetsManager assetsManager;
        private readonly IEnumerable<string> filePaths;

        public LoadingForm(AssetsManager assetsManager, IEnumerable<string> filePaths)
        {
            InitializeComponent();

            this.assetsManager = assetsManager;
            this.filePaths = filePaths;
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker) return;

            List<(BundleFileInstance bundle, string name)> filesAndBundles = new();

            Invoke(() => statusLabel.Text = "Loading AssetBundles...");
            int currentItem = 1;
            foreach (var file in filePaths)
            {
                BundleFileInstance bundle = assetsManager.LoadBundleFile(file);
                foreach (var assetsFile in bundle.file.GetAllFileNames())
                {
                    filesAndBundles.Add((bundle, assetsFile));
                }
                worker.ReportProgress((int)((float)currentItem++ / filePaths.Count() * 100F));
            }

            Invoke(() => statusLabel.Text = "Loading assets...");
            currentItem = 1;
            foreach (var (bundle, name) in filesAndBundles)
            {
                assetsManager.LoadAssetsFileFromBundle(bundle, name);
                worker.ReportProgress((int)((float)currentItem++ / filesAndBundles.Count * 100F));
            }
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            loadingBackgroundWorker.RunWorkerAsync();
        }
    }
}
