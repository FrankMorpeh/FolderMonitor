using FolderMonitor.Pages;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu
{
    public class UIHandler
    {
        private MainMenuPage itsMainMenuPage;

        public UIHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }


        // Data handling view template
        public void ShowAddTrackerTemplate()
        {
            ShowAddSignOnButton();
            UnblockFilterAddingButton();
        }
        public void ShowUpdateTrackerTemplate()
        {
            ShowUpdateSignOnButton();
            BlockFilterAddingButton();
        }
        private void ShowUpdateSignOnButton()
        {
            itsMainMenuPage.addOrUpdateTrackerButton.Content = "Update tracker";
        }
        private void ShowAddSignOnButton()
        {
            itsMainMenuPage.addOrUpdateTrackerButton.Content = "Add tracker";
        }
        private void BlockFilterAddingButton()
        {
            itsMainMenuPage.addFilterButton.IsEnabled = false;
        }
        private void UnblockFilterAddingButton()
        {
            itsMainMenuPage.addFilterButton.IsEnabled = true;
        }


        // Warnings
        public void CloseStackPanelWarning()
        {
            WarningView.CloseStackPanelWarning(itsMainMenuPage.warningStackPanel);
        }
    }
}
