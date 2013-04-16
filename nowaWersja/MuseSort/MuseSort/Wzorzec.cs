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
        public String wzorzec;
        #region publiczne metody klasy
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

		//należy tworzyć regexy zaczynające się od ^ i kończące na $
		//aby brać pod uwagę cały łańcuch wejściowy
        public Boolean czyPasuje(String lancuch)
        {
            Boolean rezultat = false;
            //Sprawdzanie, czy zmienna lancuch pasuje do regexa
            if (regex != null) 
            {
                rezultat = regex.IsMatch(lancuch);
            }
            return rezultat;
        }
        #endregion
        #region metody pomocnicze klasy
        //######################################METODY POMOCNICZE KLASY######################################
        #endregion
    }
}
