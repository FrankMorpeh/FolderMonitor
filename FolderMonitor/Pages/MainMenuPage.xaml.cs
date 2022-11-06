using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private MainWindow itsContent;

        public MainMenuPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
        }
        private void AddTracker_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
