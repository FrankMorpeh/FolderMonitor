namespace FolderMonitor.Models.DirectoryChangeModel
{
    public interface IDirectoryChangeModel
    {
        DirectoryChangeType ChangeType { get; }
        string ChangeName { get; }
        string ChangeTime { get; }
    }
}