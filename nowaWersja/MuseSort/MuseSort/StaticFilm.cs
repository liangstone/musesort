using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MuseSort
{
    class StaticFilm
    {
        public static List<Wzorzec> wzorceNazwy = new List<Wzorzec>();

        public static Boolean dodajWzorzec(String wzorzec, String regex)
        {
            Boolean sukces = sprawdzWzorzec(wzorzec);

            if (sukces)
            {
                Wzorzec nowy = new Wzorzec(regex, wzorzec);
                wzorceNazwy.Add(nowy);
                
            }
            return sukces;
        }

        public static Boolean sprawdzWzorzec(String wzorzec)
        {
            foreach (Wzorzec wzor in wzorceNazwy)
            {
                if (wzor.czyPasuje(wzorzec))
                {
                    return false;
                }
            }

            return true;
        }//end  Boolean sprawdzWzorzec(String wzorzec)

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


        }//end void wczytajWzorceZPliku(String path)
    }
}
