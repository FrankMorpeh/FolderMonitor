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
        public override void SetFontFamily()
        {
            itsFilter.FontFamily = new System.Windows.Media.FontFamily("Open Sans Condensed");
        }
        public override void SetFontSize()
        {
            itsFilter.FontSize = 14;
        }
    }
}