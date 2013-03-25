using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vlc.DotNet.Core.Medias;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace MuseSort
{
    class Film : StaticFilm
    {
        DaneFilmu dane;
        String sciezka = "";
        String sciezkaZrodlowa = "";
        String nazwa = "";
        //Tagi to MediaBase.Metadatas, czyli np. tagi.Metadatas
        VlcControl tagi;
        VlcControl stareTagi;
        Boolean pobranoZNazwy = false;
        public String logi = "";

        //#############################PUBLICZNE METODY KLASY############################################

        //Konstruktor standardowy
        public Film()
        {
            dane = new DaneFilmu();
            tagi = null;
            stareTagi = null;
        }

        //Konstruktor dowolnego pliku
        public Film(String path)
        {
            sciezkaZrodlowa = path;
            sciezka = path;
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new DaneFilmu();

            tagi = new VlcControl();
            stareTagi = new VlcControl();
//---------------poniżej rzuca błędem NullReferenceException--------------
            tagi.Media = new LocationMedia(sciezka);
            stareTagi.Media = new LocationMedia(sciezka);
//------------------------------------------------------------------------
            pobierzTagi();
        }

        //Konstruktor dla pliku, który został skopiowany w ramach działania programu
        public Film(String path, String source)
        {
            sciezkaZrodlowa = source;
            sciezka = path;
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new DaneFilmu();

            //tagi = 
            //stareTagi = 
            pobierzTagi();
        }

        
        public void zapiszTagi()
        {
            //Zapisuje dane z obiektu dane do obiektu tagi
            //niektóre informacje poniżej mogą być zbędne
            tagi.Media.Metadatas.Album = dane.album;
            tagi.Media.Metadatas.Artist = dane.artysta;
            tagi.Media.Metadatas.Copyright = dane.prawaAutorskie;
            tagi.Media.Metadatas.Date = dane.data;
            tagi.Media.Metadatas.Description = dane.opis;
            tagi.Media.Metadatas.Genre = dane.gatunek;
            tagi.Media.Metadatas.Language = dane.jezyk;
            tagi.Media.Metadatas.Publisher = dane.wydawca;
            tagi.Media.Metadatas.Title = dane.tytul;
            tagi.Media.Metadatas.TrackID = dane.id;
            tagi.Media.Metadatas.TrackNumber = dane.numer;
            tagi.Media.Metadatas.Save();
            //Uaktualnia dane w obiekcie stareTagi
            logi += "Zapisano nowe tagi." + Environment.NewLine;
        }

        //Przywraca do obiektu dane informacje z obiektu stareTagi
        public void przywrocDomyslneTagi()
        {
            
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

        //Na podstawie danych w obiekcie dane tworzy nową nazwę pliku
        public String generujNazwePlikuZTagow()
        {
            String nowaNazwa = "";
            
            logi += "Wygenerowano nową nazwę: " + nowaNazwa + Environment.NewLine;
            return nowaNazwa;
        }

        //Zmienia nazwę pliku i zmienną nazwa
        public void zmienNazwePliku(String nowaNazwa)
        {
            nowaNazwa = usunZnakiSpecjalne(nowaNazwa);
            //tagi = null;
            //stareTagi = null;
            String nowaSciezka = System.IO.Path.GetDirectoryName(sciezka) + "\\" + nowaNazwa + "." + System.IO.Path.GetExtension(sciezka);
            System.IO.File.Move(sciezka, nowaSciezka);
            logi += "Zmieniono nazwę pliku. Stara nazwa: " + nazwa + " Nowa nazwa: " + nowaNazwa + Environment.NewLine;
            nazwa = nowaNazwa;
            sciezka = nowaSciezka;
            //tagi = 
            //stareTagi = 
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
            if (tagi != null && tagi.Media != null)
            {
                //niektóre informacje poniżej mogą być zbędne
                dane.album = tagi.Media.Metadatas.Album;
                dane.artysta = tagi.Media.Metadatas.Artist;
                dane.prawaAutorskie = tagi.Media.Metadatas.Copyright;
                dane.data = tagi.Media.Metadatas.Date;
                dane.opis = tagi.Media.Metadatas.Description;
                dane.gatunek = tagi.Media.Metadatas.Genre;
                dane.jezyk = tagi.Media.Metadatas.Language;
                dane.wydawca = tagi.Media.Metadatas.Publisher;
                dane.tytul = tagi.Media.Metadatas.Title;
                dane.id = tagi.Media.Metadatas.TrackID;
                dane.numer = tagi.Media.Metadatas.TrackNumber;
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
