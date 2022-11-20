using FolderMonitor.Models.DirectoryTrackerModel;

namespace FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod
{
    public class UpdateTrackerTemplateMethod : AddOrUpdateTrackerTemplateMethod
    {
        protected override bool AddOrUpdateTracker()
        {
            return itsMainMenuPage.itsContent.itsDirectoryTrackerView.UpdateTrackerAt(new DirectoryTrackerModel(itsMainMenuPage.itsChosenFolder
                , itsFilters[0]), itsMainMenuPage.itsSelectedTrackerModelIndex);
        }
    }
}
