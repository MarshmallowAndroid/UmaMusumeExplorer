using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeExplorer.Controls;
using UmaMusumeExplorer.Controls.RaceMusicSimulator.Classes;
using UmaMusumeFiles;
using UmaMusumeFiles.Tables;

namespace PlayerGui.Controls.RaceMusicSimulator
{
    public partial class RaceMusicSimulatorControl : UserControl
    {
        private RaceBgm raceBgm;
        private List<Pattern> firstPatternBgmList;
        private List<Pattern> secondPatternBgmList;
        private Pattern firstPattern;
        private Pattern secondPattern;

        private WaveOutEvent waveOut;

        private Bgm paddockBgm;
        private Bgm entryTableBgm;
        private Bgm resultCutinBgm;
        private Bgm resultListBgm;
        private Bgm firstPatternBgm;
        private Bgm secondPatternBgm;

        private MixingSampleProvider mixer;

        public RaceMusicSimulatorControl()
        {
            InitializeComponent();
        }

        private void RaceSimulatorControl_Load(object sender, EventArgs e)
        {
            waveOut = new WaveOutEvent();

            IEnumerable<RaceBgm> raceBgm = PersistentData.RaceBgm;

            foreach (var bgm in raceBgm)
            {
                bgmIDComboBox.Items.Add(new BgmComboBoxItem() { RaceBgm = bgm });
            }
        }

        private void BgmIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

