using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace FolderMonitor.Converters
{
    public static class FiltersConverter
    {
        // To list
        public static List<string> ToFiltersList(string filter)
        {
            return filter.Split(", ").ToList();
        }
        public static List<string> ToFiltersList(StackPanel filtersStackPanel)
        {
            List<string> filters = new List<string>();
            foreach (object objFilter in filtersStackPanel.Children)
            {
                TextBox filter = (TextBox)objFilter;
                filters.Add(filter.Text.Trim());
            }
            return filters;
        }


        // To string
        public static string ToFilterString(List<string> filters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < filters.Count; i++)
            {
                stringBuilder.Append(filters[i]);
                if (i + 1 < filters.Count)
                    stringBuilder.Append(", ");
            }
            return stringBuilder.ToString();
        }
    }
}