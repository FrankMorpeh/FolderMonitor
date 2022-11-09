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
        private event Action<IDirectoryTrackerModel> itsAddTrackerEvent;
        private event Action<IDirectoryTrackerModel> itsRemoveTrackerEvent;
        private event Action<List<IDirectoryTrackerModel>> itsTrackersLoadedEvent; // adds also trackers to the list of FileSystemWatchers
        public List<IDirectoryTrackerModel> Trackers { get { return itsTrackers.Cast<IDirectoryTrackerModel>().ToList(); } }


        public DirectoryTrackerController(FolderMonitorHandler folderMonitorHandler) 
        { 
            itsTrackers = new List<DirectoryTrackerModel>();
            SetEvents(folderMonitorHandler);
        }
        public DirectoryTrackerController(FolderMonitorHandler folderMonitorHandler, List<IDirectoryTrackerModel> trackers)
        {
            itsTrackers = trackers.Cast<DirectoryTrackerModel>().ToList();
            SetEvents(folderMonitorHandler);
        }
        private void SetEvents(FolderMonitorHandler folderMonitorHandler)
        {
            itsAddTrackerEvent += folderMonitorHandler.AddFolderToMonitor;
            itsRemoveTrackerEvent += folderMonitorHandler.RemoveFolderFromMonitor;
            itsTrackersLoadedEvent += folderMonitorHandler.LoadFolders;
        }


        public bool AddTracker(string folderPath, List<string> filters)
        {
            if (!HasSameFilters(folderPath, filters))
            {
                foreach (string filter in filters)
                {
                    itsAddTrackerEvent(new DirectoryTrackerModel(folderPath, filter));
                    // the id for the added tracker will be done inside the event handler (FolderMonitorHandler.AddFolderToMonitor)
                    itsTrackers.Add(new DirectoryTrackerModel(folderPath, filter));
                }
                return true;
            }
            else
                return false;
        }
        private bool HasSameFilters(string folderPath, List<string> filters)
        {
            bool hasSameFilters = false;
            foreach (string filter in filters)
            {
                if (itsTrackers.Exists(t => t.FolderPath == folderPath && t.Filter == filter))
                {
                    hasSameFilters = true;
                    break;
                }
            }
            return hasSameFilters;
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
            return new DirectoryTrackerMemento(itsTrackers);
        }
        public void LoadState(DirectoryTrackerMemento directoryTrackerMemento)
        {
            itsTrackers = directoryTrackerMemento.Trackers;
            itsTrackersLoadedEvent(itsTrackers.Cast<IDirectoryTrackerModel>().ToList());
        }
    }
}