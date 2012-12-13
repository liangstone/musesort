using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;
using System.Text.RegularExpressions;

namespace museSort
{
    class utwor
    {
        public String sciezka;
        public String nazwa;
        private string staraNazwa;
        public String rozszerzenie;
        public String[] wykonawca;
        public String tytul;
        public String album;
        public String[] gatunek;
        public String rok;
        public int numer;
        public TagLib.File tagi;
        private TagLib.File stareTagi;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };


        public utwor(String path)
        {
            //Console.WriteLine("sciezka = path;");
            sciezka = path;

            //Console.WriteLine("if (!System.IO.File.Exists(path))");
            if (!System.IO.File.Exists(path))
            {
                nazwa = "Błąd: Plik nie istnieje.";
                return;
            }

            //Console.WriteLine("rozszerzenie = System.IO.Path.GetExtension(path).Substring(1);");
            rozszerzenie = System.IO.Path.GetExtension(path).Substring(1);
            nazwa = System.IO.Path.GetFileNameWithoutExtension(path);
            staraNazwa = System.IO.Path.GetFileNameWithoutExtension(path);


            //Console.WriteLine("");
            if (!wspierane_rozszerzenia.Contains(rozszerzenie))
            {
                nazwa = "Błąd: Nie wspierane rozszerzenie: " + rozszerzenie;
            }
            else
            {
                //Console.WriteLine("tagi = TagLib.File.Create(path);");
                tagi = TagLib.File.Create(path);
                stareTagi = TagLib.File.Create(path);
                //Console.WriteLine("pobranie_danych();");
                pobranie_danych();
                //Console.WriteLine("analizuj_sciezke();");
                analizuj_sciezke();
                zapisz_tagi();
                zapisz_tagi_standaryzuj_nazwe();
                PrzyjmijNazwe();
            }

        }

        //pobieranie danych z tagu i nazwy pliku
        private void pobranie_danych()                      //wpisanie danych do obiektów w klasie
        {
            nazwa = usun_znaki_spec(nazwa);                 //zamiana na duże litery, bez znaków specjalnych

            tytul = tagi.Tag.Title;                         //pobranie tytułu
            album = usun_znaki_spec(tagi.Tag.Album);        //pobranie albumu
            wykonawca = tagi.Tag.Artists;                   //pobranie wykonawców
            gatunek = tagi.Tag.Genres;                      //pobranie gatunku
            rok = tagi.Tag.Year.ToString();
            numer = int.Parse(tagi.Tag.Track.ToString());   //pobranie numeru piosenki

            if (wykonawca.Length == 0)                      //jesli nie ma wykonawcy
            {
                wykonawca = new String [1];
                wykonawca[0] = "";
            }
            else
            {                                               //jeżeli są to:
                for (int i = 0; i < wykonawca.Length; i++) //zamiana na duże litery, bez znaków specjalnych
                {
                    wykonawca[i] = usun_znaki_spec(wykonawca[i]);
                }
            }

            if (gatunek.Length == 0)                      //jesli nie ma gatunku
            {
                gatunek = new String[1];
                gatunek[0] = "";
            }
            else 
            {
                for (int i = 0; i < gatunek.Length; i++)
                {
                    gatunek[i] = usun_znaki_spec(gatunek[i]);
                }
            }

            Regex reg_nr = new Regex("^\\d*");             //pobranie numeru
            String tmp_nr = reg_nr.Match(nazwa).Value;
            if (numer == 0)                             
            {
                if (tmp_nr != null && tmp_nr.Length < 4)    //dodaj numer jesli jest w nazwie
                {
                    numer = int.Parse(tmp_nr);
                }
            }
            String tmp_rok = "";
            int index_rok = 0;
            Regex reg_rok = new Regex("\\D(1|2)\\d{3}\\D");             //pobranie roku
            foreach (Match match_rok in reg_rok.Matches(nazwa.Replace("_","__")+"_"))            
            {                                                                  
                tmp_rok = match_rok.Value.Substring(1,4);
                index_rok = match_rok.Index;
            }

            if (tmp_rok != "")
            {
                rok = tmp_rok;
            }

            if (tytul == null || wykonawca[0].Equals(""))         //jeśli w nazwie nie ma wykonawcy lub tytułu pobrac tytuł
            {
                String[] temp = { album };                  //zamiana string na string[]
                String szukane = nazwa;
                szukane = szukane.Substring(0, index_rok - 3) + szukane.Substring(index_rok + 1, szukane.Length - index_rok - 1);   //usuniecie daty
                szukane = usun_z_nazwy(temp, szukane);      //usuwanie zbędnych informacji z nazwy
                szukane = usun_z_nazwy(gatunek, szukane);   //aby otrzymać brakującą informację
                //if(numer != 0 && tmp_nr == numer.ToString())
                //{
                    szukane = reg_nr.Replace(szukane, "");  //usuwanie numeru
                //}

                if (!wykonawca[0].Equals(""))                      //pobranie tytułu z nazwy, bo wykonawce mamy
                {
                    szukane = usun_z_nazwy(wykonawca, szukane);
                    tytul = oczysc_konce(szukane);
                }
                else if (tytul != null)                     //pobranie wykonawcy z nazwy
                {
                    temp[0] = tytul.ToUpper();
                    szukane = usun_z_nazwy(temp, szukane);
                    wykonawca[0] = oczysc_konce(szukane);
                }
              //else  { wykonawca i tytuł zawierają null }
            }
        }

