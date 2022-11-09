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
using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.Views.DirectoryTrackerView;
using FolderMonitor.Memento.TrackersMemento;
using System.ComponentModel;

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

        public FolderMonitorHandler itsFolderMonitorHandler;

        public IDirectoryTrackerController itsDirectoryTrackerController;
        public IDirectoryTrackerView itsDirectoryTrackerView;

        public PageController itsPageController;
        public PageView itsPageView;

        public MainWindow()
        {
            InitializeComponent();

            itsDirectoryChangeController = new DirectoryChangeController();
            DirectoryChangeSaver.LoadDirectoryChanges(itsDirectoryChangeController);
            itsDirectoryChangeView = new DirectoryChangeView((DirectoryChangeController)itsDirectoryChangeController);
            itsDirectoryChangeController.ChangeView = itsDirectoryChangeView;

            itsFolderMonitorHandler = new FolderMonitorHandler(itsDirectoryChangeController);

            itsDirectoryTrackerController = new DirectoryTrackerController(itsFolderMonitorHandler);
            DirectoryTrackerSaver.LoadDirectoryTrackers((DirectoryTrackerController)itsDirectoryTrackerController);
            itsDirectoryTrackerView = new DirectoryTrackerView((DirectoryTrackerController)itsDirectoryTrackerController);

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
        private void Game_Closing(object sender, CancelEventArgs e)
        {
            DirectoryChangeSaver.SaveDirectoryChanges(itsDirectoryChangeController);
            DirectoryTrackerSaver.SaveDirectoryTrackers((DirectoryTrackerController)itsDirectoryTrackerController);
        }
    }
}