using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MuseSort
{
    class StaticUtwor
    {
        public static List<Wzorzec> wzorceNazwy = new List<Wzorzec>();
        public static List<Wzorzec> wzorceSciezki = new List<Wzorzec>();

        public static Boolean dodajWzorzec(String wzorzec, String regex, String rodzaj)
        {
            Boolean sukces = sprawdzWzorzec(wzorzec, rodzaj);

            if (sukces)
            {
                Wzorzec nowy = new Wzorzec(regex, wzorzec);
                if (rodzaj == "wzorceNazwy")
                {
                    wzorceNazwy.Add(nowy);
                }
                else if (rodzaj == "wzorceSciezki")
                {
                    wzorceSciezki.Add(nowy);
                }
            }

            return sukces;
        }

        public static Boolean sprawdzWzorzec(String wzorzec, String rodzaj)
        {
            List<Wzorzec> wzorce;
            if (rodzaj == "WzorceNazwy")
            {
                wzorce = wzorceNazwy;
            }
            else
            {
                wzorce = wzorceSciezki;
            }

            foreach (Wzorzec wzor in wzorce)
            {
                if (wzor.czyPasuje(wzorzec))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
