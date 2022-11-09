using FolderMonitor.Controllers.DirectoryTrackerController;
using FolderMonitor.FileReaders.JsonReader;

namespace FolderMonitor.Memento.TrackersMemento
{
    public static class DirectoryTrackerSaver
    {
        public static void SaveDirectoryTrackers(DirectoryTrackerController directoryTrackerController)
        {
            DirectoryTrackerFileSaver.SaveDirectoryTrackersToFile(directoryTrackerController.SaveState());
        }
        public static void LoadDirectoryTrackers(DirectoryTrackerController directoryTrackerController)
        {
            DirectoryTrackerMemento directoryTrackerMemento = DirectoryTrackerFileSaver.LoadDirectoryTrackerMemento();
            if (directoryTrackerMemento != null)
                directoryTrackerController.LoadState(directoryTrackerMemento);
        }
    }
}