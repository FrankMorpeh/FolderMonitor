using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.Models.DirectoryTrackerModel;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryTrackerView
{
    public interface IDirectoryTrackerView
    {
        ListView TrackersListView { set; }
        IDirectoryTrackerController TrackerController { set; }
        void ShowTrackers();
        void AddTracker(IDirectoryTrackerModel trackerModel);
        void RemoveTracker(int index);
        void ClearTrackers();
    }
}