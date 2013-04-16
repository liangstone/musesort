using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace MuseSort
{
    public partial class SzczegolyMuzyki : Form
    {
        public SzczegolyMuzyki()
        {
            InitializeComponent();
            pobierzdane();
        }
        private void pobierzdane()
        {
            WebClient klient = new WebClient();
            Console.WriteLine("Pobieram ilosc produktow...");
            klient.Encoding = Encoding.UTF8;
            string content = "";
            try
            {
                content = klient.DownloadString("http://en.wikipedia.org/wiki/Kurt_Cobain");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("HTTP Connection Error: " + e.Message);
                System.Console.ReadLine();
                System.Environment.Exit(0);
            }
            label1.Text = content;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            IEnumerable<HtmlNode> links = from link in doc.DocumentNode.Descendants()
                                          where link.Name == "span" && link.Attributes["dir"] != null && link.Attributes["dir"].Value == "auto"
                                          select link;
            string tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label1.Text = tresc;
        }
    }
}
