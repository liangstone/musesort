using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;

namespace MuseSortTesting
{
    [TestClass]
    public class UtworTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void KonstruktorNieprawidlowaSciezka()
        {
            new Utwor("Nieprawidłowa ścieżka");
        }

        [TestMethod]
        public void PobierzDaneZeSciezki()
        {
            const string wzorzecTestowy = @"<source>\<wykonawca>\<album>\<tytul>";
            UstawieniaProgramu.getInstance().wczytajUstawienia();
            var wzorce = Utwor.wzorceSciezki;
            try
            {
                Utwor.wzorceSciezki.Clear();
                Utwor.dodajWzorzecSciezki(wzorzecTestowy);
                var utwor =
                    new Utwor(SetAbsolutePath(@"muzyka\BlindGuardian\ANightAtTheOpera\") +
                              "07 Kristin Chenoweth-Popular.mp3")
                        {
                            dane =
                                {
                                    numer = 0,
                                    wykonawca = new[] {string.Empty},
                                    tytul = string.Empty,
                                    album = string.Empty
                                }
                        };
                utwor.pobierzTagiZeSciezki();

                Assert.AreEqual("ANightAtTheOpera", utwor.dane.album, "Album się nie zgadza.");
                Assert.AreEqual("BlindGuardian", utwor.dane.wykonawca[0], "Wykonawca się nie zgadza.");
            }
            finally
            {
                Utwor.wzorceSciezki = wzorce;
                UstawieniaProgramu.getInstance().zapiszUstawienia();
            }
        }

        [TestMethod]
        public void PobierzDaneZNazwy()
        {
            const string wzorzecTestowy = "<numer> <wykonawca>-<tytul>";
            UstawieniaProgramu.getInstance().wczytajUstawienia();
            var wzorce = Utwor.wzorceNazwy;
            try
            {
                Utwor.wzorceNazwy.Clear();
                Utwor.dodajWzorzecNazwy(wzorzecTestowy);
                var utwor =
                    new Utwor(SetAbsolutePath(@"muzyka\BlindGuardian\ANightAtTheOpera\") +
                              "07 Kristin Chenoweth-Popular.mp3")
                        {
                            dane = {numer = 0, wykonawca = new[] {string.Empty}, tytul = string.Empty}
                        };
                utwor.pobierzTagiZNazwy();
                Assert.AreEqual("Popular", utwor.dane.tytul, "Nie zgadza się tytuł.");
                Assert.AreEqual((uint)7, utwor.dane.numer, "Nie zgadza się numer.");
                Assert.AreEqual("Kristin Chenoweth", utwor.dane.wykonawca[0], "Nie zgadza się wykonawca.");
            }
            finally
            {
                Utwor.wzorceSciezki = wzorce;
                UstawieniaProgramu.getInstance().zapiszUstawienia();
            }
        }

        private static string SetAbsolutePath(string sciezka)
        {
            while (!Directory.Exists(sciezka))
                sciezka = @"..\" + sciezka;
            sciezka = Path.GetFullPath(sciezka);
            return sciezka;
        }
    }
}
