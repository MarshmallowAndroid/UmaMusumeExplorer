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
            Task.Run(() =>
            {
                gameAssets = UmaDataHelper.GetGameAssetDataRows(ga => true);
                gameAssets.Sort((ga1, ga2) => string.Compare(ga1.Name, ga2.Name));

                TreeNode rootNode = new("Root");
                foreach (var asset in gameAssets)
                {
                    //int lastSlashIndex = asset.Name.IndexOf('/');
                    //if (lastSlashIndex < 1) continue;

                    //string node = asset.Name.Substring(0, lastSlashIndex);

                    //if (!rootNode.Nodes.ContainsKey(node))
                    //    rootNode.Nodes.Add(node, node);
                    NodesFromPath(rootNode, asset.Name);
                }

                Invoke(() =>
                {
                    fileTreeView.BeginUpdate();
                    fileTreeView.Nodes.Add(rootNode);
                    fileTreeView.EndUpdate();
                });
            });
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

        private void FileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void FileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

        }
    }
}
