using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace MuseSort
{
    class FolderXML
    {
        String sciezka;
        XmlDocument plikXML;
        public String schemat;
        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################

        //Tworzenie obiektu FolderXML wiążącego nowy obiekt z folderem ze ścieżki, sprawdza, czy folder posiada plik struktury logicznej
        //I wiąże plik z obiektem plikXML
        public FolderXML(String path)
        {
            sciezka = path;
            plikXML = new XmlDocument();
            String plik = sciezka + "\\" + "struktura_logiczna.xml";
            if (System.IO.File.Exists(sciezka + "\\" + "struktura_logiczna.xml"))
            {
                plikXML.Load(plik);
                schemat = plikXML.GetElementsByTagName("schemat").Item(0).InnerText;
            }
        }

        //Tworzenie obiektu FolderXML wiążącego plik
        public FolderXML(String path, String scheme)
        {
            sciezka = path;
            schemat = scheme;
            plikXML = new XmlDocument();
            
        }

        //Tworzenie pliku XML dla podanej w argumencie path sciezki
        public void generujXML()
        {
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
            generuj_elementy(sciezka, main, plikXML);
            plikXML.AppendChild(main);
            plikXML.Save(p);
        }

        //Sprawdzanie, czy dane w pliku powiązym z obiektem zgadzają się z rzeczywistem systemem plików na dysku
        public Boolean analizuj()
        {
            if (sciezka == "" || !File.Exists(sciezka + "\\" + "struktura_logiczna.xml"))
            {
                return false;
            }
            XmlDocument tempXML = new XmlDocument();
            XmlDeclaration dec = tempXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            tempXML.AppendChild(dec);
            XmlElement main = tempXML.CreateElement("body");
            XmlElement sc = tempXML.CreateElement("schemat");
            XmlText wartosc = tempXML.CreateTextNode(schemat);
            sc.AppendChild(wartosc);
            main.AppendChild(sc);
            generuj_elementy(sciezka, main, tempXML);
            tempXML.AppendChild(main);
            String p = sciezka + "\\" + "temp.xml";
            String q = sciezka + "\\" + "struktura_logiczna.xml";
            tempXML.Save(p);
            if (!File.Exists(p) || !File.Exists(q))
                return false;

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

        //Aktualizaowanie danych w pliku powiązanym z obiektem
        public void aktualizuj()
        {
            generujXML();
        }
        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        //Generowanie węzłów do pliku XML (wywoływane na potrzeby metody generujXML)
        private void generuj_elementy(String path, XmlElement parent, XmlDocument doc)
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

        #endregion

    }
}