        private String usun_z_nazwy(String[] text, String nazwa)        //usuwanie słów z "text" występujących w "nazwa"
        {                                                           //przyjmuje string[] ze względu na autorów, gatunki
            String[] temp;                                          //kolizja oznaczen global "nazwa", local "nazwa"
            var pattern = new StringBuilder();
            Regex regex;
            foreach (String s in text)
            {
                if (s != null)
                {
                    temp = s.Split(' ');
                    for (int i = 0; i < temp.Length - 1; i++)
                    {
                        pattern.Append(temp[i]);
                        pattern.Append("(.?)");
                    }
                    pattern.Append(temp[temp.Length - 1]);
                    regex = new Regex(pattern.ToString());
                    nazwa = regex.Replace(nazwa, String.Empty,1);
                    //System.Console.WriteLine("\n--cos: " + nazwa + "\n");
                }
            }
            return nazwa;
        }

        private String usun_znaki_spec(String text)                     //usuwanie znaków specjalnych
        {
            if (text == null) text = "";
            String wynik = text;
            Regex regex = new Regex("[\\. \\$ \\^ \\{ \\[ \\( \\| \\) \\* \\+ \\? \\\\]+");
            wynik = regex.Replace(wynik, "_");
            wynik = wynik.Trim('_');
            return wynik.ToUpper();
        }

        private String oczysc_konce(String text)                        //usuwa znaki specjalne z początku i końca tekstu
        {
            Regex reg = new Regex("^[\\-* _*]*|[\\-* _*]*$");
            text = reg.Replace(text, String.Empty);
            return text;
        }


        public bool zapisz_tagi()
        {
            przepisz_pola_do_tagow();
            try
            {
                tagi.Save();
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Brak uprawnień do zmiany pliku:\n" + sciezka);
                return false;
            }
            return true;
        }

