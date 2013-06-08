using System;
using System.IO;
using System.IO.Fakes;
using System.Text;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;

namespace MuseSortTesting
{
    [TestClass]
    public class PlikTest
    {
        private readonly string _film = @"filmy\Film1.mov";
        private readonly string _muzyka = @"muzyka\remusesort\04. Rape Me.mp3";

        public PlikTest()
        {
            _film = Util.SetAbsoluteFilePath(_film);
            _muzyka = Util.SetAbsoluteFilePath(_muzyka);
            UstawieniaProgramu.getInstance().wczytajUstawienia();
        }

        [TestMethod]
        public void CreateTest()
        {
            var film = Plik.Create(_film);
            Assert.AreEqual(typeof(Film), film.GetType());
            var muzyka = Plik.Create(_muzyka);
            Assert.AreEqual(typeof(Utwor), muzyka.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateArgumentNull()
        {
            Plik.Create(null);
        }

        [TestMethod]
        public void KopiujTest()
        {
            var log = new StringBuilder();
            var docelowy = Util.SetAbsoluteDirectoryPath(@"muzyka\BlindGuardian");
            var nazwa = Path.GetFileName(_muzyka);
            var expected = string.Format("{0} => {1}\\{2}", _muzyka, docelowy, nazwa);
            var plik = Plik.Create(_muzyka);


            using (ShimsContext.Create())
            {
                ShimFile.CopyStringString = (s, s1) => log.Append(s + " => " + s1);
                plik.kopiujPlik(docelowy);
            }
            
            Assert.AreEqual(expected, log.ToString());
        }
    }
}
