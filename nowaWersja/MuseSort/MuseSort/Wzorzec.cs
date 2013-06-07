using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MuseSort
{
    public class Wzorzec
    {
        public Regex regex;
        public String wzorzec;
        #region publiczne metody klasy
        //#############################PUBLICZNE METODY KLASY############################################

        public Wzorzec(String nowyRegex, String nowyWzorzec)
        {
            if(nowyRegex==null||nowyWzorzec==null)
                throw new ArgumentNullException();
            if(nowyRegex[0]!='^' || nowyRegex[nowyRegex.Length-1]!='$')
                throw new ArgumentException("Niepoprawny regex: " + nowyRegex + " regexy mają zaczynać się od ^ i kończyć $");
            regex = new Regex(nowyRegex);
            wzorzec = nowyWzorzec;
        }

        //należy tworzyć regexy zaczynające się od ^ i kończące na $
        //aby brać pod uwagę cały łańcuch wejściowy
        public Boolean czyPasuje(String lancuch)
        {
            //Sprawdzanie, czy zmienna lancuch pasuje do regexa
            if (regex == null) return false;
            return regex.IsMatch(lancuch);
        }


        public Dictionary<string, string> Dopasuj(string sciezkaLubNazwa)
        {
            var match = regex.Match(sciezkaLubNazwa);
            return regex.GetGroupNames().SkipWhile(nazwagrupy=>nazwagrupy.Equals("0"))
                        .ToDictionary(nazwaGrupy => nazwaGrupy, nazwaGrupy => match.Groups[nazwaGrupy].Value);
        }
        #endregion
        #region metody pomocnicze klasy
        //######################################METODY POMOCNICZE KLASY######################################
        #endregion
    }
}
