using FolderMonitor.Pages;
using FolderMonitor.Strings;
using System.Windows.Forms;

namespace FolderMonitor.Handlers.MainMenu
{
    public class FolderDataHandler
    {
        private MainMenuPage itsMainMenuPage;

        public FolderDataHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }

        public void ChooseFolderForTracker()
        {
            if (itsMainMenuPage.itsTrackedDirectoryDialog.ShowDialog() == DialogResult.OK)
                itsMainMenuPage.chosenFolderTextBlock.Text = StringFormatter.GetShortPathToFile(itsMainMenuPage.itsTrackedDirectoryDialog.SelectedPath);
        }
    }
}