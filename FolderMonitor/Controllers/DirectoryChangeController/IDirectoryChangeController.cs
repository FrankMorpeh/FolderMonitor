using FolderMonitor.Memento.DirectoryChanges;
using FolderMonitor.Models.DirectoryChangeModel;
using FolderMonitor.Views.DirectoryChangeView;
using System.Collections.Generic;

namespace FolderMonitor.Controllers.DirectoryChangeController
{
    public interface IDirectoryChangeController
    {
        IDirectoryChangeView ChangeView { set; }
        List<IDirectoryChangeModel> Changes { get; }
        void AddChange(IDirectoryChangeModel directoryChangeModel);
        void RemoveChange(int index);
        void ClearChanges();
        void LoadState(DirectoryChangeMemento directoryChangeMemento);
        DirectoryChangeMemento SaveState();
    }
}