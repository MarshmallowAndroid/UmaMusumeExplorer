using AssetStudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    public partial class CharaChooserForm : Form
    {
        private readonly LivePermissionData livePermissionData;
        private readonly List<PinnedBitmap> pinnedBitmaps;

        private readonly AssetsManager assetsManager;

        public CharaChooserForm(LivePermissionData permissionData)
        {
            InitializeComponent();

            livePermissionData = permissionData;

            Regex chrIconRegex = new(@"\bchr_icon_[0-9]{4}\b");

            List<string> imagePaths = new();
            List<GameAsset> charaAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("chara/"));
            foreach (var asset in charaAssetRows)
            {
                if (chrIconRegex.IsMatch(asset.BaseName))
                    imagePaths.Add(UmaDataHelper.GetPath(asset));
            }
        }
    }
}
