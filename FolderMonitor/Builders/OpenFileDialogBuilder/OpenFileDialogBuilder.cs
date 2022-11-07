using Microsoft.Win32;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public abstract class OpenFileDialogBuilder
    {
        protected OpenFileDialog itsOpenFileDialog;

        public OpenFileDialogBuilder() { itsOpenFileDialog = null; }

        public void CreateOpenFileDialog()
        {
            itsOpenFileDialog = new OpenFileDialog();
        }
        public abstract void SetTitle();
        public abstract void SetFilter();
        public OpenFileDialog BuildOpenFileDialog()
        {
            return itsOpenFileDialog;
        }
    }
}