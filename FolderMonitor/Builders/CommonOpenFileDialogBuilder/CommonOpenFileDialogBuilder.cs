using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public abstract class CommonOpenFileDialogBuilder
    {
        protected CommonOpenFileDialog itsCommonOpenFileDialog;

        public CommonOpenFileDialogBuilder() { itsCommonOpenFileDialog = null; }

        public void CreateOpenFileDialog()
        {
            itsCommonOpenFileDialog = new CommonOpenFileDialog();
        }
        public abstract void SetTitle();
        public abstract void SetFilter();
        public CommonOpenFileDialog BuildCommonOpenFileDialog()
        {
            return itsCommonOpenFileDialog;
        }
    }
}