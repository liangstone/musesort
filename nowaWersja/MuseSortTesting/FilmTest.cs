using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;

namespace MuseSortTesting
{
    [TestClass]
    public class FilmTest
    {

        private readonly string _sciezka = "filmy";

        public FilmTest()
        {
            _sciezka = Util.SetAbsoluteDirectoryPath(_sciezka);
        }

        [TestMethod]
        public void TestKonstruktor()
        {
            new Film(_sciezka + @"\Film1.mov");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestKonstruktorNieprawidlowaSciezka()
        {
            new Film("Nieprawidlowa sciezka");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestKonstruktorNieprawidlowaSciezkaZrodlowa()
        {
            new Film(_sciezka, "Nieprawidlowa");
        }
    }
}
