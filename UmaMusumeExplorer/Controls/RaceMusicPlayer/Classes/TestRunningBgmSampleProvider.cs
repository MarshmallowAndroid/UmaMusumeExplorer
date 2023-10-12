using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace UmaMusumeExplorer.Controls.RaceMusicPlayer.Classes
{
    public class TestRunningBgmSampleProvider : ISampleProvider
    {
        private readonly FadeInOutSampleProvider first;
        private readonly ISampleProvider second;
        private readonly int fadeSampleCount;

        private bool lastSpurtTriggered = false;
        private int fadePosition = 0;

        public TestRunningBgmSampleProvider(Bgm firstPattern, Bgm secondPattern)
        {
            first = new(firstPattern.UmaWaveStream.ToSampleProvider());
            second = secondPattern.UmaWaveStream.ToSampleProvider();

            fadeSampleCount = 1000 * (WaveFormat.SampleRate / 1000);
        }

        public WaveFormat WaveFormat => first.WaveFormat;

        public void LastSpurt()
        {
            first.BeginFadeOut(500);
            lastSpurtTriggered = true;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            first.Read(buffer, offset, count);

            if (fadePosition >= fadeSampleCount)
            {
                float[] buffer2 = new float[count];
                second.Read(buffer2, 0, count);

                for (int i = 0; i < count; i++)
                {
                    buffer[i] += buffer2[i];
                }
            }

            if (lastSpurtTriggered && fadePosition < fadeSampleCount)
            {
                fadePosition += count;
            }

            return count;
        }
    }
}
