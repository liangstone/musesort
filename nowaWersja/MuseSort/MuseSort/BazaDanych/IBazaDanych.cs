using System;
using System.Collections.Generic;
namespace MuseSort
{
    interface IBazaDanych
    {
        /// <summary>Usuwa z bazy danych rzędy, których wartości w wybranych kolumnach są równe podanym w parametrze.</summary>
        /// <param name="where">
        /// <para>Zawiera wartości, jakie znajdują się w usuwanych rekordach.</para> 
        /// <para>Wartości dla kolumn, dla których nie sprawdzamy wartości mają pozostać jako null.</para>
        /// </param>
        void delete(WierszTabeli where);


        /// <summary>Pobiera informacje o kolumnach danej tabeli w bazie danych.</summary>
        /// <remarks>Skonsultuj się z dokumentacją implementacji w celu uzyskania ściślejszych informacji.</remarks>
        /// <param name="nazwaTabeli">Nazwa tabeli której opis ma być pobrany.</param>
        /// <returns>Każdy WierszTabeli w liście zawiera informacje o kolumnie tabeli, 
        /// w kolejności zgodnej z kolejnością kolumn w tabeli.
        /// W przypadku gdy w w bazie tabeli nie znaleziono, zwracany jest null.</returns>
        List<WierszTabeli> getSchemaInfo(string nazwaTabeli);

        /// <summary>Dodaje podany wiersz do odpowiedniej tabeli.</summary>
        /// <param name="nowyWiersz">Wiersz do dodania.</param>
        void insert(WierszTabeli nowyWiersz);

        /// <summary>Dodaje podane wierse do odpowiedniej tabeli.</summary>
        /// <param name="nowyWiersz">Wiersze do dodania.</param>
        void insert(IList<WierszTabeli> noweWiersze);

        /// <summary>Zmienia dane w rzędach, w których wartości w wybranych kolumnach są równe podanym w parametrze where 
        /// na te podane w parametrze noweDane.</summary>
        /// <param name="where">
        /// <para>Zawiera wartości, jakie znajdują się w zmienianych rekordach.</para> 
        /// <para>Wartości dla kolumn, dla których nie sprawdzamy wartości mają pozostać jako null.</para>
        /// </param>
        /// <param name="noweDane">
        /// <para>Zawiera wartości, jakie znajdą się w zmienianych rekordach.</para> 
        /// <para>Wartości dla kolumn, dla których nie zmianiamy wartości mają pozostać jako null.</para>
        /// </param>
        void update(WierszTabeli where, WierszTabeli noweDane);

        /// <summary>Zwraca listę rekordów, których wartości w wybranych kolumnach są równe podanym w parametrze.</summary>
        /// <param name="where">
        /// <para>Zawiera wartości, jakie znajdują się w zwracanych rekordach.</para> 
        /// <para>Wartości dla kolumn, dla których nie sprawdzamy wartości mają pozostać jako null.</para>
        /// </param>
        /// <returns>Lista rekordów odpowiadających zapytaniu.</returns>
        IList<WierszTabeli> select(WierszTabeli where);
    }
}
