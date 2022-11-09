namespace FolderMonitor.Models.DirectoryChangeModel
{
    public class DirectoryChangeModel : IDirectoryChangeModel
    {
        private DirectoryChangeType itsChangeType;
        private string itsChangeName;
        private string itsChangeTime;

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

        public DirectoryChangeType ChangeType { get { return itsChangeType; } set { itsChangeType = value; } }
        public string ChangeName { get { return itsChangeName; } set { itsChangeName = value; } }
        public string ChangeTime { get { return itsChangeTime; } set { itsChangeTime = value; } }
    }
}