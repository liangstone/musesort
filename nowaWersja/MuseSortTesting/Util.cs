using System.IO;

namespace MuseSortTesting
{
    public class Util
    {
        public static string SetAbsoluteDirectoryPath(string sciezka)
        {
            var path = sciezka;
            while (!Directory.Exists(path))
            {
                path = @"..\" + path;
                if(path.Length>100)
                    throw new FileNotFoundException(sciezka);
            }
            return Path.GetFullPath(path);
        }

        public static string SetAbsoluteFilePath(string sciezka)
        {
            var path = sciezka;
            while (!File.Exists(path))
            {
                path = @"..\" + path;
                if (path.Length > 100)
                    throw new FileNotFoundException(sciezka);
            }
            return Path.GetFullPath(path);
        }
    }
}