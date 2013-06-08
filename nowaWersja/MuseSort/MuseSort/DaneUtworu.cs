using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;

namespace MuseSort
{
    public class DaneUtworu : Dane
    {
        //do ponownego merga
        public String[] wykonawca = { "" };
        public String[] wykonawcaAlbumu = { "" };
        public String tytul = "";
        public String album = "";
        public String[] gatunek = { "" };
        public uint rok;
        public String komentarz = "";
        public uint liczbaPiosenek;
        public uint numerCd;
        public uint liczbaCd;
        public String tekstPiosenki = "";
        public uint bityNaMinute;
        public String dyrygent = "";
        public String prawaAutorskie = "";
        public String puid = "";
        public IPicture[] zdjecia = { };
        public uint numer;

        public DaneUtworu() {}

        public DaneUtworu(Dictionary<string,string> dane) { ZapiszDopasowaneDane(dane); }

        public Boolean czyDaneWypelnione()
        {
            return wykonawca.Length > 0 && wykonawca[0] != "" && tytul != "" && album != "";
        }

        public void ZapiszDopasowaneDane(Dictionary<string, string> dopasowanie)
        {
            foreach (var tag in dopasowanie.Keys)
            {
                var wartosc = dopasowanie[tag];
                switch (tag)
                {
                    case "numer":
                        if (numer == 0)
                            numer = UInt32.Parse(wartosc);
                        break;
                    case "rok":
                        if (rok == 0)
                            rok = UInt32.Parse(wartosc);
                        break;
                    case "wykonawca":
                        if (wykonawca[0] == "")
                            wykonawca[0] = wartosc;
                        break;
                    case "tytul":
                        if (tytul == "")
                            tytul = wartosc;
                        break;
                    case "album":
                        if (album == "")
                            album = wartosc;
                        break;
                }
            }
        }
    }
}
