using Microsoft.Win32;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public static class OpenFileDialogCreator
    {
        public static OpenFileDialog CreateOpenFileDialog(OpenFileDialogBuilder openFileDialogBuilder)
        {
            openFileDialogBuilder.CreateOpenFileDialog();
            openFileDialogBuilder.SetTitle();
            openFileDialogBuilder.SetFilter();
            return openFileDialogBuilder.BuildOpenFileDialog();
        }
    }
}