namespace FolderMonitor.Models.DirectoryTrackerModel
{
    public interface IDirectoryTrackerModel
    {
        string FolderPath { get; }
        string Filter { get; }
    }
}
