﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace MuseSort
{
    class StaticUtwor
    {
        public static List<Wzorzec> wzorceNazwy = new List<Wzorzec>();
        public static List<Wzorzec> wzorceSciezki = new List<Wzorzec>();

        public static Boolean dodajWzorzec(String wzorzec, String regex, String rodzaj)
        {
            Boolean sukces = sprawdzWzorzec(wzorzec, rodzaj);

            if (sukces)
            {
                Wzorzec nowy = new Wzorzec(regex, wzorzec);
                if (rodzaj == "wzorceNazwy")
                {
                    wzorceNazwy.Add(nowy);
                }
                else if (rodzaj == "wzorceSciezki")
                {
                    wzorceSciezki.Add(nowy);
                }
            }

            return sukces;
        }

        public static Boolean sprawdzWzorzec(String wzorzec, String rodzaj)
        {
            List<Wzorzec> wzorce;
            if (rodzaj == "WzorceNazwy")
            {
                wzorce = wzorceNazwy;
            }
            else
            {
                wzorce = wzorceSciezki;
            }

            foreach (Wzorzec wzor in wzorce)
            {
                if (wzor.czyPasuje(wzorzec))
                {
                    return false;
                }
            }

            return true;
        }//end  Boolean sprawdzWzorzec(String wzorzec, String rodzaj)

        public void wczytajWzorceZPliku(String path)
        {
            //Wczytywanie listy wzorców z pliku XML do obiektów klasy
            //W zmiennej path zawarta jest ścieżka do pliku
            XmlDocument plikXML = new XmlDocument();
            plikXML.Load(path);
            XmlNodeList wzorceList = plikXML.GetElementsByTagName("wzorzec_nazwy");
            for (int i = 0; i < wzorceList.Count; i++)
            {
                
                String nazwa = wzorceList.Item(i).FirstChild.InnerText;
                String regex = wzorceList.Item(i).LastChild.InnerText;
                Wzorzec wz = new Wzorzec(regex, nazwa);
                wzorceNazwy.Add(wz);
            }

            wzorceList = plikXML.GetElementsByTagName("wzorzec_sciezki");
            for (int i = 0; i < wzorceList.Count; i++)
            {

                String nazwa = wzorceList.Item(i).FirstChild.InnerText;
                String regex = wzorceList.Item(i).LastChild.InnerText;
                Wzorzec wz = new Wzorzec(regex, nazwa);
                wzorceSciezki.Add(wz);
            }

        }//end void wczytajWzorceZPliku(String path)

    }
}
