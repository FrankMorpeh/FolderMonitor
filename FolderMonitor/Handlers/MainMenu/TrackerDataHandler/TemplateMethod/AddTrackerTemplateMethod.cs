using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod
{
    public class AddTrackerTemplateMethod : AddOrUpdateTrackerTemplateMethod
    {
        protected override IWarning AddOrUpdateTracker()
        {
            return itsMainMenuPage.itsContent.itsDirectoryTrackerView.AddTracker(itsMainMenuPage.itsTrackedDirectoryDialog.SelectedPath, itsFilters);
        }
    }
}