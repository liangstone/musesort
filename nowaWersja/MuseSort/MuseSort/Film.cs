using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    partial class Film : Plik
    {
        DaneFilmu dane;
        String sciezka = "";
        String sciezkaZrodlowa = "";
        String nazwa = "";
        //<należy wybrać klasę źródłową> tagi;
        //<należy wybrać klasę źródłową> stareTagi;
        Boolean pobranoZNazwy = false;

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
            resetujTagi();
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

        
        public override void zapiszTagi()
        {
            //Zapisuje dane z obiektu dane do obiektu tagi
            //Uaktualnia dane w obiekcie stareTagi
            logi += "Zapisano nowe tagi." + Environment.NewLine;
        }

        //Przywraca do obiektu dane informacje z obiektu stareTagi
        public override void przywrocDomyslneTagi()
        {
            
            logi += "Anulowano modyfikowanie tagów." + Environment.NewLine;
        }

        public override void pobierzTagiZNazwy()
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
        public override String generujNazwePlikuZTagow()
        {
            String nowaNazwa = "";
            
            logi += "Wygenerowano nową nazwę: " + nowaNazwa + Environment.NewLine;
            return nowaNazwa;
        }

        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        /// <summary>Pobieranie tagów z obiektu tagi i zapisywanie w obiekcie dane</summary>
        private void pobierzTagi()
        {
            
        }

        #endregion

        #region Niezaimplementowane 
        /// <summary>Tworzy od nowa tagi (np. po zmianie nazwy, w konstruktorze).
        /// Jeszcze nie zaimplementowane.</summary>
        protected override void resetujTagi()
        {
            
        }


        public override string sciezka_katalogu_z_pol(string[] kategorie, bool duplikat = false)
        {
            throw new NotImplementedException();
        }

        protected override bool porownaj(Plik plik2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
