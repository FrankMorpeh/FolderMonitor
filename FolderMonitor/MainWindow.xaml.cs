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

        public DirectoryChangeController itsDirectoryChangeController;
        public DirectoryChangeView itsDirectoryChangeView;

        public MainWindow()
        {
            InitializeComponent();

            itsDirectoryChangeController = new DirectoryChangeController();
            DirectoryChangeSaver.LoadDirectoryChanges(itsDirectoryChangeController);
            itsDirectoryChangeView = new DirectoryChangeView(itsDirectoryChangeController);
            itsDirectoryChangeController.DirectoryChangeView = itsDirectoryChangeView;
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