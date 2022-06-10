using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;

namespace UmaMusumeExplorer.Controls.FileBrowser
{
    public partial class FileBrowserControl : UserControl
    {
        List<GameAsset> gameAssets;

        public FileBrowserControl()
        {
            InitializeComponent();
        }

        private void FileBrowserControl_Load(object sender, EventArgs e)
        {
            gameAssets = UmaDataHelper.GetGameAssetDataRows(ga => true);
            gameAssets.Sort((ga1, ga2) => string.Compare(ga1.Name, ga2.Name));

            TreeNode rootNode = new("Root");
            rootNode.Nodes.Add("dummy");

            fileTreeView.Nodes.Add(rootNode);
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

            NodesFromPath(sourceNode.Nodes[nodeName], path.Substring(lastSlashIndex + 1));
        }

        private void FileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode targetNode = e.Node;

            targetNode.Nodes.Clear();

            IEnumerable<GameAsset> assetList;

            string convertedNodePath = "";

            if (targetNode.Text == "Root")
                assetList = gameAssets;
            else
            {
                convertedNodePath = targetNode.FullPath["Root/".Length..];
                assetList = gameAssets.Where(ga => ga.Name.StartsWith(convertedNodePath + "/"));
            }

            List<GameAsset> files = new();

            foreach (var asset in assetList)
            {
                string assetName = targetNode.Text == "Root" ? asset.Name : asset.Name[(convertedNodePath.Length + 1)..];

                int firstSlashIndex = assetName.IndexOf('/');

                if (firstSlashIndex < 1)
                {
                    files.Add(asset);
                    continue;
                }

                string nodeName = assetName.Substring(0, firstSlashIndex);
                string nodeKey = convertedNodePath + '/' + nodeName;

                if (!targetNode.Nodes.ContainsKey(nodeKey))
                {
                    targetNode.Nodes.Add(nodeKey, nodeName);
                    targetNode.Nodes[nodeKey].Nodes.Add("dummy");
                }
            }

            foreach (var file in files)
            {
                string fileName = file.BaseName;

                if (file.Manifest.StartsWith("manifest"))
                    fileName += ".manifest";

                targetNode.Nodes.Add(file.Name, fileName);
                targetNode.Nodes[file.Name].ImageIndex = 1;
                targetNode.Nodes[file.Name].SelectedImageIndex = 1;
            }
        }
    }
}
