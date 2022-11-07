using System.Windows;

namespace FolderMonitor.Builders.FilterDeleteButtonBuilder
{
    public class TrackerFilterDeleteButtonBuilder : FilterDeleteButtonBuilder
    {
        public override void SetContent()
        {
            itsFilterDeleteButton.Content = "Delete";
        }
        public override void SetMaxWidth()
        {
            itsFilterDeleteButton.MaxWidth = 80;
        }
        public override void SetMaxHeight()
        {
            itsFilterDeleteButton.MaxHeight = 40;
        }
        public override void SetClickHandler(RoutedEventHandler routedEventHandler)
        {
            itsFilterDeleteButton.Click += routedEventHandler;
        }
    }
}