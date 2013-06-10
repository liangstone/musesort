using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace MuseSort
{
    public abstract class Plik
    {
        //do ponownego merga
        #region Pola i properties

        String sciezka = "";

        public String Sciezka
        {
            get { return sciezka; }
            protected set { sciezka = value; }
        }

        String sciezkaZrodlowa = "";

        public String SciezkaZrodlowa
        {
            get { return sciezkaZrodlowa; }
            protected set { sciezkaZrodlowa = value; }
        }

        String nazwa = "";

        public String Nazwa
        {
            get { return nazwa; }
            protected set { nazwa = value; }
        }

        public String logi = "";
        #endregion


        #region Metody publiczne

        ///<summary>Kopiuje plik do nowej lokalizacji i uaktualnia zmienną sciezka.</summary>
        ///<param name="nowyFolder">Ścieżka folderu, do którego plik ma być skopiowany.</param>
        public void kopiujPlik(String nowyFolder)
        {
            String nowaSciezka = Path.Combine(nowyFolder, nazwa + Path.GetExtension(Sciezka));
            System.IO.File.Copy(Sciezka, nowaSciezka);
            logi += "Wykonano kopię pliku do folderu: " + nowyFolder + Environment.NewLine;
        }

        /// <summary>Przenosi plik do podanego folderu.</summary>
        /// <param name="nowyFolder">Folder docelowy.</param>
        public void przeniesPlik(string nowyFolder)
        {
            String nowaSciezka = Path.Combine(nowyFolder, nazwa + Path.GetExtension(Sciezka));
            System.IO.File.Move(Sciezka, nowaSciezka);
            Sciezka = nowaSciezka;
            logi += "Przeniesiono plik " + nazwa + Path.GetExtension(Sciezka) + " do folderu: " + nowyFolder + Environment.NewLine;
        }

        /// <summary>Zmienia nazwę pliku i zmienną nazwa.</summary>
        /// <param name="nowaNazwa">Nowa nazwa pliku (bez rozszerzenia!)</param>
        public void zmienNazwePliku(String nowaNazwa)
        {
            nowaNazwa = usunZnakiSpecjalne(nowaNazwa);
            String nowaSciezka = System.IO.Path.GetDirectoryName(Sciezka) + "\\" + nowaNazwa + "." + System.IO.Path.GetExtension(Sciezka);
            System.IO.File.Move(Sciezka, nowaSciezka);
            logi += "Zmieniono nazwę pliku. Stara nazwa: " + nazwa + " Nowa nazwa: " + nowaNazwa + Environment.NewLine;
            nazwa = nowaNazwa;
            Sciezka = nowaSciezka;
            resetujTagi();
        }
        
        public static bool porownajJakosc(Plik plik1, Plik plik2)
        {
            if (plik1.GetType() != plik2.GetType())
                throw new ArgumentException("Porównujesz pliki \n" + plik1.Sciezka + " oraz \n" + plik2.Sciezka 
                    + "\nktóre są różnych typów! Zastanów się jak udało mieć między nimi kolizję.");
            return plik1.porownaj(plik2);
        }

        /// <summary>Tworzy nową instancję Pliku.</summary>
        /// <param name="sciezka">Ścieżka do pliku</param>
        /// <exception cref="ArgumentNullException">Jeśli podano null jako argument</exception>
        public static Plik Create(string sciezka)
        {
            if(sciezka==null)
                throw new ArgumentNullException();
            Plik wynik = null;
            string rozszerzenie = Path.GetExtension(sciezka).Substring(1);


            if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Contains(rozszerzenie))
                wynik = new Utwor(sciezka);

            else if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains(rozszerzenie))
                wynik = new Film(sciezka);

            return wynik;
        }

        /// <summary>Tworzy nową instancję Pliku.</summary>
        /// <param name="sciezka"></param>
        /// <returns></returns>
        public static Plik Create(string sciezka, string source)
        {
            Plik wynik = null;
            string rozszerzenie = Path.GetExtension(sciezka).Substring(1);


            if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Contains(rozszerzenie))
                wynik = new Utwor(sciezka,source);

            else if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains(rozszerzenie))
                wynik = new Film(sciezka,source);

            return wynik;
        }

        #endregion

        #region Metody prywatne i protected
        //Usuwanie znaków \/:*?<>|" z nazwy w celu przygotowania prawidłowej nazwy pliku
        //Wywoływane na potrzeby metod: zmienNazwePliku oraz generujNazwePlikowZTagow
        protected String usunZnakiSpecjalne(String nazwa)
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
        protected String normalizujNazwe(String nazwa)
        {
            String wynik = nazwa.ToUpper();
            wynik = wynik[0] + wynik.Substring(1).ToLower();
            return wynik;
        }

        #endregion

        #region Deklaracje metod abstrakcyjnych
        public abstract string generujNazwePlikuZTagow();
        public abstract void pobierzTagiZNazwy();
        public abstract void pobierzTagiZeSciezki();
        public abstract void przywrocDomyslneTagi();
        public abstract void zapiszTagi();
        protected abstract void resetujTagi();
        public abstract string sciezka_katalogu_z_pol(string[] kategorie, bool duplikat = false);
        protected abstract bool porownaj(Plik plik2);
        #endregion

        public static String Normalizuj(String doNormalizacji)
        {
            if (string.IsNullOrEmpty(doNormalizacji))
                return string.Empty;
            var wynik = Regex.Replace(doNormalizacji, @"[_\.\+]", " "); //Zamieniamy znaki specjalne _ . i + na spacje
            wynik = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(wynik); //Wszystki pierwsze litery na duże, 
            return wynik;
        }

        public static string[] Normalizuj(string[] doNormalizacji)
        {
            if (doNormalizacji == null || doNormalizacji.Length == 0)
                return new[] {""};
            var wynik = new string[doNormalizacji.Length];
            for (var i = 0; i < wynik.Length; i++)
            {
                wynik[i] = Normalizuj(doNormalizacji[i]);
            }
            return wynik;
        }
    }
}
