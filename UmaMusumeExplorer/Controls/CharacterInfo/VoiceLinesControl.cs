using NAudio.Wave;
using System.ComponentModel;
using System.Data;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class VoiceLinesControl : UserControl
    {
        private readonly IEnumerable<CharacterSystemText> systemTexts = AssetTables.CharacterSystemTexts;
        private readonly IWavePlayer waveOut = new WaveOutEvent() { DesiredLatency = 250 };
        private readonly BackgroundWorker exportBackgroundWorker = new() { WorkerReportsProgress = true };

        private bool loaded = false;
        private IEnumerable<CharacterSystemText>? selectedCharacterSystemTexts;
        private IEnumerable<CharacterSystemText>? selectedCostumeSystemTexts;
        private IEnumerable<CharacterSystemText>? selectedCategorySystemTexts;
        private IEnumerable<CharacterSystemText>? finalFilteredSystemTexts;
        private PinnedBitmap? iconPinnedBitmap;

        public VoiceLinesControl()
        {
            InitializeComponent();

            exportBackgroundWorker.ProgressChanged += ExportBackgroundWorker_ProgressChanged;
            exportBackgroundWorker.RunWorkerCompleted += ExportBackgroundWorker_RunWorkerCompleted;
        }

        public int CharacterId { get; set; }

        public void StopAllPlayback()
        {
            waveOut.Stop();
            waveOut.Dispose();
        }

        private void VoiceLinesControl_Load(object? sender, EventArgs e)
        {
            if (systemTexts is not null)
            {
                costumeComboBox.SelectedIndex = 0;
                categoryComboBox.SelectedIndex = 0;

                foreach (var item in AssetTables.CardDatas.Where(cd => cd.CharaId == CharacterId))
                {
                    costumeComboBox.Items.Add(new CostumeComboBoxItem(item));
                }

                loaded = true;
            }
        }

        private void CostumeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CardData? cardData = (costumeComboBox.SelectedItem as CostumeComboBoxItem)?.CardData ?? null;

            selectedCharacterSystemTexts = systemTexts.Where(st => st.CharacterId == CharacterId);
            selectedCostumeSystemTexts = selectedCharacterSystemTexts;
            iconPinnedBitmap = UnityAssets.GetCharaIcon(CharacterId);

            if (cardData is not null)
            {
                CardRarityData? rarityData = AssetTables.CardRarityDatas.Where(crd => crd.CardId == cardData.Id).FirstOrDefault();
                rarityData ??= new();

                selectedCostumeSystemTexts = selectedCharacterSystemTexts.Where(st => st.CueSheet.EndsWith(cardData.Id.ToString()));
                iconPinnedBitmap = UnityAssets.GetCharaIcon(cardData.CharaId, rarityData.RaceDressId);
            }

            cardPictureBox.Image = iconPinnedBitmap?.Bitmap;

            if (!loaded) return;

            UpdateList();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            if (selectedCostumeSystemTexts is null) return;
            selectedCategorySystemTexts = categoryComboBox.SelectedIndex switch
            {
                1 => selectedCostumeSystemTexts.Where(st => st.CueSheet.Contains("home")),
                2 => selectedCostumeSystemTexts.Where(st => st.CueSheet.Contains("training")),
                3 => selectedCostumeSystemTexts.Where(st => st.CueSheet.Contains("race")),
                4 => selectedCostumeSystemTexts.Where(st => !st.CueSheet.Contains("home") &&
                    !st.CueSheet.Contains("training") && !st.CueSheet.Contains("race")),
                _ => selectedCostumeSystemTexts,
            };
            finalFilteredSystemTexts = selectedCategorySystemTexts ?? selectedCostumeSystemTexts ?? selectedCharacterSystemTexts;

            voiceLineListPanel.Controls.Clear();

            if (finalFilteredSystemTexts is null) return;
            foreach (var characterSystemText in finalFilteredSystemTexts)
            {
                CharacterVoiceListItemControl listItem = new(characterSystemText, waveOut);
                listItem.Width = voiceLineListPanel.Width - listItem.Margin.Horizontal - SystemInformation.VerticalScrollBarWidth;
                voiceLineListPanel.Controls.Add(listItem);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            Export(false);
        }

        private void ExportSelectedButton_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        private void Export(bool checkedOnly)
        {
            FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            exportBackgroundWorker.DoWork += (s, e) =>
            {
                Invoke(() => loadingProgressBar.Visible = true);

                int currentItem = 0;
                foreach (CharacterVoiceListItemControl control in voiceLineListPanel.Controls)
                {
                    if (!control.Checked && checkedOnly) continue;
                    if (control.CharacterSystemText is null) continue;

                    WaveStream? waveStream = control.GetWaveStream();

                    string outputPath = Path.Combine(folderBrowserDialog.SelectedPath,
                        SanitizeFileName(control.CharacterSystemText.Text) + ".wav");
                    WaveFileWriter.CreateWaveFile(outputPath, waveStream);

                    exportBackgroundWorker.ReportProgress((int)((float)++currentItem / voiceLineListPanel.Controls.Count * 100F));
                }
            };
            exportBackgroundWorker.RunWorkerAsync();
        }

        private void ExportBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = e.ProgressPercentage;
        }

        private void ExportBackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;
        }

        private static string SanitizeFileName(string fileName)
        {
            foreach (var invalidChar in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidChar, '_');
            }

            return fileName;
        }
    }
}
