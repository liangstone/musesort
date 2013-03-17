using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MuseSort
{
    class Folder
    {
        String sciezka;
        String schemat;
        FolderXML xml;
        string[] kategorie;

        //#############################PUBLICZNE METODY KLASY############################################

        //Tworzenie powiązania folderu z obiektem
        public Folder(String path)
        {
            xml = new FolderXML(path);
            sciezka = path;
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
        public bool sortuj()
        {
            bool sukces = false;
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

            string[] standardDirecories = 
                new string[] 
                {
                        @"Musesort\Temp",
                        @"Musesort\Posegregowane\Nieprzydzielone",
                        @"Musesort\Zduplikowane\Posegregowane\Nieprzydzielone",
                        @"Musesort\Zduplikowane\Temp"
                };
            foreach (string directory in standardDirecories)
            {
                Directory.CreateDirectory(directory);
            }

            #endregion

            List<string> listaPlikow = znajdz_wspierane_pliki();

            sukces = sortujListePlikow(listaPlikow);

            System.Windows.Forms.MessageBox.Show("Sortowanie zakończone.");
            return sukces;
        }

        
        /// <summary>Dodawanie plików z podanego folderu do zbiorów w folderze powiązanym z obiektem</summary>
        /// <param name="folderZrodlowy">Ścieżka folderu źródłowego</param>
        /// <returns></returns>
        public Boolean dodajIPosortujFolder(String folderZrodlowy)
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

            List<string> listaPlikow = znajdz_wspierane_pliki(folderZrodlowy);
            sukces = sortujListePlikow(listaPlikow);


            System.Windows.Forms.MessageBox.Show("Dodawanie plików do posortowanego folderu zakończone.");
            progressBar2.Value = 0;
            return sukces;
        }

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
                foreach (string plik in listaPlikow)
                {
                    Utwor utwor;
                    try
                    {
                        utwor = new Utwor(plik);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Błąd w pliku " + plik);
                        Console.WriteLine(e);
                        continue;
                    }
                    sortujPlik(utwor);
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

        private void sortujPlik(Utwor plik)
        {
            string nazwaPliku = plik.NazwaPelna;
            //logiAddLine("Sortuję plik " + plik.Sciezka);

            //Kopiujemy plik do Temp i dalej działamy na kopii.
            plik.kopiujPlik(@"Musesort\Temp\");
            plik = new Utwor(@"Musesort\Temp\" + nazwaPliku, plik.Sciezka);


            string sciezka_katalogu; //Ustalamy ścieżkę katalogu.
            if (schemat == @"Piosenki\Wykonawca" && plik.Dane.wykonawca[0] != "" && plik.Dane.tytul != "")
            {
                sciezka_katalogu = @"Musesort\Posegregowane";
                nazwaPliku = plik.Dane.wykonawca[0] + '_' + plik.Dane.tytul + '.' + plik.Rozszerzenie;
            }
            else
                sciezka_katalogu = sciezka_katalogu_z_pol(plik);

            if (!Directory.Exists(sciezka_katalogu))
                Directory.CreateDirectory(sciezka_katalogu); // to tworzy też wszystkie katalogi które są "po drodze"
            // tzn. wyższego rzędu które też nie istnieją

            //Przenosimy plik.

            try
            {
                plik.przeniesPlik(sciezka_katalogu);
            }
            catch (System.IO.IOException) //rzucane w przypadku kolizji nazw plików
            {
                duplikat(new Utwor(Path.Combine(sciezka_katalogu, nazwaPliku)), plik);
            }

            progressBar2.PerformStep();
        }

        /// <summary>Przyjmuje dwa plik mające kolizję nazw, decyduje który przenieść do którego katalogu.
        /// </summary>
        /// <param name="plik1"></param>
        /// <param name="plik2"></param>
        /// <param name="preferowaneRozszerzenie">Rozszerzeenie które ma pierwszeństwo.</param>
        /// <returns>Czy plik 1 został uznany za lepszy.</returns>
        private bool duplikat(Utwor plik1, Utwor plik2, string preferowaneRozszerzenie = "")
        {
            // do decydowania który jest lepszy będziemy używali ifów, chyba prościej będzie najpierw ustalić wartość boola
            bool pierwszy_jest_lepszy = plik1.Dane.bityNaMinute >= plik2.Dane.bityNaMinute;

            if (plik1.Rozszerzenie == preferowaneRozszerzenie)
                if (plik2.Rozszerzenie != preferowaneRozszerzenie)
                    pierwszy_jest_lepszy = true;
                else if (plik2.Rozszerzenie == preferowaneRozszerzenie)
                    pierwszy_jest_lepszy = false;

            if (pierwszy_jest_lepszy) //pierwszy plik zostaje gdzie jest, drugi idzie do zduplikowanych
            {
                string nowykatalog = sciezka_katalogu_z_pol(plik2, true);
                Directory.CreateDirectory(nowykatalog);
                plik2.przeniesPlik(nowykatalog);
            }
            else //drugi plik zajmuje miejsce pierwszego, pierwszy idzie do zduplikowanych
            {
                string oryginalnaSciezka = plik1.Sciezka;
                plik1.przeniesPlik(@"Musesort\Zduplikowane\Temp\");
                plik2.przeniesPlik(Directory.GetParent(oryginalnaSciezka).ToString());
                string nowykatalog = sciezka_katalogu_z_pol(plik1, true);
                Directory.CreateDirectory(nowykatalog);
                plik1.zmienNazwePliku(Path.Combine(nowykatalog, plik1.Nazwa + '.' + plik1.Rozszerzenie));
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

            #region Sporządź listę kategorii, po których można sortować.
            Type[] poprawne_typy = { typeof(string), typeof(int), typeof(uint), typeof(string[]) }; //typy pól, po których można sortować
            List<string> poprawne_kategorie = new List<string>();
            foreach (System.Reflection.FieldInfo pole in typeof(Dane).GetFields())
                if (poprawne_typy.Contains(pole.FieldType))
                    poprawne_kategorie.Add(pole.Name);

            //poprawne_kategorie.Remove("staraNazwa");
            poprawne_kategorie.Add("alfabetycznie");

            #endregion

            for (int i = 0; i < kategorie.Length; i++)
            {
                kategorie[i] = kategorie[i].ToLower();
                if (kategorie[i] == "artysta")
                    kategorie[i] = "wykonawca";
                if (!poprawne_kategorie.Contains(kategorie[i]))
                {
                    throw new Exception("Błąd. Nie można sortować po polu " + kategorie[i]);
                }
            }

            return kategorie;
        }//end przetwarzaj_kategorie()

        /// <summary>Zwraca listę ścieżek plików .mp3 i .flac.
        /// </summary>
        /// <param name="katalog">Katalog do przeszukania.</param>
        /// <returns></returns>
        List<string> znajdz_wspierane_pliki(string katalog = null)
        {
            if (katalog == null)
                katalog = this.sciezka;
            List<string> wynik = new List<string>();
            foreach (string rozszerzenie in Utwor.wspieraneRozszerzenia)
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
                wynik.AddRange(znajdz_wspierane_pliki(podkatalog));
            }

            return wynik;
        }//end znajdz_wspierane_pliki(string katalog)

        /// <summary>Generuje ścieżkę dla katalogu na podstawie pól w sortowaniu.
        /// </summary>
        /// <param name="plik">Plik, dla którego ma być wygenerowana ścieżka.</param>
        /// <param name="duplikat">Czy generujemy ścieżkę dla duplikatu.</param>
        /// <returns>Szukana ścieżka katalogu.</returns>
        private string sciezka_katalogu_z_pol(Utwor plik, bool duplikat = false)
        {
            Type typ_utwor = typeof(Dane);
            Dane dane = plik.Dane;
            string sciezka_katalogu;
            if (duplikat)
                sciezka_katalogu = @"Musesort\Zduplikowane\Posegregowane";
            else
                sciezka_katalogu = @"Musesort\Posegregowane";

            foreach (string kategoria in kategorie) //tworzymy ścieżkę katalogu docelowego pliku
            {
                string kat = "";
                if (kategoria == "alfabetycznie")
                {
                    try
                    {
                        kat = plik.Dane.tytul.Substring(0, 1);
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                else
                {
                    Console.WriteLine(kategoria);
                    System.Reflection.FieldInfo pole = typ_utwor.GetField(kategoria);         //pobiera pole

                    if (pole.FieldType.Equals(typeof(String)))				//jeśli pole to String
                        kat = (string)pole.GetValue(dane);
                    else if (pole.FieldType.Equals(typeof(int)) || pole.FieldType.Equals(typeof(uint)))//jeśli pole to int lub uint
                        kat = Convert.ToString(pole.GetValue(dane));
                    else if (pole.FieldType.Equals(typeof(string[])))		//jeśli pole to tablica
                    {
                        try
                        {
                            kat = ((string[])pole.GetValue(dane))[0];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            kat = "";
                        }
                    }
                }
                if (kat == "")                                          //jeśli nie udało się pobrać
                {
                    if (duplikat)
                        sciezka_katalogu = @"Musesort\Zduplikowane\Posegregowane\Nieprzydzielone";
                    else
                        sciezka_katalogu = @"Musesort\Posegregowane\Nieprzydzielone";//przenieś do "Nieprzydzielone
                    break;
                }
                //kat = ZamienNaWlasciwe(kat);
                System.Console.WriteLine(kat);
                sciezka_katalogu = Path.Combine(sciezka_katalogu, kat);
                System.Console.WriteLine(sciezka_katalogu);
            }
            if (duplikat && File.Exists(Path.Combine(sciezka_katalogu, plik.Nazwa + '.' + plik.Rozszerzenie)))
            {
                string nazwa = plik.Nazwa + '.' + plik.Rozszerzenie;
                string fullpath = Path.Combine(sciezka_katalogu, nazwa);
                int i;
                for (i = 1; File.Exists(fullpath); )
                {
                    i++;
                    fullpath = Path.Combine(sciezka_katalogu + Convert.ToString(i), nazwa);
                }
                sciezka_katalogu += Convert.ToString(i);
            }

            return sciezka_katalogu;
        }//end sciezka_z_pol()

    }
}
