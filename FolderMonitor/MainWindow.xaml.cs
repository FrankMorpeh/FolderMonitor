using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.Controllers.PageController;
using FolderMonitor.FileReaders.TxtReader;
using FolderMonitor.Memento.DirectoryChanges;
using FolderMonitor.Pages;
using FolderMonitor.Views.DirectoryChangeView;
using FolderMonitor.Views.PageView;
using FolderMonitor.Handlers;
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
        public PageController itsPageController;
        public FolderMonitorHandler itsFolderMonitorHandler;
        public PageView itsPageView;

        public MainWindow()
        {
            InitializeComponent();

            itsDirectoryChangeController = new DirectoryChangeController();
            DirectoryChangeSaver.LoadDirectoryChanges(itsDirectoryChangeController);
            itsDirectoryChangeView = new DirectoryChangeView((DirectoryChangeController)itsDirectoryChangeController);
            itsDirectoryChangeController.ChangeView = itsDirectoryChangeView;

            itsFolderMonitorHandler = new FolderMonitorHandler(itsDirectoryChangeController);

            itsPageController = new PageController(AboutMenuReader.GetAboutMenuPages());
            itsPageView = new PageView(itsPageController);
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