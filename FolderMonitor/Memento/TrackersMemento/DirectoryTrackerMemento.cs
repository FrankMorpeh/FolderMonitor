using FolderMonitor.Models.DirectoryTrackerModel;
using System.Collections.Generic;

namespace FolderMonitor.Memento.TrackersMemento
{
    public class DirectoryTrackerMemento
    {
        public DirectoryTrackerMemento(List<DirectoryTrackerModel> trackers) { Trackers = trackers; }

        public List<DirectoryTrackerModel> Trackers { get; set; }
    }
}