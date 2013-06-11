using System;
using System.IO;
using MuseSort;

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

        public static void PrintFilmsInFolder(string folder)
        {
            foreach (var file in Directory.GetFiles(folder))
            {
                try
                {
                    var film = new Film(file);
                    Console.WriteLine(film.ToString());
                    File.AppendAllText(@"C:\Users\KrzysztofD\Desktop\pliki.txt", film.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    File.AppendAllText(@"C:\Users\KrzysztofD\Desktop\pliki.txt", file + "\n" + e.Message);
                }
            }
        }
    }
}