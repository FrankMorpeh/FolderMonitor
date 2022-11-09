﻿using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.Models.DirectoryChangeModel;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Strings;

namespace FolderMonitor.Handlers
{
    public class FolderMonitorHandler
    {
        private List<FileSystemWatcher> itsFilesSystemWatcher;
        private event Action<IDirectoryChangeModel> itsAddChangeEvent;

        public FolderMonitorHandler(IDirectoryChangeController directoryChangeController)
        {
            itsFilesSystemWatcher = new List<FileSystemWatcher>();
            itsAddChangeEvent += directoryChangeController.AddChange;
        }


        public void AddFolderToMonitor(IDirectoryTrackerModel trackerModel)
        {
            if (!itsFilesSystemWatcher.Contains(itsFilesSystemWatcher.Where(fsw => fsw.Equals(trackerModel)).SingleOrDefault()))
            {
                itsFilesSystemWatcher.Add(new FileSystemWatcher(trackerModel.FolderPath));
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Filter = trackerModel.Filter;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Created += OnCreated;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Deleted += OnDeleted;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Changed += OnChanged;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Renamed += OnRenamed;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].EnableRaisingEvents = true;
                trackerModel.IndexInFileWatcher = itsFilesSystemWatcher.Count - 1;
            }
        }
        public void RemoveFolderFromMonitor(IDirectoryTrackerModel trackerModel)
        {
            itsFilesSystemWatcher.Remove(itsFilesSystemWatcher.Where(fsw => fsw.Path == trackerModel.FolderPath).SingleOrDefault());
        }


        // Loading trackers from file
        public void LoadFolders(List<IDirectoryTrackerModel> trackerModels)
        {
            foreach (IDirectoryTrackerModel trackerModel in trackerModels)
                AddFolderToMonitor(trackerModel);
        }


        // Event handlers
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Create
                , StringFormatter.GetShortPathToFile(e.FullPath) + " has been created in " + fileSystemWatcher.Path, DateTime.Now.ToString("G")));
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Delete, StringFormatter.GetShortPathToFile(e.FullPath) 
                + " has been deleted from " + fileSystemWatcher.Path, DateTime.Now.ToString("G")));
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Change,
                StringFormatter.GetShortPathToFile(e.FullPath) + " has been changed in " + fileSystemWatcher.Path, DateTime.Now.ToString("G")));
        }
        private void OnRenamed(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Rename,
                StringFormatter.GetShortPathToFile(e.FullPath) + " has been renamed in " + fileSystemWatcher.Path, DateTime.Now.ToString("G")));
        }
    }
}