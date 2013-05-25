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
            var utwor =
                new Utwor(SetAbsolutePath(@"muzyka\BlindGuardian\ANightAtTheOpera\") +
                          "07 Kristin Chenoweth-Popular.mp3");
            utwor.pobierzTagiZeSciezki();
            Assert.AreEqual("ANightAtTheOpera", utwor.dane.album, "Album się nie zgadza.");
            Assert.AreEqual("BlindGuardian", utwor.dane.wykonawca[0], "Wykonawca się nie zgadza.");
        }

        [TestInitialize]
        public void SetUp()
        {
            UstawieniaProgramu.getInstance().wczytajUstawienia();
        }

        [TestMethod]
        public void PobierzDaneZNazwy()
        {
            var utwor =
                new Utwor(SetAbsolutePath(@"muzyka\BlindGuardian\ANightAtTheOpera\") +
                          "07 Kristin Chenoweth-Popular.mp3")
                {
                    dane = {numer = 0, wykonawca = new[] {string.Empty}, tytul = string.Empty}
                };
            utwor.pobierzTagiZNazwy();
            Assert.AreEqual("Popular", utwor.dane.tytul, "Nie zgadza się tytuł.");
            Assert.AreEqual(7, utwor.dane.numer, "Nie zgadza się numer.");
            Assert.AreEqual("Kristin Chenoweth", utwor.dane.wykonawca[0], "Nie zgadza się wykonawca.");
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
