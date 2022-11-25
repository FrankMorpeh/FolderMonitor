using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.Models.DirectoryChangeModel;
using System.Collections.Generic;
using System.IO;
using System;
using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.FolderMonitor
{
    public class FolderMonitorHandler
    {
        private List<FileSystemWatcher> itsFilesSystemWatcher;
        private event Action<IDirectoryChangeModel> itsAddDirectoryChangeEvent;

        public FolderMonitorHandler(IDirectoryChangeController directoryChangeController)
        {
            itsFilesSystemWatcher = new List<FileSystemWatcher>();
            itsAddDirectoryChangeEvent += directoryChangeController.AddChange;
        }


        public IWarning AddFolderToMonitor(IDirectoryTrackerModel trackerModel)
        {
            try // if it's not added, then there is no such folder anymore
            {
                itsFilesSystemWatcher.Add(new FileSystemWatcher(trackerModel.FolderPath));
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Filter = trackerModel.Filter;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Created += OnCreated;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Deleted += OnDeleted;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Changed += OnChanged;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].Renamed += OnRenamed;
                itsFilesSystemWatcher[itsFilesSystemWatcher.Count - 1].EnableRaisingEvents = true;
                trackerModel.IndexInFileWatcher = itsFilesSystemWatcher.Count - 1;

                return new None();
            }
            catch (Exception)
            {
                return new FolderHasBeenDeleted();
            }
        }
        public void RemoveFolderFromMonitorAt(int index)
        {
            itsFilesSystemWatcher.RemoveAt(index);
        }
        public void UpdateFolderInMonitorAt(IDirectoryTrackerModel trackerModel, int index)
        {
            itsFilesSystemWatcher[index].Path = trackerModel.FolderPath;
            itsFilesSystemWatcher[index].Filter = trackerModel.Filter;
        }
        public void ClearFoldersInMonitor()
        {
            ClearEventHandlers();
            itsFilesSystemWatcher.Clear();
        }
        private void ClearEventHandlers()
        {
            foreach (FileSystemWatcher fileSystemWatcher in itsFilesSystemWatcher)
            {
                fileSystemWatcher.Created -= OnCreated;
                fileSystemWatcher.Deleted -= OnDeleted;
                fileSystemWatcher.Changed -= OnChanged;
                fileSystemWatcher.Renamed -= OnRenamed;
            }    
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
            itsAddDirectoryChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Create
                , FolderMonitorHandlerMessageFormer.FormCreateMessage(e.FullPath, fileSystemWatcher.Path), DateTime.Now.ToString("G")));
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddDirectoryChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Delete
                , FolderMonitorHandlerMessageFormer.FormDeleteMessage(e.FullPath, fileSystemWatcher.Path), DateTime.Now.ToString("G")));
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddDirectoryChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Change,
                FolderMonitorHandlerMessageFormer.FormChangeMessage(e.FullPath, fileSystemWatcher.Path), DateTime.Now.ToString("G")));
        }
        private void OnRenamed(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fileSystemWatcher = (FileSystemWatcher)sender;
            itsAddDirectoryChangeEvent(new DirectoryChangeModel(DirectoryChangeType.Rename
                , FolderMonitorHandlerMessageFormer.FormRenameMessage(e.FullPath, fileSystemWatcher.Path), DateTime.Now.ToString("G")));
        }
    }
}