            waveOut.Stop();

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
                object propertyValue = property.GetValue(pattern);

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
                    bgmCueNames.Add(index, propertyValue as string);
                }
                else if (property.Name.StartsWith("BgmCuesheetName"))
                {
                    int index = int.Parse(property.Name.Replace("BgmCuesheetName", ""));
                    bgmCuesheetNames.Add(index, propertyValue as string);
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
            waveOut.Stop();

            BgmComboBoxItem comboBoxItem = bgmIDComboBox.SelectedItem as BgmComboBoxItem;
            raceBgm = comboBoxItem.RaceBgm;

            RaceBgmPattern firstPatternTable = PersistentData.RaceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm.FirstBgmPattern);
            RaceBgmPattern secondPatternTable = PersistentData.RaceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm.SecondBgmPattern);

            firstPatternBgmList = LoadPattern(firstPatternTable);
            secondPatternBgmList = LoadPattern(secondPatternTable);

            paddockCueNameTextBox.Text = raceBgm.PaddockBgmCueName;
            paddockCuesheetNameTextBox.Text = raceBgm.PaddockBgmCuesheetName;
            entryTableCueNameTextBox.Text = raceBgm.EntrytableBgmCueName;
            entryTableCuesheetNameTextBox.Text = raceBgm.EntrytableBgmCuesheetName;

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

            paddockBgm = new(PersistentData.BgmGameAssets, raceBgm.PaddockBgmCuesheetName, raceBgm.PaddockBgmCueName);
            entryTableBgm = new(PersistentData.BgmGameAssets, raceBgm.EntrytableBgmCuesheetName, raceBgm.EntrytableBgmCueName);

            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(
                paddockBgm.UmaWaveStream.WaveFormat.SampleRate,
                paddockBgm.UmaWaveStream.WaveFormat.Channels)) { ReadFully = true };

            mixer.MixerInputEnded += Mixer_MixerInputEnded;

            waveOut.Init(new VolumeSampleProvider(mixer) { Volume = 4.0f });
            waveOut.Play();
        }

        private void Mixer_MixerInputEnded(object sender, SampleProviderEventArgs e)
        {
            //MixingSampleProvider sampleProvider = sender as MixingSampleProvider;

            //sampleProvider.RemoveMixerInput(e.SampleProvider);
        }

        private void RaceResultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            RaceBgm raceBgm = (bgmIDComboBox.SelectedItem as BgmComboBoxItem).RaceBgm;
            Type type = raceBgm.GetType();

            int propertyIndex = comboBox.SelectedIndex + 1;

            if (propertyIndex > 0)
            {
                string resultCutinBgmCuesheetName = type.GetProperty("ResultCutinBgmCuesheetName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultCutinBgmCueName = type.GetProperty("ResultCutinBgmCueName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultListBgmCuesheetName = type.GetProperty("ResultListBgmCuesheetName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultListBgmCueName = type.GetProperty("ResultListBgmCueName" + propertyIndex).GetValue(raceBgm).ToString();

                resultCutInCuesheetNameTextBox.Text = resultCutinBgmCuesheetName;
                resultCutInCueNameTextBox.Text = resultCutinBgmCueName;
                resultListCuesheetNameTextBox.Text = resultListBgmCuesheetName;
                resultListCueNameTextBox.Text = resultListBgmCueName;
                resultCutinBgm = new Bgm(PersistentData.BgmGameAssets, resultCutinBgmCuesheetName, resultCutinBgmCueName);
                resultListBgm = new Bgm(PersistentData.BgmGameAssets, resultListBgmCuesheetName, resultListBgmCueName);
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
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex >= 0)
            {
                firstPattern = firstPatternBgmList.FirstOrDefault(bi => bi.BgmTime == (int)comboBox.SelectedItem);
                firstPatternCueNameTextBox.Text = firstPattern.BgmCueName;
                firstPatternCuesheetNameTextBox.Text = firstPattern.BgmCuesheetName;
                firstPatternBgm = new(PersistentData.BgmGameAssets, firstPattern.BgmCuesheetName, firstPattern.BgmCueName);
            }
            else
            {
                firstPatternCueNameTextBox.Text = "";
                firstPatternCuesheetNameTextBox.Text = "";
            }
        }

        private void SecondPatternLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedIndex >= 0)
            {
                secondPattern = secondPatternBgmList.FirstOrDefault(bi => bi.BgmTime == (int)comboBox.SelectedItem);
                secondPatternCueNameTextBox.Text = secondPattern.BgmCueName;
                secondPatternCuesheetNameTextBox.Text = secondPattern.BgmCuesheetName;
                secondPatternBgm = new(PersistentData.BgmGameAssets, secondPattern.BgmCuesheetName, secondPattern.BgmCueName);
            }
            else
            {
                secondPatternCueNameTextBox.Text = "";
                secondPatternCuesheetNameTextBox.Text = "";
            }
        }

        private void PlayButtons_Click(object sender, EventArgs e)
        {
            if (raceBgm == null) return;

            Button button = sender as Button;

            if (mixer.MixerInputs.Any())
            {
                FadeInOutSampleProvider sampleProvider = mixer.MixerInputs.Last() as FadeInOutSampleProvider;
                sampleProvider.BeginFadeOut(500);
            }

            switch (button.Name)
            {
                case "playPaddockButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(paddockBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playEntryTableButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(entryTableBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playRaceResultButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(
                        resultCutinBgm.UmaWaveStream.ToSampleProvider()));
                    mixer.AddMixerInput(new FadeInOutSampleProvider(
                        new OffsetSampleProvider(resultListBgm.UmaWaveStream.ToSampleProvider())
                        {
                            DelayBy = resultCutinBgm.UmaWaveStream.TotalTime - TimeSpan.FromSeconds(1)
                        }));
                    break;
                case "playRunningButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(firstPatternBgm.UmaWaveStream.ToSampleProvider()));
                    //mixer.AddMixerInput(new TestRunningBgmSampleProvider(firstPatternBgm, secondPatternBgm));
                    break;
                case "playLastSpurtButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(secondPatternBgm.UmaWaveStream.ToSampleProvider()));
                    //TestRunningBgmSampleProvider test = (TestRunningBgmSampleProvider)mixer.MixerInputs.Last();
                    //test.LastSpurt();
                    break;
                default:
                    break;
            }

            waveOut.Play();
        }
    }
}
