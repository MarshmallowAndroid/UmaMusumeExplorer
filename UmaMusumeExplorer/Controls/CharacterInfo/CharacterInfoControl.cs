using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using System.Text.RegularExpressions;
using UmaMusumeExplorer.Controls.CharacterInfo;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CharacterInfoControl : UserControl
    {
        private readonly IEnumerable<CharaData> charaDatas = AssetTables.CharaDatas;

        public CharacterInfoControl()
        {
            InitializeComponent();
        }

        private void CharacterInfoControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode) loadingBackgroundWorker.RunWorkerAsync();
        }
        
        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Regex chrIconRegex = new(@"\bchr_icon_[0-9]{4}\b");
            Regex chrCardIconRegex = new(@"\bchr_icon_[0-9]{4}_[0-9]{6}_[0-9]{2}\b");

            List<string> imagePaths = new();
            List<GameAsset> charaAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("chara/"));
            foreach (var asset in charaAssetRows)
            {
                if (chrIconRegex.IsMatch(asset.BaseName) || chrCardIconRegex.IsMatch(asset.BaseName) || asset.BaseName == "chr_icon_round_0000")
                    imagePaths.Add(UmaDataHelper.GetPath(asset));
            }

            AssetStudio.Progress.Default = new LoadingProgress(loadingBackgroundWorker.ReportProgress);
            UnityTextureHelpers.LoadFiles(imagePaths.ToArray());

            List<Control> pictureBoxes = new();

            int itemNumber = 1;
            foreach (var item in charaDatas)
            {
                PictureBox charaIcon = new()
                {
                    BackgroundImage = UnityTextureHelpers.GetCharaIcon(item.Id),
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 100,
                    Width = 100,
                    Tag = item
                };

                ToolTip toolTip = new();
                toolTip.SetToolTip(charaIcon, item.Id.ToString());

                charaIcon.Click += CharaIcon_Click;
                pictureBoxes.Add(charaIcon);

                Invoke(() => charaListComboBox.Items.Add(new CharaComboBoxItem(item)));

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / charaDatas.Count() * 100.0f));
            }

            e.Result = pictureBoxes.ToArray();
        }

        private void CharaIcon_Click(object sender, EventArgs e)
        {
            PictureBox charaIcon = sender as PictureBox;
            CharaData chara = charaIcon.Tag as CharaData;

            CardDetailsForm details = new(chara);
            ControlHelpers.ShowFormCenter(details, this);
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;

            charactersPanel.Controls.AddRange((Control[])e.Result);
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (charaListComboBox.SelectedItem is CharaComboBoxItem item) ControlHelpers.ShowFormCenter(new CardDetailsForm(item.CharaData), this);
        }
    }
}
