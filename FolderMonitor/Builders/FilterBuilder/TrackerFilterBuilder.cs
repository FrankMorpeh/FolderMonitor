namespace FolderMonitor.Builders.FilterBuilder
{
    public class TrackerFilterBuilder : FilterBuilder
    {
        public override void SetMaxWidth()
        {
            itsFilter.MaxWidth = 75;
        }
        public override void SetMaxHeight()
        {
            itsFilter.MaxHeight = 30;
        }
    }
}