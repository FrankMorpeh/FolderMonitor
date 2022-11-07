namespace FolderMonitor.Builders.FilterBuilder
{
    public class TrackerFilterBuilder : FilterBuilder
    {
        public override void SetWidth()
        {
            itsFilter.Width = 50;
        }
        public override void SetHeight()
        {
            itsFilter.Height = 20;
        }
    }
}