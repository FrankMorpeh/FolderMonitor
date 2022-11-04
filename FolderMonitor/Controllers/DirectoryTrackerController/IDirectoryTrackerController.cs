using FolderMonitor.Memento.TrackersMemento;
using FolderMonitor.Models.DirectoryTrackerModel;
using System.Collections.Generic;

namespace FolderMonitor.Controllers.DirectoryTrackerController
{
    public interface IDirectoryTrackerController
    {
        List<IDirectoryTrackerModel> Trackers { get; }
        void AddTracker(IDirectoryTrackerModel tracker);
        void RemoveTracker(int index);
        void ClearTrackers();
        void LoadState(DirectoryTrackerMemento directoryTrackerMemento);
        DirectoryTrackerMemento SaveState();
    }
}