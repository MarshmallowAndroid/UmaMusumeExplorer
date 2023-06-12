using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoControl : UserControl
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
            IProgress<int> defaultProgress = AssetStudio.Progress.Default;
            AssetStudio.Progress.Default = new LoadingProgress(loadingBackgroundWorker.ReportProgress);

            List<Control> pictureBoxes = new();

            int itemNumber = 1;
            foreach (var item in charaDatas)
            {
                bool playable = AssetTables.CardDatas.Any(cd => cd.CharaId == item.Id);

                CharacterPictureBox charaIcon = new(playable)
                {
                    BackgroundImage = UnityAssets.GetCharaIcon(item.Id).Bitmap,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Height = 100,
                    Width = 100,
                    Tag = item
                };

                ToolTip toolTip = new();
                toolTip.SetToolTip(charaIcon, $"{item.Id}: {AssetTables.GetText(AssetTables.CharaNameTextDatas, item.Id)}");

                charaIcon.Click += CharaIcon_Click;
                pictureBoxes.Add(charaIcon);

                Invoke(() => charaListComboBox.Items.Add(new CharaComboBoxItem(item)));

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / charaDatas.Count() * 100.0F));
            }

            AssetStudio.Progress.Default = defaultProgress;

            e.Result = pictureBoxes.ToArray();
        }

        private void CharaIcon_Click(object sender, EventArgs e)
        {
            PictureBox charaIcon = sender as PictureBox;
            CharaData chara = charaIcon.Tag as CharaData;

            CharacterInfoForm details = new(chara);
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
            if (charaListComboBox.SelectedItem is CharaComboBoxItem item) ControlHelpers.ShowFormCenter(new CharacterInfoForm(item.CharaData), this);
        }

        private void ShowPlayableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CharacterPictureBox cpb in charactersPanel.Controls)
            {
                cpb.ShowPlayability = showPlayableCheckBox.Checked;
            }
        }
    }
}
