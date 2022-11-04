using FolderMonitor.Memento.DirectoryChanges;
using System;
using System.IO;
using System.Text.Json;

namespace FolderMonitor.Memento.DirectoryChanges
{
    public static class DirectoryChangeFileSaver
    {
        public static void SaveDirectoryChangesToFile(DirectoryChangeMemento directoryChangeMemento)
        {
            try
            {
                string serializedDirectoryChangeMemento = JsonSerializer.Serialize(directoryChangeMemento);
                File.WriteAllText(MainWindow.itsInitialLocation + "\\SaveFiles\\DirectoryChanges\\DirectoryChanges.json", serializedDirectoryChangeMemento);
            }
            catch (Exception) {}
        }
        public static DirectoryChangeMemento LoadDirectoryChangesFromFile()
        {
            DirectoryChangeMemento directoryChangesMemento = null;

            try
            {
                FileStream fileStream = new FileStream(MainWindow.itsInitialLocation + "\\SaveFiles\\DirectoryChanges\\DirectoryChanges.json", FileMode.Open);
                directoryChangesMemento = JsonSerializer.Deserialize<DirectoryChangeMemento>(fileStream);
            }
            catch (Exception) {}

            return directoryChangesMemento;
        }
    }
}