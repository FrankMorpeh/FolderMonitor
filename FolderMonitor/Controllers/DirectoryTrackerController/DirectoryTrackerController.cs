using FolderMonitor.Handlers;
using FolderMonitor.Memento.TrackersMemento;
using FolderMonitor.Models.DirectoryTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FolderMonitor.Controllers.DirectoryTrackerController
{
    delegate void UpdateTrackerAtDelegate(IDirectoryTrackerModel directoryTrackerModel, int index);
    public class DirectoryTrackerController : IDirectoryTrackerController
    {
        private List<DirectoryTrackerModel> itsTrackers;
        private event Action<IDirectoryTrackerModel> itsAddTrackerEvent;
        private event Action<int> itsRemoveTrackerEvent;
        private event UpdateTrackerAtDelegate itsUpdateTrackerAtEvent;
        private event Action itsClearTrackersEvent;
        private event Action<List<IDirectoryTrackerModel>> itsTrackersLoadedEvent; // adds also trackers to the list of FileSystemWatchers
        public List<IDirectoryTrackerModel> Trackers { get { return itsTrackers.Cast<IDirectoryTrackerModel>().ToList(); } }


        // Constructors
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
            itsRemoveTrackerEvent += folderMonitorHandler.RemoveFolderFromMonitorAt;
            itsUpdateTrackerAtEvent += folderMonitorHandler.UpdateFolderInMonitorAt;
            itsClearTrackersEvent += folderMonitorHandler.ClearFoldersInMonitor;
            itsTrackersLoadedEvent += folderMonitorHandler.LoadFolders;
        }


        // Data handling
        public bool AddTracker(string folderPath, List<string> filters)
        {
            if (filters.Count == 0) // if there are no filters, then just add one record both to DirectoryTrackerContorller and FolderMonitorHandler
            {
                itsAddTrackerEvent(new DirectoryTrackerModel(folderPath, string.Empty));
                itsTrackers.Add(new DirectoryTrackerModel(folderPath, string.Empty));
                return true;
            }
            else // add a couple of records for one folder based on different filters
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
            itsRemoveTrackerEvent(index);
            itsTrackers.RemoveAt(index);
        }
        public bool UpdateTrackerAt(IDirectoryTrackerModel trackerModel, int index)
        {
            List<string> filter = new List<string>();
            filter.Add(trackerModel.Filter);

            if (!HasSameFilters(trackerModel.FolderPath, filter))
            {
                itsUpdateTrackerAtEvent(trackerModel, index);

                itsTrackers[index].FolderPath = trackerModel.FolderPath;
                itsTrackers[index].Filter = trackerModel.Filter;

                return true;
            }
            else
                return false;
        }
        public void ClearTrackers()
        {
            itsClearTrackersEvent();
            itsTrackers.Clear();
        }


        // Indexer
        public IDirectoryTrackerModel this[int index]
        {
            get { return itsTrackers[index]; }
            set { itsTrackers[index] = (DirectoryTrackerModel)value; }
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