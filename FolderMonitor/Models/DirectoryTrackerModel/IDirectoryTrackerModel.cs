using System.Collections.Generic;

namespace FolderMonitor.Models.DirectoryTrackerModel
{
    public interface IDirectoryTrackerModel
    {
        int IndexInFileWatcher { set; }
        string FolderPath { get; }
        string Filter { get; set; } // all filters from list in one string (used for ListView); view: *.format
    }
}