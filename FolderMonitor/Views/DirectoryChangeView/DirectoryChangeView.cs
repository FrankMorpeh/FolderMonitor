using FolderMonitor.Controllers.DirectoryChangeController;
using System;
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
        public void ShowChangesWithDispatcher()
        {
            itsChangesListView.Dispatcher.BeginInvoke
                (
                    new Action
                    (
                        () =>
                        {
                            ShowChanges();
                        }
                    )
                );
        }
        public void RemoveChangeAt(int index)
        {
            itsDirectoryChangeController.RemoveChangeAt(index);
            ShowChanges();
        }
        public void ClearChanges()
        {
            itsDirectoryChangeController.ClearChanges();
            ShowChanges();
        }
    }
}