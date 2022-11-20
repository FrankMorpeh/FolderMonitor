using FolderMonitor.Handlers.MainMenu.TemplateMethod;
using FolderMonitor.Pages;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu
{
    public class TrackerDataHandler
    {
        private MainMenuPage itsMainMenuPage;
        private AddOrUpdateTrackerTemplateMethod itsAddOrUpdateTrackerTemplateMethod;

        public AddOrUpdateTrackerTemplateMethod AddOrUpdateTrackerTemplateMethod
        {
            set
            {
                itsAddOrUpdateTrackerTemplateMethod = value;
                itsAddOrUpdateTrackerTemplateMethod.MainMenuPage = itsMainMenuPage;
            }
        }

        public TrackerDataHandler(MainMenuPage mainMenuPage)
        {
            itsMainMenuPage = mainMenuPage;
        }

        public void AddOrUpdateTracker()
        {
            itsAddOrUpdateTrackerTemplateMethod.AddOrUpdate();
            AddOrUpdateTrackerTemplateMethod = new AddTrackerTemplateMethod();
            itsMainMenuPage.itsMainMenuPageHandler.ShowAddTrackerTemplate();
        }
        public void DeleteTracker()
        {
            int selectedIndex = itsMainMenuPage.trackedDirectoriesListView.SelectedIndex;
            if (selectedIndex != -1)
                itsMainMenuPage.itsContent.itsDirectoryTrackerView.RemoveTracker(selectedIndex);
            else
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, new TrackerIsNotChosen());
        }
        public void EditTracker()
        {
            itsMainMenuPage.itsSelectedTrackerModelIndex = itsMainMenuPage.trackedDirectoriesListView.SelectedIndex;
            if (itsMainMenuPage.itsSelectedTrackerModelIndex != -1)
            {
                itsMainMenuPage.itsFilterController.AddFilter();

                itsMainMenuPage.itsContent.itsDirectoryTrackerView.ShowChosenTrackerOnEditPanel(itsMainMenuPage.itsSelectedTrackerModelIndex
                    , ref itsMainMenuPage.itsChosenFolder, itsMainMenuPage.itsFilterController.GetFilterTextBoxByIndex(0));

                itsMainMenuPage.itsMainMenuPageHandler.ShowUpdateTrackerTemplate();
                AddOrUpdateTrackerTemplateMethod = new UpdateTrackerTemplateMethod();
            }
            else
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, new TrackerIsNotChosen());
        }
    }
}
