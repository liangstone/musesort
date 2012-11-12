using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;

namespace museSort
{
    class utwor
    {
        public String sciezka;
        public String nazwa;
        public String rozszerzenie;
        public String wykonawca;
        public String tytul;
        public String album;
        public int numer;
        public TagLib.File tagi;

        public utwor(String path)
        {
            sciezka = path;
            String[] droga = sciezka.Split('/');
            String[] temp = droga[droga.Length - 1].Split('.');
            nazwa = temp[temp.Length - 2];
            rozszerzenie = temp[temp.Length - 1];
            
            if (!rozszerzenie.Equals("mp3") && !!rozszerzenie.Equals("flac"))
            {
                nazwa = "Błędne rozszerzenie pliku!!!";
            }
            else
            {
                tagi = TagLib.File.Create(path);
            }
        }
    }
}
