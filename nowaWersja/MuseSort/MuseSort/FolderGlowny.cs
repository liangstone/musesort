using System;
using System.Collections.Generic;
using System.IO;

namespace MuseSort
{
    class FolderGlowny
    {
        String sciezka;
        public String logi;

        public String Sciezka
        {
            get { return sciezka; }
            private set { sciezka = value; }
        }
        FolderGlownyXML xml;

        #region PUBLICZNE METODY KLASY

        /// <summary>Powiązanie nowego obiektu z folderem ze zmiennej path.
        /// </summary>
        /// <param name="path">Ścieżka folderu.</param>
        /// <exception cref="DirectoryNotFoundException">Rzucane jeśli podany folder nie istnieje.</exception>
        public FolderGlowny(String path)
        {
            if (!File.Exists(path))
                throw new DirectoryNotFoundException(path);
            xml = new FolderGlownyXML(path);
            logi = "";
            sciezka = path;
        }

        ///<summary>Analizowanie folderu pod względem obecności wymaganych obiektów oraz zgodności struktury logicznej zapisanej w pliku XML.
        ///W skrócie, sprawdzanie, czy wszystko się zgadza.
        /// </summary>
        /// <remarks>Jeszcze nie zaiplementowane.</remarks>
        public Boolean analizuj()
        {
            Boolean result = xml.analizuj();

            return result;
        }


        /// <summary>Dodaje zawartość podanego posortowanego katalogu do katalogu głównego.
        /// </summary>
        /// <remarks>Implementacja: Krzysztof</remarks>
        /// <param name="path">Ścieżka folderu do dodania.</param>
        public void dodajFolder(String path)
        {
            Folder folder = new Folder(path + "\\Musesort");
            dodajFolder(folder);
        }

        /// <summary>Dodaje zawartość podanego posortowanego katalogu do katalogu głównego.
        /// </summary>
        /// <remarks>Implementacja: Krzysztof</remarks>
        /// <param name="folder">Folder do dodania.</param>
        public void dodajFolder(Folder folder)
        {
            /* Zwraca że nie jest prawidłowo posortowane na posortowanym katalogu.
            if (!folder.analizuj())
            {
                throw new InvalidOperationException("Próba dodawania folderu " + folder.Sciezka
                    + " do folderu głównego nie powiodła się, gdyż nie jest on posortowany.");
            }*/

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(folder.Sciezka, this.sciezka);
                logi += "Przeniesiono folder: " + folder.Sciezka + " do folderu: " + this.sciezka + Environment.NewLine;
            }
            /*
             * IOException rzucane jest w 3 przypadkach:
             * Source jest root: niemożliwe, bo source to podfolder Musesort wybranego folderu.
             * Source path==target path: możliwość już obsłużona w MainGUI.dodajDoGlownegoFolderuButton_Click.
             * A więc rzucane jest z powodu kolizji plików zaś e.Data.Keys będzie zawierał pliki w folderze źródłowym które kolidują.
             */
            catch (IOException e)
            {
                foreach (string plikDodawany in e.Data.Keys)
                {
                    string plikDodawanyFolderRelatywny = Directory.GetParent(plikDodawany).ToString().Substring(folder.Sciezka.Length);
                    string nazwaPliku = Path.GetFileName(plikDodawany);
                    int i = 1;
                    string nowaSciezka = Path.Combine(this.sciezka + plikDodawanyFolderRelatywny + "(" + i + ")", nazwaPliku);
                    for (; File.Exists(nowaSciezka); i++)
                    {
                        nowaSciezka = Path.Combine(this.sciezka + plikDodawanyFolderRelatywny + "(" + i + ")", nazwaPliku);
                    }

                    Directory.CreateDirectory(Directory.GetParent(nowaSciezka).ToString()); //Tworzymy katalog jeśli potrzeba.
                    File.Copy(plikDodawany, nowaSciezka); //Kopiujemy plik.
                    logi += "Przeniesiono plik: " + plikDodawany + " do sciezki: " + nowaSciezka + Environment.NewLine;
                }
            }
            catch (UnauthorizedAccessException)
            {
                System.Windows.Forms.MessageBox.Show("UnauthorizedAccessException: Uprawnień do folderu.");
                logi += "UnauthorizedAccessException: Brak uprawnień do folderu." + Environment.NewLine;
                return;
            }
            catch (System.Security.SecurityException)
            {
                System.Windows.Forms.MessageBox.Show("SecurityException: Uprawnień do folderu.");
                logi += "UnauthorizedAccessException: Brak uprawnień do folderu." + Environment.NewLine;
                return;
            }
            System.Windows.Forms.MessageBox.Show("Operacja zakończona.");

            
        }

        #endregion

        #region METODY POMOCNICZE KLASY


        /// <summary>Zwraca listę ścieżek plików .mp3 i .flac.
        /// </summary>
        /// <param name="katalog">Katalog do przeszukania.</param>
        /// <returns></returns>
        List<string> znajdz_wspierane_pliki(string katalog = null)
        {
            if (katalog == null)
                katalog = this.sciezka;
            List<string> wynik = new List<string>();
            foreach (string rozszerzenie in UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio)
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


        #endregion
    }
}
