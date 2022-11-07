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
        public abstract void SetWidth();
        public abstract void SetHeight();
        public TextBox BuildFilter()
        {
            return itsFilter;
        }
    }
}