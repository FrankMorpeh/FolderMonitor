namespace FolderMonitor.Models.DirectoryTrackerModel
{
    public class DirectoryTrackerModel : IDirectoryTrackerModel
    {
        private int itsIndexInFileWatcher;        
        private string itsFolderPath;
        private string itsFilter;

        public DirectoryTrackerModel() 
        {
            itsIndexInFileWatcher = -1;
            itsFolderPath = string.Empty; 
            itsFilter = string.Empty;
        }
        public DirectoryTrackerModel(string folderName, string filter) 
        {
            itsIndexInFileWatcher = -1;
            itsFolderPath = folderName;
            itsFilter = filter;
        }
        
        public int IndexInFileWatcher { set { itsIndexInFileWatcher = value; } }
        public string FolderPath { get { return itsFolderPath; } set { itsFolderPath = value; } }
        public string Filter { get { return itsFilter; } set { itsFilter = value; } }
    }
}