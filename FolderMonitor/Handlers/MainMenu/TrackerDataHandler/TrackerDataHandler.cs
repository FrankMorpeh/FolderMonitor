using FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod;
using FolderMonitor.Pages;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu
{
    public class TrackerDataHandler
    {
        private MainMenuPage itsMainMenuPage;
        private AddOrUpdateTrackerTemplateMethod itsAddOrUpdateTrackerTemplateMethod;
        private UIHandler itsUIHandler;

        public AddOrUpdateTrackerTemplateMethod AddOrUpdateTrackerTemplateMethod
        {
            set
            {
                itsAddOrUpdateTrackerTemplateMethod = value;
                itsAddOrUpdateTrackerTemplateMethod.MainMenuPage = itsMainMenuPage;
            }
        }

        public TrackerDataHandler(MainMenuPage mainMenuPage, UIHandler uIHandler)
        {
            itsMainMenuPage = mainMenuPage;
            AddOrUpdateTrackerTemplateMethod = new AddTrackerTemplateMethod();
            itsUIHandler = uIHandler;
        }

        public void AddOrUpdateTracker()
        {
            itsAddOrUpdateTrackerTemplateMethod.AddOrUpdate();
            AddOrUpdateTrackerTemplateMethod = new AddTrackerTemplateMethod();
            itsUIHandler.ShowAddTrackerTemplate();
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
                itsMainMenuPage.itsFilterController.AddFilter(itsMainMenuPage);

                itsMainMenuPage.itsContent.itsDirectoryTrackerView.ShowChosenTrackerOnEditPanel(itsMainMenuPage.itsSelectedTrackerModelIndex
                    , itsMainMenuPage.itsTrackedDirectoryDialog, itsMainMenuPage.itsFilterController.GetFilterTextBoxByIndex(0));

                itsUIHandler.ShowUpdateTrackerTemplate();
                AddOrUpdateTrackerTemplateMethod = new UpdateTrackerTemplateMethod();
            }
            else
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, new TrackerIsNotChosen());
        }
        public void ClearTrackers()
        {
            itsMainMenuPage.itsContent.itsDirectoryTrackerView.ClearTrackers();
        }
    }
}