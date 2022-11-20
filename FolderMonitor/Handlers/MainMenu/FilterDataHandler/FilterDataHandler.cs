using FolderMonitor.Pages;
using System.Windows.Forms;

namespace FolderMonitor.Handlers.MainMenu
{
    public class FilterDataHandler
    {
        private MainMenuPage itsMainMenuPage;

        public FilterDataHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }

        public void ChooseFolderForTracker()
        {
            if (itsMainMenuPage.itsTrackedDirectoryDialog.ShowDialog() == DialogResult.OK)
                itsMainMenuPage.itsChosenFolder = itsMainMenuPage.itsTrackedDirectoryDialog.SelectedPath;
        }
        public void AddFilterForTracker()
        {
            itsMainMenuPage.itsFilterController.AddFilter();
        }
    }
}
