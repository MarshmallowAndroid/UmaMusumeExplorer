using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Wpf.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            PageViewModels.Add(new FileBrowserViewModel());
            PageViewModels.Add(new AudioPlayerViewModel());
        }

        public List<ViewModelBase> PageViewModels { get; } = [];
    }
}
