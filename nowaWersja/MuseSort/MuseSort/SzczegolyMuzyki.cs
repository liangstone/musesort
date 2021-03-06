﻿using System.Windows.Forms;
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
            String wykonawca = "";
            String album = "";
            try
            {
                System.Console.WriteLine(mojUtwor.dane.wykonawca.First() + " " + mojUtwor.dane.album);
                wykonawca = mojUtwor.dane.wykonawca.First();
                wykonawca = wykonawca.Replace(" ", "+");
                wykonawca = wykonawca.ToLower();
                album = mojUtwor.dane.album;
                album = album.Replace(" ", "_");
                //MessageBox.Show(album + wykonawca);
                album += "_(album)";

                pobierzdane(wykonawca, album);
            }
            catch (Exception ex)
            {
                MessageBox.Show("przed wykonaniem musisz wpisać do tagów wykonawcę oraz album");
            }
        }
        private void pobierzdane(String wykonawca, String album)
        {
            WebClient klient = new WebClient();
            klient.Encoding = Encoding.UTF8;
            string content = "";
            string content2 = "";
            try
            {

                content = klient.DownloadString("http://en.wikipedia.org/wiki/" + album);
                //MessageBox.Show("http://en.wikipedia.org/wiki/" + album);
                content2 = klient.DownloadString("http://fm.tuba.pl/artysta/" + wykonawca);
                //MessageBox.Show("http://fm.tuba.pl/artysta/" + wykonawca);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content);
                IEnumerable<HtmlNode> links = from link in doc.DocumentNode.Descendants()
                                              where link.Name == "th" && link.Attributes["class"] != null && link.Attributes["class"].Value == "summary album"
                                              select link;
                string tresc = links.ElementAt<HtmlNode>(0).InnerText;
                //MessageBox.Show(tresc);
                label1.Text = tresc;
                links = from link in doc.DocumentNode.Descendants()
                        where link.Name == "span" && link.Attributes["class"] != null && link.Attributes["class"].Value == "bday dtstart published updated"
                        select link;
                tresc = links.ElementAt<HtmlNode>(0).InnerText;
                //MessageBox.Show(tresc);
                label2.Text = tresc;
                links = from link in doc.DocumentNode.Descendants()
                        where link.Name == "span" && link.Attributes["class"] != null && link.Attributes["class"].Value == "duration"
                        select link;
                tresc = links.ElementAt<HtmlNode>(0).InnerText;
                //MessageBox.Show(tresc);

                label3.Text = tresc;

                links = from link in doc.DocumentNode.Descendants()
                        where link.Name == "a" && link.Attributes["class"] != null && link.Attributes["class"].Value == "image"
                        select link;
                tresc = links.ElementAt<HtmlNode>(0).InnerHtml;
                //MessageBox.Show(tresc);
                String[] temp = tresc.Split('"');
                //MessageBox.Show(temp[3]);
                temp[3] = temp[3].Substring(2);
                //MessageBox.Show(temp[3]);
                cover.Load("http://" + temp[3]);

                doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content2);
                links = from link in doc.DocumentNode.Descendants()
                        where link.Name == "p"
                        select link;
                tresc = links.ElementAt<HtmlNode>(0).InnerText;
                //MessageBox.Show(tresc);
                label5.Text = tresc;
            }
            catch (Exception e)
            {
                MessageBox.Show("Próba znalezienia szczegółów pliku nie powiodła się.");
            }

        }
    }
}
