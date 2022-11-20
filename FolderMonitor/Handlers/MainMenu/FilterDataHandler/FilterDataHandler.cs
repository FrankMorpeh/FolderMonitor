using FolderMonitor.Pages;

namespace FolderMonitor.Handlers.MainMenu
{
    public class FilterDataHandler
    {
        private MainMenuPage itsMainMenuPage;

        public FilterDataHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }

        public void AddFilterForTracker()
        {
            itsMainMenuPage.itsFilterController.AddFilter();
        }
    }
}
