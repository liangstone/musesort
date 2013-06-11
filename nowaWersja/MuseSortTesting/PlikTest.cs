using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Fakes;
using System.Linq;
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

        [TestMethod]
        public void PrzeniesTest()
        {
            var log = new StringBuilder();
            var docelowy = Util.SetAbsoluteDirectoryPath(@"muzyka\BlindGuardian");
            var nazwa = Path.GetFileName(_muzyka);
            var expected = string.Format("{0} => {1}\\{2}", _muzyka, docelowy, nazwa);
            var plik = Plik.Create(_muzyka);


            using (ShimsContext.Create())
            {
                ShimFile.MoveStringString = (s, s1) => log.Append(s + " => " + s1);
                plik.przeniesPlik(docelowy);
            }

            Assert.AreEqual(expected, log.ToString());
            Assert.AreEqual(docelowy+"\\"+nazwa, plik.Sciezka);
        }

        [TestMethod]
        public void NormalizujTest()
        {
            Assert.AreEqual(string.Empty, Plik.Normalizuj((string) null));
            var stringi = new[]
                {
                    string.Empty,
                    "lowercase",
                    "kilka slow",
                    "rAndOm CapS",
                    "ALL CAPS"
                };
            foreach (var doNormalizacji in stringi)
            {
                Assert.AreEqual(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(doNormalizacji), Plik.Normalizuj(doNormalizacji));
            }
            var emptyArray = new[] {""};
//            Assert.AreEqual(emptyArray, Plik.Normalizuj((string[])null));
            Assert.IsTrue(ArrayEqual(emptyArray, Plik.Normalizuj((string[])null)), "Po podaniu nulla.");
//            Assert.AreEqual(emptyArray, Plik.Normalizuj(new string[0]));
            Assert.IsTrue(ArrayEqual(emptyArray, Plik.Normalizuj(new string[0])), "Po podaniu pustego.");

            var stringiNormalizowane = Plik.Normalizuj(stringi);
            for (int i = 0; i < stringi.Length; i++)
            {
                Assert.AreEqual(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(stringi[i]), stringiNormalizowane[i]);
            }
        }

        private static bool ArrayEqual<T>(ICollection<T> arr1, IList<T> arr2)
        {
            return (arr1 != null || arr2 == null) && (arr1 == null || arr2 != null) &&
                   (arr1 == null || arr1.Count == arr2.Count && !arr1.Where((t, i) => !t.Equals(arr2[i])).Any());
        }
    }
}
