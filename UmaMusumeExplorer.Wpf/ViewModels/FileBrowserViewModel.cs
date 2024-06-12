using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UmaMusumeExplorer.Wpf.ViewModels
{
    internal class FileBrowserViewModel : PageViewModel
    {
        public override string PageName => "File Browser";

        public override Lazy<UserControl> View => new Lazy<UserControl>(() => new UserControl());
    }
}
