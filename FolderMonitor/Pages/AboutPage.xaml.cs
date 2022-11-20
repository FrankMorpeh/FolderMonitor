using FolderMonitor.Controllers.PageController;
using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Pages
{
    /// <summary>
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        private MainWindow itsContent;

        public AboutPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
            aboutTextBox.Text = itsContent.itsPageView.ShowPageByNumber(1);
        }
        public void ButtonPage_Click(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == previousPageButton)
                aboutTextBox.Text = itsContent.itsPageView.ShowPageByArrowState(ArrowState.Left);
            else if ((Button)sender == nextPageButton)
                aboutTextBox.Text = itsContent.itsPageView.ShowPageByArrowState(ArrowState.Right);
            else
                itsContent.mainFrame.GoBack(); // back to main page
        }
    }
}