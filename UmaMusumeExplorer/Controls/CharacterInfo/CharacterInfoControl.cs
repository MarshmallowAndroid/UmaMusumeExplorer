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
            OpenFormInParentCenter(details);
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

            int itemNumber = 1;
            foreach (var item in charaDatas)
            {
                Invoke(() => AddItems(item));

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / charaDatas.Count() * 100.0f));
            }
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            CharaComboBoxItem item = charaListComboBox.SelectedItem as CharaComboBoxItem;
            if (item != null) OpenFormInParentCenter(new CardDetailsForm(item.CharaData));
        }


        private void AddItems(CharaData chara)
        {
            charaListComboBox.Items.Add(new CharaComboBoxItem(chara));
            PictureBox charaIcon = new()
            {
                Width = 100,
                Height = 100,
                BackgroundImage = UnityTextureHelpers.GetCharaIcon(chara.Id),
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand,
                Tag = chara
            };

            charaIcon.Click += CharaIcon_Click;

            charactersPanel.Controls.Add(charaIcon);
        }

        private void OpenFormInParentCenter(Form form)
        {
            Form parentForm = GetParentForm(this);

            int left = parentForm.Left;
            int top = parentForm.Top;

            left += (parentForm.Width / 2) - (form.Width / 2);
            top += (parentForm.Height / 2) - (form.Height / 2);

            form.Left = left;
            form.Top = top;

            form.Show();
        }

        private Form GetParentForm(Control control)
        {
            if (control is Form parentForm)
            {
                return parentForm;
            }
            else return GetParentForm(control.Parent);
        }

    }

    internal class CharaComboBoxItem
    {
        public CharaComboBoxItem(CharaData chara)
        {
            CharaData = chara;
        }

        public CharaData CharaData { get; }

        public override string ToString()
        {
            return CharaData.Id.ToString() + ": " + PersistentData.CharaNameTextDatas.First(td => td.Index == CharaData.Id).Text;
        }
    }
}
