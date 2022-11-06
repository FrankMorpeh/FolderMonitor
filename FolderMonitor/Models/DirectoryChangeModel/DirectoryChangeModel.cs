namespace FolderMonitor.Models.DirectoryChangeModel
{
    public class DirectoryChangeModel : IDirectoryChangeModel
    {
        private readonly DirectoryChangeType itsChangeType;
        private readonly string itsChangeName;
        private readonly string itsChangeTime;

        public DirectoryChangeModel() 
        { 
            itsChangeType = DirectoryChangeType.None; 
            itsChangeName = string.Empty; 
            itsChangeTime = string.Empty; 
        }
        public DirectoryChangeModel(DirectoryChangeType changeType, string changeName, string changeTime)
        {
            itsChangeType = changeType;
            itsChangeName = changeName;
            itsChangeTime = changeTime;
        }

        public DirectoryChangeType ChangeType { get { return itsChangeType; } }
        public string ChangeName { get { return itsChangeName; } }
        public string ChangeTime { get { return itsChangeTime; } }
    }
}