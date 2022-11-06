using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterBuilder
{
    public static class FilterCreator
    {
        public static TextBox CreateFilter(FilterBuilder filterBuilder, int numberOfFilter)
        {
            filterBuilder.CreateFilter();
            filterBuilder.SetName(numberOfFilter);
            filterBuilder.SetMaxWidth();
            filterBuilder.SetMaxHeight();
            return filterBuilder.BuildFilter();
        }
    }
}