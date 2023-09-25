using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    internal class FormAnimator
    {
        private readonly Form form;
        private readonly int defaultHeight;
        private readonly int expandedHeight;

        private readonly Timer timer;

        private AnimationTarget target;
        private float currentProgress = 0F;
        private bool finished = true;
        private int recordedTop;

        public FormAnimator(Form targetForm, int defaultHeight, int expandedHeight)
        {
            form = targetForm;
            this.defaultHeight = defaultHeight;
            this.expandedHeight = expandedHeight;

            timer = new();
            timer.Interval = (int)(1000F / 60F);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (target == AnimationTarget.Expand)
            {
                form.Height = AnimateValue(defaultHeight, expandedHeight, currentProgress, EaseInOutQuart);
                form.Top = AnimateValue(recordedTop, recordedTop - (expandedHeight / 2 / 4), currentProgress, EaseInOutQuart);
            }
            else
            {
                form.Height = AnimateValue(expandedHeight, defaultHeight, currentProgress, EaseInOutQuart);
                form.Top = AnimateValue(recordedTop, recordedTop + (expandedHeight / 2 / 4), currentProgress, EaseInOutQuart);
            }

            if (!finished)
                currentProgress += timer.Interval / 400F;

            if (currentProgress >= 1F)
                finished = true;

            if (finished)
            {
                timer.Stop();
                currentProgress = 0F;
            }
        }

        public bool Expand()
        {
            if (!finished) return false;

            recordedTop = form.Top;

            timer.Start();
            target = AnimationTarget.Expand;

            finished = false;

            return true;
        }

        public bool Collapse()
        {
            if (!finished) return false;

            recordedTop = form.Top;

            timer.Start();
            target = AnimationTarget.Collapse;

            finished = false;

            return true;
        }

        private static int AnimateValue(int from, int to, float progress, Func<float, float> easingFunction)
        {
            progress = Math.Clamp(progress, 0.0F, 1.0F);

            float ease = easingFunction(progress);

            int difference = to - from;
            return from + MultiplyProgress(ease, difference);
        }

        private static int MultiplyProgress(float progress, int value)
        {
            if (value < 0)
            {
                value = (int)Math.Floor(progress * value);
            }
            else
            {
                value = (int)Math.Ceiling(progress * value);
            }

            return value;
        }

        private static float EaseInOutQuart(float x)
        {
            return (float)(x < 0.5f ? 8f * x * x * x * x : 1f - Math.Pow(-2f * x + 2f, 4f) / 2f);
        }

        private enum AnimationTarget
        {
            Expand,
            Collapse
        }
    }
}
