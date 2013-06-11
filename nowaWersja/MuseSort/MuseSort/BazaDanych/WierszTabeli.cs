using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MuseSort
{

    public class WierszTabeli
    {
        #region Pola publiczne i akcesory

        /// <summary>Zawiera nazwę tabeli, do której należy wiersz.</summary>
        public readonly string NazwaTabeli;

        /// <summary>Akcesor dający dostęp do zawartości poprzez nazwę kolumny.</summary>
        /// <returns>Zawartośc tego wiersza dla danej kolumny.</returns>
        /// <exception cref="ArrayTypeMismatchException">Rzucane w przypadku próby przypisania wartości niewłaściwego typu.</exception>
        /// <exception cref="KeyNotFoundException">Rzucane w przypadku próby odczytu z kolumny, która nie istnieje.</exception>
        public Object this[string nazwaKolumny]
        {
            get
            {
                try
                {
                    return zawartosc[nazwaKolumny];
                }
                catch (KeyNotFoundException)
                {
                    throw new KeyNotFoundException("W tabeli " + NazwaTabeli + " nie ma kolumny o nazwie " + nazwaKolumny);
                }
            }
            set
            {
                if (value.GetType() != typyKolumn[nazwaKolumny])
                    throw new ArrayTypeMismatchException("Próba przypisania wartości typu " + value.GetType().ToString()
                        + " do kolumny " + nazwaKolumny + " która przechowuje wartości typu " + typyKolumn[nazwaKolumny].ToString());
                zawartosc[nazwaKolumny] = value;
            }
        }

        /// <summary>Akcesor dający dostęp do zawartości przez indeks kolumny.</summary>
        /// <returns>Zawartośc tego wiersza dla danej kolumny.</returns>
        /// <exception cref="ArrayTypeMismatchException">Rzucane w przypadku próby przypisania wartości niewłaściwego typu.</exception>
        /// <exception cref="IndexOutOfRangeException">Rzucane w przypadku próby odczytu z kolumny, która nie istnieje.</exception>
        public Object this[int i]
        {
            get
            {
                string nazwaKolumny = tabele[NazwaTabeli].nazwyKolumn[i];
                try
                {
                    return zawartosc[nazwaKolumny];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException("W tabeli " + NazwaTabeli + " nie ma kolumny o nazwie " + nazwaKolumny, e);
                }
            }
            set
            {
                string nazwaKolumny = tabele[NazwaTabeli].nazwyKolumn[i];
                if (value.GetType() != typyKolumn[nazwaKolumny])
                    throw new ArrayTypeMismatchException("Próba przypisania wartości typu " + value.GetType().ToString()
                        + " do kolumny " + nazwaKolumny + " (indeks " + i + " ) która przechowuje wartości typu " + typyKolumn[nazwaKolumny].ToString());
                zawartosc[nazwaKolumny] = value;
            }
        }

        /// <summary>Zawiera tablicę nazw kolumn.</summary>
        public string[] NazwyKolumn
        {
            get 
            {
                try
                {
                    return tabele[NazwaTabeli].nazwyKolumn;
                }
                catch (KeyNotFoundException) //W przyadku wiersza nie odpowiadającego tabeli (SchemaTable)
                {
                    return zawartosc.Keys.ToArray();
                }
            }
        }

        /// <summary>Zawiera wartości posczególnych kolumn dla tego wiersza. </summary>
        public Object[] Wartosci
        {
            get
            {
                string[] nazwy;
                try
                {
                    nazwy = tabele[NazwaTabeli].nazwyKolumn;
                }
                catch (KeyNotFoundException) //W przyadku wiersza nie odpowiadającego tabeli (SchemaTable)
                {
                    nazwy = zawartosc.Keys.ToArray();
                }
                Object[] wynik = new Object[nazwy.Length];
                for (int i = 0; i < wynik.Length; i++)
                    wynik[i] = zawartosc[nazwy[i]];
                return wynik;
            }
        }

        #endregion

        #region Konstruktory

        /// <summary>Tworzy pusty WierszTabeli dla tabeli o podanej nazwie.
        /// Pobiera z bazy danych informacje o kolumnach i typach danych.</summary>
        public WierszTabeli(string nazwaTabeli)
        {
            
            //Sprawdzamy, czy mamy w cache 
            if (!tabele.Keys.Contains(nazwaTabeli))
            {
                List<WierszTabeli> schemaInfo = new BazaDanychSqlServerCE().getSchemaInfo(nazwaTabeli);
                if(schemaInfo==null)
                    throw new ArgumentException("W bazie danych nie znaleziono tabeli o nazwie " + nazwaTabeli);
                tabele.Add(nazwaTabeli, new SchemaInfo(schemaInfo));
            }

            string[] nazwy = tabele[nazwaTabeli].nazwyKolumn;

            this.NazwaTabeli = nazwaTabeli;
            this.zawartosc = new Dictionary<string, object>();
            this.typyKolumn = tabele[nazwaTabeli].mapaTypow;
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
            this.typyKolumn = new Dictionary<string,Type>();
            foreach (DataColumn kolumna in kolumny)
            {
                zawartosc.Add(kolumna.ColumnName, wiersz[kolumna]);
                typyKolumn.Add(kolumna.ColumnName, kolumna.DataType);
            }

            //Jeśli nie ma jeszcze odpowiedniego SchemaInfo w cache, dodajemy.
            //Nie robimy tego przed utworzeniem this.typyKolumn na wypadek gdybyśmy przekazywali informacje o SchemaTable.
            if (!tabele.Keys.Contains(NazwaTabeli) && NazwaTabeli != "SchemaTable")
            {
                List<WierszTabeli> schemaInfo = new BazaDanychSqlServerCE().getSchemaInfo(NazwaTabeli);
                tabele.Add(NazwaTabeli, new SchemaInfo(schemaInfo));
            }
        }

        /// <summary>Tworzy nowy WierszTabeli będący kopią podanego.</summary>
        public WierszTabeli(WierszTabeli wiersz)
        {
            this.NazwaTabeli = wiersz.NazwaTabeli;
            this.zawartosc = new Dictionary<string, object>(wiersz.zawartosc);
            if (NazwaTabeli == "SchemaTable") //Kopiowany wiersz trzyma informacje o tabeli.
                this.typyKolumn = new Dictionary<string, Type>(wiersz.typyKolumn);
            else //Zwykły wiersz, którego typyKolumn są referencją do wartości w cache.
                this.typyKolumn = wiersz.typyKolumn;
        }

        #endregion

        #region Metody publiczne

        /// <summary>[Overriden] Zwraca string reprezentujący dany wiersz w formacie: <br/>
        /// <para>Nazwa tabeli </para>
        /// <para>Kolumny oddzieone przecinkami</para>
        /// <para>Wartości oddzielone przecinkami w kolejności odpowiadającej kolumnom.</para></summary>
        public override string ToString()
        {
            return NazwaTabeli + '\n'
                + string.Join(", ", NazwyKolumn) + '\n'
                + string.Join(", ", Wartosci);

        }

        #endregion

        #region Pola i metody prywatne

        /// <summary>Klucze - nazwy kolumn, wartości - wartości kolumn.</summary>
        Dictionary<string, Object> zawartosc;

        /// <summary>Klucze - nazwy kolumn, wartości - typy kolumn.</summary>
        Dictionary<string, Type> typyKolumn;

        /// <summary>Cache informacji o strukturach tabel.</summary>
        static volatile Dictionary<string, SchemaInfo> tabele = new Dictionary<string, SchemaInfo>();
        
        /// <summary>Struct służący do przechowywania danych o strukturze tabeli.</summary>
        struct SchemaInfo
        {
            /// <summary>Kolumny w kolejności występowania w tabeli.</summary>
            public readonly string[] nazwyKolumn;

            /// <summary>Mapuje nazwy kolumn do ich typów C#.</summary>
            public readonly Dictionary<string, Type> mapaTypow;

            /// <summary>Bazowy konstruktor wypełniający struct podanymi danymi.</summary>
            public SchemaInfo(string[] nazwyKolumn, Dictionary<string, Type> typyKolumn)
            {
                this.nazwyKolumn = nazwyKolumn;
                this.mapaTypow = new Dictionary<string,Type>(typyKolumn);
            }

            /// <summary>Nowy SchemaInfo na podstawie informacji zwracanej przez IBazaDanych.getSchemaInfo</summary>
            public SchemaInfo(List<WierszTabeli> schemaInfo)
            {
                this.nazwyKolumn = new string[schemaInfo.Count];
                int i = 0;
                this.mapaTypow = new Dictionary<string, Type>();
                foreach(WierszTabeli kolumna in schemaInfo)
                {
                    nazwyKolumn[i] = kolumna["ColumnName"].ToString();
                    mapaTypow.Add(nazwyKolumn[i], (Type) kolumna["DataType"]);
                    i++;
                }
                    
            }

        }

        #endregion

    }
}
