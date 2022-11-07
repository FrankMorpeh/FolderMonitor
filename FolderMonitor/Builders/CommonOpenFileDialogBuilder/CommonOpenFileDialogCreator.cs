using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public static class CommonOpenFileDialogCreator
    {
        public static CommonOpenFileDialog CreateCommonOpenFileDialog(CommonOpenFileDialogBuilder openFileDialogBuilder)
        {
            openFileDialogBuilder.CreateOpenFileDialog();
            openFileDialogBuilder.SetTitle();
            openFileDialogBuilder.SetFilter();
            return openFileDialogBuilder.BuildCommonOpenFileDialog();
        }
    }
}