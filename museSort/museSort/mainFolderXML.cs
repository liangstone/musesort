﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.IO;
using System.Windows.Forms;
//#########################################################Do przerobienia w następnym zadaniu#############################################
namespace museSort
{
    class mainFolderXML
    {
        String sciezka;//przechowuje scieżkę do pliku XML
        XmlDocument plikXML;

        public mainFolderXML()//otwieramy folder do tworzenia pliku XML
        {
            sciezka = "";
            plikXML = new XmlDocument();
        }

        public mainFolderXML(String path)//wiążemy istniejący plik XML w folderze ze ścieżki z argumentu z obiektem
        {
            sciezka = path;
            plikXML = new XmlDocument();
            plikXML.Load(sciezka);

        }

        public void ustalFolder(String path)
        {
            sciezka = path;
        }

        public void generujElementy()
        {
            plikXML = new XmlDocument();
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            XmlElement main = plikXML.CreateElement("body");
            String[] pathTemp = sciezka.Split('\\');
            String path = "";
            for (int i = 0; i < pathTemp.Length - 2; i++)
            {
                path += pathTemp[i] + "\\";
            }
            path += pathTemp[pathTemp.Length - 2];
            String[] foldery = Directory.GetDirectories(path);//tworzę listę podfolderów
            Array.Sort(foldery);
            foreach (String folderName in foldery)
            {
                dodajElement(folderName, main);
            }
            plikXML.AppendChild(main);
            plikXML.Save(sciezka);
        }

        public void dodajElement(String path, XmlElement main)
        {
            XmlDocument TempXML = new XmlDocument();
            if (File.Exists(path + "\\" + "struktura_logiczna.xml"))
            {
                TempXML.Load(path + "\\" + "struktura_logiczna.xml");
                String schemat = TempXML.GetElementsByTagName("schemat").Item(0).InnerText;

                String[] nazwaTemp = path.Split('\\');
                String nazwa = nazwaTemp[nazwaTemp.Length - 1];
                XmlElement folder = plikXML.CreateElement("folder");
                XmlElement name = plikXML.CreateElement("nazwa");
                XmlText wartosc = plikXML.CreateTextNode(nazwa);
                name.AppendChild(wartosc);
                folder.AppendChild(name);
                XmlElement scheme = plikXML.CreateElement("schemat");
                wartosc = plikXML.CreateTextNode(schemat);
                scheme.AppendChild(wartosc);
                folder.AppendChild(scheme);
                main.AppendChild(folder);
            }
            else
            {
                MessageBox.Show("Błąd generowania pliku!!!");
                return;
            }
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
            XmlElement main = tempXML.CreateElement("body");
            String[] pathTemp = sciezka.Split('\\');
            String path = "";
            for (int i = 0; i < pathTemp.Length - 2; i++)
            {
                path += pathTemp[i] + "\\";
            }
            path += pathTemp[pathTemp.Length - 2];
            String[] foldery = Directory.GetDirectories(path);//tworzę listę podfolderów
            Array.Sort(foldery);
            foreach (String folderName in foldery)
            {
                dodajElementTemp(folderName, main, tempXML);
            }
            tempXML.AppendChild(main);
            String q = path + "\\" + "temp.xml";
            tempXML.Save(q);
            if (System.IO.File.ReadAllText(sciezka) == System.IO.File.ReadAllText(q))
            {
                System.IO.File.Delete(q);
                return true;
            }
            else
            {
                System.IO.File.Delete(q);
                return false;
            }
        }

        public void dodajElementTemp(String path, XmlElement main, XmlDocument tempXML)
        {
            XmlDocument TempXML = new XmlDocument();
            if (File.Exists(path + "\\" + "struktura_logiczna.xml"))
            {
                TempXML.Load(path + "\\" + "struktura_logiczna.xml");
                String schemat = TempXML.GetElementsByTagName("schemat").Item(0).InnerText;

                String[] nazwaTemp = path.Split('\\');
                String nazwa = nazwaTemp[nazwaTemp.Length - 1];
                XmlElement folder = tempXML.CreateElement("folder");
                XmlElement name = tempXML.CreateElement("nazwa");
                XmlText wartosc = tempXML.CreateTextNode(nazwa);
                name.AppendChild(wartosc);
                folder.AppendChild(name);
                XmlElement scheme = tempXML.CreateElement("schemat");
                wartosc = tempXML.CreateTextNode(schemat);
                scheme.AppendChild(wartosc);
                folder.AppendChild(scheme);
                main.AppendChild(folder);
            }
            else
            {
                MessageBox.Show("Błąd generowania pliku!!!");
                return;
            }
        }
    }
}
