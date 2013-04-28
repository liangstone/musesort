using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace MuseSort
{
    class BazaDanychSqlServerCE : MuseSort.IBazaDanych
    {
        static string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";

        #region Metody publiczne

        /// <summary>Tworzy nową instancję i testuje połączenie.</summary>
        public BazaDanychSqlServerCE()
        {
            //Próbne otwarcie połączenia - fail early principle.
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open(); 
            }
        }

        public IList<WierszTabeli> select(WierszTabeli where)
        {
            IList<WierszTabeli> wynik = new List<WierszTabeli>();
            
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand select;
                {
                    string selectText = "SELECT " + string.Join(", ", where.NazwyKolumn)
                    + " FROM " + where.NazwaTabeli + klauzulaWhere(where);
                    select = new SqlCeCommand(selectText, connection);
                }
                connection.Open();
                SqlCeDataReader reader;
                try
                {
                    reader = select.ExecuteReader();
                }
                catch (SqlCeException e)
                {
                    
                    throw new EvaluateException("Wystąpił błąd przy wykonywaniu zapytania " + select.CommandText, e);
                }

                using (DataTable tabela = new DataTable())
                {
                    tabela.Load(reader);
                    foreach (DataRow wiersz in tabela.Rows)
                    {
                        wynik.Add(new WierszTabeli(wiersz));
                    } 
                }

                reader.Close();
            }
            

            return wynik;
        }

        public void delete(WierszTabeli where)
        {

            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand delete = new SqlCeCommand("DELETE FROM " + where.NazwaTabeli + klauzulaWhere(where), connection);
                connection.Open();
                SqlCeTransaction traksakcja = connection.BeginTransaction();

                try
                {
                    delete.ExecuteNonQuery();
                    traksakcja.Commit();
                }
                catch (SqlCeException SQLe)
                {
                    InvalidOperationException e = new InvalidOperationException("Wystąpił błąd przy próbie wykonania polecenia " + delete.CommandText, SQLe);
                    try
                    {
                        traksakcja.Rollback();
                    }
                    catch (InvalidOperationException IOe)
                    {
                        e = new InvalidOperationException("Wstąpił błąd przy próbie cofnięcia transakcji \npo błędzie polecenia " + delete.CommandText, IOe);
                    }
                    throw e;
                }
            }
        }

        public void insert(WierszTabeli nowyWiersz)
        {
            nowyWiersz = opakujWartosci(nowyWiersz);
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand insert = new SqlCeCommand("INSERT INTO " + nowyWiersz.NazwaTabeli 
                    + "(" + string.Join(", ", nowyWiersz.NazwyKolumn) + ") "
                    + " VALUES (" + string.Join(", ",nowyWiersz.Wartosci) + ")"
                    , connection);
                connection.Open();
                SqlCeTransaction traksakcja = connection.BeginTransaction();

                try
                {
                    insert.ExecuteNonQuery();
                    traksakcja.Commit();
                }
                catch (SqlCeException SQLe)
                {
                    InvalidOperationException e = new InvalidOperationException("Wystąpił błąd przy próbie wykonania polecenia " + insert.CommandText, SQLe);
                    try
                    {
                        traksakcja.Rollback();
                    }
                    catch (InvalidOperationException IOe)
                    {
                        e = new InvalidOperationException("Wstąpił błąd przy próbie cofnięcia transakcji \npo błędzie polecenia " + insert.CommandText, IOe);
                    }
                    throw e;
                }

            }
        }

        public void insert(IList<WierszTabeli> noweWiersze)
        {
            if (noweWiersze.Count == 0)
                return;

            IList<WierszTabeli> toInsert = new List<WierszTabeli>();
            foreach(WierszTabeli wiersz in noweWiersze)
                toInsert.Add(opakujWartosci(wiersz));
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand insert = new SqlCeCommand();
                insert.Connection = connection;
                connection.Open();
                SqlCeTransaction traksakcja = connection.BeginTransaction();

                try
                {
                    foreach (WierszTabeli wiersz in toInsert)
                    {
                        insert.CommandText = "INSERT INTO " + wiersz.NazwaTabeli
                        + "(" + string.Join(", ", wiersz.NazwyKolumn) + ") "
                        + " VALUES (" + string.Join(", ", wiersz.Wartosci) + ")";
                        insert.ExecuteNonQuery();
                    }
                    traksakcja.Commit();
                }
                catch (SqlCeException SQLe)
                {
                    InvalidOperationException e = new InvalidOperationException("Wystąpił błąd przy próbie wykonania polecenia " + insert.CommandText, SQLe);
                    try
                    {
                        traksakcja.Rollback();
                    }
                    catch (InvalidOperationException IOe)
                    {
                        e = new InvalidOperationException("Wstąpił błąd przy próbie cofnięcia transakcji \npo błędzie polecenia " + insert.CommandText, IOe);
                    }
                    throw e;
                }

            }

        }

        public void update(WierszTabeli where, WierszTabeli noweDane)
        {
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                SqlCeCommand update = new SqlCeCommand("UPDATE " + noweDane.NazwaTabeli
                    + klauzulaWhere(noweDane).Replace("WHERE", "SET").Replace("(","").Replace(")","")
                    + klauzulaWhere(where)
                    , connection);
                //System.Windows.Forms.MessageBox.Show(update.CommandText);
                connection.Open();
                SqlCeTransaction traksakcja = connection.BeginTransaction();

                try
                {
                    update.ExecuteNonQuery();
                    traksakcja.Commit();
                }
                catch (SqlCeException SQLe)
                {
                    InvalidOperationException e = new InvalidOperationException("Wystąpił błąd przy próbie wykonania polecenia " + update.CommandText, SQLe);
                    try
                    {
                        traksakcja.Rollback();
                    }
                    catch (InvalidOperationException IOe)
                    {
                        e = new InvalidOperationException("Wstąpił błąd przy próbie cofnięcia transakcji \npo błędzie polecenia " + update.CommandText, IOe);
                    }
                    throw e;
                }

            }
        }

        /// <summary>Pobiera z bazy danych informacje o strukturze tabeli.</summary>
        /// <returns>Każdy WierszTabeli w liście zawiera informacje o kolumnie tabeli, 
        /// w kolejności zgodnej z kolejnością kolumn w tabeli.
        /// W przypadku gdy w w bazie tabeli nie znaleziono, zwracany jest null.</returns>
        public List<WierszTabeli> getSchemaInfo(string nazwaTabeli)
        {
            //List<string> _wynik = new List<string>();
            List<WierszTabeli> wynik = new List<WierszTabeli>();
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                SqlCeCommand select = new SqlCeCommand("SELECT * FROM " + nazwaTabeli + " WHERE 0=1", connection);
                SqlCeDataReader reader;
                try
                {
                    reader = select.ExecuteReader();
                }
                catch (SqlCeException)
                {
                    return null;
                }
                

                using (DataTable tabela = reader.GetSchemaTable())
                {
                    foreach (DataRow wiersz in tabela.Rows)
                    {
                        //_wynik.Add(wiersz.Field<string>("ColumnName"));
                        wynik.Add(new WierszTabeli(wiersz));
                    } 
                }
            }

            return wynik;
        }

        #endregion

        static WierszTabeli opakujWartosci(WierszTabeli wiersz)
        {
            WierszTabeli wynik = new WierszTabeli(wiersz);
            foreach (string kolumna in wiersz.NazwyKolumn)
            {
                wynik[kolumna] = opakujWartosc(wiersz[kolumna]);
            }
            return wynik;
        }

        static string opakujWartosc(Object wartosc)
        {
            if (wartosc == null)
                return null;
            if (wartosc.GetType() == typeof(string))
                return "N'" + wartosc.ToString() + "'";
            else
                return wartosc.ToString();
        }

        static string klauzulaWhere(WierszTabeli zapytanie)
        {
            List<string> warunki = new List<string>();
            zapytanie = opakujWartosci(zapytanie);
            foreach (string kolumna in zapytanie.NazwyKolumn)
            {
                if (zapytanie[kolumna] != null)
                {
                    warunki.Add(kolumna + " = " + zapytanie[kolumna]);
                }
            }

            if (warunki.Count == 0)
                return "";
            else
                return " WHERE (" + string.Join(" AND ", warunki) + ")";
        }



    }
}
