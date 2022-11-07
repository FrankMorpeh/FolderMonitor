using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterDeleteButtonBuilder
{
    public static class FilterDeleteButtonCreator
    {
        public static Button CreateFilterDeleteButton(FilterDeleteButtonBuilder filterDeleteButtonBuilder, RoutedEventHandler buttonClickHandler)
        {
            filterDeleteButtonBuilder.CreateFilterDeleteButton();
            filterDeleteButtonBuilder.SetContent();
            filterDeleteButtonBuilder.SetMaxWidth();
            filterDeleteButtonBuilder.SetMaxHeight();
            filterDeleteButtonBuilder.SetClickHandler(buttonClickHandler);
            return filterDeleteButtonBuilder.BuildFilterDeleteButton();
        }
    }
}