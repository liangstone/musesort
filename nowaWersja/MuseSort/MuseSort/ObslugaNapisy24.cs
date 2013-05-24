using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MuseSort.Pomoce
{
    public class ObslugaNapisy24
    {
        public static void test01()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type: application/x-www-form-urlencoded");
            wc.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.56 Safari/536.5");
            wc.Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            wc.Headers.Add("Accept-Encoding: identity");
            wc.Headers.Add("Accept-Language: en-US,en;q=0.8");
            wc.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");

            // http://napisy24.pl/search.php?str=piotr+dudzik+%B1%EA%E6+%F3%BF%BC%BFd%F3%F3%F3pa
            // piotr dudzik ąęć óżźżdóóópa
            // Console.WriteLine("EscapeDataReplace: " + Uri.EscapeDataString(testString).Replace("%20", "+"));

            string title = "Hobbit";
            string encodedTitle = Uri.EscapeDataString(title).Replace("%20", "+");
            string napisyURL = "http://napisy24.pl/search.php?str=";
            string requestURL = string.Format("{0}{1}", napisyURL, encodedTitle);
            //string response = wc.DownloadString(requestURL);

            // http://napisy24.pl/logowanie/
            // form_logowanieMail=waaaggh&form_logowanieHaslo=d00pad00pa&form_loginZapamietaj=1&postAction=sendLogowanie
            string loginData = @"form_logowanieMail=waaaggh&form_logowanieHaslo=d00pad00pa&form_loginZapamietaj=1&postAction=sendLogowanie";
            string cookie = string.Empty;



            //cookie = wc.ResponseHeaders["Set-Cookie"].ToString();
            //wc.UploadString("http://napisy24.pl/logowanie/", "POST", loginData);
            //wc.Headers.Add("Cookie", cookie);
            //string r1= wc.UploadString("http://napisy24.pl/logowanie/", "POST", loginData);
            //string DocumentText = wc.DownloadString("http://napisy24.pl/download/67682/");


            // The.Hobbit.2012.DVDScr.XVID.AC3.HQ.Hive-CM8.avi

            // Znaleziono 0 filmów dla "wpisz nazwę filmu basfasfdfądź napisów jakich szukasz " 
            // Nie znaleziono wyników 

            // Znaleziono 2 filmów dla "hobbit " 
            // The Hobbit: An Unexpected Journey 
            // Hobbit: Niezwykła podróż, Hobbit: Nieoczekiwana podróż 
            // DVDRip.XviD-RISES
            // 06-04-2013

            // http://napisy24.pl/download/67682/

            CookieAwareWebClient wcc = new CookieAwareWebClient();
            wcc.Headers.Add("Content-Type: application/x-www-form-urlencoded");
            wcc.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.56 Safari/536.5");
            wcc.Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            wcc.Headers.Add("Accept-Encoding: identity");
            wcc.Headers.Add("Accept-Language: en-US,en;q=0.8");
            wcc.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            //string swcc1 = wcc.DownloadString("http://napisy24.pl/logowanie/");
            string swcc2 = wcc.UploadString("http://napisy24.pl/logowanie/", "POST", loginData);
            cookie = wcc.ResponseHeaders["Set-Cookie"].ToString();
            wcc.Headers.Add("Cookie", cookie);
            wcc.DownloadFile("http://napisy24.pl/download/67682/", @"C:\aaa.zip");
            string swcc3 = wcc.DownloadString("http://napisy24.pl/download/67682/");

        }


        public class CookieAwareWebClient : WebClient
        {

            private CookieContainer m_container = new CookieContainer();

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = m_container;
                }
                return request;
            }
        }

    }
}
