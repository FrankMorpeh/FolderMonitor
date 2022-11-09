namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public class TrackerCommonFolderBrowserDialogBuilder : FolderBrowserDialogBuilder
    {
        public override void SetTitle()
        {
            itsFolderBrowserDialog.Description = "Folder";
        }
        public override void SetDescriptionForTitle()
        {
            itsFolderBrowserDialog.UseDescriptionForTitle = false;
        }
    }
}