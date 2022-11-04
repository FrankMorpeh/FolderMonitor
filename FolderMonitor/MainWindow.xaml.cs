using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.Memento.DirectoryChanges;
using FolderMonitor.Pages;
using FolderMonitor.Views.DirectoryChangeView;
using System;
using System.Windows;

namespace FolderMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string itsInitialLocation;

        public IDirectoryChangeController itsDirectoryChangeController;
        public IDirectoryChangeView itsDirectoryChangeView;

        public MainWindow()
        {
            InitializeComponent();

            itsDirectoryChangeController = new DirectoryChangeController();
            DirectoryChangeSaver.LoadDirectoryChanges(itsDirectoryChangeController);
            itsDirectoryChangeView = new DirectoryChangeView((DirectoryChangeController)itsDirectoryChangeController);
            itsDirectoryChangeController.ChangeView = itsDirectoryChangeView;
        }
        static MainWindow()
        {
            itsInitialLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            itsInitialLocation = System.IO.Path.GetDirectoryName(itsInitialLocation);
        }
        private void Window_Loaded(object sender, EventArgs e)
        {
            mainFrame.Content = new MainMenuPage(this); // move to main menu
        }
    }
}