namespace FolderMonitor.Warnings
{
    public interface IWarning
    {
        string Text { get; }
    }
    public class IncorrectFilePath : IWarning
    {
        public IncorrectFilePath() { Text = "FILE PATH IS EMPTY!"; }
        public string Text { get; }
    }
    public class IncorrectFilter : IWarning
    {
        public IncorrectFilter() { Text = "INCORRECT FILTER!"; }
        public string Text { get; }
    }
    public class TrackerIsNotChosen : IWarning
    {
        public TrackerIsNotChosen() { Text = "TRACKER IS NOT CHOSEN!"; }
        public string Text { get; }
    }
    public class SameFilter : IWarning
    {
        public SameFilter() { Text = "SUCH FILTERS ARE ALREADY APPLIED TO THIS FOLDER!"; }
        public string Text { get; }
    }
    public class DirectoryChangeIsNotChosen : IWarning
    {
        public DirectoryChangeIsNotChosen() { Text = "DIRECTORY CHANGE IS NOT CHOSEN!"; }
        public string Text { get; }
    }
    public class None : IWarning
    {
        public None() { Text = "NO ERRORS HAVE BEEN DETECTED"; }
        public string Text { get; }
    }
}