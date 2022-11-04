namespace FolderMonitor.Models.DirectoryTrackerModel
{
    public class DirectoryTrackerModel : IDirectoryTrackerModel
    {
        private readonly string itsFolderPath;
        private readonly string itsFilter;

        public DirectoryTrackerModel() { itsFolderPath = string.Empty; itsFilter = string.Empty; }
        public DirectoryTrackerModel(string folderName, string filter) { itsFolderPath = folderName; itsFilter = filter; }
        
        public string FolderPath { get { return itsFolderPath; } }
        public string Filter { get { return itsFilter; } }
    }
}