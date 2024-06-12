using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UmaMusumeExplorer.Wpf.ViewModels
{
    internal abstract class PageViewModel : ViewModelBase
    {
        public abstract string PageName { get; }

        public abstract Lazy<UserControl> View { get; }
    }
}
