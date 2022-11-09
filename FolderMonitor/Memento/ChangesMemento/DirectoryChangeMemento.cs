using FolderMonitor.Models.DirectoryChangeModel;
using System.Collections.Generic;

namespace FolderMonitor.Memento.DirectoryChanges
{
    public class DirectoryChangeMemento
    {
        public DirectoryChangeMemento(List<DirectoryChangeModel> changes) { Changes = changes; }

        public List<DirectoryChangeModel> Changes { get; set; }
    }
}