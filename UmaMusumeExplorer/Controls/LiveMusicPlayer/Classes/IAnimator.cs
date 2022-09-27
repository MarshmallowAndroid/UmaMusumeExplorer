using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    public interface IAnimator<T> : IDisposable
    {
        public Task Animate(T to, float duration);

        public delegate void ValueAnimateEventHandler(IAnimator<T> sender, T value);
        public event ValueAnimateEventHandler ValueAnimate;

        public delegate void ValueAnimateFinishedEventHandler(IAnimator<T> sender, T finalValue);
        public event ValueAnimateFinishedEventHandler ValueAnimateFinished;
    }
}
