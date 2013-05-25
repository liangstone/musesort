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
        private string _sciezkaMuzyka = @"muzyka";
        private string _sciezkaFilmy = @"filmy";

        [ClassInitialize]
        public void UstalSciezki()
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

        [TestMethod]
        public void SortujUtworyTest()
        {
            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;
                ShimMessageBox.ShowString = message => DialogResult.OK;


                //const string sciezkaTestowa = @"C:\Users\KrzysztofD\Documents\Visual Studio 2012\Projects\MuseSort\testowanie\muzyka";
                var folder = new Folder(_sciezkaMuzyka);
                var progressBar = new ProgressBar();
                folder.progressBar2 = progressBar;
                folder.ustalSchemat(@"Wykonawca\Album\Piosenki");
                UstawieniaProgramu.getInstance().wczytajUstawienia();
                folder.sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio);
            }
        }

        [TestMethod]
        public void SortujFilmyTest()
        {
            //const string sciezkaTestowa = @"C:\Users\KrzysztofD\Documents\Visual Studio 2012\Projects\MuseSort\testowanie\filmy";
            const int liczbaPlikow = 10;
            const string schemat = "Dyrektorzy\\Tytul";

            UstawieniaProgramu.getInstance().wczytajUstawienia();
            UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add("mov");
            if(Directory.Exists(_sciezkaFilmy + "\\Musesort"))
                Directory.Delete(_sciezkaFilmy + "\\Musesort", true);

            var inList = Folder.znajdz_wspierane_pliki(_sciezkaFilmy, UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            var expectedInList= new List<string>();
            for (var i = 1; i <= liczbaPlikow; i++)
                expectedInList.Add(_sciezkaFilmy + @"\Film" + i + ".mov");
            var expectedOutList = new List<string>();


            inList.Sort();
            expectedInList.Sort();
            Console.WriteLine(@"Znalezione pliki:");
            foreach (string znalezionyPlik in inList)
                Console.WriteLine(znalezionyPlik);
            Console.WriteLine(@"Spodziewane pliki:");
            foreach (var znalezionyPlik in expectedInList)
                Console.WriteLine(znalezionyPlik);
            Assert.IsTrue(inList.Count==expectedInList.Count && inList.TrueForAll(expectedInList.Contains),
                "Błąd przygotowania testu: zawartość folderu testowego nie zgadza się z przewidywaną." );

            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;
                //Dictionary<string, Film> testFiles = new Dictionary<string, Film>();
                IDictionary<string, DaneFilmu> testData = new Dictionary<string, DaneFilmu>();
                //Film testFile;
                var dane = new[,]
                {
                    // tytuł, dyrektor
                    {"Akira","Katsuhiro Otomo"},
                    {"Matrix","Wachowski Brothers"},
                    {"Matrix: Reloaded","Wachowski Brothers"},
                    {"Matrix: Revolutions","Wachowski Brothers"},
                    {"The Great Gatsby","Baz Luhrmann"},
                    {"Iron Man 3","Shane Black"},
                    {"Evil Dead","Sam Raimi"},
                    {"Oz the Great and Powerful","Sam Raimi"},
                    {"Warm Bodies","Jonathan Levine"},
                    {"A Good Day to Die Hard","John Moore"},
                };
                var i = 0;
                foreach(var path in inList)
                {
                    //testFile = new Film(path);
                    var tmp = new DaneFilmu {tytul = dane[i, 0], dyrektorzy = new[] {dane[i, 1]}};
                    //testFile.dane.tytul = dane[i, 0];
                    //testFile.dane.dyrektorzy = new string[]{ dane[i,1], };
                    //testFiles.Add(testFile.Nazwa, testFile);
                    testData.Add(Path.GetFileName(path), tmp);
                    //expectedOutList.Add(sciezkatestowa + '\\' + @"\Musesort\Filmy\Posegregowane\"
                    //    + testFile.dane.dyrektorzy[0] + '\\' + testFile.dane.tytul + '\\' + Path.GetFileName(path)); //Przypominam: schemat to "Dyrektorzy/Tytul"
                    expectedOutList.Add(_sciezkaFilmy + '\\' + @"\Musesort\Filmy\Posegregowane\"
                        + tmp.dyrektorzy[0] + '\\' + tmp.tytul + '\\' + Path.GetFileName(path));
                    i++;
                }

                //Kiedy wywołany zostanie Create w sortowaniu, zwróć przygotowany wcześniej plik.

                Func<string, Plik> createPlik = path => 
                {
                    var wynik = new Film(path);
                    wynik.dane = testData[wynik.Nazwa];
                    return wynik;
                };
                //ShimPlik.CreateString = (path) => testFiles[Path.GetFileNameWithoutExtension(path)];
                //ShimPlik.CreateStringString = (path, path2) => testFiles[Path.GetFileNameWithoutExtension(path)];
                ShimPlik.CreateString = path => createPlik(path);
                ShimPlik.CreateStringString = (path1, path2) => createPlik(path1);
                //ShimPlik.AllInstances.kopiujPlikString = (@this, path) => { @this.sciezka = path};
                ShimMessageBox.ShowString = (message) => DialogResult.OK;

                var testFolder = new Folder(_sciezkaFilmy);
                var progressBar = new ProgressBar();
                testFolder.progressBar2 = progressBar;
                testFolder.ustalSchemat(schemat);
                testFolder.sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            }

            var outList = Folder.znajdz_wspierane_pliki(_sciezkaFilmy + "\\Musesort", UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);

            outList.Sort();
            expectedOutList.Sort();

            Console.WriteLine(@"Posortowane pliki:");
            foreach (string znalezionyPlik in outList)
                Console.WriteLine(znalezionyPlik);
            Console.WriteLine(@"Spodziewane pliki:");
            foreach (string znalezionyPlik in expectedOutList)
                Console.WriteLine(znalezionyPlik);

            Assert.IsTrue(inList.Count == expectedOutList.Count && outList.TrueForAll(expectedInList.Contains),
                "Lista posortowanych plików nie zgadza się z przewidywaną: zawartość folderu testowego nie zgadza się z przewidywaną.");
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
