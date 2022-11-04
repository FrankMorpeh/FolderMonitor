using System.IO;

namespace FolderMonitor.FileReaders.TxtReader
{
    public static class TxtReader
    {
        public static string ReadTxtFile(string path)
        {
            StreamReader streamReader = null;
            string text = string.Empty;
            try
            {
                streamReader = new StreamReader(new FileStream(MainWindow.itsInitialLocation + path, FileMode.Open, FileAccess.Read));
                text = streamReader.ReadToEnd();
            }
            catch (IOException) { }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
            return text;
        }
    }
}