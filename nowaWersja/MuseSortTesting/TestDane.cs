using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuseSortTesting
{
    [TestClass]
    public class TestDane
    {
        [TestMethod]
        public void CzyDaneWypelnioneTest()
        {
            var dane = new MuseSort.DaneUtworu();

            Assert.IsFalse(dane.czyDaneWypelnione());

            dane.wykonawca = new[]{"Wykonawca"};
            dane.tytul = "Tytuł";
            dane.album = "Album";

            Assert.IsTrue(dane.czyDaneWypelnione());
        }
    }
}
