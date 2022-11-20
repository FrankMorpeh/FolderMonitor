using FolderMonitor.Controllers.DirectoryChangeController;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryChangeView
{
    public interface IDirectoryChangeView
    {
        ListView ChangesListView { set; }
        IDirectoryChangeController ChangeController { set; }
        void ShowChanges();
        void RemoveChangeAt(int index);
        void ClearChanges();
    }
}