using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace MuseSort
{
    public class UstawieniaProgramu
    {
        //do ponownego merga
        private static volatile UstawieniaProgramu instancja;
        public String folderGlowny;
        public String domyslneSortowanie;
        public String domyslnaBazaDanych;
        public List<String> wspieraneRozszerzeniaAudio;
        public List<String> wspieraneRozszerzeniaVideo;

        private UstawieniaProgramu()
        {
            wspieraneRozszerzeniaVideo = new List<String>();
            wspieraneRozszerzeniaAudio = new List<String>();
            domyslnaBazaDanych = "";
            domyslneSortowanie = "";
            folderGlowny = "";
        }

        public static UstawieniaProgramu getInstance()
        {
            if (instancja == null)
            {
                instancja = new UstawieniaProgramu();
            }

            return instancja;
        }

        public void zapiszUstawienia()
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

            foreach (Wzorzec s in Utwor.wzorceNazwy)
            {
                XmlElement wzorzec = plikXML.CreateElement("utworWzorzecNazwy");
                XmlElement wz = plikXML.CreateElement("wzorzec");
                wartosc = plikXML.CreateTextNode(s.wzorzec);
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                wz = plikXML.CreateElement("regex");
                wartosc = plikXML.CreateTextNode(s.regex.ToString());
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                main.AppendChild(wzorzec);
            }

            foreach (Wzorzec s in Utwor.wzorceSciezki)
            {
                XmlElement wzorzec = plikXML.CreateElement("utworWzorzecSciezki");
                XmlElement wz = plikXML.CreateElement("wzorzec");
                wartosc = plikXML.CreateTextNode(s.wzorzec);
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                wz = plikXML.CreateElement("regex");
                wartosc = plikXML.CreateTextNode(s.regex.ToString());
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                main.AppendChild(wzorzec);
            }

            foreach (Wzorzec s in Film.wzorceNazwy)
            {
                XmlElement wzorzec = plikXML.CreateElement("filmWzorzecNazwy");
                XmlElement wz = plikXML.CreateElement("wzorzec");
                wartosc = plikXML.CreateTextNode(s.wzorzec);
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                wz = plikXML.CreateElement("regex");
                wartosc = plikXML.CreateTextNode(s.regex.ToString());
                wz.AppendChild(wartosc);
                wzorzec.AppendChild(wz);
                main.AppendChild(wzorzec);
            }

            plikXML.AppendChild(main);
            plikXML.Save(@"C:\museSort\config.xml");
        }

        public void wczytajUstawienia()
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
            Film.wczytajWzorceZPliku(@"C:\museSort\config.xml");
            Utwor.wczytajWzorceZPliku(@"C:\museSort\config.xml");
        }
    }
}
