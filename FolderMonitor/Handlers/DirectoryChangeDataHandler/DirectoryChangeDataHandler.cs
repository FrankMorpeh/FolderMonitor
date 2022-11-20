using FolderMonitor.Pages;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu
{
    public class DirectoryChangeDataHandler
    {
        private MainMenuPage itsMainMenuPage;

        public DirectoryChangeDataHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }

        public void DeleteDirectoryChange()
        {
            int selectedIndex = itsMainMenuPage.directoryChangesListView.SelectedIndex;
            if (selectedIndex != -1)
                itsMainMenuPage.itsContent.itsDirectoryChangeView.RemoveChangeAt(selectedIndex);
            else
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock
                    , new DirectoryChangeIsNotChosen());
        }
        public void ClearDirectoryChanges()
        {
            itsMainMenuPage.itsContent.itsDirectoryChangeView.ClearChanges();
        }
    }
}