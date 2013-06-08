using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    public class DaneFilmu : Dane
    {
        //do ponownego merga
        public String tytul = "";
        public String gatunki = "";
        public String opis = "";
        public String jezyk = "";
        public String rezyser = "";
        public String aktorzy = "";
        //public uint rok;

        public DaneFilmu() {}

        public DaneFilmu(Dictionary<string, string> dictionary)
        {
            ZapiszDopasowaneDane(dictionary);
        }

        public void ZapiszDopasowaneDane(Dictionary<string, string> dopasowanie)
        {
            foreach (var tag in dopasowanie.Keys)
            {
                var wartosc = dopasowanie[tag];
                switch (tag)
                {
                    /*case "rok":
                        if (rok == 0)
                            rok = UInt32.Parse(wartosc);
                        break;*/
                    case "tytul":
                        if (tytul == "")
                            tytul = wartosc;
                        break;
                    case "gatunek":
                        if (gatunki == "")
                            gatunki = wartosc;
                        break;
                    case "opis":
                        if (opis == "")
                            opis = wartosc;
                        break;
                    case "jezyk":
                        if (jezyk == "")
                            jezyk = wartosc;
                        break;
                    case "rezyser":
                        if (rezyser == "")
                            rezyser = wartosc;
                        break;
                    case "aktorzy":
                        if (aktorzy == "")
                            aktorzy = wartosc;
                        break;
                }
            }
        }
    }
}
