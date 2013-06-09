using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;
using MuseSort.Fakes;

namespace MuseSortTesting
{
    [TestClass]
    public class TestowanieSortowania
    {
        private readonly string _sciezkaMuzyka = @"muzyka";
        private readonly string _sciezkaFilmy = @"filmy";

        #region WzorceSortowaniaUtowrow

        private static readonly string[] WzorceSortowaniaUtowrow = new[]
            {
                @"Wykonawca\Album\Piosenki",
                @"Wykonawca\Rok\Album\Piosenki",
                @"Gatunek\Wykonawca\Album\Piosenki",
                @"Gatunek\Wykonawca\Piosenki",
                @"Rok\Gatunek\Wykonawca\Album\Piosenki",
                @"Rok\Wykonawca\Album\Piosenki",
                @"Piosenki\Alfabetycznie",
                @"Piosenki\Wykonawca"
            };

        #endregion


        #region DaneFilmow

        private static readonly Dictionary<string, string>[] DaneFilmow = new[]
            {
                new Dictionary<string, string>
                    {
                        {"tytul", "Akira"},
                        {"rezyser", "Katsuhiro Otomo"},
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix"},
                        {"rezyser", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix Reloaded"},
                        {"rezyser", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix Revolutions"},
                        {"rezyser", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "The Great Gatsby"},
                        {"rezyser", "Baz Luhrmann"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Iron Man 3"},
                        {"rezyser", "Shane Black"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Evil Dead"},
                        {"rezyser", "Sam Raimi"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Oz the Great and Powerful"},
                        {"rezyser", "Sam Raimi"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Warm Bodies"},
                        {"rezyser", "Jonathan Levine"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "A Good Day to Die Hard"},
                        {"rezyser", "John Moore"}
                    }
            };

        #endregion

        public TestowanieSortowania()
        {
            _sciezkaMuzyka = Util.SetAbsoluteDirectoryPath(_sciezkaMuzyka);
            _sciezkaFilmy = Util.SetAbsoluteDirectoryPath(_sciezkaFilmy);
        }

        #region Sortowanie muzyki

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

        #endregion

        #region Sortowanie filmow

        [TestMethod]
        public void SortujFilmyTest1()
        {
            //-------------------------------------- Setup --------------------------------------------
            var sciezkaTestowa = _sciezkaFilmy;
            const string schemat = "Rezyser\\Tytul";

            UstawieniaProgramu.getInstance().wczytajUstawienia();
            if (!UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains("mov"))
                UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add("mov");
            if (Directory.Exists(sciezkaTestowa + "\\Musesort"))
                Directory.Delete(sciezkaTestowa + "\\Musesort", true);

            //-------------------------------------- Lists --------------------------------------------
            var inList = Folder.znajdz_wspierane_pliki(sciezkaTestowa,
                                                       UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            var expectedOutList = new List<string>();
            var expectedInList = new List<string>();
            for (var i = 1; i <= 10; i++)
                expectedInList.Add(sciezkaTestowa + @"\Film" + i + ".mov");
            CheckInList(inList, expectedInList);
            var testData = FilmTestData(inList, expectedOutList);

            //------------------------------------------------------------------------------------------

            using (ShimsContext.Create())
            {
                CreateFilmShims1(testData);
                CreateTestFolder(sciezkaTestowa, schemat).sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            }

            CheckOutput(sciezkaTestowa, expectedOutList);
        }

        private static void CheckOutput(string sciezkaTestowa, List<string> expectedOutList)
        {
            var outList = Folder.znajdz_wspierane_pliki(sciezkaTestowa + "\\Musesort",
                                                        UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);

            outList.Sort();
            expectedOutList.Sort();

            Console.WriteLine(@"Posortowane pliki:");
            foreach (string znalezionyPlik in outList)
                Console.WriteLine(znalezionyPlik);
            Console.WriteLine(@"Spodziewane pliki:");
            foreach (string znalezionyPlik in expectedOutList)
                Console.WriteLine(znalezionyPlik);

            Assert.IsTrue(outList.Count == expectedOutList.Count,
                          "Lista posortowanych plików nie zgadza się z przewidywaną.");
            for (int i = 0; i < expectedOutList.Count; i++)
            {
                Assert.AreEqual(expectedOutList[i], outList[i], "Lista posortowanych plików nie zgadza się z przewidywaną.");
            }
        }

        private static Folder CreateTestFolder(string sciezkaTestowa, string schemat)
        {
            var testFolder = new Folder(sciezkaTestowa);
            var progressBar = new ProgressBar();
            testFolder.progressBar2 = progressBar;
            testFolder.ustalSchemat(schemat);
            return testFolder;
        }

        private static void CheckInList(List<string> inList, List<string> expectedInList)
        {
            inList.Sort();
            expectedInList.Sort();
            Console.WriteLine(@"Znalezione pliki:");
            foreach (string znalezionyPlik in inList)
                Console.WriteLine(znalezionyPlik);
            Console.WriteLine(@"Spodziewane pliki:");
            foreach (var znalezionyPlik in expectedInList)
                Console.WriteLine(znalezionyPlik);
            Assert.IsTrue(inList.Count == expectedInList.Count && inList.TrueForAll(expectedInList.Contains),
                          "Błąd przygotowania testu: zawartość folderu testowego nie zgadza się z przewidywaną.");
        }

        private IDictionary<string, DaneFilmu> FilmTestData(List<string> inList, List<string> expectedOutList)
        {
            IDictionary<string, DaneFilmu> testData = new Dictionary<string, DaneFilmu>();
            var i = 0;
            foreach (var path in inList)
            {
                var tmp = new DaneFilmu(DaneFilmow[i]);
                testData.Add(Path.GetFileNameWithoutExtension(path), tmp);
                expectedOutList.Add(string.Format("{0}\\Musesort\\Filmy\\Posegregowane\\{1}\\{2}\\{3}",
                                                  _sciezkaFilmy, DaneFilmow[i]["rezyser"], DaneFilmow[i]["tytul"],
                                                  Path.GetFileName(path)));
                i++;
            }
            return testData;
        }

        private static void CreateFilmShims1(IDictionary<string, DaneFilmu> testData)
        {
            ShimFolderXML.ConstructorString = (@this, path) => { };
            ShimFolderXML.AllInstances.analizuj = @this => false;
            Func<string, Plik> createPlik = path =>
                {
                    var wynik = new Film(path);
                    wynik.dane = testData[wynik.Nazwa];
                    return wynik;
                };
            ShimPlik.CreateString = path => createPlik(path);
            ShimPlik.CreateStringString = (path1, path2) => createPlik(path1);
            ShimMessageBox.ShowString = (message) => DialogResult.OK;
        }

        #endregion
    }
}