        public bool zapisz_tagi_standaryzuj_nazwe()
        {
            //Console.WriteLine("Początak zapisu " + sciezka);
            przepisz_pola_do_tagow();
            try
            {
                tagi.Save();
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Brak uprawnień do zmiany pliku:\n" + sciezka);
                return false;
            }

            //------------------------------- budowanie nowej nazwy z uwzględnieniem niekompletnych danych
            string nowanazwa;
            if (numer == 0 || wykonawca[0] == "" || tytul == "")
                nowanazwa = "Brak nazwy";
            else
                nowanazwa = Convert.ToString(numer) + ". " + wykonawca[0] + " - " + tytul;
            

            String katalog = new System.IO.DirectoryInfo(sciezka).Parent.FullName; //znajdź katalog pliku
            String nowasciezka = katalog + "\\" + nowanazwa+"." + rozszerzenie;

            if(System.IO.File.Exists(nowasciezka)) //w przypadku kolizji dodawaj rosnący numer
                for (int i = 0; System.IO.File.Exists(nowasciezka = katalog + "\\" + nowanazwa + Convert.ToString(i) + "." + rozszerzenie); i++) ;
            
            zmien_nazwe_pliku(nowasciezka);
            //Console.WriteLine("Zapisano " + nowasciezka);
            return true;
        } // end zapisz tagi

        public void zmien_nazwe_pliku(string nowasciezka)
        {
            //sprawdzanie nazwy pliku
            try
            {
                walidacja_sciezki_pliku(nowasciezka);
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return;
            }

            if (nowasciezka != sciezka)
            {
                tagi = null;
                try
                {
                    System.IO.File.Move(sciezka, nowasciezka); // spróbuj zmienić nazwę
                    sciezka = nowasciezka;                     // jeśli w move będzie błąd, sciezka zostanie taka sama
                    this.nazwa = System.IO.Path.GetFileNameWithoutExtension(sciezka);
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                }
                catch (System.NotSupportedException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                    System.Windows.Forms.MessageBox.Show("Błąd: Brak uprawnień.\n"
                        + "Przenoszenie pliku z: "+ sciezka + "\ndo: " + nowasciezka);
                }
                finally
                {
                    tagi = TagLib.File.Create(sciezka);
                }
            } // end if
        }// end zmien_nazwe_pliku

        //kopiuje plik do podanej ścieżki (można przy okazji zmienić nazwę)
        public void kopiuj(string nowasciezka)
        {
            //sprawdzanie nazwy pliku
            try
            {
                walidacja_sciezki_pliku(nowasciezka);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return;
            }

            if (nowasciezka != sciezka)
            {
                try
                {
                    System.IO.File.Copy(sciezka, nowasciezka); // spróbuj kopiować 
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                }
                catch (System.NotSupportedException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    Console.WriteLine(nowasciezka);
                    Console.WriteLine(ex); // Write error
                    System.Windows.Forms.MessageBox.Show("Błąd: Brak uprawnień.\n"
                        + "Kopiowanie pliku z: " + sciezka + "\ndo: " + nowasciezka);
                }
            } // end if
        }// end kopiuj

        //przywraca dane z czasu otworzenia pliku i zapisuje je
        public void przywroc_stare()
        {
            nazwa = (String) staraNazwa.Clone();
            tagi = stareTagi;
            zmien_nazwe_pliku(stareTagi.Name);
            zapisz_tagi();
            tagi = TagLib.File.Create(sciezka);
            pobranie_danych();
        }//end przywroc_stare

        public static void walidacja_sciezki_pliku(string filepath)
        {
            string rozszerzenie = "";
            string nazwa = "";
            try
            {
                rozszerzenie = System.IO.Path.GetExtension(filepath).Substring(1);
                nazwa = System.IO.Path.GetFileNameWithoutExtension(filepath);
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine(e);
                throw new Exception("Błąd: Nieprawidłowa ścieżka: " + filepath);
            }

            if (!wspierane_rozszerzenia.Contains(rozszerzenie))
            {
                throw new Exception( "Błąd: Nie wspierane rozszerzenie: " + rozszerzenie);
            }
            if (nazwa == "")
            {
                throw new Exception( "Błąd: Brak nazwy");
            }

        }// end walidacja_sciezki_pliku

