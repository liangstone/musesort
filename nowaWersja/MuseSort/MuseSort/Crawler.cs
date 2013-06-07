using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Windows.Forms;

namespace MuseSort
{
    class Crawler
    {
        //pobiera i zapisuje dane do tagów, zwraca true jeśli się powiodło, pobrało coś
        bool PobierzDane(Utwor utwor) 
        {
            //Sprawdzenie czy jest połączenie z internetem
            bool Polaczony = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            //Czy pobrano informacje
            bool Pobrano = false;
            //Zakończ jeżeli nie ma połączenia lub czego dodać do tagów
            if (!Polaczony && utwor.dane.album != "") return false;

            WebClient klient = new WebClient();
            klient.Encoding = Encoding.UTF8;
            string content = "";
            try
            {
                content = klient.DownloadString("http://www.lastfm.pl/music/" + utwor.dane.wykonawca[0].Replace(" ", "+") + "/_/" + utwor.dane.tytul.Replace(" ", "+"));
            }
            catch (Exception e)
            {
                MessageBox.Show("HTTP Connection Error: " + e.Message);
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            IEnumerable<HtmlNode> links = from span in doc.DocumentNode.Descendants("span").Where(x => x.Attributes["itemprop"] != null && x.Attributes["itemprop"].Value == "inAlbum")
                                            from meta in span.Descendants("meta")
                                            where meta.Attributes["itemprop"] != null && meta.Attributes["itemprop"].Value == "name"
                                            select meta;
            utwor.dane.album = links.ElementAt<HtmlNode>(0).Attributes["content"].Value.Trim();

            try
            {
                //przejscie na strone albumu
                content = klient.DownloadString("http://www.lastfm.pl/music/" + utwor.dane.wykonawca[0].Replace(" ", "+") + "/" + utwor.dane.album.Replace(" ", "+"));
            }
            catch (Exception e)
            {
                MessageBox.Show("HTTP Connection Error: " + e.Message);
            }
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);

            //pobieranie daty produkcji oraz ilości piosenek w albumie
            links = from dl in doc.DocumentNode.Descendants("dl").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "detail")
                                                from dd in dl.Descendants("dd")
                                                select dd;
            IEnumerable<HtmlNode> linksName = from dl in doc.DocumentNode.Descendants("dl").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "detail")
                    from dt in dl.Descendants("dt")
                    select dt;

            for (int i = 0; i < linksName.Count(); i++)
            {
                string name = linksName.ElementAt<HtmlNode>(i).ToString();
                string[] tmp;
                if (name.Contains("Data wydania") && utwor.dane.rok != null)
                {
                    tmp = links.ElementAt<HtmlNode>(i).ToString().Split(' ');
                    utwor.dane.rok = UInt32.Parse(tmp[tmp.Length - 1]);
                }
                else if (name.Contains("Długość") && utwor.dane.liczbaPiosenek != null)
                {
                    tmp = links.ElementAt<HtmlNode>(i).ToString().Split(' ');
                    utwor.dane.liczbaPiosenek = UInt32.Parse(tmp[0]);
                }
            }

            //pobranie numeru utworu
            links = from tr in doc.DocumentNode.Descendants("tr")
                    where tr.Attributes["itemprop"] != null && tr.Attributes["itemprop"].Value == "tracks"
                    select tr;
            foreach (HtmlNode link in links)
            {
                if (link.SelectSingleNode(".//td[@class='subjectCell']/a/span[@itemprop='name']").InnerText == utwor.dane.tytul)
                {
                    utwor.dane.numer = UInt32.Parse(link.SelectSingleNode(".//td[@class='positionCell']").InnerText);
                }
            }

            utwor.zapiszTagi();
            return Pobrano;
        }
    }
}
