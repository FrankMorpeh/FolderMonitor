using System.Windows.Forms;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public static class FolderBrowserDialogCreator
    {
        public static FolderBrowserDialog CreateFolderBrowserDialog(FolderBrowserDialogBuilder folderBrowserDialogBuilder)
        {
            folderBrowserDialogBuilder.CreateOpenFileDialog();
            folderBrowserDialogBuilder.SetTitle();
            folderBrowserDialogBuilder.SetDescriptionForTitle();
            return folderBrowserDialogBuilder.BuildCommonOpenFileDialog();
        }
    }
}