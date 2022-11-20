﻿using FolderMonitor.Pages;

namespace FolderMonitor.Handlers.MainMenu
{
    public class MainMenuPageHandler
    {
        private MainMenuPage itsMainMenuPage;
        private TrackerDataHandler itsTrackerDataHandler;
        private FilterDataHandler itsFilterDataHandler;
        private DirectoryChangeDataHandler itsDirectoryChangeDataHandler;
        private UIHandler itsUIHandler;

        public MainMenuPageHandler() 
        { 
            itsMainMenuPage = null; 
            itsTrackerDataHandler = null; 
            itsFilterDataHandler = null;
            itsDirectoryChangeDataHandler = null;
            itsUIHandler = null; 
        }
        public MainMenuPageHandler(MainMenuPage mainMenuPage) 
        {
            itsMainMenuPage = mainMenuPage;
            itsUIHandler = new UIHandler(itsMainMenuPage);
            itsTrackerDataHandler = new TrackerDataHandler(itsMainMenuPage, itsUIHandler);
            itsFilterDataHandler = new FilterDataHandler(itsMainMenuPage);
            itsDirectoryChangeDataHandler = new DirectoryChangeDataHandler(itsMainMenuPage);
        }


        // Data handling of trackers
        public void AddOrUpdateTracker()
        {
            itsTrackerDataHandler.AddOrUpdateTracker();
        }
        public void DeleteTracker()
        {
            itsTrackerDataHandler.DeleteTracker();
        }
        public void EditTracker()
        {
            itsTrackerDataHandler.EditTracker();
        }
        public void ClearTrackers()
        {
            itsTrackerDataHandler.ClearTrackers();
        }


        // Filters
        public void ChooseFolderForTracker()
        {
            itsFilterDataHandler.ChooseFolderForTracker();
        }
        public void AddFilterForTracker()
        {
            itsFilterDataHandler.AddFilterForTracker();
        }


        // Directory changes
        public void DeleteDirectoryChange()
        {
            itsDirectoryChangeDataHandler.DeleteDirectoryChange();
        }
        public void ClearDirectoryChanges()
        {
            itsDirectoryChangeDataHandler.ClearDirectoryChanges();
        }


        // UI
        public void CloseStackPanelWarning()
        {
            itsUIHandler.CloseStackPanelWarning();
        }
    }
}