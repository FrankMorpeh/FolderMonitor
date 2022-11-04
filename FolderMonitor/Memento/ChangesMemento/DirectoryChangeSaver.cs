using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.Memento.DirectoryChanges;

namespace FolderMonitor.Memento.DirectoryChanges
{
    public static class DirectoryChangeSaver
    {
        public static void SaveDirectoryChanges(DirectoryChangeController directoryChangeController)
        {
            DirectoryChangeFileSaver.SaveDirectoryChangesToFile(directoryChangeController.SaveState());
        }
        public static void LoadDirectoryChanges(DirectoryChangeController directoryChangeController)
        {
            DirectoryChangeMemento directoryChangeMemento = DirectoryChangeFileSaver.LoadDirectoryChangesFromFile();
            if (directoryChangeMemento != null)
                directoryChangeController.LoadState(directoryChangeMemento);
        }
    }
}