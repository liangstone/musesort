﻿using System;
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

        public Boolean czyDaneWypelnione()
        {
            return wykonawca.Length > 0 && wykonawca[0] != "" && tytul != "" && album != "";
        }
    }
}
