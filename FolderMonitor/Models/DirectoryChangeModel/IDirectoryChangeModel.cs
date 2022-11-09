namespace FolderMonitor.Models.DirectoryChangeModel
{
    public interface IDirectoryChangeModel
    {
        DirectoryChangeType ChangeType { get; set; }
        string ChangeName { get; set; }
        string ChangeTime { get; set; }
    }
}