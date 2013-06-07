using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MuseSort
{
    class Folder
    {

        #region POLA KLASY

        /// <summary>Ścieżka folderu.</summary>
        String sciezka;
        public String logi;
        /// <summary>Udostępnia ścieżkę do odczytu.</summary>
        public String Sciezka
        {
            get { return sciezka; }
            private set { sciezka = value; }
        }

        String schemat;
        FolderXML xml;
        string[] kategorie;

        #endregion

        #region PUBLICZNE METODY KLASY

        //Tworzenie powiązania folderu z obiektem
        public Folder(String path)
        {
            xml = new FolderXML(path);
            sciezka = path;
            logi = "";
            if (xml.analizuj())
            {
                schemat = xml.schemat;
            }
            else
            {
                schemat = "";
            }
        }

        //Analizowanie folderu pod względem wcześniejszego sortowania, obecności wymaganych obiektów oraz zgodności struktury logicznej zapisanej w pliku XML
        public Boolean analizuj()
        {
            Boolean result = xml.analizuj();
            return result;
        }

        //Ustalanie schematu sortowania folderu
        public void ustalSchemat(String schema)
        {
            schemat = schema;
            xml.schemat = schema;
            przetwarzaj_kategorie();
        }


        /// <summary>Sortowanie folderu, zwraca informację o sukcesie lub porażce w trakcie sortowania.
        /// </summary>
        /// <returns>Sukces operacji.</returns>
        public bool sortuj(IEnumerable<string> wspieraneRozszerzenia)
        {
            //System.Windows.Forms.MessageBox.Show("Rozpoczynam sortowanie.");
            //Powinno być sprawdzenie czy folder jest posortowany.
            if (schemat == null || schemat.Equals(""))
            {
                Console.WriteLine("Sortowanie nie może się odbyć. Nie jest ustawiony schemat.");
                return false;
            }

            if (Directory.Exists(sciezka + "\\Musesort"))
                Directory.Delete(sciezka + "\\Musesort", true);

            #region Ustaw obecny katalog i twórz katalogi

            string workingDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(sciezka);
            Directory.CreateDirectory(@"Musesort\Temp");

            //Wykomentowane: będą tworzone w miarę zapotrzebowania.
            //string[] standardDirecories = 
            //    new string[] 
            //    {
            //            @"Musesort\Temp",
            //            @"Musesort\Posegregowane\Nieprzydzielone",
            //            @"Musesort\Zduplikowane\Posegregowane\Nieprzydzielone",
            //            @"Musesort\Zduplikowane\Temp"
            //    };
            //foreach (string directory in standardDirecories)
            //{
            //    Directory.CreateDirectory(directory);
            //}

            #endregion

            List<string> listaPlikow = znajdz_wspierane_pliki(Sciezka, wspieraneRozszerzenia);

            bool sukces = sortujListePlikow(listaPlikow);
            logi += "Posortowano folder: " + this.sciezka + Environment.NewLine;
            System.Windows.Forms.MessageBox.Show("Sortowanie zakończone.");
            return sukces;
        }

        
        /// <summary>Dodawanie plików z podanego folderu do zbiorów w folderze powiązanym z obiektem</summary>
        /// <param name="folderZrodlowy">Ścieżka folderu źródłowego</param>
        /// <returns></returns>
        public Boolean dodajIPosortujFolder(String folderZrodlowy, IEnumerable<string> wspieraneRozszerzenia)
        {
            System.Windows.Forms.MessageBox.Show("Rozpoczynam dodawanie.");
            bool sukces = false;
            //Wykomentowane ze względu na wadliwie działające analizuj.
            //Jeśli folder nieposortowany:
            //if (!analizuj())
            //{
            //    //Jeśli sortowanie się nie powiedzie:
            //    if (!sortuj())
            //        return false;
            //}

            List<string> listaPlikow = znajdz_wspierane_pliki(folderZrodlowy, wspieraneRozszerzenia);
            sukces = sortujListePlikow(listaPlikow);

            logi += "Dodano i posortowano folder: " + folderZrodlowy + " do folderu: " + this.sciezka + Environment.NewLine;
            System.Windows.Forms.MessageBox.Show("Dodawanie plików do posortowanego folderu zakończone.");
            progressBar2.Value = 0;
            return sukces;
        }

        #endregion

        #region METODY POMOCNICZE KLASY

        //######################################METODY POMOCNICZE KLASY######################################


        #region Obsługa paska postępu i logów.

        /// <summary>Referencja do paska postępu w oknie.</summary>
        public System.Windows.Forms.ProgressBar progressBar2;


        /// <summary>Inicjalizacja paska postępu i logów na początku sortowania.</summary>
        private void logiInitSortProgress(int numberOfSteps)
        {
            progressBar2.Maximum = numberOfSteps;
            progressBar2.Value = 0;
            progressBar2.Step = 1;
        }

        #endregion

        /// <summary>Sortuje pliki z listy.</summary>
        /// <param name="listaPlikow">Ścieżki plików do posortowania.</param>
        /// <returns>Sukces operacji.</returns>
        private bool sortujListePlikow(List<string> listaPlikow)
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(sciezka);

            #region Sortowanie
            //try
            //{

                logiInitSortProgress(listaPlikow.Count);
                foreach (string sciezkaPliku in listaPlikow)
                {
                    Plik plik;
                    try
                    {
                        plik = Plik.Create(sciezkaPliku);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Błąd w pliku " + sciezkaPliku);
                        Console.WriteLine(e);
                        continue;
                    }
                    sortujPlik(plik);
                }
            //}
            //catch (Exception e) //Łapanie dowolnych nieprawidłowości.
            //{
                //System.Windows.Forms.MessageBox.Show(e.ToString());
                //return false;
            //}
            //finally
            //{
                Directory.SetCurrentDirectory(workingDirectory);
            //}
            #endregion

            //Generuj plik XML
            xml = new FolderXML(Path.Combine(sciezka, "Musesort"), schemat);
            xml.generujXML();
            
            return true;
        }

        /// <summary>Sortuje pojedynczy plik.</summary>
        /// <param name="plik">Plik do posortowania.</param>
        private void sortujPlik(Plik plik)
        {
            string nazwaPliku = Path.GetFileName(plik.Sciezka);
            //logiAddLine("Sortuję plik " + plik.Sciezka);

            //Kopiujemy plik do Temp i dalej działamy na kopii.
            plik.kopiujPlik(@"Musesort\Temp\");
            plik = Plik.Create(@"Musesort\Temp\" + nazwaPliku, plik.Sciezka);


            string sciezka_katalogu; //Ustalamy ścieżkę katalogu.
            if (schemat == @"Piosenki\Wykonawca" && plik is Utwor && ((Utwor)plik).dane.wykonawca[0] != "" && ((Utwor)plik).dane.tytul != "")
            {
                sciezka_katalogu = @"Musesort\Posegregowane";
                nazwaPliku = ((Utwor)plik).dane.wykonawca[0] + '_' + ((Utwor)plik).dane.tytul + Path.GetExtension(plik.Sciezka);
                plik.zmienNazwePliku(nazwaPliku);
            }
            else
                sciezka_katalogu = sciezka_katalogu_z_pol(plik);

            #region Tworzenie katalogu
            if (!Directory.Exists(sciezka_katalogu))
            {
                string nowyKatalog = sciezka_katalogu; //Używamy nowej zmiennej, by zachować oryginalną ścieżkę na potrzeby logowania błędów.
                while (!Directory.Exists(nowyKatalog))
                {
                    try
                    {
                        Directory.CreateDirectory(nowyKatalog); // to tworzy też wszystkie katalogi które są "po drodze"
                        // tzn. wyższego rzędu które też nie istnieją
                    }
                    catch (NotSupportedException) //Rzucane, gdy w ścieżce wystąpi ':' poza nazwą dysku.
                    {
                        int ostatniDwukropek = nowyKatalog.LastIndexOf(':');
                        if (ostatniDwukropek < nowyKatalog.LastIndexOf('\\')) //Jeśli ostatni dwukropek występuje poza nazwą ostatniego katalogu, nie sortujemy takiego pliku.
                        {
                            string message = "Nie posortowano pliku:\n" + plik.Sciezka
                                + "Gdyż wedle wybranego schematu: " + schemat
                                + "\nGenerowana jest nieprawidłowa (z punktu widzenia systemu) ścieżka:\n'"
                                + sciezka_katalogu + "'";
                            Console.WriteLine(message);
                            logi += message;
                            return;
                        }
                        nowyKatalog = nowyKatalog.Substring(0, ostatniDwukropek); //Obcinamy ostatni dwukropek
                    }
                    catch (ArgumentException) //Rzucane, gdy ścieżka jest pusta lub zaczyna się od ':'
                    {
                        string message = "Nie posortowano pliku:\n" + plik.Sciezka
                            + "Gdyż wedle wybranego schematu: " + schemat
                            + "\nGenerowana jest nieprawidłowa (z punktu widzenia systemu) ścieżka:\n'"
                            + sciezka_katalogu + "'";
                        Console.WriteLine(message);
                        logi += message;
                        return;
                    }
                }
                sciezka_katalogu = nowyKatalog; //Jeśli udało się pomyślnie utworzyć katalog, przepisujemy ostateczną ścieżkę z powrotem.
            }
            #endregion

            //Przenosimy plik.

            try
            {
                plik.przeniesPlik(sciezka_katalogu);
                logi += plik.logi;
            }
            catch (PathTooLongException)
            {
                string message = "Nie posortowano pliku:\n" + plik.Sciezka
                    + "Gdyż wedle wybranego schematu: " + schemat
                    + "\nGenerowana jest nieprawidłowa (konkratnie: za długa) ścieżka:\n'"
                    + sciezka_katalogu + "'";
                Console.WriteLine(message);
                logi += message;
            }
            catch (IOException) //rzucane w przypadku kolizji nazw plików
            {
                duplikat(Plik.Create(Path.Combine(sciezka_katalogu, nazwaPliku)), plik);
            }

            progressBar2.PerformStep();
        }

        /// <summary>Przyjmuje dwa plik mające kolizję nazw, decyduje który przenieść do którego katalogu.
        /// </summary>
        /// <param name="plik1"></param>
        /// <param name="plik2"></param>
        /// <param name="preferowaneRozszerzenie">Rozszerzenie które ma pierwszeństwo.</param>
        /// <returns>Czy plik 1 został uznany za lepszy.</returns>
        private bool duplikat(Plik plik1, Plik plik2, string preferowaneRozszerzenie = "")
        {
            logi += "Obsługa duplikatu pliku: " + Path.GetFileName(plik1.Sciezka) + Environment.NewLine ;

            // do decydowania który jest lepszy będziemy używali ifów, chyba prościej będzie najpierw ustalić wartość boola
            bool pierwszy_jest_lepszy = Plik.porownajJakosc(plik1, plik2);

            if (Path.GetExtension(plik1.Sciezka).Substring(1) == preferowaneRozszerzenie)
                if (Path.GetExtension(plik2.Sciezka).Substring(1) != preferowaneRozszerzenie)
                    pierwszy_jest_lepszy = true;
                else if (Path.GetExtension(plik2.Sciezka).Substring(1) == preferowaneRozszerzenie)
                    pierwszy_jest_lepszy = false;

            if (pierwszy_jest_lepszy) //pierwszy plik zostaje gdzie jest, drugi idzie do zduplikowanych
            {
                string nowykatalog = sciezka_katalogu_z_pol(plik2, true);
                Directory.CreateDirectory(nowykatalog);
                plik2.przeniesPlik(nowykatalog);
                logi += plik2.logi;
            }
            else //drugi plik zajmuje miejsce pierwszego, pierwszy idzie do zduplikowanych
            {
                string oryginalnaSciezka = plik1.Sciezka;
                plik1.przeniesPlik(@"Musesort\Zduplikowane\Temp\");
                plik2.przeniesPlik(Directory.GetParent(oryginalnaSciezka).ToString());
                string nowykatalog = sciezka_katalogu_z_pol(plik1, true);
                Directory.CreateDirectory(nowykatalog);
                plik1.zmienNazwePliku(Path.Combine(nowykatalog, Path.GetFileName(plik1.Sciezka)));
                logi += plik2.logi;
                logi += plik1.logi;
            }

            return pierwszy_jest_lepszy;
        }

        /// <summary>Zamienia schemat sortowania w postaci stringa na tablicę kategorii do organizowania folderów.
        /// </summary>
        /// <param name="schemat">Schemat sortowania.</param>
        /// <returns>Tablica kategorii sortowania.</returns>
        private string[] przetwarzaj_kategorie()
        {
            //zamienić na tablicę

            {
                String qq = schemat;
                List<string> temp = new List<string>(qq.Split('\\'));//zamienianie w tę i z powrotem jest nieefektywne, 
                temp.Remove("Piosenki");
                kategorie = temp.ToArray();                                       //ale i tak pracujemy na obiekcie kilkuelementowym
            }

            //Bug: walidacja kategorii zakłada, że sortujemy muzykę.

            //#region Sporządź listę kategorii, po których można sortować.
            //Type[] poprawne_typy = { typeof(string), typeof(int), typeof(uint), typeof(string[]) }; //typy pól, po których można sortować
            //List<string> poprawne_kategorie = new List<string>();
            //foreach (System.Reflection.FieldInfo pole in typeof(DaneUtworu).GetFields())
            //    if (poprawne_typy.Contains(pole.FieldType))
            //        poprawne_kategorie.Add(pole.Name);

            ////poprawne_kategorie.Remove("staraNazwa");
            //poprawne_kategorie.Add("alfabetycznie");

            //#endregion

            for (int i = 0; i < kategorie.Length; i++)
            {
                kategorie[i] = kategorie[i].ToLower();
                if (kategorie[i] == "artysta")
                    kategorie[i] = "wykonawca";
                //if (!poprawne_kategorie.Contains(kategorie[i]))
                //{
                //    throw new Exception("Błąd. Nie można sortować po polu " + kategorie[i]);
                //}
            }

            return kategorie;
        }//end przetwarzaj_kategorie()

        /// <summary>Zwraca listę ścieżek plików .mp3 i .flac.
        /// </summary>
        /// <param name="katalog">Katalog do przeszukania.</param>
        /// <returns></returns>
        List<string> znajdz_wspierane_pliki(string katalog, IEnumerable<string> wspieraneRozszerzenia)
        {
            if (katalog == null)
                throw new ArgumentNullException("Katalog jest null!");
            List<string> wynik = new List<string>();
            foreach (string rozszerzenie in wspieraneRozszerzenia)
            {
                List<string> sciezki_plikow = new List<string>(Directory.GetFiles(katalog, "*." + rozszerzenie));
                wynik.AddRange(sciezki_plikow);

            }

            //wersja możliwie szybsza: w linijce powyżej wykomentować Directory.GetFiles(katalog, "*." + rozszerzenie)
            //foreach(string plik in Directory.GetFiles(katalog))
            //{
            //    string rozszerzenie = Path.GetExtension(plik);
            //    if(utwor.wspierane_rozszerzenia.Contains(rozszerzenie))
            //        wynik[rozszerzenie].Add(plik);
            //}

            foreach (string podkatalog in Directory.GetDirectories(katalog))//dodajemy pliki z podkatalogów
            {
                wynik.AddRange(znajdz_wspierane_pliki(podkatalog, wspieraneRozszerzenia));
            }

            return wynik;
        }//end znajdz_wspierane_pliki(string katalog)

        /// <summary>Generuje ścieżkę dla katalogu na podstawie pól w sortowaniu.
        /// </summary>
        /// <param name="plik">Plik, dla którego ma być wygenerowana ścieżka.</param>
        /// <param name="duplikat">Czy generujemy ścieżkę dla duplikatu.</param>
        /// <returns>Szukana ścieżka katalogu.</returns>
        private string sciezka_katalogu_z_pol(Plik plik, bool duplikat = false)
        {
            return plik.sciezka_katalogu_z_pol(kategorie, duplikat);
        }//end sciezka_z_pol()

        #endregion
    }
}
