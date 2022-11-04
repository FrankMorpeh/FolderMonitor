using System.Collections.Generic;

namespace FolderMonitor.FileReaders.TxtReader
{
    public static class AboutMenuReader
    {
        public static List<string> GetAboutMenuPages()
        {
            List<string> aboutMenuPages = new List<string>();
            AddAboutMenuPages(aboutMenuPages);
            RemoveEmptyPages(aboutMenuPages);
            return aboutMenuPages;
        }
        private static void AddAboutMenuPages(List<string> aboutMenuPages)
        {
            aboutMenuPages.Add(TxtReader.ReadTxtFile("\\About\\AboutProgram.txt"));
        }
        private static void RemoveEmptyPages(List<string> aboutMenuPages)
        {
            aboutMenuPages.RemoveAll(p => p == string.Empty); // removes empty pages (if they haven't been loaded for some reason)
        }
    }
}
