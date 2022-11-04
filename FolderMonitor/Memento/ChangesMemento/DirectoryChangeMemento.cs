using FolderMonitor.Models.DirectoryChangeModel;
using System.Collections.Generic;

namespace FolderMonitor.Memento.DirectoryChanges
{
    public class DirectoryChangeMemento
    {
        public DirectoryChangeMemento(List<IDirectoryChangeModel> changes) { Changes = changes; }

        public List<IDirectoryChangeModel> Changes { get; set; }
    }
}