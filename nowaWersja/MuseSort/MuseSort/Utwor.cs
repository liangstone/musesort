using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MuseSort
{
    partial class Utwor : Plik
    {
        #region atrybuty klasy
        public DaneUtworu dane;

        TagLib.File tagi;
        TagLib.File stareTagi;
        Boolean pobranoZNazwy = false;
        Boolean pobranoZeSciezki = false;
        
        #endregion
        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################


        /// <summary>Tworzy obiekt Utwór odpowiedający danemu plikowi muzycznemu.</summary>
        /// <param name="path">Ścieżka pliku.</param>
        /// <exception cref="FileNotFoundException">Rzucane jeśli podany plik nie istnieje</exception>
        public Utwor(String path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException(path);
            Sciezka = SciezkaZrodlowa = path;
            Nazwa = Path.GetFileNameWithoutExtension(path);
            dane = new DaneUtworu();
            tagi = TagLib.File.Create(path);
            stareTagi = TagLib.File.Create(path);
            pobierzTagi();
        }

        /// <summary>Konstruktor dla pliku, który został skopiowany w ramach działania programu</summary>
        /// <param name="path">Ścieżka pliku skopiowanego</param>
        /// <param name="source">Ścieżka pliku oryginalnego</param>
        /// <exception cref="FileNotFoundException">Rzucane jeśli któryś z podanych plików nie istnieje</exception>
        public Utwor(String path, String source)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            if(!File.Exists(source))
                throw new FileNotFoundException(source);
            SciezkaZrodlowa = source;
            Sciezka = path;
            Nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new DaneUtworu();
            tagi = TagLib.File.Create(path);
            stareTagi = TagLib.File.Create(path);
            pobierzTagi();
        }

        //Zapisuje dane z obiektu dane do obiektu tagi
        //Uaktualnia dane w obiekcie stareTagi
        public override void zapiszTagi()
        {
            tagi.Tag.Album = dane.album;
            tagi.Tag.BeatsPerMinute = dane.bityNaMinute;
            tagi.Tag.Conductor = dane.dyrygent;
            tagi.Tag.Genres = dane.gatunek;
            tagi.Tag.Comment = dane.komentarz;
            tagi.Tag.DiscCount = dane.liczbaCd;
            tagi.Tag.TrackCount = dane.liczbaPiosenek;
            tagi.Tag.Track = dane.numer;
            tagi.Tag.Disc = dane.numerCd;
            tagi.Tag.Copyright = dane.prawaAutorskie;
            tagi.Tag.MusicIpId = dane.puid;
            tagi.Tag.Year = dane.rok;
            tagi.Tag.Lyrics = dane.tekstPiosenki;
            tagi.Tag.Title = dane.tytul;
            tagi.Tag.Performers = dane.wykonawca;
            tagi.Tag.AlbumArtists = dane.wykonawcaAlbumu;
            tagi.Tag.Pictures = dane.zdjecia;
            tagi.Save();
            stareTagi = tagi;
            logi += "Zapisano nowe tagi." + Environment.NewLine;
        }

        //Przywraca do obiektu dane informacje z obiektu stareTagi
        public override void przywrocDomyslneTagi()
        {
            tagi = stareTagi;
            pobierzTagi();
            logi += "Anulowano modyfikowanie tagów." + Environment.NewLine;
        }

        

        //Generuje tagi z nazwy pliku i zapisuje w obiekcie dane
        public override void pobierzTagiZNazwy()
        {
            var wzorzec = wzorceNazwy.Find(w => w.czyPasuje(Nazwa));
            if(wzorzec==null) return;
            var dopasowanie = wzorzec.Dopasuj(Nazwa);
            ZapiszDopasowaneDane(dopasowanie);

            #region Stary kod

/*//Generuje tagi z nazwy pliku i zapisuje w obiekcie dane
            //Zmienia wartość zmiennej pobranoZNazwy na true
            //Do wykonania tej metody wykorzystujemy listę wzorców z obiektu wzorceNazwy
            foreach (Wzorzec wzor in wzorceNazwy)
            {
                if (wzor.czyPasuje(Nazwa))
                {
                    pobranoZNazwy = true;
                }
            }
            pobranoZNazwy = false;
            //narazie wyszukuje po numer, autor, album, tytuł 
            if(!dane.czyDaneWypelnione() || dane.numer == 0)    //tu należy umieścić wyszukiwane informacje jeśli zostaną jakieś dodane
            {                                                   //oraz należy dodać ifa na koncu funkcji
                Wzorzec wzr = null;
                foreach (Wzorzec w in wzorceNazwy)
                {
                    if (w.czyPasuje(Nazwa))     //wybranie pasującego wzorcu
                    {
                        pobranoZNazwy = true;
                        wzr = w;
                        break;
                    }
                }
                if (pobranoZNazwy == true)      //jeśli mamy pasujący wzorzec
                {
                    char[] wzrSep = { '<', '>' };
                    String[] wzrSp = wzr.wzorzec.Split(wzrSep);    //podział wzorcu na elementy
                    String tmp = "";                                        //otrymamy {"dane", "separator", "dane"...}
                    for (int i = 0; i < wzrSp.Length / 2; i++)              //zakładam że pomiędzy informacjami występują separatory
                    {
                        tmp += wzrSp[1 + 2 * i];                 
                    }
                    char[] nazwaSep = tmp.ToCharArray();
                    String[] nazwaSp = Nazwa.Split(nazwaSep);       //podział nazwy na oczekiwane informacje

                    String s = "";
                    for (int i=0; i <= (nazwaSp.Length + 1)/2; i++) //sprawdzenie pokolei zawartości wzorca
                    {                                               //wypełnienie pustych pol
                        s = wzrSp[i*2];
                        if (dane.numer == 0 && s.Equals("numer")) 
                        {
                            UInt32.TryParse(nazwaSp[i], out dane.numer);
                            logi += "Dodano numer do tagów z nazwy: " + nazwaSp[i] + Environment.NewLine;
                        }
                        else if (!(dane.wykonawca.Length > 0 && dane.wykonawca[0] != "") && s.Equals("wykonawca")) 
                        {
                            dane.wykonawca = new String[1];
                            dane.wykonawca[0] = nazwaSp[i];
                            logi += "Dodano wykonawcę do tagów z nazwy: " + nazwaSp[i] + Environment.NewLine;
                        }
                        else if (dane.album.Equals("") && s.Equals("album")) 
                        {
                            dane.album = nazwaSp[i];
                            logi += "Dodano album do tagów z nazwy: " + nazwaSp[i] + Environment.NewLine;
                        }
                        else if (dane.tytul.Equals("") && s.Equals("tytul")) 
                        {
                            dane.tytul = nazwaSp[i];
                            logi += "Dodano tytuł do tagów z nazwy: " + nazwaSp[i] + Environment.NewLine;
                        }
                    }
                }
            }*/

            #endregion

        }

        private void ZapiszDopasowaneDane(Dictionary<string, string> dopasowanie)
        {
            foreach (var tag in dopasowanie.Keys)
            {
                var wartosc = dopasowanie[tag];
                switch (tag)
                {
                    case "numer":
                        if (dane.numer == 0)
                            dane.numer = uint.Parse(wartosc);
                        break;
                    case "rok":
                        if (dane.rok == 0)
                            dane.rok = uint.Parse(wartosc);
                        break;
                    case "wykonawca":
                        if (dane.wykonawca[0] == "")
                            dane.wykonawca[0] = wartosc;
                        break;
                    case "tytul":
                        if (dane.tytul == "")
                            dane.tytul = wartosc;
                        break;
                    case "album":
                        if (dane.album == "")
                            dane.album = wartosc;
                        break;
                }
            }
        }

        //Generuje tagi ze ścieżki do pliku i zapisuje w obiekcie dane
        //Zakładamy, że ta metoda jest wywoływana po metodzie pobierzTagiZNazwy
        public override void pobierzTagiZeSciezki()
        {
            var wzorzec = wzorceSciezki.Find(w => w.czyPasuje(SciezkaZrodlowa));
            if (wzorzec == null) return;
            var dopasowanie = wzorzec.Dopasuj(SciezkaZrodlowa);
            ZapiszDopasowaneDane(dopasowanie);

            #region Stary kod

//narazie wyszukuje po  autor, album
           /* if (!dane.czyDaneWypelnione()) //tu należy umieścić wyszukiwane informacje jeśli zostaną jakieś dodane
            {
                //oraz należy dodać ifa na koncu funkcji
                Wzorzec wzr = null;
                foreach (Wzorzec w in wzorceSciezki)
                {
                    if (w.czyPasuje(Nazwa)) //wybranie pasującego wzorcu
                    {
                        pobranoZeSciezki = true;
                        wzr = w;
                        break;
                    }
                }
                if (pobranoZeSciezki == true) //jeśli mamy pasujący wzorzec
                {
                    char[] wzrSep = {'<', '>'};
                    String[] wzrSp = wzr.wzorzec.Split(wzrSep); //podział wzorcu na elementy
                    String[] nazwaSp = Nazwa.Split('\\'); //podział nazwy na oczekiwane informacje
                    //zakładam że wzorzec do scieżki wygląda <Autor><Album>
                    int nazwaLen = nazwaSp.Length; //a to odpowiada scieżce ...\\Autor\\Album\\plik.ext
                    int wzrLen = wzrSp.Length;
                    int nazwaIndex = nazwaLen - wzrLen - 1; //-1 ponieważ ścieżka zawiera nazwę pliku
                    String s = "";
                    for (int i = 0; i < wzrSp.Length; i--) //sprawdzenie pokolei zawartości wzorca
                    {
                        //wypełnienie pustych pól
                        if (!(dane.wykonawca.Length > 0 && dane.wykonawca[0] != "") && s.Equals("wykonawca"))
                        {
                            dane.wykonawca = new String[1];
                            dane.wykonawca[0] = nazwaSp[nazwaIndex + i];
                            logi += "Dodano wykonawca do tagów ze ścieżki: " + nazwaSp[i] + Environment.NewLine;
                        }
                        else if (dane.album.Equals("") && s.Equals("album"))
                        {
                            dane.album = nazwaSp[nazwaIndex + i];
                            logi += "Dodano album do tagów ze ścieżki: " + nazwaSp[i] + Environment.NewLine;
                        }
                    }
                }
            }*/

            #endregion

        }

        ///<summary>Na podstawie danych w obiekcie dane tworzy nową nazwę pliku.</summary>
        public override String generujNazwePlikuZTagow()
        {
            String nowaNazwa = "";
            if (dane.czyDaneWypelnione())
            {
                if (dane.numer > 0)
                {
                    nowaNazwa += dane.numer + ". ";
                }
                nowaNazwa += normalizujNazwe(dane.wykonawca[0]) + " - " + normalizujNazwe(dane.tytul);
                nowaNazwa = usunZnakiSpecjalne(nowaNazwa);
            }
            logi += "Wygenerowano nową nazwę: " + nowaNazwa + Environment.NewLine;
            return nowaNazwa;
        }

        public override string sciezka_katalogu_z_pol(string[] kategorie, bool duplikat = false)
        {
            string sciezka_katalogu;
            if (duplikat)
                sciezka_katalogu = @"Musesort\Muzyka\Zduplikowane\Posegregowane\";
            else
                sciezka_katalogu = @"Musesort\Muzyka\Posegregowane\";

            string sciezkaZDanych = dane.sciezkaKataloguZPol(kategorie);

            if (sciezkaZDanych.Equals("")) //przenieś do "Nieprzydzielone
            {
                if (duplikat)
                    sciezka_katalogu = @"Musesort\Muzyka\Zduplikowane\Posegregowane\Nieprzydzielone";
                else
                    sciezka_katalogu = @"Musesort\Muzyka\Posegregowane\Nieprzydzielone";
            }
            else
                sciezka_katalogu += sciezkaZDanych;

            if (kategorie.Last() == "alfabetycznie")
                sciezka_katalogu += dane.tytul.Substring(0, 1);

            if (duplikat && File.Exists(Path.Combine(sciezka_katalogu, Path.GetFileName(Sciezka))))
            {
                string fullpath = Path.Combine(sciezka_katalogu, Nazwa);
                int i;
                for (i = 1; File.Exists(fullpath); )
                {
                    i++;
                    fullpath = Path.Combine(sciezka_katalogu + Convert.ToString(i), Nazwa);
                }
                sciezka_katalogu += Convert.ToString(i);
            }

            return sciezka_katalogu;
        }

        #endregion
        #region metody pomocnicze klasy
        //######################################METODY POMOCNICZE KLASY######################################

        protected override void resetujTagi()
        {
            tagi = TagLib.File.Create(Sciezka);
            stareTagi = TagLib.File.Create(Sciezka);
        }

        //Pobieranie tagów z obiektu tagi i zapisywanie w obiekcie dane
        private void pobierzTagi()
        {
            dane.album = tagi.Tag.Album;
            dane.bityNaMinute = tagi.Tag.BeatsPerMinute;
            dane.dyrygent = tagi.Tag.Conductor;
            dane.gatunek = tagi.Tag.Genres;
            dane.komentarz = tagi.Tag.Comment;
            dane.liczbaCd = tagi.Tag.DiscCount;
            dane.liczbaPiosenek = tagi.Tag.TrackCount;
            dane.numer = tagi.Tag.Track;
            dane.numerCd = tagi.Tag.Disc;
            dane.prawaAutorskie = tagi.Tag.Copyright;
            dane.puid = tagi.Tag.MusicIpId;
            dane.rok = tagi.Tag.Year;
            dane.tekstPiosenki = tagi.Tag.Lyrics;
            dane.tytul = tagi.Tag.Title;
            dane.wykonawca = tagi.Tag.Performers;
            dane.wykonawcaAlbumu = tagi.Tag.AlbumArtists;
            dane.zdjecia = tagi.Tag.Pictures;
            logi += "Pobrano tagi z pliku." + Environment.NewLine;
            if (dane.czyDaneWypelnione())
            {
                logi += "Pobrane tagi są kompletne." + Environment.NewLine;
            }
        }

        /// <summary>Porównuje jakość plików.</summary>
        /// <param name="plik2">Drugi plik do porównania. Z powodu kompatybilności deklarowany typ plik, 
        /// ale zakładamy że ma to być drugi tego samego typu.</param>
        /// <exception cref="InvalidCastException">Rzucane jeśli drugi plik jest innego typu.</exception>
        /// <returns>True jeśli pliki są równie "dobre" lub pierwszy jest lepszy.</returns>
        protected override bool porownaj(Plik plik2)
        {
            return dane.bityNaMinute >= ((Utwor)plik2).dane.bityNaMinute;
        }

        #endregion



    }
}
