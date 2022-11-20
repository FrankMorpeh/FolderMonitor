namespace FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod
{
    public class AddTrackerTemplateMethod : AddOrUpdateTrackerTemplateMethod
    {
        protected override bool AddOrUpdateTracker()
        {
            return itsMainMenuPage.itsContent.itsDirectoryTrackerView.AddTracker(itsMainMenuPage.itsChosenFolder, itsFilters);
        }
    }
}