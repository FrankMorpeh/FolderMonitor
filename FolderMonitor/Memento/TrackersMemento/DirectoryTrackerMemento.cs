using FolderMonitor.Models.DirectoryTrackerModel;
using System.Collections.Generic;

namespace FolderMonitor.Memento.TrackersMemento
{
    public class DirectoryTrackerMemento
    {
        public DirectoryTrackerMemento(List<IDirectoryTrackerModel> trackers) { Trackers = trackers; }

        public List<IDirectoryTrackerModel> Trackers { get; set; }
    }
}
