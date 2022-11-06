using System.Collections.Generic;
using System.Linq;

namespace FolderMonitor.Converters
{
    public static class FilterConverter
    {
        public static List<string> ToFilterList(string filter)
        {
            return filter.Split(", ").ToList();
        }
    }
}