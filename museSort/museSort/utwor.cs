﻿using System;
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
        public String rozszerzenie;
        public String[] wykonawca;
        public String tytul;
        public String album;
        public String[] gatunek;
        public int numer;
        public TagLib.File tagi;

        public utwor(String path)
        {
            sciezka = path;
            String[] droga = sciezka.Split('\\');               //brawo, było Split('/')... //komnetarz do usuniecia
            String[] temp = droga[droga.Length - 1].Split('.');
            nazwa = "";
            for (int i = 0; i < temp.Length-2; i++)
            {
                nazwa += temp[i] + ".";
            }
            nazwa += temp[temp.Length - 2];
            rozszerzenie = temp[temp.Length - 1];
            
            if (!rozszerzenie.Equals("mp3") && !rozszerzenie.Equals("flac"))
            {
                nazwa = "Błędne rozszerzenie pliku!!!";
            }
            else
            {
                tagi = TagLib.File.Create(path);
            }

            pobranie_danych();

        }

        //pobieranie danych z tagu i nazwy pliku
        private void pobranie_danych()                      //wpisanie danych do obiektów w klasie
        {
            nazwa = usun_zanki_spec(nazwa);                 //zamiana na duże litery, bez znaków specjalnych

            tytul = tagi.Tag.Title;                         //pobranie tytułu
            album = usun_zanki_spec(tagi.Tag.Album);        //pobranie albumu
            wykonawca = tagi.Tag.Artists;                   //pobranie wykonawców
            gatunek = tagi.Tag.Genres;                      //pobranie gatunku
            numer = int.Parse(tagi.Tag.Track.ToString());   //pobranie numeru piosenki

            if (wykonawca.Length == 0) wykonawca[0] = "";    //sprawdzenie tagu
            else 
            {                                               //jeżeli są to:
                for (int i = 0; i < wykonawca.Length; i++ ) //zamiana na duże litery, bez znaków specjalnych
                {
                    wykonawca[i] = usun_zanki_spec(wykonawca[i]);
                }
            }

            if (gatunek.Length == 0) gatunek[0] = "";        //j.w.
            else 
            {
                for (int i = 0; i < gatunek.Length; i++)
                {
                    gatunek[i] = usun_zanki_spec(gatunek[i]);
                }
            }

            if (tytul == null || wykonawca == null)         //jeśli w nazwie nie ma wykonawcy lub tytułu pobrac tytuł
            {
                String[] temp = { album };                  //zamiana string na string[]
                String szukane = nazwa;
                szukane = usun_z_nazwy(temp, szukane);      //usuwanie zbędnych informacji z nazwy
                szukane = usun_z_nazwy(gatunek, szukane);   //aby otrzymać brakującą informację

                String snumer;                              //aby usunąć numer piosenki, przerabiamy go na string
                if (numer % 10 == 0)                        //dodajemy "0" na początek, wrazie wystapienia np. 02.tytul.mp3
                    snumer = String.Concat("0", numer.ToString()); 
                else 
                    snumer = numer.ToString();

                if (szukane.Substring(0, 2).Equals(snumer)) //czy szukany tytul/wykonawca zaczyna się od numeru piosenki
                {                                           //najpierw dla podwójnej cyfry np. "01","21"...
                    szukane = szukane.Substring(0, 2);
                }
                else if (szukane.Substring(0, 1).Equals(numer.ToString()))
                {                                           //dla wystąpienia pojedynczej numeracji np. 1.tytul.flac
                    szukane = szukane.Substring(0, 1);
                }

                /* Jeżeli zakładamy, że album/tytuł/wykonawca nie zaczynają się od cyfry
                 * czego i tak nie mamy zapewnionego w wypadku powyższego wystąpienia oraz jemu równemu numerowi piosenki
                Regex reg = new Regex("^\\d*");
                szukane = reg.Replace(szukane, String.Empty);
                */

                if (wykonawca != null)                      //pobranie tytułu z nazwy, bo wykonawce mamy
                {
                    szukane = usun_z_nazwy(wykonawca, szukane);
                    tytul = oczysc_konce(szukane);
                }
                else if (tytul != null)                     //pobranie wykonawcy z nazwy
                {
                    temp[0] = tytul;
                    szukane = usun_z_nazwy(temp, szukane);
                    Regex reg = new Regex("^\\d*");         //Jeśli znajduje się numer piosenki w nazwie to usun
                    szukane = reg.Replace(szukane, String.Empty);
                    wykonawca[0] = oczysc_konce(szukane);
                }
              //else  { wykonawca i tytuł zawierają null }
            }

            /*//-----------------------TEST------------------------------
            if (tytul != null) System.Console.WriteLine("\ntytuł: " + tytul);
            System.Console.WriteLine("album : " + album);
            if (wykonawca != null) System.Console.WriteLine("wykonawca: " + wykonawca[0]);
            if (gatunek != null) System.Console.WriteLine("gatunek: " + gatunek[0]);
            System.Console.WriteLine("nazwa: " + nazwa + "\n");
            //----------------------------------------------------------*/
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

        private String usun_zanki_spec(String text)                     //usuwanie znaków specjalnych
        {
            String wynik = text;
            Regex regex = new Regex("[\\. \\$ \\^ \\{ \\[ \\( \\| \\) \\* \\+ \\? \\\\]+");
            wynik = regex.Replace(wynik, "_");
            return wynik.ToUpper();
        }

        private String oczysc_konce(String text)                        //usuwa znaki specjalne z początku i końca tekstu
        {
            Regex reg = new Regex("^(\\-*_*)*|$(\\-*_*)*");
            text = reg.Replace(text, String.Empty);
            return text;
        }
    }
}
