using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UmaMusumeExplorer.Wpf.Helpers;
using UmaMusumeExplorer.Wpf.ViewModels;

namespace UmaMusumeExplorer.Wpf.Views.AudioPlayer
{
    [Page("Audio Player")]
    /// <summary>
    /// Interaction logic for AudioPlayer.xaml
    /// </summary>
    public partial class AudioPlayer : UserControl
    {
        public AudioPlayer()
        {
            InitializeComponent();
            DataContext = new AudioPlayerViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
