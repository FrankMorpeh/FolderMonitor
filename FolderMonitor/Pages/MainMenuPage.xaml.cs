using FolderMonitor.Builders.OpenFileDialogBuilder;
using FolderMonitor.Controllers.FilterController;
using FolderMonitor.Converters;
using FolderMonitor.Validators;
using FolderMonitor.Warnings;
using System.Collections.Generic;
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
        private MainWindow itsContent;
        private FolderBrowserDialog itsTrackedDirectoryDialog;
        private string itsChosenFolder;
        private FilterController itsFilterController;
        
        public MainMenuPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;

            itsTrackedDirectoryDialog = FolderBrowserDialogCreator.CreateFolderBrowserDialog(new TrackerCommonFolderBrowserDialogBuilder());
            itsFilterController = new FilterController(filtersStackPanel, deleteFilterButtonsStackPanel);

            itsContent.itsDirectoryTrackerView.TrackersListView = trackedDirectoriesListView;
            itsContent.itsDirectoryTrackerView.ShowTrackers();
            itsContent.itsDirectoryChangeView.ChangesListView = directoryChangesListView;
            itsContent.itsDirectoryChangeView.ShowChanges();
        }
        private void AddTracker_Click(object sender, RoutedEventArgs e)
        {
            List<string> filters = FiltersConverter.ToFiltersStringList(itsFilterController.FiltersStackPanel);
            if (FiltersValidator.CheckFilters(filters).GetType() == typeof(None))
            {
                if (itsContent.itsDirectoryTrackerView.AddTracker(itsChosenFolder, filters) == false)
                    WarningView.ShowStackPanelWarningByType(warningStackPanel, warningTextBlock, new SameFilter());
            }
            else
                WarningView.ShowStackPanelWarningByType(warningStackPanel, warningTextBlock, new IncorrectFilter());
        }
        private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            if (itsTrackedDirectoryDialog.ShowDialog() == DialogResult.OK)
                itsChosenFolder = itsTrackedDirectoryDialog.SelectedPath;
        }
        private void AddFilter_Click(object sender, RoutedEventArgs e)
        {
            itsFilterController.AddFilter();
        }
        private void DeleteTracker_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = trackedDirectoriesListView.SelectedIndex;
            if (selectedIndex != -1)
                itsContent.itsDirectoryTrackerView.RemoveTracker(selectedIndex);
            else
                WarningView.ShowStackPanelWarningByType(warningStackPanel, warningTextBlock, new TrackerIsNotChosen());
        }
        private void WarningOkButton_Click(object sender, RoutedEventArgs e)
        {
            WarningView.CloseStackPanelWarning(warningStackPanel);
        }
    }
}