using FolderMonitor.Handlers;
using FolderMonitor.Memento.TrackersMemento;
using FolderMonitor.Models.DirectoryTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FolderMonitor.Controllers.DirectoryTrackerController
{
    public class DirectoryTrackerController : IDirectoryTrackerController
    {
        private List<DirectoryTrackerModel> itsTrackers;
        private event Func<IDirectoryTrackerModel, int> itsAddTrackerEvent;
        private event Action<IDirectoryTrackerModel> itsRemoveTrackerEvent;
        public List<IDirectoryTrackerModel> Trackers { get { return itsTrackers.Cast<IDirectoryTrackerModel>().ToList(); } }


        public DirectoryTrackerController() 
        { 
            itsTrackers = new List<DirectoryTrackerModel>();
            itsAddTrackerEvent = null;
            itsRemoveTrackerEvent = null;
        }
        public DirectoryTrackerController(List<IDirectoryTrackerModel> trackers, FolderMonitorHandler folderMonitorHandler)
        {
            itsTrackers = trackers.Cast<DirectoryTrackerModel>().ToList();
            itsAddTrackerEvent += folderMonitorHandler.AddFolderToMonitor;
            itsRemoveTrackerEvent += folderMonitorHandler.RemoveFolderFromMonitor;
        }


        public void AddTracker(IDirectoryTrackerModel tracker)
        {
            tracker.IndexInFileWatcher = itsAddTrackerEvent(tracker);
            itsTrackers.Add((DirectoryTrackerModel)tracker);
        }
        public void RemoveTracker(int index)
        {
            itsRemoveTrackerEvent(itsTrackers[index]);
            itsTrackers.RemoveAt(index);
        }
        public void ClearTrackers()
        {
            itsTrackers.Clear();
        }
        

        // Memento
        public DirectoryTrackerMemento SaveState()
        {
            return new DirectoryTrackerMemento(itsTrackers.Cast<IDirectoryTrackerModel>().ToList());
        }
        public void LoadState(DirectoryTrackerMemento directoryTrackerMemento)
        {
            itsTrackers = directoryTrackerMemento.Trackers.Cast<DirectoryTrackerModel>().ToList();
        }
    }
}