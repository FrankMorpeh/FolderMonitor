using FolderMonitor.Models.DirectoryTrackerModel;
using System.Collections.Generic;
using System.IO;

namespace FolderMonitor.Validators.TrackerValidators
{
    public static class DeletedFoldersValidator
    {
        public static List<DirectoryTrackerModel> RemoveTrackersAccordingToDeletedFolders(List<DirectoryTrackerModel> trackerModels)
        {
            List<DirectoryTrackerModel> workingTrackerModels = new List<DirectoryTrackerModel>();
            foreach (DirectoryTrackerModel trackerModel in trackerModels)
            {
                if (Directory.Exists(trackerModel.FolderPath))
                    workingTrackerModels.Add(trackerModel);
            }
            return workingTrackerModels;
        }
    }
}