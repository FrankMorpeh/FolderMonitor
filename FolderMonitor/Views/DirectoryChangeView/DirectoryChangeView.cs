using FolderMonitor.Controllers.DirectoryChangeController;
using System.Windows.Controls;

namespace FolderMonitor.Views.DirectoryChangeView
{
    public class DirectoryChangeView : IDirectoryChangeView
    {
        private ListView itsChangesListView;
        private DirectoryChangeController itsDirectoryChangeController;
        public ListView ChangesListView { set { itsChangesListView = value; } }
        public IDirectoryChangeController ChangeController { set { itsDirectoryChangeController = (DirectoryChangeController)value; } }


        public DirectoryChangeView(DirectoryChangeController directoryChangeController = null) 
        {
            itsChangesListView = null;
            itsDirectoryChangeController = directoryChangeController; 
        }


        public void ShowChanges()
        {
            itsChangesListView.ItemsSource = itsDirectoryChangeController.Changes;
            itsChangesListView.Items.Refresh();
        }
        public void RemoveChange(int index)
        {
            itsDirectoryChangeController.RemoveChange(index);
            ShowChanges();
        }
        public void ClearChanges()
        {
            itsDirectoryChangeController.ClearChanges();
            ShowChanges();
        }
    }
}