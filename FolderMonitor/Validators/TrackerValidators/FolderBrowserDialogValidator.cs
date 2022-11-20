using FolderMonitor.Warnings;
using System.Windows.Forms;

namespace FolderMonitor.Validators.TrackerValidators
{
    public static class FolderBrowserDialogValidator
    {
        public static IWarning CheckChosenFolderTextBlock(FolderBrowserDialog folderBrowserDialog)
        {
            if (folderBrowserDialog.SelectedPath == string.Empty)
                return new IncorrectFilePath();
            else
                return new None();
        }
    }
}