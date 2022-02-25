using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeFiles;
using UmaMusumeFiles.Tables;
using System.Text.RegularExpressions;
using UmaMusumeExplorer.Controls.CharacterInfo;
using UmaMusumeExplorer.Controls;
using System.ComponentModel;
using System.Drawing;

namespace PlayerGui.Controls.CharacterInfo
{
    public partial class CharacterInfoControl : UserControl
    {
        private readonly IEnumerable<CharaData> charaDatas = PersistentData.CharaDatas;

        public CharacterInfoControl()
        {
            InitializeComponent();
        }

        private void CharacterInfoControl_Load(object sender, EventArgs e)
        {
            loadingBackgroundWorker.RunWorkerAsync();
        }

        private void CharaIcon_Click(object sender, EventArgs e)
        {
            PictureBox charaIcon = sender as PictureBox;
            CharaData chara = charaIcon.Tag as CharaData;

            CardDetailsForm details = new(chara);
            Form parentForm = GetParentForm(this);

            int left = parentForm.Left;
            int top = parentForm.Top;

            left += (parentForm.Width / 2) - (details.Width / 2);
            top += (parentForm.Height / 2) - (details.Height / 2);

            details.Left = left;
            details.Top = top;

            details.Show();
        }

        private Form GetParentForm(Control control)
        {
            if (control is Form parentForm)
            {
                return parentForm;
            }
            else return GetParentForm(control.Parent);
        }

        private void LoadingBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Regex charIconRegex = new("\\bchr_icon_[0-9]{4}\\b");

            List<string> imagePaths = new();
            foreach (var item in UmaFileHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("chara/")))
            {
                if (charIconRegex.IsMatch(item.BaseName) || item.BaseName == "chr_icon_round_0000")
                    imagePaths.Add(UmaFileHelper.GetPath(item));
            }

            AssetStudio.Progress.Default = new AssetStudioProgress(loadingBackgroundWorker.ReportProgress);
            UnityTextureHelpers.LoadFiles(imagePaths.ToArray());

            List<PictureBox> charaIcons = new();

            int itemNumber = 1;
            foreach (var item in charaDatas)
            {
                PictureBox charaIcon = new()
                {
                    Width = 100,
                    Height = 100,
                    BackgroundImage = UnityTextureHelpers.GetCharaIcon(item.Id),
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Cursor = Cursors.Hand,
                    Tag = item
                };

                charaIcon.Click += CharaIcon_Click;
                charaIcons.Add(charaIcon);

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / charaDatas.Count() * 100.0f));
            }

            e.Result = charaIcons;
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;

            charactersPanel.Controls.AddRange(((List<PictureBox>)e.Result).ToArray());
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            CharaData chara = charaDatas.FirstOrDefault(c => (int)selectNumericUpDown.Value == c.Id);
            if (chara != null) new CardDetailsForm(chara).Show();
        }
    }
}
