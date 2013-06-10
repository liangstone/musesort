using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MuseSort
{
    public partial class Film : Plik
    {
        public DaneFilmu dane;
        //<należy wybrać klasę źródłową> tagi;
        //<należy wybrać klasę źródłową> stareTagi;
        //do ponownego merga
        Vlc.DotNet.Core.Medias.PathMedia dataFile;
        Boolean pobranoZNazwy = false;

        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################

        /// <summary>Tworzy obiekt Utwór odpowiedający danemu plikowi filmowemu.</summary>
        /// <param name="path">Ścieżka pliku.</param>
        /// <exception cref="FileNotFoundException">Rzucane jeśli podany plik nie istnieje</exception>
        public Film(String path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            Sciezka = SciezkaZrodlowa = path;
            dataFile = new Vlc.DotNet.Core.Medias.PathMedia(path);
            Nazwa = Path.GetFileNameWithoutExtension(path);
            dane = new DaneFilmu();
            resetujTagi();
            pobierzTagi();
        }

        /// <summary>Konstruktor dla pliku, który został skopiowany w ramach działania programu</summary>
        /// <param name="path">Ścieżka pliku skopiowanego</param>
        /// <param name="source">Ścieżka pliku oryginalnego</param>
        /// <exception cref="FileNotFoundException">Rzucane jeśli któryś z podanych plików nie istnieje</exception>
        public Film(String path, String source)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            if (!File.Exists(source))
                throw new FileNotFoundException(source);
            SciezkaZrodlowa = source;
            Sciezka = path;
            Nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            dataFile = new Vlc.DotNet.Core.Medias.PathMedia(path);
            dane = new DaneFilmu();
            //tagi = 
            //stareTagi = 
            pobierzTagi();
        }

        
        public override void zapiszTagi()
        {
            //Zapisuje dane z obiektu dane do obiektu tagi
            //Uaktualnia dane w obiekcie stareTagi
            try
            {
                dataFile.Metadatas.Title = dane.tytul;
                dataFile.Metadatas.Description = dane.opis;
                dataFile.Metadatas.Language = dane.jezyk;
                dataFile.Metadatas.Copyright = dane.rezyser;
                dataFile.Metadatas.Artist = dane.aktorzy;
                dataFile.Metadatas.Genre = dane.gatunki;
                dataFile.Metadatas.Save();
                logi += "Zapisano nowe tagi." + Environment.NewLine;
            }
            catch (Exception e)
            {
                logi += "Nastąpił błąd zapisywania tagów: " + e.Message + Environment.NewLine;
                MessageBox.Show("Nastąpił błąd zapisywania tagów: " + e.Message);
            }
            
        }

        //Przywraca do obiektu dane informacje z obiektu stareTagi
        public override void przywrocDomyslneTagi()
        {
            resetujTagi();
            logi += "Anulowano modyfikowanie tagów." + Environment.NewLine;
        }

        public override void pobierzTagiZNazwy()
        {
            var wzorzec = wzorceNazwy.Find(w => w.czyPasuje(Nazwa));
            if (wzorzec == null) return;
            var dopasowanie = wzorzec.Dopasuj(Nazwa);
            dane.ZapiszDopasowaneDane(dopasowanie);
        }

        public override void pobierzTagiZeSciezki()
        {
            var wzorzec = wzorceSciezki.Find(w => w.czyPasuje(SciezkaZrodlowa));
            if (wzorzec == null) return;
            var dopasowanie = wzorzec.Dopasuj(SciezkaZrodlowa);
            dane.ZapiszDopasowaneDane(dopasowanie);
        }

        //Na podstawie danych w obiekcie dane tworzy nową nazwę pliku
        public override String generujNazwePlikuZTagow()
        {
            String nowaNazwa = "";
            
            logi += "Wygenerowano nową nazwę: " + nowaNazwa + Environment.NewLine;
            nowaNazwa = normalizuj(nowaNazwa);
            return nowaNazwa;
        }

        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        /// <summary>Pobieranie tagów z obiektu tagi i zapisywanie w obiekcie dane</summary>
        private void pobierzTagi()
        {
            resetujTagi();
        }

        #endregion

        #region Niezaimplementowane 
        /// <summary>Tworzy od nowa tagi (np. po zmianie nazwy, w konstruktorze).
        /// Jeszcze nie zaimplementowane.</summary>
        protected override void resetujTagi()
        {
            dane.tytul = normalizuj(dataFile.Metadatas.Title);
            dane.opis = normalizuj(dataFile.Metadatas.Description);
            dane.jezyk = normalizuj(dataFile.Metadatas.Language);
            dane.rezyser = normalizuj(dataFile.Metadatas.Copyright);
            dane.aktorzy = normalizuj(dataFile.Metadatas.Artist);
            dane.gatunki = normalizuj(dataFile.Metadatas.Genre);
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

        public override string ToString()
        {
            var stringRepresentation =
                string.Format(
                    "{0}\nTytul: {1}\nJezyk: {2}\nReżyser: {3}\nGatunek: {4}\nAktorzy: {5}\nOpis: {6}",
                    Sciezka, dane.tytul, dane.jezyk, dane.rezyser, dane.gatunki, dane.aktorzy, dane.opis);
            return stringRepresentation;
        }
    }
}
