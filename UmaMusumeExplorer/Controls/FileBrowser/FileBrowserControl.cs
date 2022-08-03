using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly List<GameAsset> selectedAssets = new();

        public FileBrowserControl()
        {
            InitializeComponent();
        }

        private void FileBrowserControl_Load(object sender, EventArgs e)
        {
            gameAssets = UmaDataHelper.GetGameAssetDataRows(ga => true);
            gameAssets.Sort((ga1, ga2) => string.Compare(ga1.Name, ga2.Name));

            TreeNode rootNode = new("Root");
            rootNode.Nodes.Add("");

            fileTreeView.Nodes.Add(rootNode);

            extractListView.Columns[0].Width = (int)(extractListView.Width * 0.80f);
            extractListView.Columns[1].Width = -2;
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
                assetList = gameAssets;
            else
            {
                convertedNodePath = expandingNode.FullPath["Root/".Length..];
                assetList = gameAssets.Where(ga => ga.Name.StartsWith(convertedNodePath + "/"));
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
                if (itemCount > 1000)
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

            totalFileCountLabel.Text = $"{selectedAssets.Count} files";
            totalFileSizeLabel.Text = $"{selectedAssets.Sum(a => a.Length) / 1000000.0f:f2} MB";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            selectedAssets.Clear();
            extractListView.Items.Clear();

            totalFileCountLabel.Text = $"0 files";
            totalFileSizeLabel.Text = $"0 MB";
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            string outputDirectory = Directory.CreateDirectory("Extracted").FullName;

            foreach (var assets in selectedAssets)
            {
                string realFilePath = Path.Combine(outputDirectory, assets.Name);
            }
        }

        private void FileTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //if (e.Action == TreeViewAction.Unknown) return;
            //if (e.Node.FullPath == "Root") return;

            //GameAsset asset = (GameAsset)e.Node.Tag;

            //if (asset != null)
            //{
            //    UpdateSelectedAssets(asset, e.Node.Checked);
            //}
            //else
            //{
            //    string convertedNodePath = e.Node.FullPath[("Root/".Length)..];
            //    foreach (var item in gameAssets.Where(ga => ga.Name.StartsWith(convertedNodePath)))
            //    {
            //        UpdateSelectedAssets(item, e.Node.Checked);
            //    }
            //}
        }

        void UpdateSelectedAssets(GameAsset asset, bool isChecked)
        {
            TreeNode[] matching = fileTreeView.Nodes.Find(asset.Name, true);
            if (matching.Length > 0) matching[0].Checked = isChecked;

            //if (isChecked)
            //{
            if (!selectedAssets.Contains(asset) && !extractListView.Items.ContainsKey(asset.Name))
            {
                selectedAssets.Add(asset);
                ListViewItem item = extractListView.Items.Add(asset.Name, asset.BaseName, 0);
                item.SubItems.Add($"{asset.Length / 1000.0f:f2} KB");
            }
            //}
            //else
            //{
            //    selectedAssets.Remove(asset);
            //    extractListView.Items.Remove(extractListView.Items[asset.Name]);
            //}
        }

        void AddToListView(GameAsset asset)
        {
            ListViewItem item = extractListView.Items.Add(asset.Name, asset.BaseName, 0);
            item.SubItems.Add($"{asset.Length / 1000.0f:f2} KB");
        }
    }
}
