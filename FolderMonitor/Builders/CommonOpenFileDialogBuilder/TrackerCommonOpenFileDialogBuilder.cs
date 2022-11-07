namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public class TrackerCommonOpenFileDialogBuilder : CommonOpenFileDialogBuilder
    {
        public override void SetTitle()
        {
            itsCommonOpenFileDialog.Title = "Folder";
        }
        public override void SetFilter()
        {
            //itsCommonOpenFileDialog.Filter = "Folder |*.";
        }
    }
}