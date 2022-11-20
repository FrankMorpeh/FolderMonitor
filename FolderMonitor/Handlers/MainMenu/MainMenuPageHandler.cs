using FolderMonitor.Pages;

namespace FolderMonitor.Handlers.MainMenu
{
    public class MainMenuPageHandler
    {
        private MainMenuPage itsMainMenuPage;
        private TrackerDataHandler itsTrackerDataHandler;
        private FilterDataHandler itsFilterDataHandler;
        private UIHandler itsUIHandler;

        public MainMenuPageHandler() { itsMainMenuPage = null; itsTrackerDataHandler = null; itsFilterDataHandler = null; itsUIHandler = null; }
        public MainMenuPageHandler(MainMenuPage mainMenuPage) 
        {
            itsMainMenuPage = mainMenuPage;
            itsUIHandler = new UIHandler(itsMainMenuPage);
            itsTrackerDataHandler = new TrackerDataHandler(itsMainMenuPage, itsUIHandler);
            itsFilterDataHandler = new FilterDataHandler(itsMainMenuPage);
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


        // Filters
        public void ChooseFolderForTracker()
        {
            itsFilterDataHandler.ChooseFolderForTracker();
        }
        public void AddFilterForTracker()
        {
            itsFilterDataHandler.AddFilterForTracker();
        }


        // UI
        public void CloseStackPanelWarning()
        {
            itsUIHandler.CloseStackPanelWarning();
        }
    }
}