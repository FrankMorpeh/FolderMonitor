using FolderMonitor.Models.DirectoryTrackerModel;
using FolderMonitor.Warnings;

namespace FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod
{
    public class UpdateTrackerTemplateMethod : AddOrUpdateTrackerTemplateMethod
    {
        protected override IWarning AddOrUpdateTracker()
        {
            return itsMainMenuPage.itsContent.itsDirectoryTrackerView.UpdateTrackerAt(new DirectoryTrackerModel(
                itsMainMenuPage.itsTrackedDirectoryDialog.SelectedPath, itsFilters[0]), itsMainMenuPage.itsSelectedTrackerModelIndex);
        }
    }
}
