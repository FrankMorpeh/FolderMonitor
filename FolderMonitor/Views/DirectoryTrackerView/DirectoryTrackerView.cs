using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Strings;
using FolderMonitor.Warnings;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryTrackerView
{
    public class DirectoryTrackerView : IDirectoryTrackerView
    {
        private ListView itsTrackersListView;
        private DirectoryTrackerController itsTrackerController;

        public ListView TrackersListView { set { itsTrackersListView = value; } }
        public IDirectoryTrackerController TrackerController { set { itsTrackerController = (DirectoryTrackerController)value; } }


        public DirectoryTrackerView(DirectoryTrackerController trackerController = null) { itsTrackerController = trackerController; }


        public void ShowTrackers()
        {
            itsTrackersListView.ItemsSource = itsTrackerController.Trackers;
            itsTrackersListView.Items.Refresh();
        }
        public IWarning AddTracker(string folderPath, List<string> filters)
        {
            IWarning warning = itsTrackerController.AddTracker(folderPath, filters);
            if (warning is None)
                ShowTrackers();
            return warning;
        }
        public void RemoveTracker(int index)
        {
            itsTrackerController.RemoveTracker(index);
            ShowTrackers();
        }
        public IWarning UpdateTrackerAt(IDirectoryTrackerModel directoryTrackerModel, int index)
        {
            IWarning warning = itsTrackerController.UpdateTrackerAt(directoryTrackerModel, index);
            if (warning is None)
                ShowTrackers();
            return warning;
        }
        public void ClearTrackers()
        {
            itsTrackerController.ClearTrackers();
            ShowTrackers();
        }
        public void ShowChosenTrackerOnEditPanel(int index, System.Windows.Forms.FolderBrowserDialog folderBrowserDialog, TextBlock chosenFolderTextBlock,
            TextBox filterTextBox)
        {
            folderBrowserDialog.SelectedPath = itsTrackerController[index].FolderPath;
            chosenFolderTextBlock.Text = StringFormatter.GetShortPathToFile(itsTrackerController[index].FolderPath);
            filterTextBox.Text = itsTrackerController[index].Filter;
        }
    }
}