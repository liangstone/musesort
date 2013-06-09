using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;
using MuseSort.Fakes;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Fakes;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;


namespace MuseSortTesting
{
    [TestClass]
    public class TestFolder
    {
        private readonly string _sciezkaMuzyka = @"muzyka";
        private readonly string _sciezkaFilmy = @"filmy";

        public TestFolder()
        {
            _sciezkaMuzyka = SetAbsolutePath(_sciezkaMuzyka);
            _sciezkaFilmy = SetAbsolutePath(_sciezkaFilmy);
        }
        [TestMethod]
        public void KonstruktorTest()
        {
            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;

                ShimDirectory.ExistsString = path => path == _sciezkaMuzyka;

                var folder = new Folder(_sciezkaMuzyka);
                Assert.AreEqual(_sciezkaMuzyka, folder.Sciezka);
                Assert.AreEqual("", folder.logi);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void KonstruktorNieprawidlowaSciezkaTest()
        {
            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;

                ShimDirectory.ExistsString = path => path == _sciezkaMuzyka;

                new Folder("Nieprawidłowa ścieżka");
            }
        }

        [TestMethod]
        public void AnalizujTest()
        {
            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;

                ShimFile.ExistsString = path => path == _sciezkaMuzyka;

                var folder = new Folder(_sciezkaMuzyka);
                Assert.IsFalse(folder.analizuj());

                ShimFolderXML.AllInstances.analizuj = @this => true;
                Assert.IsTrue(folder.analizuj());
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
