using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort.Pomoce
{
    public enum WynikPobieraniaNapisow
    {
        ok = 1,
        error = 2,
        brak = 3
    }
    class ObslugaNapiProjekt
    {
        public static WynikPobieraniaNapisow PobierzNapisy(string path)
        {
            if (path == null || path == string.Empty)
            {
                return WynikPobieraniaNapisow.error;
            }


            CookieAwareWebClient wc = new CookieAwareWebClient();

            // szukanie napisow.
            // http://www.napiprojekt.pl/?dz=20&id=a2dc3159a4f00fdfcb0e1d3c9ff031fd&search=Dragons%20-%20Riders%20of%20Berk%20S01E01%20480p%20PL.avi

            // info o filmie.
            // http://www.napiprojekt.pl/index.php?dz=22&id=a2dc3159a4f00fdfcb0e1d3c9ff031fd&film=Dragons%20-%20Riders%20of%20Berk%20S01E01%20480p%20PL.avi
            // http://www.napiprojekt.pl/index.php?dz=22&id=f2bed6d99e5ecc9d7b2b3cb7c51c273e&film=Dragons%20-%20Riders%20of%20Berk%20S01E01%20480p%20PL.avi
            // http://www.napiprojekt.pl/index.php?dz=22&id=f2bed6d99e5ecc9d7b2b3cb7c51c273e&film=The.Hobbit.2012.DVDScr.XVID.AC3.HQ.Hive-CM8.avi
            // http://www.napiprojekt.pl/index.php?dz=22&id=&film=The.Hobbit.2012.DVDScr.XVID.AC3.HQ.Hive-CM8.avi


            string nazwaPliku = System.IO.Path.GetFileName(path);
            string nazwaEncoded = Uri.EscapeDataString(nazwaPliku);
            string url = "http://www.napiprojekt.pl/index.php?dz=22&id=a2dc3159a4f00fdfcb0e1d3c9ff031fd&film=" + nazwaEncoded;

            string wyszukiwanieResponse = wc.DownloadString(url);
            // NapiProjekt nie znalazł napisów? 
            // To jeszcze nic straconego!

            // http://www.napiprojekt.pl/napisy-29516-Hobbit-Niezwykła-podróż-(2012)
            // http://www.napiprojekt.pl/napisy1,1-dla-29516-Hobbit-Niezwykła-podróż-(2012)

            if (wyszukiwanieResponse.Contains(@"<a href=""napisy1,1-dla-"))
            {
                // <a href="#">katalog.napiprojekt.pl</a>-&gt;<a href="napisy1,1-dla-29516-Hobbit-Niezwykła-podróż-(2012)">napisy</a>
                int start = wyszukiwanieResponse.IndexOf(@"<a href=""napisy1,1-dla-");
                int koniec = wyszukiwanieResponse.IndexOf(@""">napisy</a>");
                string href = wyszukiwanieResponse.Substring(start, koniec - start);

                // problem z ID z zapytania.

                return WynikPobieraniaNapisow.ok;
            }
            if (wyszukiwanieResponse.Contains(@"NapiProjekt nie znalaz"))
            {
                return WynikPobieraniaNapisow.brak;
            }

            return WynikPobieraniaNapisow.error;
        }

        public static WynikPobieraniaNapisow PobierzNapisy(Film film)
        {
            return PobierzNapisy(film.SciezkaZrodlowa);
        }
    }
}
