using System.Windows.Forms;

namespace FolderMonitor.Builders.OpenFileDialogBuilder
{
    public abstract class FolderBrowserDialogBuilder
    {
        protected FolderBrowserDialog itsFolderBrowserDialog;

        public FolderBrowserDialogBuilder() { itsFolderBrowserDialog = null; }

        public void CreateOpenFileDialog()
        {
            itsFolderBrowserDialog = new FolderBrowserDialog();
        }
        public abstract void SetTitle();
        public abstract void SetDescriptionForTitle();
        public FolderBrowserDialog BuildCommonOpenFileDialog()
        {
            return itsFolderBrowserDialog;
        }
    }
}