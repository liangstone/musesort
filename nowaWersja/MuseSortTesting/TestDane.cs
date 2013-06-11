using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;

namespace MuseSortTesting
{
    [TestClass]
    public class TestDane
    {
        [TestMethod]
        public void CzyDaneWypelnioneTest()
        {
            var dane = new DaneUtworu();

            Assert.IsFalse(dane.czyDaneWypelnione());

            dane.wykonawca = new[]{"Wykonawca"};
            dane.tytul = "Tytuł";
            dane.album = "Album";

            Assert.IsTrue(dane.czyDaneWypelnione());
        }

        [TestMethod]
        public void KonstruktorDaneUtworu()
        {
            var dane = new Dictionary<string, string>
                {
                    {"numer" ,      "1"},
                    { "rok",        "1991" },
                    { "wykonawca",  "Fox" },
                    { "gatunek",    "Grunge" },
                    { "tytul",      "Alla" },
                    { "album",      "Al" }
                };
            var daneUtworu = new DaneUtworu(dane);
            Assert.AreEqual(dane["tytul"], daneUtworu.tytul);
            Assert.AreEqual(dane["wykonawca"], daneUtworu.wykonawca[0]);
            Assert.AreEqual(dane["gatunek"], daneUtworu.gatunek[0]);
            Assert.AreEqual(dane["album"], daneUtworu.album);
            Assert.AreEqual((uint)1, daneUtworu.numer);
            Assert.AreEqual((uint)1991, daneUtworu.rok);
        }
    }
}
