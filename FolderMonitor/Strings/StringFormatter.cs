namespace FolderMonitor.Strings
{
    public static class StringFormatter
    {
        public static string GetShortPathToFile(string fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
        }
    }
}