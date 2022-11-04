using FolderMonitor.Models.DirectoryChangeModel;
using System.Collections.Generic;

namespace FolderMonitor.Controllers.DirectoryChangeController
{
    public interface IDirectoryChangeController
    {
        List<IDirectoryChangeModel> Changes { get; }
        void AddChange(IDirectoryChangeModel directoryChangeModel);
        void RemoveChange(int index);
        void ClearChanges();
    }
}