using System.IO;

namespace MuseSortTesting
{
    public class Util
    {
        public static string SetAbsolutePath(string sciezka)
        {
            while (!Directory.Exists(sciezka))
            {
                sciezka = @"..\" + sciezka;
                if(sciezka.Length>100)
                    throw new FileNotFoundException();
            }
            return Path.GetFullPath(sciezka);
        }
    }
}