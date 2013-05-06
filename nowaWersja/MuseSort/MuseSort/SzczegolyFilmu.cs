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
    public partial class SzczegolyFilmu : Form
    {
        public SzczegolyFilmu(String x)
        {
            InitializeComponent();
            x = x.Replace(" ", ".");
            x = x.Replace("ą", "a");
            x = x.Replace("ć", "c");
            x = x.Replace("Ć", "C");
            x = x.Replace("ę", "e");
            x = x.Replace("ł", "l");
            x = x.Replace("Ł", "L");
            x = x.Replace("ń", "n");
            x = x.Replace("ó", "o");
            x = x.Replace("Ó", "O");
            x = x.Replace("ś", "s");
            x = x.Replace("Ś", "S");
            x = x.Replace("ź", "z");
            x = x.Replace("Ź", "Z");
            x = x.Replace("ż", "z");
            x = x.Replace("Ż", "Z");
            pobierzdane(x);
        }
        private void pobierzdane(String x)
        {
            WebClient klient = new WebClient();
            Console.WriteLine("Pobieram ilosc produktow...");
            klient.Encoding = Encoding.UTF8;
            string content = "";
            try
            {
                content = klient.DownloadString("http://www.filmweb.pl/" + x);
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
                                          where link.Name == "div" && link.Attributes["class"] != null && link.Attributes["class"].Value == "filmPlot"
                                          select link;
            string tresc = links.ElementAt<HtmlNode>(0).InnerText;
            tresc = tresc.Replace("oacute;", "ó");
            label1.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "div" && link.Attributes["class"] != null && link.Attributes["class"].Value == "filmTime"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label2.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "div" && link.Attributes["class"] != null && link.Attributes["class"].Value == "communityRate"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label3.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                          where link.Name == "span" && link.Attributes["id"] != null && link.Attributes["id"].Value == "filmPremiereWorld"
                          select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label4.Text = tresc;
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "div" && link.Attributes["id"] != null && link.Attributes["id"].Value == "filmTitle"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            label5.Text = tresc;
            
            links = from link in doc.DocumentNode.Descendants()
                    where link.Name == "div" && link.Attributes["class"] != null && link.Attributes["class"].Value == "filmPosterBox"
                    select link;
            tresc = links.ElementAt<HtmlNode>(0).InnerText;
            //MessageBox.Show(tresc);
            String [] temp = tresc.Split('"');
            //MessageBox.Show(temp[1]);
            Poster.Load(temp[1]);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
