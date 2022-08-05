using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;

namespace UmaMusumeExplorer.Controls.FileBrowser
{
    public partial class FileBrowserControl : UserControl
    {
        private List<GameAsset> gameAssets;
        private List<GameAsset> searchedAssets;
        private List<GameAsset> targetAssets;
        private readonly List<GameAsset> selectedAssets = new();

        private static readonly string localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow");
        private static readonly string umaMusumeDirectory = Path.Combine(localLow, "Cygames", "umamusume");
        private static readonly string dataDirectory = Path.Combine(umaMusumeDirectory, "dat");

        private bool searched;

        public FileBrowserControl()
        {
            InitializeComponent();
        }

        private void FileBrowserControl_Load(object sender, EventArgs e)
        {
            gameAssets = UmaDataHelper.GetGameAssetDataRows();
            gameAssets.Sort((ga1, ga2) => string.Compare(ga1.Name, ga2.Name));

            TreeNode rootNode = new("Root");
            rootNode.Nodes.Add("");

            fileTreeView.Nodes.Add(rootNode);

            extractListView.Columns[0].Width = (int)(extractListView.Width * 0.80f);
            extractListView.Columns[1].Width = -2;

            targetAssets = gameAssets;
        }

        private void NodesFromPath(TreeNode sourceNode, string path)
        {
            int lastSlashIndex = path.IndexOf('/');
            if (lastSlashIndex < 1)
            {
                sourceNode.Nodes.Add(path);
                return;
            }

            string nodeName = path[..lastSlashIndex];

            if (!sourceNode.Nodes.ContainsKey(nodeName))
                sourceNode.Nodes.Add(nodeName, nodeName);

            NodesFromPath(sourceNode.Nodes[nodeName], path[(lastSlashIndex + 1)..]);
        }

        private void FileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode expandingNode = e.Node;
            expandingNode.Nodes.Clear();

            IEnumerable<GameAsset> assetList;

            string convertedNodePath = "";

            if (expandingNode.Text == "Root")
                assetList = targetAssets;
            else
            {
                convertedNodePath = expandingNode.FullPath["Root/".Length..];
                assetList = targetAssets.Where(ga => ga.Name.StartsWith(convertedNodePath + "/"));
            }

            List<GameAsset> files = new();

            foreach (var asset in assetList)
            {
                string assetName = expandingNode.Text == "Root" ? asset.Name : asset.Name[(convertedNodePath.Length + 1)..];

                int firstSlashIndex = assetName.IndexOf('/');
                if (firstSlashIndex < 1)
                    files.Add(asset);
                else
                {
                    string nodeName = assetName[..firstSlashIndex];
                    string nodeKey = convertedNodePath + '/' + nodeName;

                    if (!expandingNode.Nodes.ContainsKey(nodeKey))
                    {
                        expandingNode.Nodes.Add(nodeKey, nodeName);
                        expandingNode.Nodes[nodeKey].Nodes.Add("");
                    }
                }

            }

