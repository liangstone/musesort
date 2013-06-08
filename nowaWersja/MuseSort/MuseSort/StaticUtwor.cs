using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MuseSort
{
    public partial class Utwor
    {
        //do ponownego merga
        public static List<Wzorzec> wzorceNazwy = new List<Wzorzec>();
        public static List<Wzorzec> wzorceSciezki = new List<Wzorzec>();
        private static readonly WzorzecFactory WzorzecFactory = new WzorzecFactory(WzorzecFactory.SlownikRegexowDlaUtowrow);

        private static Boolean SprawdzWzorzec(String wzorzec, List<Wzorzec> wzorce)
        {
            return wzorce.All(wzorzecNaLiscie => !wzorzecNaLiscie.czyPasuje(wzorzec));
        }

//end  Boolean sprawdzWzorzec(String wzorzec, String rodzaj)

        public static void wczytajWzorceZPliku(String path)
        {
            //Wczytywanie listy wzorców z pliku XML do obiektów klasy
            //W zmiennej path zawarta jest ścieżka do pliku
            XmlDocument plikXML = new XmlDocument();
            plikXML.Load(path);
            XmlNodeList wzorceList = plikXML.GetElementsByTagName("utworWzorzecNazwy");
            for (int i = 0; i < wzorceList.Count; i++)
            {
                
                String nazwa = wzorceList.Item(i).FirstChild.InnerText;
                dodajWzorzecNazwy(nazwa);
                /*String regex = wzorceList.Item(i).LastChild.InnerText;
                Wzorzec wz = new Wzorzec(regex, nazwa);
                wzorceNazwy.Add(wz);*/
            }

            wzorceList = plikXML.GetElementsByTagName("utworWzorzecSciezki");
            for (int i = 0; i < wzorceList.Count; i++)
            {

                String nazwa = wzorceList.Item(i).FirstChild.InnerText;
                dodajWzorzecSciezki(nazwa);
                /*String regex = wzorceList.Item(i).LastChild.InnerText;
                Wzorzec wz = new Wzorzec(regex, nazwa);
                wzorceSciezki.Add(wz);*/
            }

        }//end void wczytajWzorceZPliku(String path)

        public static bool dodajWzorzecNazwy(string wzorzec)
        {
            return DodajWzorzec(wzorzec, wzorceNazwy);
        }

        public static bool dodajWzorzecSciezki(string wzorzec)
        {
            return DodajWzorzec(wzorzec, wzorceSciezki);
        }

        private static bool DodajWzorzec(string wzorzec, List<Wzorzec> lista)
        {
            if (!SprawdzWzorzec(wzorzec, lista)) return false; //Jeden z wzorców na liście rozpoznaje string jako poprawną nazwę/ścieżkę.
            lista.Add(WzorzecFactory.GetWzorzec(wzorzec));
            return true;
            
        }
    }
}
