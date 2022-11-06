using FolderMonitor.Builders.FilterBuilder;
using FolderMonitor.Converters;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Validators;
using FolderMonitor.Warnings;
using Microsoft.Win32;
using System.CodeDom;
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
        private OpenFileDialog itsTrackedDirectoryDialog;
        private string itsChosenFolder;

        public MainMenuPage(MainWindow content)
        {
            InitializeComponent();
            itsContent = content;
            InitTrackedDirectoryDialog();
        }
        private void InitTrackedDirectoryDialog()
        {
            itsTrackedDirectoryDialog = new OpenFileDialog();
            itsTrackedDirectoryDialog.Title = "Folder";
            itsTrackedDirectoryDialog.Filter = "Folder |*.";
        }
        private void AddTracker_Click(object sender, RoutedEventArgs e)
        {
            List<string> filters = FiltersConverter.ToFiltersList(filtersStackPanel);
            if (FiltersValidator.CheckFilters(filters).GetType() == typeof(None))
            {
                itsContent.itsDirectoryTrackerView.AddTracker(new DirectoryTrackerModel(itsChosenFolder
                    , FiltersConverter.ToFilterString(filters)));
            }
        }
        private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            if (itsTrackedDirectoryDialog.ShowDialog() == true)
                itsChosenFolder = itsTrackedDirectoryDialog.FileName;
        }
        private void AddFilter_Click(object sender, RoutedEventArgs e)
        {
            filtersStackPanel.Children.Add(FilterCreator.CreateFilter(new TrackerFilterBuilder(), filtersStackPanel.Children.Count + 1));
        }
        private void DeleteTracker_Click(object sender, RoutedEventArgs e)
        {

        }
        private void WarningOkButton_Click(object sender, RoutedEventArgs e)
        {
            itsWarningStackPanel.Visibility = Visibility.Hidden;
        }
    }
}