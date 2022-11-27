using FolderMonitor.Pages;
using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterDeleteButtonBuilder
{
    public static class FilterDeleteButtonCreator
    {
        public static Button CreateFilterDeleteButton(FilterDeleteButtonBuilder filterDeleteButtonBuilder, RoutedEventHandler buttonClickHandler
            , MainMenuPage mainMenuPage)
        {
            filterDeleteButtonBuilder.CreateFilterDeleteButton();
            filterDeleteButtonBuilder.SetContent();
            filterDeleteButtonBuilder.SetMaxWidth();
            filterDeleteButtonBuilder.SetMaxHeight();
            filterDeleteButtonBuilder.SetClickHandler(buttonClickHandler);
            filterDeleteButtonBuilder.SetStyle(mainMenuPage);
            return filterDeleteButtonBuilder.BuildFilterDeleteButton();
        }
    }
}