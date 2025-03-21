﻿using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.RaceMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.RaceMusicPlayer
{
    partial class RaceMusicPlayerControl : UserControl
    {
        private readonly IEnumerable<RaceBgm> raceBgms = AssetTables.RaceBgms;
        private readonly IEnumerable<RaceBgmPattern> raceBgmPatterns = AssetTables.RaceBgmPatterns;
        private readonly IEnumerable<ManifestEntry> audioAssetEntries = AssetTables.AudioAssetEntries;

        private RaceBgm? currentRaceBgm;
        private List<Pattern>? firstPatternBgmList;
        private List<Pattern>? secondPatternBgmList;
        private Pattern? firstPattern;
        private Pattern? secondPattern;

        private IWavePlayer? waveOut;

        private Bgm? paddockBgm;
        private Bgm? entryTableBgm;
        private Bgm? resultCutinBgm;
        private Bgm? resultListBgm;
        private Bgm? firstPatternBgm;
        private Bgm? secondPatternBgm;

        private AutoRemoveMixingSampleProvider? mixer;
        private VolumeSampleProvider? volumeSampleProvider;

        private string lastPressedButtonName = "";

        public RaceMusicPlayerControl()
        {
            InitializeComponent();
        }

        private void RaceSimulatorControl_Load(object sender, EventArgs e)
        {
            if (raceBgms is null) return;

            waveOut = new WaveOutEvent();

            foreach (var bgm in raceBgms)
            {
                bgmIdComboBox.Items.Add(new BgmComboBoxItem() { RaceBgm = bgm });
            }

            if (bgmIdComboBox.Items.Count > 0)
                bgmIdComboBox.SelectedIndex = 0;
        }

        private void BgmIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paddockCueNameTextBox.Text = "";
            paddockCuesheetNameTextBox.Text = "";
            entryTableCueNameTextBox.Text = "";
            entryTableCuesheetNameTextBox.Text = "";

            raceResultComboBox.SelectedIndex = -1;
            firstPatternLengthComboBox.SelectedIndex = -1;
            secondPatternLengthComboBox.SelectedIndex = -1;

            firstPatternLengthComboBox.Items.Clear();
            secondPatternLengthComboBox.Items.Clear();

            waveOut?.Stop();

            paddockBgm?.Dispose();
            entryTableBgm?.Dispose();
            resultCutinBgm?.Dispose();
            resultListBgm?.Dispose();
        }

        private static List<Pattern> LoadPattern(RaceBgmPattern pattern)
        {
            Type type = pattern.GetType();

            Dictionary<int, int> bgmTimes = new();
            Dictionary<int, string> bgmCueNames = new();
            Dictionary<int, string> bgmCuesheetNames = new();

            int validItems = 0;
            foreach (var property in type.GetProperties())
            {
                object? propertyValue = property.GetValue(pattern);

                if (propertyValue is null) continue;

                switch (property.PropertyType.Name)
                {
                    case "Int32":
                        if ((int)propertyValue == 0) continue;
                        break;
                    case "String":
                        if (propertyValue as string == string.Empty) continue;
                        break;
                    default:
                        break;
                }

                if (property.Name.StartsWith("BgmTime"))
                {
                    int index = int.Parse(property.Name.Replace("BgmTime", ""));
                    bgmTimes.Add(index, (int)propertyValue);
                }
                else if (property.Name.StartsWith("BgmCueName"))
                {
                    int index = int.Parse(property.Name.Replace("BgmCueName", ""));
                    bgmCueNames.Add(index, (propertyValue as string) ?? "");
                }
                else if (property.Name.StartsWith("BgmCuesheetName"))
                {
                    int index = int.Parse(property.Name.Replace("BgmCuesheetName", ""));
                    bgmCuesheetNames.Add(index, (propertyValue as string) ?? "");
                }

                validItems++;
            }

            List<Pattern> bgmItems = new();

            for (int i = 1; i <= (validItems - 1) / 3; i++)
            {
                bgmItems.Add(new Pattern()
                {
                    BgmTime = bgmTimes[i],
                    BgmCueName = bgmCueNames[i],
                    BgmCuesheetName = bgmCuesheetNames[i]
                });
            }

            return bgmItems;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            waveOut?.Stop();

            if (bgmIdComboBox.SelectedItem is not BgmComboBoxItem comboBoxItem) return;

            currentRaceBgm = comboBoxItem.RaceBgm;

            RaceBgmPattern? firstPatternTable = raceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm?.FirstBgmPattern);
            RaceBgmPattern? secondPatternTable = raceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm?.SecondBgmPattern);

            if (firstPatternTable is null || secondPatternTable is null) return;

            firstPatternBgmList = LoadPattern(firstPatternTable);
            secondPatternBgmList = LoadPattern(secondPatternTable);

            if (currentRaceBgm is null) return;

            paddockCueNameTextBox.Text = currentRaceBgm.PaddockBgmCueName;
            paddockCuesheetNameTextBox.Text = currentRaceBgm.PaddockBgmCuesheetName;
            entryTableCueNameTextBox.Text = currentRaceBgm.EntrytableBgmCueName;
            entryTableCuesheetNameTextBox.Text = currentRaceBgm.EntrytableBgmCuesheetName;

            foreach (var item in firstPatternBgmList)
            {
                firstPatternLengthComboBox.Items.Add(item.BgmTime);
            }

            foreach (var item in secondPatternBgmList)
            {
                secondPatternLengthComboBox.Items.Add(item.BgmTime);
            }

            raceResultComboBox.SelectedIndex = 0;
            firstPatternLengthComboBox.SelectedIndex = 0;
            secondPatternLengthComboBox.SelectedIndex = 0;

            paddockBgm = new(audioAssetEntries, currentRaceBgm.PaddockBgmCuesheetName, currentRaceBgm.PaddockBgmCueName);
            entryTableBgm = new(audioAssetEntries, currentRaceBgm.EntrytableBgmCuesheetName, currentRaceBgm.EntrytableBgmCueName);

            mixer = new(WaveFormat.CreateIeeeFloatWaveFormat(
                paddockBgm.UmaWaveStream.WaveFormat.SampleRate,
                paddockBgm.UmaWaveStream.WaveFormat.Channels))
            { ReadFully = true };

            volumeSampleProvider = new VolumeSampleProvider(mixer)
            {
                Volume = (float)amplifyUpDown.Value
            };

            waveOut.Init(volumeSampleProvider);
            waveOut?.Play();
        }

        private void RaceResultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox comboBox) return;
            if (bgmIdComboBox.SelectedItem is not BgmComboBoxItem item) return;
            RaceBgm? raceBgm = item.RaceBgm;

            if (raceBgm is null) return;

            Type type = raceBgm.GetType();

            int propertyIndex = comboBox.SelectedIndex + 1;

            if (propertyIndex > 0)
            {
                string resultCutinBgmCuesheetName = type.GetProperty("ResultCutinBgmCuesheetName" + propertyIndex)?.GetValue(raceBgm)?.ToString() ?? "";
                string resultCutinBgmCueName = type.GetProperty("ResultCutinBgmCueName" + propertyIndex)?.GetValue(raceBgm)?.ToString() ?? "";
                string resultListBgmCuesheetName = type.GetProperty("ResultListBgmCuesheetName" + propertyIndex)?.GetValue(raceBgm)?.ToString() ?? "";
                string resultListBgmCueName = type.GetProperty("ResultListBgmCueName" + propertyIndex)?.GetValue(raceBgm)?.ToString() ?? "";

                resultCutInCuesheetNameTextBox.Text = resultCutinBgmCuesheetName;
                resultCutInCueNameTextBox.Text = resultCutinBgmCueName;
                resultListCuesheetNameTextBox.Text = resultListBgmCuesheetName;
                resultListCueNameTextBox.Text = resultListBgmCueName;
                resultCutinBgm = new Bgm(audioAssetEntries, resultCutinBgmCuesheetName, resultCutinBgmCueName);
                resultListBgm = new Bgm(audioAssetEntries, resultListBgmCuesheetName, resultListBgmCueName);
            }
            else
            {
                resultCutInCuesheetNameTextBox.Text = "";
                resultCutInCueNameTextBox.Text = "";
                resultListCuesheetNameTextBox.Text = "";
                resultListCueNameTextBox.Text = "";
            }
        }

        private void FirstPatternLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            if (comboBox.SelectedIndex >= 0)
            {
                firstPattern = firstPatternBgmList?.FirstOrDefault(bi => bi.BgmTime == (int)(comboBox.SelectedItem ?? 0));

                if (firstPattern is null) return;

                firstPatternCueNameTextBox.Text = firstPattern.BgmCueName;
                firstPatternCuesheetNameTextBox.Text = firstPattern.BgmCuesheetName;
                firstPatternBgm = new(audioAssetEntries, firstPattern.BgmCuesheetName, firstPattern.BgmCueName);
            }
            else
            {
                firstPatternCueNameTextBox.Text = "";
                firstPatternCuesheetNameTextBox.Text = "";
            }
        }

        private void SecondPatternLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            if (comboBox.SelectedIndex >= 0)
            {
                secondPattern = secondPatternBgmList?.FirstOrDefault(bi => bi.BgmTime == (int)(comboBox.SelectedItem ?? 0));

                if (secondPattern is null) return;

                secondPatternCueNameTextBox.Text = secondPattern.BgmCueName;
                secondPatternCuesheetNameTextBox.Text = secondPattern.BgmCuesheetName;
                secondPatternBgm = new(audioAssetEntries, secondPattern.BgmCuesheetName, secondPattern.BgmCueName);
            }
            else
            {
                secondPatternCueNameTextBox.Text = "";
                secondPatternCuesheetNameTextBox.Text = "";
            }
        }

        private void PlayButtons_Click(object sender, EventArgs e)
        {
            if (sender is not Button button) return;

            if (currentRaceBgm is null) return;
            if (mixer is null) return;
            if (paddockBgm is null) return;
            if (entryTableBgm is null) return;
            if (resultCutinBgm is null) return;
            if (resultListBgm is null) return;
            if (firstPatternBgm is null) return;
            if (secondPatternBgm is null) return;

            if (mixer.MixerInputs.Any())
            {
                foreach (FadeInOutEventSampleProvider sampleProvider in mixer.MixerInputs.Cast<FadeInOutEventSampleProvider>())
                {
                    sampleProvider.BeginFadeOut(500);
                }
            }

            if (lastPressedButtonName == button.Name)
                mixer.RemoveAllMixerInputs();

            lastPressedButtonName = button.Name;

            switch (button.Name)
            {
                case "playPaddockButton":
                    paddockBgm.UmaWaveStream.Position = 0;
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(paddockBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playEntryTableButton":
                    entryTableBgm.UmaWaveStream.Position = 0;
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(entryTableBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playRaceResultButton":
                    resultCutinBgm.UmaWaveStream.Position = 0;
                    resultListBgm.UmaWaveStream.Position = 0;
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(
                        resultCutinBgm.UmaWaveStream.ToSampleProvider()));
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(
                        new OffsetSampleProvider(resultListBgm.UmaWaveStream.ToSampleProvider())
                        {
                            DelayBy = resultCutinBgm.UmaWaveStream.TotalTime - TimeSpan.FromSeconds(1)
                        }));
                    break;
                case "playRunningButton":
                    firstPatternBgm.UmaWaveStream.Position = 0;
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(firstPatternBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playLastSpurtButton":
                    secondPatternBgm.UmaWaveStream.Position = 0;
                    mixer.AddMixerInput(new FadeInOutEventSampleProvider(secondPatternBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                default:
                    break;
            }

            waveOut?.Play();
        }

        private void TogglePlayButton_Click(object sender, EventArgs e)
        {
            if (currentRaceBgm is null) return;

            try
            {
                if (waveOut?.PlaybackState == PlaybackState.Playing)
                    waveOut.Pause();
                else
                    waveOut?.Play();
            }
            catch (Exception)
            {
                waveOut.Init(volumeSampleProvider);
                waveOut?.Play();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            mixer?.RemoveAllMixerInputs();
        }

        private void AmplifyUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (volumeSampleProvider is null) return;
            volumeSampleProvider.Volume = (float)amplifyUpDown.Value;
        }
    }
}
