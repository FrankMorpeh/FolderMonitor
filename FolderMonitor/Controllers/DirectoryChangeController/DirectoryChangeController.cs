using FolderMonitor.Memento.DirectoryChanges;
using FolderMonitor.Models.DirectoryChangeModel;
using FolderMonitor.Views.DirectoryChangeView;
using System.Collections.Generic;
using System.Linq;

namespace FolderMonitor.Controllers.DirectoryChangeController
{
    public class DirectoryChangeController : IDirectoryChangeController
    {
        private List<DirectoryChangeModel> itsChanges;
        private DirectoryChangeView itsDirectoryChangeView;
        public IDirectoryChangeView ChangeView { set { itsDirectoryChangeView = (DirectoryChangeView)value; } }

        public DirectoryChangeController() { itsChanges = new List<DirectoryChangeModel>(); itsDirectoryChangeView = null; }
        public DirectoryChangeController(List<IDirectoryChangeModel> changes, IDirectoryChangeView directoryChangeView = null) 
        { 
            itsChanges = changes.Cast<DirectoryChangeModel>().ToList(); 
            itsDirectoryChangeView = (DirectoryChangeView)directoryChangeView;
        }

        public List<IDirectoryChangeModel> Changes { get { return itsChanges.Cast<IDirectoryChangeModel>().ToList(); } }
        public void AddChange(IDirectoryChangeModel change) 
        { 
            itsChanges.Add((DirectoryChangeModel)change);
            itsDirectoryChangeView.ShowChanges();
        }
        public void RemoveChange(int index) { itsChanges.RemoveAt(index); }
        public void ClearChanges() { itsChanges.Clear(); }


        // Memento
        public DirectoryChangeMemento SaveState()
        {
            return new DirectoryChangeMemento(Changes);
        }
        public void LoadState(DirectoryChangeMemento directoryChangesMemento)
        {
            itsChanges = directoryChangesMemento.Changes.Cast<DirectoryChangeModel>().ToList();
        }
    }
}