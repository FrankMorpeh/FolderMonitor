using FolderMonitor.Models.DirectoryTrackerModel;
using System.Collections.Generic;

namespace FolderMonitor.Controllers.DirectoryTrackerController
{
    public interface IDirectoryTrackerController
    {
        List<IDirectoryTrackerModel> Trackers { get; }
        // doesn't take IDirectoryTrackerModel, because there can be many filters, and loop needs to be implemented for this scenario
        bool AddTracker(string folderPath, List<string> filters); // returns false if there are the same filters
        void RemoveTracker(int index);
        void ClearTrackers();
    }
}