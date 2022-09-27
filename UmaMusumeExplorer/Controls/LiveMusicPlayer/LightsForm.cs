using AssetStudio;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes.UnityTypes;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    public partial class LightsForm : Form
    {
        private readonly AssetsManager assetsManager = new();
        private readonly SongMixer mixer;

        private readonly Thread lightsThread;

        private readonly List<LiveTimelineKeyBlinkLightData> lightData = new();
        private int currentKeyIndex = 0;

        private readonly ColorAnimator color1;
        private readonly ColorAnimator color2;
        private readonly ColorAnimator color3;

        public LightsForm(int musicId, SongMixer songMixer)
        {
            InitializeComponent();

            mixer = songMixer;

            GameAsset cameraAsset = UmaDataHelper.GetGameAssetDataRows(ga => ga.BaseName == $"son{musicId}_camera").FirstOrDefault();

            assetsManager.LoadFiles(UmaDataHelper.GetPath(cameraAsset));

            MonoBehaviour cameraMonoBehaviour = null;
            foreach (var file in assetsManager.assetsFileList)
            {
                foreach (var gameObject in file.Objects)
                {
                    if (gameObject.type == ClassIDType.MonoBehaviour)
                    {
                        cameraMonoBehaviour = (MonoBehaviour)gameObject;
                        break;
                    }
                }
            }

            if (cameraMonoBehaviour is not null)
            {
                OrderedDictionary typeTree = cameraMonoBehaviour.ToType();
                LiveTimelineWorkSheet blinkLightData = (LiveTimelineWorkSheet)TypeTreeUtility.TypeTreeToType(typeof(LiveTimelineWorkSheet), typeTree);

                foreach (var key in blinkLightData.BlinkLightList.First(bd => bd.Name == "pfb_env_live10120_blinklight_led_a000").Keys.ThisList)
                {
                    lightData.Add(key);
                }
            }

            lightsThread = new(DoLightsPlayback);
            lightsThread.Start();

            color1 = new(System.Drawing.Color.Black);
            color2 = new(System.Drawing.Color.Black);
            color3 = new(System.Drawing.Color.Black);

            color1.ValueAnimate += Color1_ValueAnimate;
            color2.ValueAnimate += Color2_ValueAnimate;
            color3.ValueAnimate += Color3_ValueAnimate;
        }

        private void Color3_ValueAnimate(IAnimator<System.Drawing.Color> sender, System.Drawing.Color value)
        {
            pictureBox1.BackColor = value;
        }

        private void Color2_ValueAnimate(IAnimator<System.Drawing.Color> sender, System.Drawing.Color value)
        {
            pictureBox2.BackColor = value;
        }

        private void Color1_ValueAnimate(IAnimator<System.Drawing.Color> sender, System.Drawing.Color value)
        {
            pictureBox3.BackColor = value;
        }

        private void DoLightsPlayback()
        {
            //LyricsTrigger currentLyricsTrigger = lyricsTriggers[lyricsTriggerIndex];
            while (true)
            {
                double framesElapsed = mixer.CurrentTime.TotalMilliseconds / 1000.0d * 60.0d;

                while (framesElapsed >= lightData[currentKeyIndex].Frame)
                {
                    LiveTimelineKeyBlinkLightData current = lightData[currentKeyIndex];

                    color1.Animate(current.PowerArray[0] == 1.0f ? current.Color0Array[0].ToColor() : Color.Black, current.KeepTime * 1000.0f);
                    color2.Animate(current.PowerArray[1] == 1.0f ? current.Color0Array[1].ToColor() : Color.Black, current.KeepTime * 1000.0f);
                    color3.Animate(current.PowerArray[2] == 1.0f ? current.Color0Array[2].ToColor() : Color.Black, current.KeepTime * 1000.0f);

                    if (currentKeyIndex < lightData.Count - 1)
                        currentKeyIndex++;
                    else break;

                    //currentLyricsTrigger = lyricsTriggers[lyricsTriggerIndex];
                }

                Thread.Sleep(1);
            }
        }

        private void TryInvoke(Action action)
        {
            try
            {
                Invoke(action);
            }
            catch (Exception)
            {
            }
        }
    }
}
