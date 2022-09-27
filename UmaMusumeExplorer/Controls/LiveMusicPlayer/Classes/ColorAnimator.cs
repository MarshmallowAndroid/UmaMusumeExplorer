using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    public sealed class ColorAnimator : IAnimator<Color>
    {
        private readonly Timer animationTimer = new(1000f / 60f);

        private Color fromColor;
        private Color lastColor;
        private Color toColor;

        private readonly AnimationCommon.EasingFunction easingFunction;

        private float animationDuration = 0f;
        private float animationPercentage = 0f;

        public ColorAnimator(Color initialColor)
        {
            lastColor = initialColor;
            easingFunction = EasingFunctions.Linear;

            animationTimer.Elapsed += AnimationTimer_Elapsed;
        }

        public ColorAnimator(Color initialColor, AnimationCommon.EasingFunction ease) : this(initialColor)
        {
            easingFunction = ease;
        }

        private void AnimationTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lastColor = AnimationCommon.AnimateColor(fromColor, toColor, animationPercentage, easingFunction);
            ValueAnimate?.Invoke(this, lastColor);

            animationPercentage += (float)animationTimer.Interval / animationDuration;

            if (animationPercentage >= 1.0f)
            {
                animationTimer.Stop();
                ValueAnimateFinished?.Invoke(this, lastColor);
            }
        }

        public Task Animate(Color to, float duration)
        {
            animationTimer.Stop();

            if (duration <= 0f)
            {
                lastColor = to;
                ValueAnimate?.Invoke(this, to);
                return Task.CompletedTask;
            }

            animationPercentage = 0.0f;

            fromColor = lastColor;
            toColor = to;
            animationDuration = duration;

            animationTimer.Start();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            animationTimer.Stop();

            animationTimer.Elapsed -= AnimationTimer_Elapsed;
            animationTimer.Dispose();
        }

        public event IAnimator<Color>.ValueAnimateEventHandler ValueAnimate;
        public event IAnimator<Color>.ValueAnimateFinishedEventHandler ValueAnimateFinished;
    }
}
