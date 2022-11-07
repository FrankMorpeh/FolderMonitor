using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterBuilder
{
    public static class FilterCreator
    {
        public static TextBox CreateFilter(FilterBuilder filterBuilder)
        {
            filterBuilder.CreateFilter();
            filterBuilder.SetWidth();
            filterBuilder.SetHeight();
            return filterBuilder.BuildFilter();
        }
    }
}