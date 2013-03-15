using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MuseSort
{
    class Wzorzec
    {
        Regex regex;
        String wzorzec;

        //#############################PUBLICZNE METODY KLASY############################################

        public Wzorzec()
        {
            regex = null;
            wzorzec = "";
        }

        public Wzorzec(String nowyRegex, String nowyWzorzec)
        {
            regex = new Regex(nowyRegex);
            wzorzec = nowyWzorzec;
        }

        public Boolean czyPasuje(String lancuch)
        {
            Boolean rezultat = false;
            //Sprawdzanie, czy zmienna lancuch pasuje do regexa
            return rezultat;
        }


        //######################################METODY POMOCNICZE KLASY######################################
    }
}
