using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeExplorer.Controls;
using UmaMusumeExplorer.Controls.RaceMusicSimulator;
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

        private readonly WaveOutEvent waveOut;

        private Bgm paddockBgm;
        private Bgm entryTableBgm;
        private Bgm resultCutInBgm;
        private Bgm resultListBgm;
        private Bgm firstPatternBgm;
        private Bgm secondPatternBgm;

        private MixingSampleProvider mixer;

        public RaceMusicSimulatorControl()
        {
            InitializeComponent();

            waveOut = new WaveOutEvent();
        }

        private void RaceSimulatorControl_Load(object sender, EventArgs e)
        {
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
            resultCutInBgm?.Dispose();
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
                        if ((string)propertyValue == string.Empty) continue;
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
                    bgmCueNames.Add(index, (string)propertyValue);
                }
                else if (property.Name.StartsWith("BgmCuesheetName"))
                {
                    int index = int.Parse(property.Name.Replace("BgmCuesheetName", ""));
                    bgmCuesheetNames.Add(index, (string)propertyValue);
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

            BgmComboBoxItem comboBoxItem = (BgmComboBoxItem)bgmIDComboBox.SelectedItem;
            raceBgm = comboBoxItem.RaceBgm;

            RaceBgmPattern firstPatternTable = PersistentData.RaceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm.FirstBgmPattern);
            RaceBgmPattern secondPatternTable = PersistentData.RaceBgmPatterns.FirstOrDefault(p =>
                p.Id == comboBoxItem.RaceBgm.SecondBgmPattern);

            firstPatternBgmList = LoadPattern(firstPatternTable);
            secondPatternBgmList = LoadPattern(secondPatternTable);

            paddockCueNameTextBox.Text = raceBgm.PaddockBgmCueName;
            paddockCuesheetNameTextBox.Text = raceBgm.PaddockBgmCuesheetName;
            entryTableCueNameTextBox.Text = raceBgm.EntryTableBgmCueName;
            entryTableCuesheetNameTextBox.Text = raceBgm.EntryTableBgmCuesheetName;

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

            paddockBgm = new(PersistentData.BgmGameFiles, raceBgm.PaddockBgmCuesheetName, raceBgm.PaddockBgmCueName);
            entryTableBgm = new(PersistentData.BgmGameFiles, raceBgm.EntryTableBgmCuesheetName, raceBgm.EntryTableBgmCueName);

            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(
                paddockBgm.UmaWaveStream.WaveFormat.SampleRate,
                paddockBgm.UmaWaveStream.WaveFormat.Channels));

            mixer.MixerInputEnded += Mixer_MixerInputEnded;

            waveOut.Init(new VolumeSampleProvider(mixer) { Volume = 3.0f });
            waveOut.Play();
        }

        private void Mixer_MixerInputEnded(object sender, SampleProviderEventArgs e)
        {
            MixingSampleProvider sampleProvider = (MixingSampleProvider)sender;

            sampleProvider.RemoveMixerInput(e.SampleProvider);
        }

        private void RaceResultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            RaceBgm raceBgm = ((BgmComboBoxItem)bgmIDComboBox.SelectedItem).RaceBgm;
            Type type = raceBgm.GetType();

            int propertyIndex = comboBox.SelectedIndex + 1;

            if (propertyIndex > 0)
            {
                string resultCutInBgmCuesheetName = type.GetProperty("ResultCutInBgmCuesheetName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultCutInBgmCueName = type.GetProperty("ResultCutInBgmCueName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultListBgmCuesheetName = type.GetProperty("ResultListBgmCuesheetName" + propertyIndex).GetValue(raceBgm).ToString();
                string resultListBgmCueName = type.GetProperty("ResultListBgmCueName" + propertyIndex).GetValue(raceBgm).ToString();

                resultCutInCuesheetNameTextBox.Text = resultCutInBgmCuesheetName;
                resultCutInCueNameTextBox.Text = resultCutInBgmCueName;
                resultListCuesheetNameTextBox.Text = resultListBgmCuesheetName;
                resultListCueNameTextBox.Text = resultListBgmCueName;
                resultCutInBgm = new Bgm(PersistentData.BgmGameFiles, resultCutInBgmCuesheetName, resultCutInBgmCueName);
                resultListBgm = new Bgm(PersistentData.BgmGameFiles, resultListBgmCuesheetName, resultListBgmCueName);
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
                firstPatternBgm = new(PersistentData.BgmGameFiles, firstPattern.BgmCuesheetName, firstPattern.BgmCueName);
            }
            else
            {
                firstPatternCueNameTextBox.Text = "";
                firstPatternCuesheetNameTextBox.Text = "";
            }
        }

        private void SecondPatternLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex >= 0)
            {
                secondPattern = secondPatternBgmList.FirstOrDefault(bi => bi.BgmTime == (int)comboBox.SelectedItem);
                secondPatternCueNameTextBox.Text = secondPattern.BgmCueName;
                secondPatternCuesheetNameTextBox.Text = secondPattern.BgmCuesheetName;
                secondPatternBgm = new(PersistentData.BgmGameFiles, secondPattern.BgmCuesheetName, secondPattern.BgmCueName);
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

            Button button = (Button)sender;

            switch (button.Name)
            {
                case "playPaddockButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(paddockBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playEntryTableButton":
                    mixer.AddMixerInput(new FadeInOutSampleProvider(entryTableBgm.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playRaceResultButton":
                    //mixer.AddMixerInput(new FadeInOutSampleProvider(raceR.UmaWaveStream.ToSampleProvider()));
                    break;
                case "playRunningButton":
                    mixer.AddMixerInput(new TestRunningBgmSampleProvider(firstPatternBgm, secondPatternBgm));
                    break;
                case "playLastSpurtButton":
                    //mixer.AddMixerInput(new FadeInOutSampleProvider(secondPatternBgm.UmaWaveStream.ToSampleProvider()));
                    TestRunningBgmSampleProvider test = (TestRunningBgmSampleProvider)mixer.MixerInputs.Last();
                    test.LastSpurt();
                    break;
                default:
                    break;
            }

            waveOut.Play();
        }
    }
}
