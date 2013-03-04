using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    class Folder
    {
        String sciezka;
        String schemat;
        FolderXML xml;

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
        }

        //Sortowanie folderu, zwraca informację o sukcesie lub porażce w trakcie sortowania
        public Boolean sortuj()
        {
            Boolean result = true;

            return result;
        }

        //Dodawanie plików z folderu ze ściezki w zmiennej Path do zbiorów w folderze powiązanym z obiektem
        public Boolean dodajIPosortujFolder(String path)
        {
            Boolean result = true;

            return result;
        }

        //######################################METODY POMOCNICZE KLASY######################################
    }
}
