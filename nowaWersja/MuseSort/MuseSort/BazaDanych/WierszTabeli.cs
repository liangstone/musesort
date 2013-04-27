using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MuseSort
{

    class WierszTabeli
    {
        #region Pola publiczne i akcesory

        /// <summary>Zawiera nazwę tabeli, do której należy wiersz.</summary>
        public readonly string NazwaTabeli;

        /// <summary>Akcesor dający dostęp do zawartości poprzez nazwę kolumny.</summary>
        /// <returns>Zawartośc danego wiersza dla danej kolumny.</returns>
        public Object this[string nazwaKolumny]
        {
            get
            {
                return zawartosc[nazwaKolumny];
            }
            set
            {
                zawartosc[nazwaKolumny] = value;
            }
        }

        /// <summary>Zawiera tablicę nazw kolumn.</summary>
        public string[] NazwyKolumn
        {
            get { return zawartosc.Keys.ToArray(); }
        }

        /// <summary>Zawiera wartości posczególnych kolumn dla tego wiersza. 
        /// Kolejność jest nieokreślona, ale taka sama jak odpowiednich kolumn w <see cref="NazwyKolumn"/></summary>
        public Object[] Wartosci
        {
            get
            {
                return zawartosc.Values.ToArray();
            }
        }

        #endregion

        #region Konstruktory

        /// <summary>Tworzy pusty WierszTabeli dla tabeli o podanej nazwie.
        /// Pobiera z bazy danych informacje o kolumnach.</summary>
        public WierszTabeli(string nazwaTabeli)
        {
            //Sprawdzamy, czy mamy w cache 
            if (!nazwyKolumnDict.Keys.Contains(nazwaTabeli))
                nazwyKolumnDict.Add(nazwaTabeli, new BazaDanychSqlServerCE().getNazwyKolumn(nazwaTabeli));

            string[] nazwy = nazwyKolumnDict[nazwaTabeli];
            if (nazwy == null)
                throw new ArgumentException("Nieprawidłowa nazwa tabeli: " + nazwaTabeli);

            this.NazwaTabeli = nazwaTabeli;
            this.zawartosc = new Dictionary<string, object>();
            for (int i = 0; i < nazwy.Length; i++)
            {
                this.zawartosc.Add(nazwy[i], null);
            }
        }

        /// <summary>Tworzy WierszTabeli na podstawie DataRow.</summary>
        public WierszTabeli(DataRow wiersz)
        {
            this.NazwaTabeli = wiersz.Table.TableName;
            DataColumnCollection kolumny = wiersz.Table.Columns;
            this.zawartosc = new Dictionary<string, object>();
            foreach (DataColumn kolumna in kolumny)
            {
                zawartosc.Add(kolumna.ColumnName, wiersz[kolumna]);
            }
        }

        /// <summary>Tworzy nowy WierszTabeli będący kopią podanego.</summary>
        public WierszTabeli(WierszTabeli wiersz)
        {
            this.NazwaTabeli = wiersz.NazwaTabeli;
            this.zawartosc = new Dictionary<string, object>(wiersz.zawartosc);
        }

        #endregion

        #region Metody publiczne

        public override string ToString()
        {
            return NazwaTabeli + '\n'
                + string.Join(", ", NazwyKolumn) + '\n'
                + string.Join(", ", Wartosci);

        }

        #endregion


        #region Pola i metody prywatne

        Dictionary<string, Object> zawartosc;
        static volatile Dictionary<string, string[]> nazwyKolumnDict = new Dictionary<string, string[]>();

        #endregion

    }
}
