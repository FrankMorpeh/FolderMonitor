using FolderMonitor.Controllers.DirectoryTrackerController;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryTrackerView
{
    public interface IDirectoryTrackerView
    {
        ListView TrackersListView { set; }
        IDirectoryTrackerController TrackerController { set; }
        void ShowTrackers();
        bool AddTracker(string folderPath, List<string> filters);
        void RemoveTracker(int index);
        void ClearTrackers();
    }
}