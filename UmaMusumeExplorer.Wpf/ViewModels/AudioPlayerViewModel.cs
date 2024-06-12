using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UmaMusumeExplorer.Wpf.Views.AudioPlayer;

namespace UmaMusumeExplorer.Wpf.ViewModels
{
    internal class AudioPlayerViewModel : PageViewModel
    {
        public override string PageName => "Audio Player";

        public override Lazy<UserControl> View => new(() => new AudioPlayer());
    }
}
