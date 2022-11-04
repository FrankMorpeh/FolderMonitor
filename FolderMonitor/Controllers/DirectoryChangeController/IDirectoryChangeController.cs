using FolderMonitor.Models.DirectoryChangeModel;

namespace FolderMonitor.Controllers.DirectoryChangeController
{
    public interface IDirectoryChangeController
    {
        void AddChange(IDirectoryChangeModel directoryChangeModel);
        void RemoveChange(int id);
    }
}