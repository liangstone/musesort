using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    class Film : StaticFilm
    {
        DaneFilmu dane;
        String sciezka = "";
        String sciezkaZrodlowa = "";
        String nazwa = "";
        //<należy wybrać klasę źródłową> tagi;
        //<należy wybrać klasę źródłową> stareTagi;
        Boolean pobranoZNazwy = false;
        public String logi = "";

        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################

        //Konstruktor standardowy
        public Film()
        {
            dane = new DaneFilmu();
            //tagi = null;
            //stareTagi = null;
        }

        //Konstruktor dowolnego pliku
        public Film(String path)
        {
            sciezka = sciezkaZrodlowa = path;
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new DaneFilmu();
            //tagi = 
            //stareTagi = 
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
        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        //Pobieranie tagów z obiektu tagi i zapisywanie w obiekcie dane
        private void pobierzTagi()
        {
            
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
        #endregion
    }
}
