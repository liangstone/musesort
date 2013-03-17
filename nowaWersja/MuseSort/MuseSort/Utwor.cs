using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    class Utwor : StaticUtwor
    {
        Dane dane;
        String sciezka = "";
        String sciezkaZrodlowa = "";
        String nazwa = "";
        TagLib.File tagi;
        TagLib.File stareTagi;
        Boolean pobranoZNazwy = false;
        Boolean pobranoZeSciezki = false;
        public String logi = "";
        public static string[] wspieraneRozszerzenia = { "mp3", "flac" };
        
        //#############################PUBLICZNE METODY KLASY############################################

        //Konstruktor standardowy
        public Utwor()
        {
            dane = new Dane();
            tagi = null;
            stareTagi = null;
        }

        //Konstruktor dowolnego pliku
        public Utwor(String path)
        {
            sciezka = sciezkaZrodlowa = path;
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new Dane();
            tagi = TagLib.File.Create(path);
            stareTagi = TagLib.File.Create(path);
            pobierzTagi();
        }

        //Konstruktor dla pliku, który został skopiowany w ramach działania programu
        public Utwor(String path, String source)
        {
            sciezkaZrodlowa = source;
            sciezka = path;
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new Dane();
            tagi = TagLib.File.Create(path);
            stareTagi = TagLib.File.Create(path);
            pobierzTagi();
        }

        //Zapisuje dane z obiektu dane do obiektu tagi
        //Uaktualnia dane w obiekcie stareTagi
        public void zapiszTagi()
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
        public void przywrocDomyslneTagi()
        {
            tagi = stareTagi;
            pobierzTagi();
            logi += "Anulowano modyfikowanie tagów." + Environment.NewLine;
        }

        public void pobierzTagiZNazwy()
        {
            //Generuje tagi z nazwy pliku i zapisuje w obiekcie dane
            //Zmienia wartość zmiennej pobranoZNazwy na true
            //Do wykonania tej metody wykorzystujemy listę wzorców z obiektu wzorceNazwy
            foreach (Wzorzec wzor in wzorceNazwy)
            {
                if (wzor.czyPasuje(nazwa))
                {
                    pobranoZNazwy = true;
                }
            }
            pobranoZNazwy = false;
        }

        //Generuje tagi ze ścieżki do pliku i zapisuje w obiekcie dane
        //Zakładamy, że ta metoda jest wywoływana po metodzie pobierzTagiZNazwy
        public void pobierzTagiZeSciezki()
        {
            //narazie wyszukuje po  autor, album
            if (!dane.czyDaneWypelnione())    //tu należy umieścić wyszukiwane informacje jeśli zostaną jakieś dodane
            {                                 //oraz należy dodać ifa na koncu funkcji
                Wzorzec wzr = null;
                foreach (Wzorzec w in wzorceSciezki)
                {
                    if (w.czyPasuje(nazwa))     //wybranie pasującego wzorcu
                    {
                        pobranoZeSciezki = true;
                        wzr = w;
                        break;
                    }
                }
                if (pobranoZeSciezki == true)      //jeśli mamy pasujący wzorzec
                {
                    char[] wzrSep = { '<', '>' };
                    String[] wzrSp = wzr.wzorzec.Split(wzrSep);    //podział wzorcu na elementy
                    String[] nazwaSp = nazwa.Split('\\');                   //podział nazwy na oczekiwane informacje
                                                                            //zakładam że wzorzec do scieżki wygląda <Autor><Album>
                    int nazwaLen = nazwaSp.Length;                          //a to odpowiada scieżce ...\\Autor\\Album\\plik.ext
                    int wzrLen = wzrSp.Length;
                    int nazwaIndex = nazwaLen - wzrLen - 1;                 //-1 ponieważ ścieżka zawiera nazwę pliku
                    String s = "";
                    for (int i = 0; i < wzrSp.Length; i--)              //sprawdzenie pokolei zawartości wzorca
                    {                                                   //wypełnienie pustych pól
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
            }
        }

        //Na podstawie danych w obiekcie dane tworzy nową nazwę pliku
        public String generujNazwePlikuZTagow()
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

        //Zmienia nazwę pliku i zmienną nazwa
        public void zmienNazwePliku(String nowaNazwa)
        {
            nowaNazwa = usunZnakiSpecjalne(nowaNazwa);
            tagi = null;
            stareTagi = null;
            String nowaSciezka = System.IO.Path.GetDirectoryName(sciezka)+ "\\" + nowaNazwa + "." + System.IO.Path.GetExtension(sciezka);
            System.IO.File.Move(sciezka, nowaSciezka);
            logi += "Zmieniono nazwę pliku. Stara nazwa: " + nazwa + " Nowa nazwa: " + nowaNazwa + Environment.NewLine;
            nazwa = nowaNazwa;
            sciezka = nowaSciezka;
            tagi = TagLib.File.Create(nowaSciezka);
            stareTagi = TagLib.File.Create(nowaSciezka);
        }

        //Kopiuje plik do lokalizacji w zmiennej path i uaktualnia zmienną sciezka
        public void kopiujPlik(String path)
        {
            String nowaSciezka = path + nazwa + "." + System.IO.Path.GetExtension(sciezka);
            System.IO.File.Copy(sciezka, nowaSciezka);
            logi += "Wykonano kopię pliku do folderu: " + path + Environment.NewLine;
        }


        //######################################METODY POMOCNICZE KLASY######################################

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

        //Usuwanie znaków \/:*?<>|" z nazwy w celu przygotowania prawidłowej nazwy pliku
        //Wywoływane na potrzeby metod: zmienNazwePliku oraz generujNazwePlikowZTagow
        private String usunZnakiSpecjalne(String nazwa)
        {
            String wynik = nazwa;
            wynik.Replace("\\", "");
            wynik.Replace("/", "");
            wynik.Replace(":", "");
            wynik.Replace("*", "");
            wynik.Replace("?", "");
            wynik.Replace("<", "");
            wynik.Replace(">", "");
            wynik.Replace("|", "");
            wynik.Replace("\"", "");
            return wynik;
        }

        //Zmiana nazwy w taki sposób, aby zaczynała się z dużej i kończyła małymi literami
        private String normalizujNazwe(String nazwa)
        {
            String wynik = nazwa.ToUpper();
            wynik = wynik[0] + wynik.Substring(1).ToLower();
            return wynik;
        }
    }
}