            foreach (var file in files)
            {
                string fileName = file.BaseName;

                if (file.Manifest.StartsWith("manifest"))
                    fileName += ".manifest";

                if (!expandingNode.Nodes.ContainsKey(file.Name))
                {
                    expandingNode.Nodes.Add(file.Name, fileName);

                    TreeNode node = expandingNode.Nodes[file.Name];

                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    node.Tag = file;
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = fileTreeView.SelectedNode;

            if (node is null) return;
            if (node.FullPath == "Root") return;

            GameAsset asset = (GameAsset)node.Tag;

            if (asset is not null)
            {
                UpdateSelectedAssets(asset, node.Checked);
            }
            else
            {
                string convertedNodePath = node.FullPath[("Root/".Length)..];

                IEnumerable<GameAsset> assetsToAdd = gameAssets.Where(ga => ga.Name.StartsWith(convertedNodePath));
                int itemCount = assetsToAdd.Count();
                if (itemCount > 10000)
                {
                    DialogResult confirmResult =
                        MessageBox.Show($"Adding {itemCount} items. This might take a long time.\n\nProceed?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.No) return;
                }

                foreach (var item in assetsToAdd)
                {
                    UpdateSelectedAssets(item, node.Checked);
                }
            }

            selectedAssets.Sort((a, b) => a.BaseName.CompareTo(b.BaseName));

            ListViewItem[] items = new ListViewItem[selectedAssets.Count];
            int index = 0;
            foreach (var selectedAsset in selectedAssets)
            {
                ListViewItem item = new ListViewItem(selectedAsset.BaseName);
                item.Name = selectedAsset.Name;
                item.SubItems.Add(GenerateSizeString(selectedAsset.Length));
                item.Tag = selectedAsset;
                items[index++] = item;
            }

            extractListView.Items.Clear();
            extractListView.Items.AddRange(items);

            totalFileCountLabel.Text = $"{selectedAssets.Count} files";
            totalFileSizeLabel.Text = GenerateSizeString(selectedAssets.Sum(a => a.Length));
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = extractListView.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                extractListView.Items.Remove(item);
                selectedAssets.Remove((GameAsset)item.Tag);
            }

            totalFileCountLabel.Text = $"{selectedAssets.Count} files";
            totalFileSizeLabel.Text = GenerateSizeString(selectedAssets.Sum(a => a.Length));
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            selectedAssets.Clear();
            extractListView.Items.Clear();

            totalFileCountLabel.Text = $"0 files";
            totalFileSizeLabel.Text = $"0 B";
        }

        private async void ExtractButton_Click(object sender, EventArgs e)
        {
            string outputDirectory = Directory.CreateDirectory("Extracted").FullName;

            object finishedLock = new();

            int total = selectedAssets.Count;

            Task[] copyTasks = new Task[total];
            int index = 0;
            int finished = 0;
            foreach (var asset in selectedAssets)
            {
                copyTasks[index] = new Task(() =>
                {
                    string dataFileName = asset.Hash;
                    string dataFilePath = Path.Combine(dataDirectory, dataFileName[..2], dataFileName);
                    string realFileName = asset.Name.TrimStart('/');
                    if (asset.Manifest.StartsWith("manifest")) realFileName += ".manifest";
                    string realFilePath = Path.Combine(outputDirectory, realFileName);
                    string destinationDirectory;

                    if (!string.IsNullOrEmpty(Path.GetDirectoryName(realFileName)))
                        destinationDirectory = Path.Combine(outputDirectory, Path.GetDirectoryName(realFileName));
                    else destinationDirectory = outputDirectory;

                    Directory.CreateDirectory(destinationDirectory);

                    if (!File.Exists(realFilePath) && File.Exists(dataFilePath)) File.Copy(dataFilePath, realFilePath);

                    lock (finishedLock)
                    {
                        finished++;
                        Invoke(() => progressBar1.Value = (int)(((float)finished / total) * 100.0f));
                    }
                });
                copyTasks[index++].Start();
            }

            await Task.WhenAll(copyTasks);

            MessageBox.Show("Extract complete.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 0;
        }

        private string GenerateSizeString(int length)
        {
            StringBuilder sizeString = new();

            string[] units = new string[]
            {
                "B", "KB", "MB", "GB"
            };

            int unitIndex = (int)Math.Floor(Math.Log(length, 10) / 3);
            unitIndex = unitIndex >= 0 ? unitIndex : 0;
            float divide = (float)Math.Pow(1000, unitIndex);
            sizeString.Append($"{length / divide:f2} {units[unitIndex]}");

            return sizeString.ToString();
        }

        void UpdateSelectedAssets(GameAsset asset, bool isChecked)
        {
            TreeNode[] matching = fileTreeView.Nodes.Find(asset.Name, true);
            if (matching.Length > 0) matching[0].Checked = isChecked;

            if (!selectedAssets.Contains(asset))
                selectedAssets.Add(asset);
        }

        private void OpenFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileTreeView.SelectedNode.Tag is GameAsset asset)
            {
                string dataFileName = asset.Hash;
                string dataFilePath = Path.Combine(dataDirectory, dataFileName[..2], dataFileName);

                if (!File.Exists(dataFilePath))
                {
                    MessageBox.Show("Asset does not exist locally.", "Asset not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Process.Start("explorer.exe", $"/select, \"{dataFilePath}\"");
            }
        }

        private void TreeViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool isFolder = (GameAsset)fileTreeView.SelectedNode.Tag is null;
            toolStripSeparator1.Visible = !isFolder;
            openFileLocationToolStripMenuItem.Visible = !isFolder;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!searched)
            {
                searchedAssets = UmaDataHelper.GetGameAssetDataRows().Where(ga => ga.BaseName.Contains(searchTextBox.Text)).ToList();
                searchedAssets.Sort((ga1, ga2) => ga1.Name.CompareTo(ga2.Name));
                targetAssets = searchedAssets;

                fileTreeView.Nodes[0].Collapse();

                searched = true;
                searchButton.Text = "Reset";
            }
            else
            {
                searchedAssets.Clear();
                targetAssets = gameAssets;

                searchButton.Text = "Search";

                searched = false;
            }
        }
    }
}
