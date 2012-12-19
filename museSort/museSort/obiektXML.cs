﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace museSort
{
    class obiektXML
    {
        String sciezka;//przechowuje scieżkę do pliku XML
        XmlDocument plikXML;
        String schemat;

        public obiektXML(String sc)//otwieramy folder do tworzenia pliku XML
        {
            sciezka = "";
            schemat = sc;
            plikXML = new XmlDocument();
        }

        public obiektXML(String path, String sc)//wiążemy istniejący plik XML w folderze ze ścieżki z argumentu z obiektem
        {
            sciezka = path;
            schemat = sc;
            plikXML = new XmlDocument();
            String p = sciezka + "\\" + "struktura_logiczna.xml";
            plikXML.Load(p);

        }

        public void generujXML(String path)//tworzymy nowy plik XML
        {
            sciezka = path;
            String p = sciezka + "\\" + "struktura_logiczna.xml";//sciezka z plikiem
            if (System.IO.File.Exists(p))
            {
                System.IO.File.Delete(p);
            }
            plikXML = new XmlDocument();
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            XmlElement main = plikXML.CreateElement("body");
            XmlElement sc = plikXML.CreateElement("schemat");
            XmlText wartosc = plikXML.CreateTextNode(schemat);
            sc.AppendChild(wartosc);
            main.AppendChild(sc);
            generuj_elementy(path, main, plikXML);
            plikXML.AppendChild(main);
            plikXML.Save(p);

        }

        public void generuj_elementy(String path, XmlElement parent, XmlDocument doc)
        {
            XmlElement aktualny;
            String[] foldery = path.Split('\\'); //pobieram nazwę aktualnego folderu

            aktualny = doc.CreateElement("folder");
            XmlElement name = doc.CreateElement("nazwa");
            XmlText wartosc = doc.CreateTextNode(foldery[foldery.Length - 1]);
            name.AppendChild(wartosc);
            aktualny.AppendChild(name);

            foldery = Directory.GetDirectories(path);//tworzę listę podfolderów
            Array.Sort(foldery);
            foreach (string folderName in foldery)
            {
                generuj_elementy(folderName, aktualny, doc);
            }

            string[] pliki;
            pliki = Directory.GetFiles(path); //tworzę listę plików
            foreach (string fileName in pliki)
            {
                if (!(System.IO.Path.GetExtension(fileName).Substring(1) == "xml"))
                {
                    XmlElement plik = doc.CreateElement("plik");
                    name = doc.CreateElement("nazwa");
                    foldery = fileName.Split('\\');
                    wartosc = doc.CreateTextNode(foldery[foldery.Length - 1]);
                    name.AppendChild(wartosc);
                    plik.AppendChild(name);
                    aktualny.AppendChild(plik);
                }
            }

            parent.AppendChild(aktualny);
        }

        public Boolean analizuj()
        {
            if (sciezka == "")
            {
                return true;
            }
            XmlDocument tempXML = new XmlDocument();
            XmlDeclaration dec = tempXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            tempXML.AppendChild(dec);
            XmlElement main = tempXML.CreateElement("lista_folderow");
            generuj_elementy(sciezka, main, tempXML);
            tempXML.AppendChild(main);
            String p = sciezka + "\\" + "temp.xml";
            String q = sciezka + "\\" + "struktura_logiczna.xml";
            tempXML.Save(p);
            if (System.IO.File.ReadAllText(p) == System.IO.File.ReadAllText(q))
            {
                System.IO.File.Delete(p);
                return true;
            }
            else
            {
                System.IO.File.Delete(p);
                return false;
            }

        }

        public void aktualizuj()
        {
            generujXML(sciezka);
        }

    }
}