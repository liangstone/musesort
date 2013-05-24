using System;
using System.IO;
using System.Linq;

namespace MuseSort
{
    public partial class Film : Plik
    {
        public DaneFilmu dane;
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
            Sciezka = SciezkaZrodlowa = path;
            Nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dane = new DaneFilmu();
            resetujTagi();
            pobierzTagi();
        }

        //Konstruktor dla pliku, który został skopiowany w ramach działania programu
        public Film(String path, String source)
        {
            SciezkaZrodlowa = source;
            Sciezka = path;
            Nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
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
                if (wzor.czyPasuje(Nazwa))
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
            string sciezka_katalogu;
            if (duplikat)
                sciezka_katalogu = @"Musesort\Filmy\Zduplikowane\Posegregowane\";
            else
                sciezka_katalogu = @"Musesort\Filmy\Posegregowane\";

            string sciezkaZDanych = dane.sciezkaKataloguZPol(kategorie);

            if (sciezkaZDanych.Equals("")) //przenieś do "Nieprzydzielone
            {
                if (duplikat)
                    sciezka_katalogu = @"Musesort\Filmy\Zduplikowane\Posegregowane\Nieprzydzielone";
                else
                    sciezka_katalogu = @"Musesort\Filmy\Posegregowane\Nieprzydzielone";
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

        protected override bool porownaj(Plik plik2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
