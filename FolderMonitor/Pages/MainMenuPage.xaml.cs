using FolderMonitor.Builders.OpenFileDialogBuilder;
using FolderMonitor.Controllers.FilterController;
using FolderMonitor.Handlers.MainMenu;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FolderMonitor.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainWindow itsContent;
        public FolderBrowserDialog itsTrackedDirectoryDialog;
        public string itsChosenFolder;
        public int itsSelectedTrackerModelIndex;
        public FilterController itsFilterController;
        public MainMenuPageHandler itsMainMenuPageHandler;
        
        public MainMenuPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;

            itsTrackedDirectoryDialog = FolderBrowserDialogCreator.CreateFolderBrowserDialog(new TrackerCommonFolderBrowserDialogBuilder());
            itsChosenFolder = string.Empty;
            itsFilterController = new FilterController(filtersStackPanel, deleteFilterButtonsStackPanel);
            itsMainMenuPageHandler = new MainMenuPageHandler(this);

            itsContent.itsDirectoryTrackerView.TrackersListView = trackedDirectoriesListView;
            itsContent.itsDirectoryTrackerView.ShowTrackers();
            itsContent.itsDirectoryChangeView.ChangesListView = directoryChangesListView;
            itsContent.itsDirectoryChangeView.ShowChanges();
        }


        private void AddOrUpdateTracker_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.AddOrUpdateTracker();
        }
        private void DeleteTracker_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.DeleteTracker();
        }
        private void EditTracker_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.EditTracker();
        }
        private void ClearTrackers_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.ClearTrackers();
        }


        private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.ChooseFolderForTracker();
        }
        private void AddFilter_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.AddFilterForTracker();
        }


        private void DeleteChange_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.DeleteDirectoryChange();
        }
        private void ClearChanges_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.ClearDirectoryChanges();
        }


        private void WarningOkButton_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.CloseStackPanelWarning();
        }


        private void About_Click(object sender, RoutedEventArgs e)
        {
            itsMainMenuPageHandler.ShowAboutPage();
        }
    }
}