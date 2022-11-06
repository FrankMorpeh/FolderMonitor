using FolderMonitor.Converters;
using System.Collections.Generic;

namespace FolderMonitor.Models.DirectoryTrackerModel
{
    public class DirectoryTrackerModel : IDirectoryTrackerModel
    {
        private readonly string itsFolderPath;
        private string itsFilter;
        private List<string> itsFilters;

        public DirectoryTrackerModel() { itsFolderPath = string.Empty; itsFilter = string.Empty; itsFilters = null; }
        public DirectoryTrackerModel(string folderName, string filter) 
        { 
            itsFolderPath = folderName; 
            itsFilter = filter;
            itsFilters = FilterConverter.ToFilterList(itsFilter);
        }
        
        public string FolderPath { get { return itsFolderPath; } }
        public string Filter { get { return itsFilter; } set { itsFilter = value; } }
    }
}