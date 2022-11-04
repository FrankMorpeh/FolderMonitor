using FolderMonitor.Controllers.DirectoryChangeController;
using FolderMonitor.FileReaders.JsonReader;

namespace FolderMonitor.Memento.DirectoryChanges
{
    public static class DirectoryChangeSaver
    {
        public static void SaveDirectoryChanges(IDirectoryChangeController directoryChangeController)
        {
            DirectoryChangeFileSaver.SaveDirectoryChangesToFile(directoryChangeController.SaveState());
        }
        public static void LoadDirectoryChanges(IDirectoryChangeController directoryChangeController)
        {
            DirectoryChangeMemento directoryChangeMemento = DirectoryChangeFileSaver.LoadDirectoryChangesFromFile();
            if (directoryChangeMemento != null)
                directoryChangeController.LoadState(directoryChangeMemento);
        }
    }
}