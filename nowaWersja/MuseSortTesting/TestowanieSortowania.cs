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
        #region Pola

        private readonly string _sciezkaMuzyka = @"muzyka";
        private readonly string _sciezkaFilmy = @"filmy";

        private static readonly Dictionary<string, string>[] DaneFilmow = new[]
            {
                new Dictionary<string, string>
                    {
                        {"tytul", "Akira"},
                        {"dyrektor", "Katsuhiro Otomo"},
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix"},
                        {"dyrektor", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix: Reloaded"},
                        {"dyrektor", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Matrix: Revolutions"},
                        {"dyrektor", "Wachowski Brothers"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "The Great Gatsby"},
                        {"dyrektor", "Baz Luhrmann"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Iron Man 3"},
                        {"dyrektor", "Shane Black"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Evil Dead"},
                        {"dyrektor", "Sam Raimi"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Oz the Great and Powerful"},
                        {"dyrektor", "Sam Raimi"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "Warm Bodies"},
                        {"dyrektor", "Jonathan Levine"}
                    },
                new Dictionary<string, string>
                    {
                        {"tytul", "A Good Day to Die Hard"},
                        {"dyrektor", "John Moore"}
                    }
            };

        #endregion


        public TestowanieSortowania()
        {
            _sciezkaMuzyka = SetAbsolutePath(_sciezkaMuzyka);
            _sciezkaFilmy = SetAbsolutePath(_sciezkaFilmy);
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
            if (!UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains("mov"))
                UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add("mov");
            if (Directory.Exists(_sciezkaFilmy + "\\Musesort"))
                Directory.Delete(_sciezkaFilmy + "\\Musesort", true);

            var inList = Folder.znajdz_wspierane_pliki(_sciezkaFilmy, UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            var expectedInList = new List<string>();
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
            Assert.IsTrue(inList.Count == expectedInList.Count && inList.TrueForAll(expectedInList.Contains),
                "Błąd przygotowania testu: zawartość folderu testowego nie zgadza się z przewidywaną.");

            using (ShimsContext.Create())
            {
                ShimFolderXML.ConstructorString = (@this, path) => { };
                ShimFolderXML.AllInstances.analizuj = @this => false;
                //Dictionary<string, Film> testFiles = new Dictionary<string, Film>();
                IDictionary<string, DaneFilmu> testData = new Dictionary<string, DaneFilmu>();
                //Film testFile;
                var i = 0;
                foreach (var path in inList)
                {
                    //testFile = new Film(path);
                    var tmp = new DaneFilmu (DaneFilmow[i]);
//                    tmp = new DaneFilmu { tytul = dane[i, 0], dyrektorzy = new[] { dane[i, 1] } };
                    //testFile.dane.tytul = dane[i, 0];
                    //testFile.dane.dyrektorzy = new string[]{ dane[i,1], };
                    //testFiles.Add(testFile.Nazwa, testFile);
                    testData.Add(Path.GetFileName(path), tmp);
                    //expectedOutList.Add(sciezkatestowa + '\\' + @"\Musesort\Filmy\Posegregowane\"
                    //    + testFile.dane.dyrektorzy[0] + '\\' + testFile.dane.tytul + '\\' + Path.GetFileName(path)); //Przypominam: schemat to "Dyrektorzy/Tytul"
                    expectedOutList.Add(_sciezkaFilmy + '\\' + @"\Musesort\Filmy\Posegregowane\"
                        + DaneFilmow[i]["dyrektor"] + '\\' + DaneFilmow[i]["tytul"] + '\\' + Path.GetFileName(path));
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
