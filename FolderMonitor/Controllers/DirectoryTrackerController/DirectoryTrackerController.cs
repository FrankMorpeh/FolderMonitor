using FolderMonitor.Handlers.FolderMonitor;
using FolderMonitor.Memento.TrackersMemento;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Validators.TrackerValidators;
using FolderMonitor.Warnings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FolderMonitor.Controllers.DirectoryTrackerController
{
    delegate void UpdateTrackerAtDelegate(IDirectoryTrackerModel directoryTrackerModel, int index);
    public class DirectoryTrackerController : IDirectoryTrackerController
    {
        private List<DirectoryTrackerModel> itsTrackers;
        private event Func<IDirectoryTrackerModel, IWarning> itsAddTrackerEvent;
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
        public IWarning AddTracker(string folderPath, List<string> filters)
        {
            if (filters.Count == 0) // if there are no filters, then just add one record both to DirectoryTrackerContorller and FolderMonitorHandler
                return AddTrackerWithNoFilters(folderPath);
            else // add a couple of records for one folder based on different filters
                return AddTrackerWithManyFilters(folderPath, filters);
        }
        private IWarning AddTrackerWithNoFilters(string folderPath)
        {
            if (!HasSameFilter(folderPath, string.Empty))
            {
                IWarning warning = itsAddTrackerEvent(new DirectoryTrackerModel(folderPath, string.Empty));
                if (warning is None) // if not None, then folder has been deleted
                    itsTrackers.Add(new DirectoryTrackerModel(folderPath, string.Empty));
                return warning;
            }
            else
                return new SameFilter();
        }
        private IWarning AddTrackerWithManyFilters(string folderPath, List<string> filters)
        {
            if (!HasSameFilters(folderPath, filters))
            {
                foreach (string filter in filters)
                {
                    if (itsAddTrackerEvent(new DirectoryTrackerModel(folderPath, filter)) is None)
                        itsTrackers.Add(new DirectoryTrackerModel(folderPath, filter));
                    else
                        return new FolderHasBeenDeleted();
                }
                return new None();
            }
            else
                return new SameFilter();
        }
        private bool HasSameFilter(string folderPath, string filter)
        {
            return itsTrackers.Exists(t => t.FolderPath == folderPath && t.Filter == filter);
        }
        private bool HasSameFilters(string folderPath, List<string> filters)
        {
            bool hasSameFilters = false;
            foreach (string filter in filters)
            {
                if (HasSameFilter(folderPath, filter))
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

        public IWarning UpdateTrackerAt(IDirectoryTrackerModel trackerModel, int index)
        {
            if (!HasSameFilter(trackerModel.FolderPath, trackerModel.Filter))
            {
                itsUpdateTrackerAtEvent(trackerModel, index);

                itsTrackers[index].FolderPath = trackerModel.FolderPath;
                itsTrackers[index].Filter = trackerModel.Filter;

                return new None();
            }
            else
                return new SameFilter();
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
            itsTrackers = DeletedFoldersValidator.RemoveTrackersAccordingToDeletedFolders(directoryTrackerMemento.Trackers);
            itsTrackersLoadedEvent(itsTrackers.Cast<IDirectoryTrackerModel>().ToList());
        }
    }
}