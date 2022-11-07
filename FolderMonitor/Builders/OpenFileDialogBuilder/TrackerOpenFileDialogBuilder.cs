namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public class TrackerOpenFileDialogBuilder : OpenFileDialogBuilder
    {
        public override void SetTitle()
        {
            itsOpenFileDialog.Title = "Folder";
        }
        public override void SetFilter()
        {
            itsOpenFileDialog.Filter = "Folder |*.";
        }
    }
}