using FolderMonitor.Warnings;

namespace FolderMonitor.Validators.TrackerValidators
{
    public static class FolderBrowserDialogValidator
    {
        public static IWarning CheckFolderBrowserDialog(string filePath)
        {
            if (filePath == string.Empty)
                return new IncorrectFilePath();
            else
                return new None();
        }
    }
}