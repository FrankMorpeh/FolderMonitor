namespace FolderMonitor.Models.DirectoryChangeModel
{
    public interface IDirectoryChangeModel
    {
        string ChangeName { get; }
        DirectoryChangeType ChangeType { get; }
        string ChangeTime { get; }
    }
}