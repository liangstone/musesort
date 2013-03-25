using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MuseSort
{
    static class UstawieniaProgramu
    {
        public static String folderGlowny = "";
        public static String domyslneSortowanie = "";
        public static String domyslnaBazaDanych = "";
        public static List<String> wspieraneRozszerzeniaAudio = new List<String>();
        public static List<String> wspieraneRozszerzeniaVideo = new List<String>();

        public static void zapiszUstawienia()
        {
            if (System.IO.File.Exists(@"C:\museSort\config.xml"))
            {
                System.IO.File.Delete(@"C:\museSort\config.xml");
            }
            XmlDocument plikXML = new XmlDocument();
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            XmlElement main = plikXML.CreateElement("body");
            XmlElement mainFolder = plikXML.CreateElement("folderGlowny");
            XmlText wartosc = plikXML.CreateTextNode(folderGlowny);
            mainFolder.AppendChild(wartosc);
            main.AppendChild(mainFolder);
            XmlElement defaultSort = plikXML.CreateElement("domyslneSortowanie");
            wartosc = plikXML.CreateTextNode(domyslneSortowanie);
            defaultSort.AppendChild(wartosc);
            main.AppendChild(defaultSort);
            XmlElement defaultDateBase = plikXML.CreateElement("domyslnaBazaDanych");
            wartosc = plikXML.CreateTextNode(domyslnaBazaDanych);
            defaultDateBase.AppendChild(wartosc);
            main.AppendChild(defaultDateBase);

            foreach(String s in wspieraneRozszerzeniaAudio)
            {
                XmlElement audio = plikXML.CreateElement("rozszerzenieAudio");
                wartosc = plikXML.CreateTextNode(s);
                audio.AppendChild(wartosc);
                main.AppendChild(audio);
            }

            foreach (String s in wspieraneRozszerzeniaVideo)
            {
                XmlElement video = plikXML.CreateElement("rozszerzenieVideo");
                wartosc = plikXML.CreateTextNode(s);
                video.AppendChild(wartosc);
                main.AppendChild(video);
            }

            plikXML.AppendChild(main);
            plikXML.Save(@"C:\museSort\config.xml");
        }

        public static void wczytajUstawienia()
        {
            XmlDocument plikXML = new XmlDocument();
            plikXML.Load(@"C:\museSort\config.xml");
            XmlNode node = plikXML.GetElementsByTagName("folderGlowny").Item(0);
            folderGlowny = node.InnerText;
            node = plikXML.GetElementsByTagName("domyslneSortowanie").Item(0);
            domyslneSortowanie = node.InnerText;
            node = plikXML.GetElementsByTagName("domyslnaBazaDanych").Item(0);
            domyslnaBazaDanych = node.InnerText;
            XmlNodeList lista = plikXML.GetElementsByTagName("rozszerzenieAudio");
            foreach (XmlNode x in lista)
            {
                wspieraneRozszerzeniaAudio.Add(x.InnerText);
            }
            lista = plikXML.GetElementsByTagName("rozszerzenieVideo");
            foreach (XmlNode x in lista)
            {
                wspieraneRozszerzeniaVideo.Add(x.InnerText);
            }
        }
    }
}
