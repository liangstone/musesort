using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    class FolderGlowny
    {
        String sciezka;
        FolderGlownyXML xml;

        //#############################PUBLICZNE METODY KLASY############################################

        //Powiązanie nowego obiektu z folderem ze zmiennej path
        public FolderGlowny(String path)
        {
            xml = new FolderGlownyXML(path);
            sciezka = path;
        }

        //Analizowanie folderu pod względem obecności wymaganych obiektów oraz zgodności struktury logicznej zapisanej w pliku XML
        //W skrócie, sprawdzanie, czy wszystko się zgadza
        public Boolean analizuj()
        {
            Boolean result = true;

            return result;
        }

        //Dodawanie folderu do głównego zbioru biblioteki
        public void dodajFolder(String path)
        {

        }

        //######################################METODY POMOCNICZE KLASY######################################
    }
}
