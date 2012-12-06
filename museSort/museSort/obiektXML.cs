using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace museSort
{
    class obiektXML
    {
        String sciezka;
        XmlDocument plikXML;

        public obiektXML()//otwieramy folder do tworzenia pliku XML
        {
            sciezka = "";
            plikXML = new XmlDocument();
        }

        public obiektXML(String path)//wiążemy istniejący plik XML w folderze ze ścieżki z argumentu z obiektem
        {
            sciezka = path;
            plikXML = new XmlDocument();
            plikXML.Load(sciezka);

        }

        public void utworz_nowy_xml(String path)//tworzymy nowy plik XML
        {
            sciezka = path + "\\" + "struktura_logiczna.xml";
            if (System.IO.File.Exists(sciezka))
            {
                System.IO.File.Delete(sciezka);
            }
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            String[] foldery = path.Split('\\');
            XmlElement main = plikXML.CreateElement("lista_folderow");
            generuj_elementy(path, main);
            plikXML.AppendChild(main);
            plikXML.Save(sciezka);

        }

        public void generuj_elementy(String path, XmlElement parent)
        {
            XmlElement aktualny;
            String[] foldery = path.Split('\\'); //pobieram nazwę aktualnego folderu

            aktualny = plikXML.CreateElement("folder");
            XmlElement name = plikXML.CreateElement("nazwa");
            XmlText wartosc = plikXML.CreateTextNode(foldery[foldery.Length - 1]);
            name.AppendChild(wartosc);
            aktualny.AppendChild(name);

            foldery = Directory.GetDirectories(path);//tworzę listę podfolderów
            Array.Sort(foldery);
            foreach (string folderName in foldery)
            {
                generuj_elementy(folderName, aktualny);
            }

            string[] pliki;
            pliki = Directory.GetFiles(path); //tworzę listę plików
            foreach (string fileName in pliki)
            {
                XmlElement plik = plikXML.CreateElement("plik");
                name = plikXML.CreateElement("nazwa");
                foldery = fileName.Split('\\');
                wartosc = plikXML.CreateTextNode(foldery[foldery.Length - 1]);
                name.AppendChild(wartosc);
                plik.AppendChild(name);
                aktualny.AppendChild(plik);
            }

            parent.AppendChild(aktualny);
        }
    }
}
