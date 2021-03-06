﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace museSort
{
    class utwor
    {
        public String sciezka="";
        public String nazwa="";
        private string staraNazwa="";
        public String rozszerzenie="";
        public String[] wykonawca={""};
        public String[] wykonawca_albumu = { "" };
        public String tytul = "";
        public String album = "";
        public String[] gatunek = { "" };
        public String rok = "";
        public String komentarz = "";
        public uint liczba_piosenek;
        public uint numer_cd;
        public uint liczba_cd;
        public String tekst_piosenki = "";
        public uint bity_na_minute;
        public String dyrygent = "";
        public String prawa_autorskie = "";
        public String puid = "";                     //określa "brzmienie" piosenki
        public IPicture[] zdjecia={};
        public int numer;
        public TagLib.File tagi;
        private TagLib.File stareTagi;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };
        public Boolean pobierane_z_nazwy = false;
        public Boolean pobierane_ze_sciezki = false;


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
                //nazwa = "Błąd: Nie wspierane rozszerzenie: " + rozszerzenie;
                throw new NotSupportedException("Błąd: Nie wspierane rozszerzenie: " + rozszerzenie);
            }
            else
            {
                //Console.WriteLine("tagi = TagLib.File.Create(path);");
                tagi = TagLib.File.Create(path);
                stareTagi = TagLib.File.Create(path);
                przepisz_tagi();
            }

        }


        //pobiera i przetwarza tagi
        public void pobierz_tagi(string sciezka="")
        {
            przepisz_tagi();
            if (!czy_mamy_tagi())
            {
                try
                {
                    pobranie_danych();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                pobierane_z_nazwy = true;
            }
            if (!czy_mamy_tagi())
            {
                analizuj_sciezke(sciezka);
                pobierane_ze_sciezki = true;
            }
            try
            {
                PrzyjmijNazwe();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Nie zainicjalizowano poprawnie pliku:\n" + sciezka);
            }
        }

        public bool przepisz_tagi()
        {
            if (tagi != null)
            {
                wykonawca = tagi.Tag.Artists;
                wykonawca_albumu = tagi.Tag.AlbumArtists;
                tytul = tagi.Tag.Title;
                album = tagi.Tag.Album;
                gatunek = tagi.Tag.Genres;
                rok = tagi.Tag.Year.ToString();
                komentarz = tagi.Tag.Comment;
                liczba_piosenek = tagi.Tag.TrackCount;
                numer_cd = tagi.Tag.Disc;
                liczba_cd = tagi.Tag.DiscCount;
                tekst_piosenki = usun_znaki_spec(tagi.Tag.Lyrics);
                bity_na_minute = tagi.Tag.BeatsPerMinute;
                dyrygent = usun_znaki_spec(tagi.Tag.Conductor);
                prawa_autorskie = usun_znaki_spec(tagi.Tag.Copyright);
                puid = usun_znaki_spec(tagi.Tag.MusicIpId);                     //MusicIp Id
                zdjecia = tagi.Tag.Pictures;
                numer = int.Parse(tagi.Tag.Track.ToString());
                return true;
            }
            else
            {
                //MessageBox.Show("Nie wygenerowałem tagów");
                Console.WriteLine("Nie zainicjalizowano tagów dla pliku " + sciezka);
                return false;
            }
        }

        public Boolean czy_mamy_tagi()
        {
            if (   wykonawca == null 
                || wykonawca.Length==0
                || wykonawca[0] == null 
                || wykonawca[0] == "" 
                || tytul == null
                || tytul.Length == 0
                || tytul == "" 
                || album == null 
                || album == "")
            {
                return false;
            }
            return true;
        }

        //pobieranie danych z tagu i nazwy pliku
        private void pobranie_danych()                      //wpisanie danych do obiektów w klasie
        {
            nazwa = usun_znaki_spec(nazwa);                 //zamiana na duże litery, bez znaków specjalnych
            if (tagi == null)
                throw new NullReferenceException("Błąd w pobieranych dla pliku " + sciezka + "\n" + nazwa);
            tytul = tagi.Tag.Title;                         //pobranie tytułu
            album = usun_znaki_spec(tagi.Tag.Album);        //pobranie albumu
            wykonawca = tagi.Tag.Artists;                   //pobranie wykonawców
            gatunek = tagi.Tag.Genres;                      //pobranie gatunku
            rok = tagi.Tag.Year.ToString();
            numer = int.Parse(tagi.Tag.Track.ToString());   //pobranie numeru piosenki

            wykonawca_albumu = tagi.Tag.AlbumArtists;
            for (int i = 0; i < wykonawca_albumu.Length; i++) 
            {
                wykonawca_albumu[i] = usun_znaki_spec(wykonawca_albumu[i]);
                wykonawca_albumu[i] = ZamienNaWlasciwaNazwe(wykonawca_albumu[i]);
            }
            komentarz = usun_znaki_spec(tagi.Tag.Comment);
            liczba_piosenek = tagi.Tag.TrackCount;
            numer_cd = tagi.Tag.Disc;
            liczba_cd = tagi.Tag.DiscCount;
            tekst_piosenki = usun_znaki_spec(tagi.Tag.Lyrics);
            bity_na_minute = tagi.Tag.BeatsPerMinute;
            dyrygent = usun_znaki_spec(tagi.Tag.Conductor);
            prawa_autorskie = usun_znaki_spec(tagi.Tag.Copyright);
            puid = usun_znaki_spec(tagi.Tag.MusicIpId);                     //MusicIp Id
            zdjecia = tagi.Tag.Pictures;

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
                if (tmp_nr != null && tmp_nr != "" && tmp_nr.Length < 4)    //dodaj numer jesli jest w nazwie
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
                try
                {
                    szukane = szukane.Substring(0, index_rok - 3) + szukane.Substring(index_rok + 1, szukane.Length - index_rok - 1);   //usuniecie daty
                }
                catch { } //ignoruje wyjątki rzucane z powodu pustej nazwy
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
            Regex regex = new Regex("[\\. \\$ \\^ \\{ \\} \\] \\[ \\( \\| \\) \\; \\* \\+ _ \\? \\: / \\\" \\' \\> \\< \\\\]+");
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
                //PrzyjmijNazwe();
                tagi.Save();
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Brak uprawnień do zmiany pliku:\n" + sciezka);
                return false;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Nie zainicjalizowano poprawnie pliku:\n" + sciezka);
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
                //PrzyjmijNazwe();
                tagi.Save();
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Brak uprawnień do zmiany pliku:\n" + sciezka);
                return false;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                System.Windows.Forms.MessageBox.Show("Nie zainicjalizowano poprawnie pliku:\n" + sciezka);
                return false;
            }


            //------------------------------- budowanie nowej nazwy z uwzględnieniem niekompletnych danych
            string nowanazwa;
            if (/*numer == 0 || */wykonawca[0] == "" || tytul == "")
            {
                Console.WriteLine("W pliku " + sciezka + "\nNumer: " + Convert.ToString(numer) + " Wykonawca: " + wykonawca[0]
                    + " Tytul: " + tytul);
                nowanazwa = "Brak nazwy";
            }
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
            if (!System.IO.Path.IsPathRooted(nowasciezka))
            {
                //MessageBox.Show(sciezka + " wlazłem jednak w ifa ");
                nowasciezka = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), nowasciezka);
            }
            Console.WriteLine("Przenoszę plik " + sciezka + "\ndo " + nowasciezka);
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
                catch (System.IO.IOException ex) //Jeśli jest kolizja 
                {
                    throw new System.IO.IOException(nowasciezka+"\n" + ex.Message);
                }
                catch (System.NotSupportedException ex)
                {
                    Console.WriteLine(nowasciezka);
                    MessageBox.Show("Błąd not supported exeption " + ex.Message);
                    Console.WriteLine(ex); // Write error
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    Console.WriteLine(nowasciezka);
                    MessageBox.Show("Błąd not unauthorized access exeption " + ex.Message);
                    Console.WriteLine(ex); // Write error
                    System.Windows.Forms.MessageBox.Show("Błąd: Brak uprawnień.\n"
                        + "Przenoszenie pliku z: "+ sciezka + "\ndo: " + nowasciezka);
                }
                finally
                {
                    //MessageBox.Show("Jednak wlazłem");
                    tagi = TagLib.File.Create(sciezka);
                }
            } // end if
        }// end zmien_nazwe_pliku

        //kopiuje plik do podanej ścieżki (można przy okazji zmienić nazwę)
        public void kopiuj(string nowasciezka)
        {
            Console.WriteLine("Kopiuję " + sciezka + " do " + nowasciezka);
            if (!System.IO.Path.IsPathRooted(nowasciezka))
            {
                //String[] temp1 = sciezka.Split('\\');
                //String temporary = "";
                //for (int i = 0; i < temp1.Length - 2; i++)
                //{
                //    temporary += temp1[i] + "\\";
                //}
                //temporary += temp1[temp1.Length-2];
                //nowasciezka = System.IO.Path.Combine(temporary, nowasciezka);
                nowasciezka = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), nowasciezka);
            }
            Console.WriteLine("Kopiuję " + sciezka + " do " + nowasciezka);
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
            if (staraNazwa == null)
                return;
            nazwa = staraNazwa.Clone().ToString();
            tagi = stareTagi;
            zmien_nazwe_pliku(stareTagi.Name);
            zapisz_tagi();
            tagi = TagLib.File.Create(sciezka);
            try
            {
                pobranie_danych();
            }
            catch {}
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
            if (tytul != null && tytul != "")
            {
                tagi.Tag.Title = ZamienNaWlasciwe(tytul);
            }
            else
            {
                tagi.Tag.Title = tytul;
            }
            if (wykonawca != null)
            {
                for (int i = 0; i < wykonawca.Length - 1; i++)
                {
                    wykonawca[i] = ZamienNaWlasciwe(wykonawca[i]);
                }
            }
            tagi.Tag.Artists = wykonawca;
            if (album != null && album != "")
            {
                tagi.Tag.Album = ZamienNaWlasciwe(album);
            }
            else
            {
                tagi.Tag.Album = album;
            }
            if (gatunek != null)
            {
                for (int i = 0; i < gatunek.Length - 1; i++)
                {
                    gatunek[i] = ZamienNaWlasciwe(gatunek[i]);
                }
            }
            tagi.Tag.Genres = gatunek;
            tagi.Tag.Track = uint.Parse(numer.ToString());
            if (komentarz == null || komentarz == "")
            {
                tagi.Tag.Comment = "";
            }
            else
            {
                tagi.Tag.Comment = ZamienNaWlasciwaNazwe(komentarz);
            }
            tagi.Tag.TrackCount = liczba_piosenek;
            tagi.Tag.Disc = numer_cd;
            tagi.Tag.DiscCount = liczba_cd;
            if (tekst_piosenki == null || tekst_piosenki == "")
            {
                tagi.Tag.Lyrics = "";
            }
            else
            {
                tagi.Tag.Lyrics = ZamienNaWlasciwaNazwe(tekst_piosenki);
            }
            tagi.Tag.BeatsPerMinute = bity_na_minute;
            if (dyrygent == null || dyrygent == "")
            {
                tagi.Tag.Conductor = "";
            }
            else
            {
                tagi.Tag.Conductor = ZamienNaWlasciwaNazwe(dyrygent);
            }
            if (prawa_autorskie == null || prawa_autorskie == "")
            {
                tagi.Tag.Copyright = "";
            }
            else
            {
                tagi.Tag.Copyright = ZamienNaWlasciwaNazwe(prawa_autorskie);
            }
            if (puid == null || puid == "")
            {
                tagi.Tag.MusicIpId = "";
            }
            else
            {
                tagi.Tag.MusicIpId = ZamienNaWlasciwaNazwe(puid); //MusicIp Id
            }           
            tagi.Tag.Pictures = zdjecia;
            tagi.Tag.AlbumArtists = wykonawca_albumu;
        }

        public void analizuj_sciezke(string sciezka = "")
        {
            if (sciezka == "")
                sciezka = this.sciezka;
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
            System.Console.Write(b);
            tagi.Tag.Album = ZamienNaWlasciwe(tagi.Tag.Album);
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
            if (x == null)
                return x;
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
                    //System.Console.WriteLine(nowe);
                    //for (int k = 0; k < wyrazy.Length; k++)
                    //{
                    //    System.Console.WriteLine(wyrazy[k]);
                    //}
                    nowe = nowe.Trim();
                    return nowe;
        }//end ZamienNaWlasciwe(String x)

        public String ZamienNaWlasciwaNazwe(String x)
        {
            /*Nazwę pliku oraz tagi należy zmienić w taki sposób, że będą one zapisane 
             * ze spacjami zamiast podkreśleń oraz dużymi i małymi literami. Każdy wyraz
             * ma się zaczynać od dużej litery, a cała reszta liter jest mała*/
            
            x.Trim();
            if (x.Length == 0) 
                return x;
            String[] wyrazy = x.Split(' ');
            String nowe = "";
            String a = "";
            String b = "";
            for (int i = 0; i < wyrazy.Length; i++)
            {
                //System.Console.WriteLine(wyrazy[i]);
                if (wyrazy[i].Length == 0)
                    continue;
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
            //System.Console.WriteLine(nowe);
            //for (int k = 0; k < wyrazy.Length; k++)
            //{
            //    System.Console.WriteLine(wyrazy[k]);
            //}
            nowe = nowe.Trim();
            return nowe;
        }//end ZamienNaWlasciwe(String x)

    }// end class utwor
}// end namespace musesort
