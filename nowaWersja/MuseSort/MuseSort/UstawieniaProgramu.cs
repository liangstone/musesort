using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;


namespace MuseSort
{
    public class UstawieniaProgramu
    {
        //do ponownego merga
        private static volatile UstawieniaProgramu instancja;
        public String folderGlowny;
        public String domyslneSortowanieMuzyki;
        public List<String> wspieraneRozszerzeniaAudio;
        public List<String> wspieraneRozszerzeniaVideo;
        private bool _ustawieniaWczytane = false;
        public string domyslneSortowanieFilmow;

        private UstawieniaProgramu()
        {
            wspieraneRozszerzeniaVideo = new List<String>();
            wspieraneRozszerzeniaAudio = new List<String>();
            domyslneSortowanieMuzyki = "";
            domyslneSortowanieFilmow = "";
            folderGlowny = "";
            loadLibVlc();
        }

        public static UstawieniaProgramu getInstance()
        {
            if (instancja == null)
            {
                instancja = new UstawieniaProgramu();
            }

            return instancja;
        }

        private void loadLibVlc()
        {
            try
            {
                Vlc.DotNet.Core.VlcContext.LibVlcDllsPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + @"\libraries\libvlc\";
                Vlc.DotNet.Core.VlcContext.LibVlcPluginsPath = Environment.CurrentDirectory.Replace("\\bin\\Debug", "") + @"\libraries\libvlc\plugins\";
                Vlc.DotNet.Core.VlcContext.Initialize();
            }
            catch (Exception e)
            {
                MessageBox.Show("Nastąpił błąd ładowania bibliotek Vlc, nie będzie możliwa obsługa plików video! " + e.Message);
            }
        }

        public void zapiszUstawienia()
        {
            if (System.IO.File.Exists(@"C:\museSort\config.xml"))
            {
                System.IO.File.Delete(@"C:\museSort\config.xml");
            }
            XmlDocument plikXML = KonwertujZawartoscDoXml();
            plikXML.Save(@"C:\museSort\config.xml");
        }

        private XmlDocument KonwertujZawartoscDoXml()
        {
            XmlDocument plikXML= new XmlDocument();
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            plikXML.AppendChild(CreateMainNode(plikXML));
            return plikXML;
        }

        private XmlElement CreateMainNode(XmlDocument document)
        {
            var main = document.CreateElement("body");

            main.AppendChild(GetXmlElementWithTextNode(document, "folderGlowny", folderGlowny));
            main.AppendChild(GetXmlElementWithTextNode(document, "domyslneSortowanieMuzyki", domyslneSortowanieMuzyki));
            main.AppendChild(GetXmlElementWithTextNode(document, "domyslneSortowanieFilmow", domyslneSortowanieFilmow));

            AddListToXmlNode(document, main, "rozszerzenieAudio", wspieraneRozszerzeniaAudio);
            AddListToXmlNode(document, main, "rozszerzenieVideo", wspieraneRozszerzeniaVideo);
            AddListToXmlNode(document, main, "utworWzorzecNazwy", Utwor.wzorceNazwy);
            AddListToXmlNode(document, main, "utworWzorzecSciezki", Utwor.wzorceSciezki);
            AddListToXmlNode(document, main, "filmWzorzecNazwy", Film.wzorceNazwy);

            return main;
        }

        private static void AddListToXmlNode(XmlDocument document, XmlNode node, string nazwa, IEnumerable<string> lista)
        {
            foreach (var zawartosc in lista)
                node.AppendChild(GetXmlElementWithTextNode(document, nazwa, zawartosc));
        }

        private static void AddListToXmlNode(XmlDocument document, XmlNode node, string nazwa, IEnumerable<Wzorzec> lista)
        {
            foreach (var wzorzec in lista)
                node.AppendChild(WzorzecToXml(document, nazwa, wzorzec));
        }

        private static XmlElement WzorzecToXml(XmlDocument document, string nazwa, Wzorzec wzorzec)
        {
            var xmlElement = document.CreateElement(nazwa);
            xmlElement.AppendChild(GetXmlElementWithTextNode(document, "wzorzec", wzorzec.wzorzec));
            xmlElement.AppendChild(GetXmlElementWithTextNode(document, "regex", wzorzec.regex.ToString()));
            return xmlElement;
        }

        private static XmlElement GetXmlElementWithTextNode(XmlDocument document, string nazwa, string zawartosc)
        {
            var xmlElement = document.CreateElement(nazwa);
            xmlElement.AppendChild(document.CreateTextNode(zawartosc));
            return xmlElement;
        }

        public void wczytajUstawienia()
        {
            if(_ustawieniaWczytane)
                return;
            _ustawieniaWczytane = true;
            XmlDocument plikXML = new XmlDocument();
            plikXML.Load(@"C:\museSort\config.xml");
            folderGlowny        = plikXML.GetElementsByTagName("folderGlowny")      .Item(0).InnerText;
            domyslneSortowanieMuzyki = plikXML.GetElementsByTagName("domyslneSortowanieMuzyki").Item(0).InnerText;
            domyslneSortowanieFilmow = plikXML.GetElementsByTagName("domyslneSortowanieFilmow").Item(0).InnerText;
            foreach (XmlNode x in plikXML.GetElementsByTagName("rozszerzenieAudio"))
            {
                wspieraneRozszerzeniaAudio.Add(x.InnerText);
            }
            foreach (XmlNode x in plikXML.GetElementsByTagName("rozszerzenieVideo"))
            {
                wspieraneRozszerzeniaVideo.Add(x.InnerText);
            }
            Film.wczytajWzorceZPliku(@"C:\museSort\config.xml");
            Utwor.wczytajWzorceZPliku(@"C:\museSort\config.xml");
        }
    }
}
