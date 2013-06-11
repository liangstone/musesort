using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;
using MuseSort.Fakes;
using System.Linq;

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
            UstawieniaProgramu.getInstance().wczytajUstawienia();
        }

        #region Sortowanie muzyki

        [TestMethod]
        public void SortujUtworyWszystkieSchematy()
        {
            //-------------------------------------- Setup -------------------------------------------
            /*Wykonawca\Album\Piosenki
            Wykonawca\Rok\Album\Piosenki
            Gatunek\Wykonawca\Album\Piosenki
            Gatunek\Wykonawca\Piosenki
            Rok\Gatunek\Wykonawca\Album\Piosenki
            Rok\Wykonawca\Album\Piosenki
            Piosenki\Alfabetycznie
            Piosenki\Wykonawca*/
            var schematy = new []
                {
                    @"Piosenki\Alfabetycznie",
                    @"Wykonawca\Album\Piosenki",
                    @"Gatunek\Wykonawca\Piosenki",
                    @"Rok\Wykonawca\Album\Piosenki",
                    @"Wykonawca\Rok\Album\Piosenki",
                    @"Gatunek\Wykonawca\Album\Piosenki",
                    @"Rok\Gatunek\Wykonawca\Album\Piosenki",
//                    @"Piosenki\Wykonawca" //Sczególny przypadek - sortowanie ze zmianą nazwy
                };
            var sciezkaTestowa = Path.Combine(_sciezkaMuzyka, "test prosty");

            //-------------------------------------- Lists --------------------------------------------
            var expectedInList = new List<string>
                {
                    "01.QDC - Belief",
                    "02.QDC - Old Diary",
                    "03.QDC - Forgotten Road",
                    "1362338352.foxamoore_one_sleepless_night",
                    "1362775647.foxamoore_children_of_orion"
                };

            var dane = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Belief", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ethnic"}
                        },
                    new DaneUtworu
                        {
                           tytul = "Old Diary",
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ambient"}

                        },
                    new DaneUtworu
                        {
                            tytul = "Forgotten Road", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ambient"}
                        },
                    new DaneUtworu
                        {
                            tytul = "One Sleepless Night", 
                            wykonawca = new[] {"Fox Amoore"},
                            album = "Singles 2013",
                            rok = 2013,
                            gatunek = new[]{ "Soundtrack"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Children of Orion", 
                            wykonawca = new[] {"Fox Amoore"},
                            album = "Utunu And Kikivuli",
                            rok = 2013,
                            gatunek = new[]{ "Soundtrack"}
                        }
                };

            expectedInList = expectedInList.Select(file => Path.Combine(sciezkaTestowa, file+".mp3")).ToList();
            var rozszerzenia = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio;
            

            using (ShimsContext.Create())
            {
                UniversalShims();
                //const string sciezkaTestowa = @"C:\Users\KrzysztofD\Documents\Visual Studio 2012\Projects\MuseSort\testowanie\muzyka";
                foreach (var schemat in schematy)
                {
                    TestSortowania(schemat, sciezkaTestowa, rozszerzenia, expectedInList, dane);
                }
            }
        }

        [TestMethod]
        public void SortujUtworyPobierzTagiZNazwy()
        {
            const string schemat = @"Wykonawca\Tytul\Numer\Piosenki";
            var sciezkaTestowa = Path.Combine(_sciezkaMuzyka, "test tagow z nazwy");
            var expectedInList = new List<string>
                {
                    "01.QDC - Belief",
                    "04 - Muse - Map Of The Problematique",
                    "07 Kristin Chenoweth-Popular"
                };
            expectedInList = expectedInList.Select(file => Path.Combine(sciezkaTestowa, file + ".mp3")).ToList();
            var wzorce = new[]
                {
                    "<numer>.<wykonawca> - <tytul>",
                    "<numer> - <wykonawca> - <tytul>",
                    "<numer> <wykonawca>-<tytul>"
                };
            foreach (var wzorzec in wzorce.Where(wzorzec => Utwor.wzorceNazwy.Find(w => w.wzorzec == wzorzec) == null))
            {
                Utwor.dodajWzorzecNazwy(wzorzec);
            }
            UstawieniaProgramu.getInstance().zapiszUstawienia();
            var dane = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Belief",
                            wykonawca = new[] {"QDC"},
                            numer = 1
                        },
                    new DaneUtworu
                        {
                            tytul = "Map Of The Problematique",
                            wykonawca = new[] {"Muse"},
                            numer = 4
                        },
                    new DaneUtworu
                        {
                            tytul = "Popular",
                            wykonawca = new[] {"Kristin Chenoweth"},
                            numer = 7
                        },
                };
            var rozszerzenia = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio;
            foreach (var utwor in expectedInList.Select(
                sciezka => new Utwor(sciezka) {dane = {wykonawca = new[] {""}, tytul = "", numer = 0}}))
            {
                utwor.zapiszTagi();
            }

            using (ShimsContext.Create())
            {
                UniversalShims();
                TestSortowania(schemat, sciezkaTestowa, rozszerzenia, expectedInList, dane);
            }
        }

        [TestMethod]
        public void SortujUtworyPobierzTagiZeSciezki()
        {

            const string schemat = @"Wykonawca\Rok\Album\Tytul\Piosenki";
            var sciezkaTestowa = Path.Combine(_sciezkaMuzyka, "test tagow ze sciezki");
            var expectedInList = new List<string>
                {
                    @"2003\Ethnic\Łukasz Brzostek (QDC)\Alchemist\_",
                    @"2003\Ambient\Łukasz Brzostek (QDC)\Alchemist\_",
                    @"2013\Soundtrack\Fox Amoore\Singles 2013\_"
                };
            expectedInList = expectedInList.Select(file => Path.Combine(sciezkaTestowa, file + ".mp3")).ToList();
            var wzorce = new[]
                {
                    @"<source>\<rok>\<gatunek>\<wykonawca>\<album>\<ignore>"
                };

            foreach (var wzorzec in wzorce.Where(wzorzec => Utwor.wzorceSciezki.Find(w => w.wzorzec == wzorzec) == null))
            {
                Utwor.dodajWzorzecSciezki(wzorzec);
            }
            UstawieniaProgramu.getInstance().zapiszUstawienia();
            var dane = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Belief", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ethnic"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Old Diary", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ambient"}
                        },
                    new DaneUtworu
                        {
                            tytul = "One Sleepless Night", 
                            wykonawca = new[] {"Fox Amoore"},
                            album = "Singles 2013",
                            rok = 2013,
                            gatunek = new[]{ "Soundtrack"}
                        },
                };
            var rozszerzenia = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio;
            foreach (var utwor in expectedInList.Select(
                        sciezka => new Utwor(sciezka) { dane = { wykonawca = new[] { "" }, numer = 0, rok = 0, album = ""} }))
            {
                utwor.zapiszTagi();
            }

            using (ShimsContext.Create())
            {
                UniversalShims();
                TestSortowania(schemat, sciezkaTestowa, rozszerzenia, expectedInList, dane);
            }
        }

        private static void TestSortowania(string schemat, string sciezkaTestowa, List<string> rozszerzenia, List<string> expectedInList,
                                           IList<DaneUtworu> dane)
        {
            PrzeprowadzSortowanie(schemat, sciezkaTestowa, rozszerzenia, expectedInList);

            var expectedOutList = ExpectedOutList(schemat, sciezkaTestowa, expectedInList, dane);

            CheckOutput(sciezkaTestowa, expectedOutList, rozszerzenia);
        }

        private static List<string> ExpectedOutList(string schemat, string sciezkaTestowa, List<string> expectedInList, IList<DaneUtworu> dane)
        {
            if(expectedInList.Count!=dane.Count)
                throw new ArgumentException(string.Format("Długośc listy plików {0} nie równa ilości danych {1}", expectedInList.Count, dane.Count));
            var expectedOutList = expectedInList.Select(
                (path, i) => Path.Combine(sciezkaTestowa,
                                          @"Musesort\Muzyka\Posegregowane",
                                          SciezkaKataloguZPol(schemat, dane[i]),
                                          Path.GetFileName(path)));
            return expectedOutList.ToList();
        }

        private static void PrzeprowadzSortowanie(string schemat, string sciezkaTestowa, List<string> rozszerzenia, List<string> expectedInList)
        {
            Console.WriteLine("\n\nTestujemy schematem: {0}\n\n", schemat);

            if (Directory.Exists(sciezkaTestowa + "\\Musesort"))
                Directory.Delete(sciezkaTestowa + "\\Musesort", true);

            CheckInList(Folder.znajdz_wspierane_pliki(sciezkaTestowa, rozszerzenia), expectedInList);

            CreateTestFolder(sciezkaTestowa, schemat).sortuj(rozszerzenia);
        }

        private static string SciezkaKataloguZPol(string schemat, DaneUtworu dane)
        {
            var wynik = new List<string>();
            foreach (var element in schemat.Split('\\'))
            {
                switch (element)
                {
                    case "Wykonawca":
                        wynik.Add(dane.wykonawca[0]);
                        break;
                    case "Album":
                        wynik.Add(dane.album);
                        break;
                    case "Rok":
                        wynik.Add(dane.rok.ToString());
                        break;
                    case "Gatunek":
                        wynik.Add(dane.gatunek[0]);
                        break;
                    case "Alfabetycznie":
                        wynik.Add(dane.tytul[0].ToString());
                        break;
                    case "Numer":
                        wynik.Add(dane.numer.ToString());
                        break;
                    case "Tytul":
                        wynik.Add(dane.tytul);
                        break;
                }
            }
            return string.Join("\\", wynik);
        }


        #endregion

        #region Przenoszenie muzyki

        [TestMethod]
        public void TestPrzenoszenia()
        {
            const string schemat = @"Wykonawca\Album\Piosenki";
            var folderDocelowy = Path.Combine(_sciezkaMuzyka, @"test przenoszenia\folder docelowy");
            var folderZrodlowy = Path.Combine(_sciezkaMuzyka, @"test przenoszenia\folder zrodlowy");
            var rozszerzenia = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio;
            var expectedInList1 = new List<string>
                {
                    "01.QDC - Belief",
                    "04 - Muse - Map Of The Problematique",
                    "07 Kristin Chenoweth-Popular"
                };
            expectedInList1 = expectedInList1.Select(file => Path.Combine(folderDocelowy, file + ".mp3")).ToList();
            var dane1 = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Belief", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ethnic"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Map Of The Problematique",
                            wykonawca = new[] {"Muse"},
                            album = "Black Holes And Revelations",
                            gatunek = new[]{"Rock"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Popular",
                            wykonawca = new[] {"Kristin Chenoweth"},
                            album = "Wicked Soundtrack",
                            gatunek = new[]{"24"}
                        },
                };
            var expectedInList2 = new List<string>(ExpectedOutList(schemat, folderDocelowy, expectedInList1, dane1))
                {
                    folderZrodlowy + @"\Nirvana\In Utero\04. Rape Me.mp3",
                    folderZrodlowy + @"\1362775647.foxamoore_children_of_orion.mp3"
                };
            var dane2 = dane1.Concat(new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Rape Me",
                            wykonawca = new[] {"Nirvana"},
                            album = "In Utero",
                            gatunek = new[]{"Grunge"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Children Of Orion",
                            wykonawca = new[] {"Fox Amoore"},
                            album = "Utunu And Kikivuli",
                            gatunek = new[]{"Soundtrack"}
                        },
                }).ToArray();
            var expectedOutList = ExpectedOutList(schemat, folderDocelowy, expectedInList2, dane2);

            using (ShimsContext.Create())
            {
                UniversalShims();
                PrzeprowadzSortowanie(schemat, folderDocelowy, rozszerzenia, expectedInList1);
                CreateTestFolder(folderDocelowy, schemat).dodajIPosortujFolder(folderZrodlowy, rozszerzenia);
                CheckOutput(folderDocelowy, expectedOutList, rozszerzenia);
            }
        }

        [TestMethod]
        public void TestDodawaniaDoFolderuGlowanego()
        {
            const string schemat = @"Wykonawca\Album\Piosenki";
            var folderDocelowy = Path.Combine(_sciezkaMuzyka, @"test przenoszenia\folder docelowy");
            var folderZrodlowy = Path.Combine(_sciezkaMuzyka, @"test przenoszenia\folder zrodlowy");
            var rozszerzenia = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio;
            var expectedInList1 = new List<string>
                {
                    "01.QDC - Belief",
                    "04 - Muse - Map Of The Problematique",
                    "07 Kristin Chenoweth-Popular"
                };
            expectedInList1 = expectedInList1.Select(file => Path.Combine(folderDocelowy, file + ".mp3")).ToList();
            var dane1 = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Belief", 
                            wykonawca = new[] {"Łukasz Brzostek (QDC)"},
                            album = "Alchemist",
                            rok = 2003,
                            gatunek = new[]{ "Ethnic"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Map Of The Problematique",
                            wykonawca = new[] {"Muse"},
                            album = "Black Holes And Revelations",
                            gatunek = new[]{"Rock"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Popular",
                            wykonawca = new[] {"Kristin Chenoweth"},
                            album = "Wicked Soundtrack",
                            gatunek = new[]{"24"}
                        },
                };
            var expectedInList2 = new List<string>
                {
                    folderZrodlowy + @"\Nirvana\In Utero\04. Rape Me.mp3",
                    folderZrodlowy + @"\1362775647.foxamoore_children_of_orion.mp3"
                };
            var dane2 = new[]
                {
                    new DaneUtworu
                        {
                            tytul = "Rape Me",
                            wykonawca = new[] {"Nirvana"},
                            album = "In Utero",
                            gatunek = new[]{"Grunge"}
                        },
                    new DaneUtworu
                        {
                            tytul = "Children Of Orion",
                            wykonawca = new[] {"Fox Amoore"},
                            album = "Utunu And Kikivuli",
                            gatunek = new[]{"Soundtrack"}
                        },
                };
            var expectedInList3 = new List<string>(expectedInList1);
            expectedInList3.AddRange(expectedInList2);
            var dane3 = dane1.Concat(dane2).ToArray();
            var expectedOutList = ExpectedOutList(schemat, folderDocelowy, expectedInList3, dane3);

            using (ShimsContext.Create())
            {
                UniversalShims();
                PrzeprowadzSortowanie(schemat, folderDocelowy, rozszerzenia, expectedInList1);
                PrzeprowadzSortowanie(schemat, folderZrodlowy, rozszerzenia, expectedInList2);
                var folderGlowny = new FolderGlowny(folderDocelowy);
                folderGlowny.dodajFolder(folderZrodlowy);
                Console.WriteLine(folderGlowny.logi);
                CheckOutput(folderDocelowy, expectedOutList, rozszerzenia);
            }
        }

        #endregion

        #region Sortowanie filmow

        [TestMethod]
        public void SortujFilmyTest1()
        {
            //-------------------------------------- Setup -------------------------------------------
            var sciezkaTestowa = _sciezkaFilmy;
            const string schemat = "Rezyser\\Tytul";

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
                UniversalShims();
                CreateFilmShims1(testData);
                CreateTestFolder(sciezkaTestowa, schemat).sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            }

            CheckOutput(sciezkaTestowa, expectedOutList, UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
        }

        [TestMethod]
        public void SortujFilmyTest2()
        {
            //-------------------------------------- Setup --------------------------------------------
            var sciezkaTestowa = Util.SetAbsoluteDirectoryPath("filmy otagowane");
            const string schemat = "Aktorzy\\Tytul";

            UstawieniaProgramu.getInstance().wczytajUstawienia();
            if (!UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains("mp4"))
                UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add("mp4");
            if (Directory.Exists(sciezkaTestowa + "\\Musesort"))
                Directory.Delete(sciezkaTestowa + "\\Musesort", true);

            //-------------------------------------- Lists --------------------------------------------
            var inList = Folder.znajdz_wspierane_pliki(sciezkaTestowa,
                                                       UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
            var expectedInList = new List<string>();
            var expectedOutList = new List<string>();
            expectedInList.Add(sciezkaTestowa + @"\My Little Pony season 3 Episode 7 Wonderbolt Academy.mp4");
            expectedOutList.Add(string.Format("{0}\\Musesort\\Filmy\\Posegregowane\\{1}\\{2}\\{3}",
                                              sciezkaTestowa, "Lauren Faust", "Wonderbolts Academy",
                                              "My Little Pony season 3 Episode 7 Wonderbolt Academy.mp4"));

            expectedInList.Add(sciezkaTestowa + @"\ROSA (HD) Epic AWARD Winning Matrix style Fantasy Action Ani.mp4");
            expectedOutList.Add(string.Format("{0}\\Musesort\\Filmy\\Posegregowane\\{1}\\{2}\\{3}",
                                              sciezkaTestowa, "Madartistpublishing", "Rosa",
                                              "ROSA (HD) Epic AWARD Winning Matrix style Fantasy Action Ani.mp4"));

            expectedInList.Add(sciezkaTestowa + @"\RUIN.mp4");
            expectedOutList.Add(string.Format("{0}\\Musesort\\Filmy\\Posegregowane\\{1}\\{2}\\{3}",
                                              sciezkaTestowa, "Wes Ball", "RUIN",
                                              "RUIN.mp4"));



            CheckInList(inList, expectedInList);

            //------------------------------------------------------------------------------------------

            using (ShimsContext.Create())
            {
                UniversalShims();
                var testFolder = CreateTestFolder(sciezkaTestowa, schemat);
                var wspieraneRozszerzeniaVideo = UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo;
                testFolder.sortuj(wspieraneRozszerzeniaVideo);
            }

            CheckOutput(sciezkaTestowa, expectedOutList, UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo);
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
            Func<string, Plik> createPlik = path =>
                {
                    var wynik = new Film(path);
                    wynik.dane = testData[wynik.Nazwa];
                    return wynik;
                };
            ShimPlik.CreateString = path => createPlik(path);
            ShimPlik.CreateStringString = (path1, path2) => createPlik(path1);
        }

        #endregion

        private static void CheckOutput(string sciezkaTestowa, List<string> expectedOutList, List<string> wspieraneRozszerzenia)
        {
            var outList = Folder.znajdz_wspierane_pliki(sciezkaTestowa + "\\Musesort", wspieraneRozszerzenia);

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


        private static void UniversalShims()
        {
            ShimFolderXML.ConstructorString = (@this, path) => { };
            ShimFolderXML.AllInstances.analizuj = @this => false;
            ShimMessageBox.ShowString = (message) => DialogResult.OK;
        }
    }
}
