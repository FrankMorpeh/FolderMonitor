namespace FolderMonitor.Models.DirectoryChangeModel
{
    public class DirectoryChangeModel : IDirectoryChangeModel
    {
        private readonly string itsChangeName;
        private readonly DirectoryChangeType itsChangeType;
        private readonly string itsChangeTime;

        public DirectoryChangeModel() { itsChangeName = string.Empty; itsChangeType = DirectoryChangeType.None; itsChangeTime = string.Empty; }
        public DirectoryChangeModel(string changeName, DirectoryChangeType changeType, string changeTime)
        {
            itsChangeName = changeName;
            itsChangeType = changeType;
            itsChangeTime = changeTime;
        }

        public string ChangeName { get { return itsChangeName; } }
        public DirectoryChangeType ChangeType { get { return itsChangeType; } }
        public string ChangeTime { get { return itsChangeTime; } }
    }
}