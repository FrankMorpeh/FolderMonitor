namespace FolderMonitor.Views.DirectoryChangeView
{
    public interface IDirectoryChangeView
    {
        void ShowChanges();
        void RemoveChange(int index);
        void ClearChanges();
    }
}