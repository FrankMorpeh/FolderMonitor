using System;
using System.Windows.Controls;

namespace FolderMonitor.Builders.FilterBuilder
{
    public abstract class FilterBuilder
    {
        protected TextBox itsFilter;

        public FilterBuilder() { itsFilter = null; }
        public void CreateFilter()
        {
            itsFilter = new TextBox();
        }
        public void SetName(int numberOfFilter)
        {
            itsFilter.Name = "filter" + Convert.ToString(numberOfFilter);
        }
        public abstract void SetMaxWidth();
        public abstract void SetMaxHeight();
        public TextBox BuildFilter()
        {
            return itsFilter;
        }
    }
}