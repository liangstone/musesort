using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;

namespace MuseSort
{
    class Crawler
    {
        //pobiera i zapisuje dane do tagów, zwraca true jeśli się powiodło, pobrało coś
        bool PobierzDane(Utwor utwor) 
        {
            //Sprawdzenie czy jest połączenie z internetem
            bool Polaczony = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            //Zakończ jeżeli nie ma połączenia lub czego dodać do tagów
            if (!Polaczony && utwor.dane.album != "") return false;

            try
            {
                WebClient klient = new WebClient();
                klient.Encoding = Encoding.UTF8;
                string content = utwor.dane.tytul.Replace(" ","+");
                content = klient.DownloadString("http://www.lastfm.pl/music/" + utwor.dane.wykonawca + "/_/" + content);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content);
                IEnumerable<HtmlNode> links = from span in doc.DocumentNode.Descendants("span").Where(x => x.Attributes["itemprop"] != null && x.Attributes["itemprop"].Value == "inAlbum")
                                              from meta in span.Descendants("meta")
                                              where meta.Attributes["itemprop"] != null && meta.Attributes["itemprop"].Value == "name"
                                              select meta;
                utwor.dane.album = links.ElementAt<HtmlNode>(0).Attributes["content"].Value.Trim();
            }
            catch 
            {
                return false;
            }
            //zapisanie pobranych tagów
            utwor.zapiszTagi();
            return true;
        }
    }
}
