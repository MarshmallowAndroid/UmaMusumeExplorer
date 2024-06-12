using System.Windows;

namespace UmaMusumeExplorer.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsDefined(typeof(PageAttribute))))
            //{
            //    if (type.BaseType != typeof(UserControl)) continue;

            //    string pageName = type.GetCustomAttributes<PageAttribute>().First().PageName;

            //    TabItem tabItem = new TabItem
            //    {
            //        Header = pageName,
            //        Content = new Lazy<UserControl>(() => (UserControl)Activator.CreateInstance(type)!).Value
            //    };
            //    tabControl.Items.Add(tabItem);
            //}
        }
    }
}