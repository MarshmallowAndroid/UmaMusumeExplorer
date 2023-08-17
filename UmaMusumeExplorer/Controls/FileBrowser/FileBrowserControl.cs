using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;

namespace UmaMusumeExplorer.Controls.FileBrowser
{
    partial class FileBrowserControl : UserControl
    {
        private readonly SortedDictionary<string, GameAsset> gameAssets = new();
        private IDictionary<string, GameAsset> searchedAssets;
        private IDictionary<string, GameAsset> targetAssets;
        private readonly SortedDictionary<string, GameAsset> selectedAssets = new();

        private bool searched;

        public FileBrowserControl()
        {
            InitializeComponent();
        }

        private void FileBrowserControl_Load(object sender, EventArgs e)
        {
            foreach (var gameAsset in UmaDataHelper.GetGameAssetDataRows())
            {
                gameAssets.Add(gameAsset.Name, gameAsset);
            }

            TreeNode rootNode = new("Root");
            rootNode.Nodes.Add("");

            fileTreeView.Nodes.Add(rootNode);

            extractListView.Columns[0].Width = (int)(extractListView.Width * 0.80F);
            extractListView.Columns[1].Width = -2;

            targetAssets = gameAssets;
        }

        private void FileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode expandingNode = e.Node;
            expandingNode.Nodes.Clear();

            IEnumerable<KeyValuePair<string, GameAsset>> assetList;

            string convertedNodePath = "";

            if (expandingNode.Text == "Root")
                assetList = targetAssets;
            else
            {
                convertedNodePath = expandingNode.FullPath["Root/".Length..];
                assetList = targetAssets.Where(ga => ga.Key.StartsWith(convertedNodePath + "/"));
            }

            SortedDictionary<string, GameAsset> files = new();

            foreach (var assetValue in assetList)
            {
                GameAsset asset = assetValue.Value;
                string assetName = expandingNode.Text == "Root" ? asset.Name : asset.Name[(convertedNodePath.Length + 1)..];

                int firstSlashIndex = assetName.IndexOf('/');
                if (firstSlashIndex < 1)
                    files.Add(asset.Name, asset);
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

            foreach (var file in files.Values)
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

        private async void AddToolStripMenuItem_Click(object sender, EventArgs e)
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
                string convertedNodePath = node.FullPath["Root/".Length..];

                IEnumerable<KeyValuePair<string, GameAsset>> assetsToAdd = targetAssets.Where(ga => ga.Key.StartsWith(convertedNodePath + '/'));

                int itemCount = assetsToAdd.Count();
                if (itemCount > 10000)
                {
                    DialogResult confirmResult =
                        MessageBox.Show($"Adding {itemCount} items. This might take a long time.\n\nProceed?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.No) return;
                }

                await Task.Run(() =>
                {
                    int currentAsset = 0;
                    foreach (var item in assetsToAdd)
                    {
                        Invoke(() => UpdateSelectedAssets(item.Value, node.Checked));
                        currentAsset++;

                        float percent = (float)currentAsset / itemCount;
                        Invoke(() => progressBar.Value = (int)(percent * 100.0F));
                    }
                });
            }

            await Task.Run(() =>
            {
                List<ListViewItem> dependencyItems = new();
                if (SelectedAssetsHaveDependencies())
                {
                    DialogResult addDependencyResult = MessageBox.Show("Include dependencies?", "Dependencies found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (addDependencyResult == DialogResult.Yes)
                    {
                        List<GameAsset> dependencies = new();
                        int currentAsset = 0;
                        int assetCount = selectedAssets.Count;
                        foreach (var selectedAsset in selectedAssets.Values)
                        {
                            AddDependenciesRecurse(dependencies, selectedAsset);
                            currentAsset++;

                            float percent = (float)currentAsset / assetCount;
                            Invoke(() => progressBar.Value = (int)(percent * 100.0F));
                        }

                        foreach (var dependencyAsset in dependencies)
                        {
                            Invoke(() => UpdateSelectedAssets(dependencyAsset, node.Checked));

                            ListViewItem item = new(dependencyAsset.Name);
                            item.SubItems.Add(GenerateSizeString(dependencyAsset.Length));
                            item.Tag = dependencyAsset;

                            dependencyItems.Add(item);
                        }
                    }
                }

                ListViewItem[] items = new ListViewItem[selectedAssets.Count];
                int index = 0;
                foreach (var selectedAsset in selectedAssets.Values)
                {
                    ListViewItem item = new(selectedAsset.Name);
                    item.SubItems.Add(GenerateSizeString(selectedAsset.Length));
                    item.Tag = selectedAsset;
                    items[index++] = item;
                }

                Invoke(() =>
                {
                    extractListView.Items.Clear();
                    extractListView.Items.AddRange(items);

                    totalFileCountLabel.Text = $"{selectedAssets.Count} files";
                    totalFileSizeLabel.Text = GenerateSizeString(selectedAssets.Sum(a => (long)a.Value.Length));
                });
            });
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = extractListView.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                extractListView.Items.Remove(item);
                selectedAssets.Remove(((GameAsset)item.Tag).Name);
            }

            totalFileCountLabel.Text = $"{selectedAssets.Count} files";
            totalFileSizeLabel.Text = GenerateSizeString(selectedAssets.Values.Sum(a => a.Length));
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
            int total = extractListView.Items.Count;

            if (total < 1) return;

            FolderBrowserDialog folderBrowserDialog = new();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel) return;

