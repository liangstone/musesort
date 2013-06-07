using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MuseSort
{
    partial class Film
    {
        //do ponownego merga
        public static List<Wzorzec> wzorceNazwy = new List<Wzorzec>();
        private static readonly WzorzecFactory WzorzecFactory = new WzorzecFactory(WzorzecFactory.SlownikRegexowDlaFilmow);
        private List<Wzorzec> wzorceSciezki = new List<Wzorzec>();

        public static Boolean dodajWzorzecNazwy(String wzorzec)
        {
            return DodajWzorzec(wzorzec, wzorceNazwy);
            /*Boolean sukces = sprawdzWzorzec(wzorzec);

            if (sukces)
            {
                Wzorzec nowy = new Wzorzec(regex, wzorzec);
                wzorceNazwy.Add(nowy);
                
            }
            return sukces;*/
        }

        private static bool DodajWzorzec(string wzorzec, List<Wzorzec> lista)
        {

            if (!sprawdzWzorzec(wzorzec, wzorceNazwy)) return false; //Jeden z wzorców na liście rozpoznaje string jako poprawną nazwę/ścieżkę.
            lista.Add(WzorzecFactory.GetWzorzec(wzorzec));
            UstawieniaProgramu.getInstance().zapiszUstawienia();
            return true;
        }

        private static Boolean sprawdzWzorzec(String wzorzec, List<Wzorzec> lista)
        {
            return lista.All(wzor => !wzor.czyPasuje(wzorzec));
        }

//end  Boolean sprawdzWzorzec(String wzorzec)

        public static void wczytajWzorceZPliku(String path)
        {
            //Wczytywanie listy wzorców z pliku XML do obiektów klasy
            //W zmiennej path zawarta jest ścieżka do pliku
            wzorceNazwy = new List<Wzorzec>();
            XmlDocument plikXML = new XmlDocument();
            plikXML.Load(path);
            XmlNodeList wzorceList = plikXML.GetElementsByTagName("filmWzorzecNazwy");
            for (int i = 0; i < wzorceList.Count; i++)
            {

                String nazwa = wzorceList.Item(i).FirstChild.InnerText;
                dodajWzorzecNazwy(nazwa);
                /*String regex = wzorceList.Item(i).LastChild.InnerText;
                Wzorzec wz = new Wzorzec(regex, nazwa);
                wzorceNazwy.Add(wz);*/
            }


        }//end void wczytajWzorceZPliku(String path)
    }
}
