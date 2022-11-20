namespace FolderMonitor.Handlers.MainMenu.TemplateMethod
{
    public class AddTrackerTemplateMethod : AddOrUpdateTrackerTemplateMethod
    {
        protected override bool AddOrUpdateTracker()
        {
            return itsMainMenuPage.itsContent.itsDirectoryTrackerView.AddTracker(itsMainMenuPage.itsChosenFolder, itsFilters);
        }
    }
}