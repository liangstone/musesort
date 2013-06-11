using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseSort;
using MuseSort.Fakes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe.Fakes;


namespace MuseSortTesting
{
	[TestClass]
	public class TestWierszTabeli
	{
		#region Testowanie Konstruktorów
		
		/// <summary>Testuje tworzenie prawidłowego obiektu przez konstruktor z podaniem nazwy tabeli.</summary>
		[TestMethod]
		public void KonstruktorNazwaTabeli()
		{
			using (ShimsContext.Create())
			{
				CreateSchemaInfo();

				var wiersz = new WierszTabeli("NazwaTabeli");
				Assert.AreEqual("NazwaTabeli\nID, StringColumn\n", wiersz.ToString());
				Assert.AreEqual("NazwaTabeli", wiersz.NazwaTabeli);
			}
		}

	    private static ShimWierszTabeli ShimWierszIdColumn()
		{
			return new ShimWierszTabeli
				{
					ItemGetString = nazwaKolumny =>
						{
							switch (nazwaKolumny)
							{
								case "ColumnName":
									return "ID";
								case "DataType":
									return typeof (int);
								default:
									throw new KeyNotFoundException("Nieprawidłowy klucz " + nazwaKolumny);
							}
						}
				};
		}

	    /// <summary>Testuje czy rzuca prawidłowy wyjątek przy niprawidłowej nazwie tabeli.</summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void KonstruktorNazwaTabeliNieprawidlowa()
		{
			using (ShimsContext.Create())
			{
				ShimSqlCeConnection.AllInstances.Open = @this => { };
				ShimBazaDanychSqlServerCE.AllInstances.getSchemaInfoString = (@this, nazwaTabeli) => null;
				new WierszTabeli("NieprawidłowaTabela");
			}
		}

	    /// <summary>Testuje tworzenie prawidłowego obiektu przez konstruktor z podaniem obiektu <see cref="DataRow"/>.</summary>
		[TestMethod]
		public void KonstruktorDataRow()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();
				Assert.AreEqual("NazwaTabeli\nID, StringColumn\n1, Tekst", wiersz.ToString()); 
			}
		}

	    /// <summary>Testuje tworzenie prawidłowej kopii obiektu przez konstruktor.</summary>
		[TestMethod]
		public void KonstruktorWierszTabeli()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();
				var wiersz2 = new WierszTabeli(wiersz);

				Assert.AreEqual(wiersz.ToString(), wiersz2.ToString());
				Assert.AreNotSame(wiersz, wiersz2);
				Assert.AreNotSame(wiersz.Wartosci, wiersz2.Wartosci);
			}
		}

	    #endregion

	    #region Testowanie akcesora przez nazwę kolumny

	    /// <summary>Testuje poprawne działanie indeksera udostępniającego zawartość przez nazwę kolumny.</summary>
		[TestMethod]
		public void AkcesorString()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();

				Assert.AreEqual(1, wiersz["ID"]);
				Assert.AreEqual("Tekst", wiersz["StringColumn"]);

				wiersz["ID"] = 2;
				Object wynik = wiersz["ID"];
				Assert.AreEqual(2, wynik);

				wiersz["StringColumn"] = "Inny tekst";
				Assert.AreEqual("Inny tekst", wiersz["StringColumn"]);
			}
		}

	    /// <summary>Testuje sprawdzanie typów przez indekser udostępniający zawartość przez nazwę kolumny.</summary>
		[TestMethod]
		[ExpectedException(typeof(ArrayTypeMismatchException))]
		public void AkcesorStringTypeCheck()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();
				wiersz["ID"] = "String w miejsce inta";
			}
		}

	    /// <summary>Testuje rzucanie wyjątków przez indekser udostępniający zawartość przez nazwę kolumny 
		/// przy nieprawidłowej nazwie.</summary>
		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void AkcesorStringKeyCheck()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();
				Object o = wiersz["Nieprawidłowy klucz"];
			}
		}

	    #endregion

	    #region Testowanie akcesora przez int

	    /// <summary>Testuje poprawne działanie indeksera udostępniającego zawartość przez indeks kolumny.</summary>
		[TestMethod]
		public void AkcesorInt()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();

				Assert.AreEqual(1, wiersz[0]);
				Assert.AreEqual("Tekst", wiersz[1]);

				wiersz[0] = 2;
				Assert.AreEqual(2, wiersz[0]);

				wiersz[1] = "Inny tekst";
				Assert.AreEqual("Inny tekst", wiersz[1]);
			}
		}

	    /// <summary>Testuje sprawdzanie typów przez indekser udostępniający zawartość przez indeks kolumny.</summary>
		[TestMethod]
		[ExpectedException(typeof(ArrayTypeMismatchException))]
		public void AkcesorIntTypeCheck()
		{
			using (ShimsContext.Create())
			{
				var wiersz = CreateStandardWierszTabeli();

				wiersz[0] = "String w miejsce inta";
			}
		}
	    #endregion

	    #region Metody pomocnicze

	    /// <summary>Testuje rzucanie wyjątków przez indekser udostępniający zawartość przez indeks kolumny 
	    /// przy nieprawidłowym kluczu.</summary>
	    [TestMethod]
	    [ExpectedException(typeof (IndexOutOfRangeException))]
	    public void AkcesorIntIndexBoundary()
	    {
	        using (ShimsContext.Create())
	        {
	            var wiersz = CreateStandardWierszTabeli();
	            Object o = wiersz[2];
	        }
	    }


	    private static WierszTabeli CreateStandardWierszTabeli()
	    {
	        CreateSchemaInfo();
	        var tabela = CreateStandardDataTable();
	        return new WierszTabeli(tabela.Rows[0]);
	    }

	    private static DataTable CreateStandardDataTable()
	    {
	        var tabela = new DataTable("NazwaTabeli");
	        tabela.Columns.Add("ID", typeof (int));
	        tabela.Columns.Add("StringColumn", typeof (string));
	        tabela.Rows.Add(1, "Tekst");
	        return tabela;
	    }

	    private static void CreateSchemaInfo()
	    {
	        ShimSqlCeConnection.AllInstances.Open = @this => { };
	        var mojalista = new List<WierszTabeli>();
	        var shimWiersz = ShimWierszIdColumn();

	        mojalista.Add(shimWiersz);

	        shimWiersz = ShimWierszStringColumn();
	        mojalista.Add(shimWiersz);

	        ShimBazaDanychSqlServerCE.AllInstances.getSchemaInfoString = (@this, nazwaTabeli) => mojalista;
	    }

	    private static ShimWierszTabeli ShimWierszStringColumn()
	    {
	        return new ShimWierszTabeli
	            {
	                ItemGetString = nazwaKolumny =>
	                    {
	                        switch (nazwaKolumny)
	                        {
	                            case "ColumnName":
	                                return "StringColumn";
	                            case "DataType":
	                                return typeof (string);
	                            default:
	                                throw new KeyNotFoundException("Nieprawidłowy klucz " + nazwaKolumny);
	                        }
	                    }
	            };
	    }

	    #endregion

	}
}
