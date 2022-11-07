using FolderMonitor.Builders.OpenFileDialogBuilder;
using FolderMonitor.Controllers.FilterController;
using FolderMonitor.Converters;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Validators;
using FolderMonitor.Warnings;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
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
        private CommonOpenFileDialog itsTrackedDirectoryDialog;
        private string itsChosenFolder;
        private FilterController itsFilterController;

        public MainMenuPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
            itsTrackedDirectoryDialog = CommonOpenFileDialogCreator.CreateCommonOpenFileDialog(new TrackerCommonOpenFileDialogBuilder());
            itsFilterController = new FilterController(filtersStackPanel, deleteFilterButtonsStackPanel);
        }
        private void AddTracker_Click(object sender, RoutedEventArgs e)
        {
            List<string> filters = FiltersConverter.ToFiltersStringList(itsFilterController.FiltersStackPanel);
            if (FiltersValidator.CheckFilters(filters).GetType() == typeof(None))
            {
                itsContent.itsDirectoryTrackerView.AddTracker(new DirectoryTrackerModel(itsChosenFolder
                    , FiltersConverter.ToFilterString(filters)));
            }
            else
                WarningView.ShowStackPanelWarningByType(warningStackPanel, warningTextBlock, new IncorrectFilter());
        }
        private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            //if (itsTrackedDirectoryDialog.ShowDialog() == true)
            //    itsChosenFolder = itsTrackedDirectoryDialog.FileName;
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