namespace FolderMonitor.Warnings
{
    public interface IWarning
    {
        string Text { get; }
    }
    public class IncorrectFilter : IWarning
    {
        public IncorrectFilter() { Text = "INCORRECT FILTER!"; }
        public string Text { get; }
    }
    public class None : IWarning
    {
        public None() { Text = "NO ERRORS HAVE BEEN DETECTED"; }
        public string Text { get; }
    }
}