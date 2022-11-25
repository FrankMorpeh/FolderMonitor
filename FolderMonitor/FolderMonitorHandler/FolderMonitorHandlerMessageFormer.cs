using FolderMonitor.Strings;

namespace FolderMonitor.Handlers.FolderMonitor
{
    public static class FolderMonitorHandlerMessageFormer
    {
        public static string FormCreateMessage(string filefullPath, string folderFullPath)
        {
            return FormMessage(filefullPath, folderFullPath, " has been created in ");
        }
        public static string FormDeleteMessage(string filefullPath, string folderFullPath)
        {
            return FormMessage(filefullPath, folderFullPath, " has been deleted from ");
        }
        public static string FormChangeMessage(string filefullPath, string folderFullPath)
        {
            return FormMessage(filefullPath, folderFullPath, " has been changed in ");
        }
        public static string FormRenameMessage(string filefullPath, string folderFullPath)
        {
            return FormMessage(filefullPath, folderFullPath, " has been renamed in ");
        }
        private static string FormMessage(string filefullPath, string folderFullPath, string uniqueSign)
        {
            return "\"" + StringFormatter.GetShortPathToFile(filefullPath) + "\""
                + uniqueSign + "\"" + folderFullPath + "\"";
        }
    }
}