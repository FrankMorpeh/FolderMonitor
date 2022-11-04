using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.Models.DirectoryTrackerModel;
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
        public void AddTracker(IDirectoryTrackerModel trackerModel)
        {
            itsTrackerController.AddTracker(trackerModel);
            ShowTrackers();
        }
        public void RemoveTracker(int index)
        {
            itsTrackerController.RemoveTracker(index);
            ShowTrackers();
        }
        public void ClearTrackers()
        {
            itsTrackerController.ClearTrackers();
            ShowTrackers();
        }
    }
}
