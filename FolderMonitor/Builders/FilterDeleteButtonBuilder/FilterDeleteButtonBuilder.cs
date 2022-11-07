using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterDeleteButtonBuilder
{
    public abstract class FilterDeleteButtonBuilder
    {
        protected Button itsFilterDeleteButton;

        public FilterDeleteButtonBuilder() { itsFilterDeleteButton = null; }
        public void CreateFilterDeleteButton()
        {
            itsFilterDeleteButton = new Button();
        }
        public abstract void SetContent();
        public abstract void SetMaxWidth();
        public abstract void SetMaxHeight();
        public abstract void SetClickHandler(RoutedEventHandler routedEventHandler);
        public Button BuildFilterDeleteButton()
        {
            return itsFilterDeleteButton;
        }
    }
}