using FolderMonitor.Memento.TrackersMemento;
using System.IO;
using System.Text.Json;
using System;

namespace FolderMonitor.FileReaders.JsonReader
{
    public static class DirectoryTrackerFileSaver
    {
        public static void SaveDirectoryTrackersToFile(DirectoryTrackerMemento directoryTrackerMemento)
        {
            try
            {
                string serializedDirectoryTrackerMemento = JsonSerializer.Serialize(directoryTrackerMemento);
                File.WriteAllText(MainWindow.itsInitialLocation + "\\SaveFiles\\DirectoryTrackers\\DirectoryTrackers.json", serializedDirectoryTrackerMemento);
            }
            catch (Exception) {}
        }
        public static DirectoryTrackerMemento LoadDirectoryTrackerMemento()
        {
            DirectoryTrackerMemento directoryTrackerMemento = null;

            try
            {
                FileStream fileStream = new FileStream(MainWindow.itsInitialLocation + "\\SaveFiles\\DirectoryTrackers\\DirectoryTrackers.json"
                    , FileMode.Open);
                directoryTrackerMemento = JsonSerializer.Deserialize<DirectoryTrackerMemento>(fileStream);
            }
            catch (Exception) {}

            return directoryTrackerMemento;
        }
    }
}
