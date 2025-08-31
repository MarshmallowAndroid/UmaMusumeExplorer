using System.Diagnostics;

namespace UmaMusumeExplorer.Utility
{
    internal class FormAnimator
    {
        private readonly Form form;
        private readonly int defaultHeight;
        private readonly int expandedHeight;

        private readonly PreciseTimer timer;

        private AnimationTarget target;
        private float currentProgress = 0F;
        private bool finished = true;
        private int recordedTop;

        public FormAnimator(Form targetForm, int defaultHeight, int expandedHeight)
        {
            form = targetForm;
            this.defaultHeight = defaultHeight;
            this.expandedHeight = expandedHeight;

            timer = new((int)(1000F / 30F));
            timer.Elapsed += Elapsed;
        }

        private void Elapsed()
        {
            if (target == AnimationTarget.Expand)
            {
                form.Invoke(() => form.Height = AnimateValue(defaultHeight, expandedHeight, currentProgress, Ease));
                form.Invoke(() => form.Top = AnimateValue(recordedTop, recordedTop - expandedHeight / 2 / 4, currentProgress, Ease));
            }
            else
            {
                form.Invoke(() => form.Height = AnimateValue(expandedHeight, defaultHeight, currentProgress, Ease));
                form.Invoke(() => form.Top = AnimateValue(recordedTop, recordedTop + expandedHeight / 2 / 4, currentProgress, Ease));
            }

            if (currentProgress > 1F)
                finished = true;

            if (!finished)
                currentProgress += timer.Interval / 600F;

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

        private static float Ease(float x)
        {
            // Formulas from https://easings.net/

            // EaseInOutCubic
            //return (float)(x < 0.5F ? 8F * x * x * x * x : 1F - Math.Pow(-2F * x + 2F, 4F) / 2F);

            // EaseOutCubic
            //return (float)(1F - Math.Pow(1F - x, 3));

            // EaseOutExpo
            return (float)(x == 1 ? 1 : 1 - Math.Pow(2, -10 * x));

            // EaseOutBack
            //const float c1 = 1.70158f;
            //const float c3 = c1 + 1;
            //return (float)(1 + c3 * Math.Pow(x - 1, 3) + c1 * Math.Pow(x - 1, 2));

            // EaseOutElastic
            //const float c4 = (float)(2 * Math.PI / 3);
            //return (float)(x == 0 ? 0 : x == 1 ? 1 : (Math.Pow(2, -10 * x) * Math.Sin(((x * 10) - 0.75) * c4)) + 1);

            // EaseOutBounce
            //const float n1 = 7.5625f;
            //const float d1 = 2.75f;
            //if (x < 1 / d1)
            //{
            //    return n1 * x * x;
            //}
            //else if (x < 2 / d1)
            //{
            //    return (float)(n1 * (x -= 1.5f / d1) * x + 0.75);
            //}
            //else if (x < 2.5 / d1)
            //{
            //    return (float)(n1 * (x -= 2.25f / d1) * x + 0.9375);
            //}
            //else
            //{
            //    return (float)(n1 * (x -= 2.625f / d1) * x + 0.984375);
            //}
        }

        private enum AnimationTarget
        {
            Expand,
            Collapse
        }

        class PreciseTimer
        {
            private Thread? timerThread;
            private bool continueRunning;

            public PreciseTimer(float interval)
            {
                Interval = interval;
            }

            public float Interval { get; }

            public void Start()
            {
                timerThread = new Thread(RunTimer)
                {
                    IsBackground = true
                };
                timerThread.Start();
                continueRunning = true;
            }

            public void Stop()
            {
                continueRunning = false;
            }

            private void RunTimer()
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();

                double next = 0d;
                while (continueRunning)
                {
                    next += Interval;

                    double elapsed;
                    while (true)
                    {
                        elapsed = ElapsedMillis(stopwatch);
                        double difference = next - elapsed;
                        if (difference <= 0F) break;
                        else Thread.SpinWait(10);
                        if (!continueRunning) return;
                    }

                    Elapsed?.Invoke();

                    if (!continueRunning) return;

                    if (stopwatch.Elapsed.TotalSeconds >= 10d)
                    {
                        next = 0d;
                        stopwatch.Restart();
                    }
                }
            }

            private static double ElapsedMillis(Stopwatch stopwatch)
            {
                return stopwatch.ElapsedTicks * (1000F / Stopwatch.Frequency);
            }

            public delegate void PreciseTimerEventHandler();
            public event PreciseTimerEventHandler? Elapsed;
        }
    }
}