            string outputDirectory = folderBrowserDialog.SelectedPath;

            object finishedLock = new();

            Task[] copyTasks = new Task[total];
            int index = 0;
            int finished = 0;
            foreach (ListViewItem item in extractListView.Items)
            {
                GameAsset asset = item.Tag as GameAsset;

                copyTasks[index] = new Task(() =>
                {
                    string dataFilePath = UmaDataHelper.GetPath(asset);
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
                        Invoke(() => progressBar.Value = (int)((float)finished / total * 100.0F));
                    }
                });
                copyTasks[index++].Start();
            }

            await Task.WhenAll(copyTasks);

            MessageBox.Show("Extract complete.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Value = 0;
        }

        private void OpenFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileTreeView.SelectedNode is null) return;

            if (fileTreeView.SelectedNode.Tag is GameAsset asset)
            {
                string dataFilePath = UmaDataHelper.GetPath(asset);

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
            if (fileTreeView.SelectedNode is null) return;

            bool isFolder = (GameAsset)fileTreeView.SelectedNode.Tag is null;
            toolStripSeparator1.Visible = !isFolder;
            openFileLocationToolStripMenuItem.Visible = !isFolder;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!searched)
            {
                searchedAssets = UmaDataHelper.GetGameAssetDataRows().Where(ga => ga.Name.Contains(searchTextBox.Text)).ToDictionary(ga => ga.Name); ;
                targetAssets = searchedAssets;

                searched = true;
                searchButton.Text = "Reset";
            }
            else
            {
                searchedAssets.Clear();
                targetAssets = gameAssets;

                searched = false;
                searchButton.Text = "Search";
            }

            fileTreeView.Nodes[0].Collapse();
            fileTreeView.Nodes[0].Nodes.Add("");
        }

        private bool SelectedAssetsHaveDependencies()
        {
            foreach (var asset in selectedAssets.Values)
            {
                if (asset.Dependencies.Any()) return true;
            }

            return false;
        }

        private void AddDependenciesRecurse(List<GameAsset> dependencyList, GameAsset gameAsset, int iteration = 0)
        {
            if (gameAsset.Dependencies == "") return;

            foreach (var dependency in gameAsset.Dependencies.Split(';'))
            {
                GameAsset dependencyAsset = gameAssets[dependency];

                if (dependencyAsset is not null)
                {
                    if (iteration <= 100)
                        AddDependenciesRecurse(dependencyList, dependencyAsset, ++iteration);

                    if (!dependencyList.Contains(dependencyAsset))
                        dependencyList.Add(dependencyAsset);
                }
            }
        }

        private void UpdateSelectedAssets(GameAsset asset, bool isChecked)
        {
            TreeNode[] matching = fileTreeView.Nodes.Find(asset.Name, true);
            if (matching.Length > 0) matching[0].Checked = isChecked;

            if (!selectedAssets.ContainsKey(asset.Name))
                selectedAssets.Add(asset.Name, asset);
        }

        private static string GenerateSizeString(long length)
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
    }
}
