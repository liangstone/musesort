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
        public SzczegolyMuzyki(String x)
        {
            InitializeComponent();
            Utwor mojUtwor = new Utwor(x);
            String wykonawca = mojUtwor.dane.wykonawca.First();
            wykonawca = wykonawca.Replace(" ", "_");
            String album = mojUtwor.dane.album;
            album = album.Replace(" ", "_");
            album += "_(album)";
            pobierzdane(wykonawca, album);
        }
        private void pobierzdane(String wykonawca, String album)
        {
            WebClient klient = new WebClient();
            klient.Encoding = Encoding.UTF8;
            string content = "";
            try
            {
                content = klient.DownloadString("http://en.wikipedia.org/wiki/" + album);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("HTTP Connection Error: " + e.Message);
                System.Console.ReadLine();
                System.Environment.Exit(0);
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            IEnumerable<HtmlNode> links = from link in doc.DocumentNode.Descendants()
                                          where link.Name == "th" && link.Attributes["class"] != null && link.Attributes["class"].Value == "summary album"
                                          select link;
            string tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label1.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                        where link.Name == "span" && link.Attributes["class"] != null && link.Attributes["class"].Value == "bday dtstart published updated"
                        select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label2.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "span" && link.Attributes["class"] != null && link.Attributes["class"].Value == "duration"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;

            label3.Text = tresc;


            try
            {
                content = klient.DownloadString("http://fm.tuba.pl/artysta/" + wykonawca);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("HTTP Connection Error: " + e.Message);
                System.Console.ReadLine();
                System.Environment.Exit(0);
            }
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "p"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label5.Text = tresc;
        }
    }
}
