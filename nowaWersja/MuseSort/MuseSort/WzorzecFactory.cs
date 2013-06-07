using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MuseSort
{

    class WzorzecFactory
    {
        #region Metody publiczne

        /// <summary>Podając odpowiedni słownik definiujący buildera dla Utworów/Filmów/czegokolwiek. Użyj jednego z pól statycznych.</summary>
        /// <param name="slownikRegexow">Klucze to nazwy tagów, wartości regexy dla tych tagów.</param>
        public WzorzecFactory(Dictionary<string, string> slownikRegexow)
        {
            _slownikRegexow = slownikRegexow;
            FactoryRegex = BuildFactoryRegex();
        }

        public static readonly Dictionary<string, string> SlownikRegexowDlaUtowrow;
        public static readonly Dictionary<string, string> SlownikRegexowDlaFilmow;

        /// <summary>Konstruktor statyczny buduje standardowe słowniki</summary>
        static WzorzecFactory()
        {
            SlownikRegexowDlaFilmow = new Dictionary<string, string>
                {
                    {"source",      ".*?"}, //Zawartośc będzie ignorowana - folder nadrzędny 
                    {"<tytul>",     @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+"},
                    {"<dyrektor>",  @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+"},
                    {"<gatunek>",   @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+"},
                    {"<rok>",       @"[\d]{4}"}
                };
            SlownikRegexowDlaUtowrow = new Dictionary<string, string>
                {
                    {"source",      ".*?"}, //Zawartośc będzie ignorowana - folder nadrzędny 
                    {"rok",         @"[\d]{4}"},
                    {"numer",       @"[\d]+"}
                };
            foreach (var tagSlowny in new[] {"tytul", "wykonawca", "album"})
            {
                SlownikRegexowDlaUtowrow.Add(tagSlowny, @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+");
            }
        }

        /// <summary>Metoda fabryczna. Przyjmuje wzorzec w którym nazwy tagów są otoczone nawiasami ostrymi i tworzy na jego podstawie Wzorzec 
        /// zawierający regex z nazwanymi grupami.</summary>
        /// <exception cref="ArgumentException">Rzucane jeśli nie znaleziono tagów.</exception>
        /// <exception cref="ArgumentNullException">Rzucane jeśli przkazany został null string.</exception>
        /// <remarks>
        /// Algorytm jest prosty - oddzielamy (regexem, a jakże!) występujące na zmianę tagi i tekst poza nimi,
        /// to drugie dodajemy do regexa wprost, escape'ując znaki,
        /// tagi zastępujemy odpowiadającymi im regexami ze słownika.
        /// </remarks>
        public Wzorzec GetWzorzec(string wzorzecWejsciowy)
        {
            if (wzorzecWejsciowy == null)
                throw new ArgumentNullException();

            //Wzorzec wyjściowy budujemy używając StringBuildera z buforem 2*długość wzorca wejściowego - powinno starczyć.
            var wzorzecWyjsciowy = new StringBuilder(wzorzecWejsciowy.Length*2);

            wzorzecWyjsciowy.Append("^"); //Zaczynamy znakiem początku łańcucha.

            var dopasowaneGrupy = Dopasuj(wzorzecWejsciowy);
            var liczbaTagow = LiczbaTagow(dopasowaneGrupy);//Regex łapie nam n tagów i n+1 nietagów, zaczynając od nietaga. 
            if(liczbaTagow==0)
                throw new ArgumentException(wzorzecWejsciowy + " nie zawiera tagów.");

            for (var i = 0; i < liczbaTagow; i++) 
            {
                //Odpowiednie metody wyciągają i obrabiają dane żeby były gotowe do wstawienia.
                wzorzecWyjsciowy.Append(TekstPrzedItymTagiem(dopasowaneGrupy, i));
                wzorzecWyjsciowy.Append(RegexITegoTaga(dopasowaneGrupy, i));
            }
            wzorzecWyjsciowy.Append(TekstPoOstatnimTagu(dopasowaneGrupy));

            wzorzecWyjsciowy.Append("$"); //Zamykamy znakiem końca łańcucha.

            return new Wzorzec(wzorzecWyjsciowy.ToString(), wzorzecWejsciowy);
        }

        #endregion

        #region Metody pomocnicze, elementy prywatne

        /// <summary>Podany w konstruktorze słownik mapujący tagi do regexów.</summary>
        private readonly Dictionary<string, string> _slownikRegexow;

        /// <summary>Służy do parsowania stringa, na podstawie którego tworzymy regex nowego Wzorca.</summary>
        internal readonly Regex FactoryRegex;

        /// <summary>Służy do wygenerowania regexa fabrycznego definującego jak wyglądają wzorce.
        /// W typ przypadku: tagi w nawiasach ostrych otoczone jakimiś dowolnymi innymi znakami.</summary>
        private Regex BuildFactoryRegex()
        {
                                                                        //Przygotowujemy listę tagów do wsadzenia w regexa
            var tagi = string.Join("|",                                 //Oddzielone znakiem alternatywy
                                   _slownikRegexow.Keys.Select(    
                                       tag => string.Format("<{0}>",   //Otoczone nawiasami ostrymi
                                                            Regex.Escape(tag))));//I na wszeli wypadek escapowane.

            var wzorzecTagi = string.Format(@"(?'tag'{0})", tagi); //Regex-grupa nazwana łapiąca każdy z tagów
            const string wzorzecNieTagi =   @"(?'nieTag'.*?)";     //Grupa łapiąca resztę

            var wzorzec = string.Format(    @"^(?:{0}{1})+{0}",    //Regex łapiący występujące na przemian tagi i pozostały tekst.
                                            wzorzecNieTagi, wzorzecTagi); 
            return new Regex(wzorzec);
        }

        /// <summary>Zwraca GroupCollection zawierającą wszystkie dane znalezione przez regex fabryki.</summary>
        private GroupCollection Dopasuj(string wzorzec)
        {
            return FactoryRegex.Match(wzorzec).Groups;
        }

        /// <summary>Zwraca liczbę tagów ("nazwa", "wykonawca"...) znajdujących się we wzorcu wejściowym.</summary>
        /// <param name="dopasowaneGrupy">Zwrócone przez metodę Dopasuj.</param>
        private static int LiczbaTagow(GroupCollection dopasowaneGrupy)
        {
            return dopasowaneGrupy["tag"].Captures.Count;
        }

        /// <summary>Zwraca znaki występujące we wzorcu przed i-tym tagiem, escapując znaki specjalne regexów.</summary>
        /// <param name="dopasowaneGrupy">Zwrócone przez metodę Dopasuj.</param>
        /// <param name="i">Numer kolejnego taga.</param>
        private static string TekstPrzedItymTagiem(GroupCollection dopasowaneGrupy, int i)
        {
            var tekstPrzedItymTagiem = dopasowaneGrupy["nieTag"].Captures[i].Value;
                //Captures zawierają po kolei wszystkie stringi, jakie regex dopasował do danej grupy.

            tekstPrzedItymTagiem = Regex.Escape(tekstPrzedItymTagiem);
                //Escapowanie jest ważne - przecież często numer kończy się kropką, a w ścieżkach naturalnie będą backslashe.

            return tekstPrzedItymTagiem;
        }

        /// <summary>Zwraca regex-grupę nazwaną która będzie identyfikowała i-ty tag w stringach analizowanych przez budowany Wzorzec.</summary>
        /// <param name="dopasowaneGrupy">Zwrócone przez metodę Dopasuj.</param>
        /// <param name="i">Numer kolejnego taga.</param>
        private string RegexITegoTaga(GroupCollection dopasowaneGrupy, int i)
        {
            var nazwaGrupy = dopasowaneGrupy["tag"].Captures[i].Value;
                //Captures zawierają po kolei wszystkie stringi, jakie regex dopasował do danej grupy.

            nazwaGrupy = nazwaGrupy.Substring(1, nazwaGrupy.Length - 2); //Obcinamy nawiasy ostre z końców.
            var regexITegoTaga = string.Format("(?'{0}'{1})", //Schemat grupy nazwanej: (?'nazwa'regex)
                                               nazwaGrupy, _slownikRegexow[nazwaGrupy]);
            return regexITegoTaga;
        }


        /// <summary>Zwraca znaki występujące we wzorcu po ostatnim tagu, escapując znaki specjalne regexów.</summary>
        /// <param name="dopasowaneGrupy">Zwrócone przez metodę Dopasuj.</param>
        private static string TekstPoOstatnimTagu(GroupCollection dopasowaneGrupy)
        {
            //W regexach ostatnia złapana wartość jest w Value grupy - jeśli twoja grupa się nie powtarza używamy po prostu tego do wyciągania wartości.
            return Regex.Escape(dopasowaneGrupy["nieTag"].Value);
        }

        #endregion

    }

}
