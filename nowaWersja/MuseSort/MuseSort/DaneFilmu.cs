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
        public String[] gatunki = { "" };
        public String[] dyrektorzy = { "" };
        public uint rok;

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
                    case "rok":
                        if (rok == 0)
                            rok = UInt32.Parse(wartosc);
                        break;
                    case "tytul":
                        if (tytul == "")
                            tytul = wartosc;
                        break;
                    case "dyrektor":
                        if (dyrektorzy[0] == "")
                            dyrektorzy[0] = wartosc;
                        break;
                    case "gatunek":
                        if (gatunki[0] == "")
                            gatunki[0] = wartosc;
                        break;
                }
            }
        }
    }
}
