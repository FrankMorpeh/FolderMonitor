using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Warnings;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryTrackerView
{
    public interface IDirectoryTrackerView
    {
        ListView TrackersListView { set; }
        IDirectoryTrackerController TrackerController { set; }
        void ShowTrackers();
        IWarning AddTracker(string folderPath, List<string> filters);
        void RemoveTracker(int index);
        IWarning UpdateTrackerAt(IDirectoryTrackerModel directoryTrackerModel, int index);
        void ClearTrackers();
        void ShowChosenTrackerOnEditPanel(int index, System.Windows.Forms.FolderBrowserDialog folderBrowserDialog, TextBlock chosenFolderTextBlock
            , TextBox filterTextBox); // FolderBrowserDialog is for actual path, TextBlock is just for displaying the name of the chosen folder
    }
}