        // przepisuje pola klasy utwor do tagów w utwor.tagi.Tag
        public void przepisz_pola_do_tagow()
        {
            if (tagi == null)
                return;
            tagi.Tag.Title = tytul;
            tagi.Tag.Artists = wykonawca;
            tagi.Tag.Album = album;
            tagi.Tag.Genres = gatunek;
            tagi.Tag.Track = uint.Parse(numer.ToString());
        }

        public void analizuj_sciezke()
        {

            //Przygotowanie listy folderów
            String[] foldery = sciezka.Split('\\');
            String aktualnyFolder = foldery[foldery.Length - 2];
            try
            {
                int odkonca = 2;
                if (foldery.Length == 1)
                {
                    aktualnyFolder = "";
                }
                else
                {
                    aktualnyFolder = foldery[foldery.Length - odkonca];
                    if (Regex.Match(aktualnyFolder, @"cd|CD|Cd|disc|disk|Disc|Disk|DISC|DISK|płyta|Płyta|PŁYTA|plyta|Plyta|PLYTA").Success)
                    {
                        odkonca++;
                        aktualnyFolder = foldery[foldery.Length - odkonca];
                    }
                }
                //Lista folderów przygotowana

                if (album == "" && wykonawca.Length == 1 && wykonawca[0] == "")
                {
                    if (!Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        //Przygotowujemy album, jeśli się da
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|#|0\d\.|\d\d\.");
                        album = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        album = reg.Replace(album, " ");
                        album = album.Trim();

                        //Wybieramy folder wyżej w poszukiwaniu wykonawcy
                        odkonca++;
                        aktualnyFolder = foldery[foldery.Length - odkonca];

                        if (!Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                        {
                            reg = new Regex(@"(\(\w*\))|(\[\w*\])|\d\d\d\d|(\(\w* \w*\))|(\[\w* \w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|#|DISCOGRAFIA|Discografia|discografia|DISCOGRAPHY|DYSKOGRAFIA|STUDIO ALBUMS|ALBUMS|ALBUMY|Discography|Dyskografia|Studio albums|Studio Albums|Albums|Albumy|discography|dyskografia|studio albums|albums|albumy");
                            wykonawca[0] = reg.Replace(aktualnyFolder, "");
                            reg = new Regex(@"_");
                            wykonawca[0] = reg.Replace(wykonawca[0], " ");
                            wykonawca[0] = wykonawca[0].Trim();
                            if (wykonawca[0] == album) //Jeśli folder został zduplikowany, idziemy wyżej
                            {
                                String temp = wykonawca[0];
                                odkonca++;
                                aktualnyFolder = foldery[foldery.Length - odkonca];
                                if (!Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                                {
                                    reg = new Regex(@"(\(\w*\))|(\[\w*\])|\d\d\d\d|(\(\w* \w*\))|(\[\w* \w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|#|DISCOGRAFIA|Discografia|discografia|DISCOGRAPHY|DYSKOGRAFIA|STUDIO ALBUMS|ALBUMS|ALBUMY|Discography|Dyskografia|Studio albums|Studio Albums|Albums|Albumy|discography|dyskografia|studio albums|albums|albumy");
                                    wykonawca[0] = reg.Replace(aktualnyFolder, "");
                                    reg = new Regex(@"_");
                                    wykonawca[0] = reg.Replace(wykonawca[0], " ");
                                    wykonawca[0] = wykonawca[0].Trim();
                                    if (wykonawca[0] == "")
                                    {
                                        wykonawca[0] = temp;
                                    }
                                }
                                else if (Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                                {
                                    reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\(\w* \w*\))|(\[\w* \w*\])|(\[\w*-\w*\])|#|\.|\d\d\d\d");
                                    String nazwa_folderu = reg.Replace(aktualnyFolder, "");
                                    reg = new Regex(@"_");
                                    nazwa_folderu = reg.Replace(nazwa_folderu, " ");
                                    nazwa_folderu = nazwa_folderu.Trim();

                                    String[] albumIAutor = nazwa_folderu.Split('-');

                                    if (albumIAutor.Length >= 2)
                                    {
                                        if (albumIAutor[0] == album)
                                        {
                                            wykonawca[0] = albumIAutor[1];
                                            if (albumIAutor.Length > 2)
                                            {
                                                for (int i = 2; i < albumIAutor.Length; i++)
                                                {
                                                    wykonawca[0] += albumIAutor[i];
                                                }
                                                reg = new Regex(@" by \w*");
                                                wykonawca[0] = reg.Replace(wykonawca[0], "");
                                            }
                                        }
                                        else
                                        {
                                            wykonawca[0] = albumIAutor[0];
                                        }
                                        wykonawca[0] = wykonawca[0].Trim();
                                        reg = new Regex(@" by \w*");
                                        wykonawca[0] = reg.Replace(wykonawca[0], "");
                                    }
                                }

                            }

                        }
                        else if (Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                        {
                            reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\.|\d\d\d\d");
                            String nazwa_folderu = reg.Replace(aktualnyFolder, "");
                            reg = new Regex(@"_");
                            nazwa_folderu = reg.Replace(nazwa_folderu, " ");
                            nazwa_folderu = nazwa_folderu.Trim();

                            String[] albumIAutor = nazwa_folderu.Split('-');

                            if (albumIAutor.Length >= 2)
                            {
                                if (albumIAutor[0] == album)
                                {
                                    wykonawca[0] = albumIAutor[1];
                                    if (albumIAutor.Length > 2)
                                    {
                                        for (int i = 2; i < albumIAutor.Length; i++)
                                        {
                                            wykonawca[0] += albumIAutor[i];
                                        }
                                        reg = new Regex(@" by \w*");
                                        wykonawca[0] = reg.Replace(wykonawca[0], "");
                                    }
                                }
                                else
                                {
                                    wykonawca[0] = albumIAutor[0];
                                }
                                wykonawca[0] = wykonawca[0].Trim();
                                reg = new Regex(@" by \w*");
                                wykonawca[0] = reg.Replace(wykonawca[0], "");
                            }
                        }


                    }
                    else if (Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                        String nazwa_folderu = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        nazwa_folderu = reg.Replace(nazwa_folderu, " ");
                        nazwa_folderu = nazwa_folderu.Trim();

                        String[] albumIAutor = nazwa_folderu.Split('-');
                        if (albumIAutor.Length >= 2 && ((albumIAutor[0] == "AC" && albumIAutor[1] == "DC") || (albumIAutor[0] == "A" && albumIAutor[1] == "Ha")))
                        {
                            albumIAutor[0] = albumIAutor[0] + albumIAutor[1];
                            for (int i = 1; i < albumIAutor.Length - 1; i++)
                            {
                                albumIAutor[i] = albumIAutor[i + 1];
                            }
                            albumIAutor[albumIAutor.Length - 1] = "";
                        }

                        if (albumIAutor.Length >= 2)
                        {
                            wykonawca[0] = albumIAutor[0];
                            wykonawca[0] = wykonawca[0].Trim();
                            album = albumIAutor[1];
                            album = album.Trim();
                            reg = new Regex(@" by \w*");
                            album = reg.Replace(album, "");

                            reg = new Regex(@"\d+\.");
                            wykonawca[0] = reg.Replace(wykonawca[0], "");
                            if (albumIAutor.Length > 2)
                            {
                                for (int i = 2; i < albumIAutor.Length; i++)
                                {
                                    album += albumIAutor[i];
                                }
                                reg = new Regex(@" by \w*");
                                album = reg.Replace(album, "");
                            }
                        }
                    }

                    if (!zapisz_tagi())
                        return;
                }
                else if (album == "" && wykonawca.Length >= 1 && wykonawca[0] != "")
                {
                    if (!Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                        album = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        album = reg.Replace(album, " ");
                        album = album.Trim();

                        if (!zapisz_tagi())
                            return;
                    }
                    else if (Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                        String nazwa_folderu = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        nazwa_folderu = reg.Replace(nazwa_folderu, " ");
                        nazwa_folderu = nazwa_folderu.Trim();

                        String[] albumIAutor = nazwa_folderu.Split('-');

                        if (albumIAutor.Length >= 2)
                        {
                            if (albumIAutor[0].Trim() == wykonawca[0])
                            {

                                if (albumIAutor.Length > 2)
                                {
                                    for (int i = 2; i < albumIAutor.Length; i++)
                                    {
                                        album += albumIAutor[i];
                                    }
                                    reg = new Regex(@" by \w*");
                                    album = reg.Replace(album, "");
                                }
                            }
                            else
                            {
                                album = albumIAutor[0];
                            }
                            album = album.Trim();
                            reg = new Regex(@" by \w*");
                            album = reg.Replace(album, "");
                        }
                        else
                        {
                            album = albumIAutor[0];
                            album = album.Trim();
                            reg = new Regex(@" by \w*");
                            album = reg.Replace(album, "");
                        }
                    }

                    if (!zapisz_tagi())
                        return;
                }
                else if (album != "" && wykonawca.Length == 1 && wykonawca[0] == "")
                {
                    if (!Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                        wykonawca[0] = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        wykonawca[0] = reg.Replace(wykonawca[0], " ");
                        wykonawca[0] = wykonawca[0].Trim();
                        if (wykonawca[0] == album)
                        {
                            odkonca++;
                            if (foldery.Length > odkonca)
                            {
                                aktualnyFolder = foldery[foldery.Length - odkonca];
                                reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                                wykonawca[0] = reg.Replace(aktualnyFolder, "");
                                reg = new Regex(@"_");
                                wykonawca[0] = reg.Replace(wykonawca[0], " ");
                                wykonawca[0] = wykonawca[0].Trim();
                                String[] nieakceptowalne = { "new", "Downloads", "mp3", "Muzyka", "Pobrane", "Muza", "muza" };
                                if (nieakceptowalne.Contains<String>(wykonawca[0]))
                                {
                                    wykonawca[0] = album;
                                }
                            }
                            else
                            {
                                wykonawca[0] = album;
                            }

                        }
                        if (!zapisz_tagi())
                            return;
                    }
                    else if (Regex.Match(aktualnyFolder, @"\w*-\w*").Success)
                    {
                        Regex reg = new Regex(@"(\(\w*\))|(\[\w*\])|(\(\w*-\w*\))|(\[\w*-\w*\])|(\(\w* \w*\))|(\[\w* \w*\])|#|\d\d\d\d|0\d\.|\d\d\.");
                        String nazwa_folderu = reg.Replace(aktualnyFolder, "");
                        reg = new Regex(@"_");
                        nazwa_folderu = reg.Replace(nazwa_folderu, " ");
                        nazwa_folderu = nazwa_folderu.Trim();

                        String[] albumIAutor = nazwa_folderu.Split('-');

                        if (albumIAutor.Length >= 2)
                        {
                            if (albumIAutor[0].Trim() == album)
                            {
                                wykonawca[0] = albumIAutor[1];
                                if (albumIAutor.Length > 2)
                                {
                                    for (int i = 2; i < albumIAutor.Length; i++)
                                    {
                                        wykonawca[0] += albumIAutor[i];
                                    }
                                    reg = new Regex(@" by \w*");
                                    wykonawca[0] = reg.Replace(wykonawca[0], "");
                                }
                            }
                            else
                            {
                                wykonawca[0] = albumIAutor[0];
                            }
                            wykonawca[0] = wykonawca[0].Trim();
                            reg = new Regex(@" by \w*");
                            wykonawca[0] = reg.Replace(wykonawca[0], "");
                        }
                    }

                    if (!zapisz_tagi())
                        return;
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }//end analizuj_sciezke()

        public void PrzyjmijNazwe()
        {
            
            tagi.Tag.Title = ZamienNaWlasciwe(tagi.Tag.Title);
            tagi.Tag.Album = ZamienNaWlasciwe(tagi.Tag.Album);
            int i = 0;
            String [] a;
            String [] b;
            a = new String[tagi.Tag.Genres.Length];
            for (i = 0; i < tagi.Tag.Genres.Length; i++)
            {
                a[i] = ZamienNaWlasciwe(tagi.Tag.Genres[i]);
            }
            tagi.Tag.Genres = a;
            b = new String[tagi.Tag.Artists.Length];
            for (i = 0; i < tagi.Tag.Artists.Length; i++)
            {
                b[i] = ZamienNaWlasciwe(tagi.Tag.Artists[i]);
            }
            tagi.Tag.Artists = b;
            tagi.Save();
           
            nazwa = ZamienNaWlasciwaNazwe(System.IO.Path.GetFileNameWithoutExtension(sciezka));
            nazwa = ZamienNaWlasciwe(nazwa);
            nazwa = ZamienNaWlasciwaNazwe(nazwa);
            //sic!
            String katalog = new System.IO.DirectoryInfo(sciezka).Parent.FullName; //znajdź katalog pliku
            nazwa += "." + rozszerzenie;
            String nowasciezka = katalog + "\\" + nazwa;
            zmien_nazwe_pliku(nowasciezka);
        }//end PrzyjmijNazwe()


        public String ZamienNaWlasciwe(String x)
        {
            /*Nazwę pliku oraz tagi należy zmienić w taki sposób, że będą one zapisane 
             * ze spacjami zamiast podkreśleń oraz dużymi i małymi literami. Każdy wyraz
             * ma się zaczynać od dużej litery, a cała reszta liter jest mała*/
                    String[] wyrazy = x.Split('_');
                    String nowe = "";
                    String a = "";
                    String b = "";
                    for (int i = 0; i < wyrazy.Length; i++)
                    {
                        //System.Console.WriteLine(wyrazy[i]);
                        a = wyrazy[i].Substring(0, 1);
                        a = a.ToUpper();
                        b = wyrazy[i].Substring(1, wyrazy[i].Length-1);
                        b = b.ToLower();
                        //System.Console.WriteLine(wyrazy[i]);
                        nowe += a + b;
                        //System.Console.WriteLine(nowe);
                        nowe += ' ';
                       // System.Console.WriteLine(nowe);
                    }
                    System.Console.WriteLine(nowe);
                    for (int k = 0; k < wyrazy.Length; k++)
                    {
                        System.Console.WriteLine(wyrazy[k]);
                    }
                    nowe = nowe.Trim();
                    return nowe;
        }//end ZamienNaWlasciwe(String x)

        public String ZamienNaWlasciwaNazwe(String x)
        {
            /*Nazwę pliku oraz tagi należy zmienić w taki sposób, że będą one zapisane 
             * ze spacjami zamiast podkreśleń oraz dużymi i małymi literami. Każdy wyraz
             * ma się zaczynać od dużej litery, a cała reszta liter jest mała*/
            String[] wyrazy = x.Split(' ');
            String nowe = "";
            String a = "";
            String b = "";
            for (int i = 0; i < wyrazy.Length; i++)
            {
                //System.Console.WriteLine(wyrazy[i]);
                a = wyrazy[i].Substring(0, 1);
                a = a.ToUpper();
                b = wyrazy[i].Substring(1, wyrazy[i].Length - 1);
                b = b.ToLower();
                //System.Console.WriteLine(wyrazy[i]);
                nowe += a + b;
                //System.Console.WriteLine(nowe);
                nowe += ' ';
                // System.Console.WriteLine(nowe);
            }
            System.Console.WriteLine(nowe);
            for (int k = 0; k < wyrazy.Length; k++)
            {
                System.Console.WriteLine(wyrazy[k]);
            }
            nowe = nowe.Trim();
            return nowe;
        }//end ZamienNaWlasciwe(String x)

    }// end class utwor
}// end namespace musesort
