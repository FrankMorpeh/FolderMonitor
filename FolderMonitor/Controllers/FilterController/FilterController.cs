using FolderMonitor.Builders.FilterBuilder;
using FolderMonitor.Builders.FilterDeleteButtonBuilder;
using System.Windows;
using System.Windows.Controls;

namespace FolderMonitor.Controllers.FilterController
{
    public class FilterController // doesn't have View, as it already controls the displayed data
    {
        private StackPanel itsFiltersStackPanel;
        private StackPanel itsFilterDeleteButtonsStackPanel;

        public StackPanel FiltersStackPanel { get { return itsFiltersStackPanel; } }
        public StackPanel FilterDeleteButtonsStackPanel { get { return itsFilterDeleteButtonsStackPanel; } }

        public FilterController(StackPanel filtersStackPanel, StackPanel filterDeleteButtonsStackPanel) 
        {
            itsFiltersStackPanel = filtersStackPanel;
            itsFilterDeleteButtonsStackPanel = filterDeleteButtonsStackPanel;
        }

        public void AddFilter()
        {
            itsFiltersStackPanel.Children.Add(FilterCreator.CreateFilter(new TrackerFilterBuilder()));
            itsFilterDeleteButtonsStackPanel.Children.Add(FilterDeleteButtonCreator.CreateFilterDeleteButton(new TrackerFilterDeleteButtonBuilder()
                , RemoveFilter_Click));
        }
        public void ClearFilters()
        {
            itsFiltersStackPanel.Children.Clear();
            itsFilterDeleteButtonsStackPanel.Children.Clear();
        }
        public TextBox GetFilterTextBoxByIndex(int index)
        {
            return (TextBox)itsFiltersStackPanel.Children[index];
        }
        public Button GetFilterDeleteButtonByIndex(int index)
        {
            return (Button)itsFilterDeleteButtonsStackPanel.Children[index];
        }

        private void RemoveFilter_Click(object sender, RoutedEventArgs e)
        // removes the text filter (TextBox) according to the position of the delete button that fired the event; also removes the delete button
        {
            itsFiltersStackPanel.Children.RemoveAt(itsFilterDeleteButtonsStackPanel.Children.IndexOf((Button)sender));
            itsFilterDeleteButtonsStackPanel.Children.Remove((Button)sender);
        }
    }
}