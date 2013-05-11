using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseSort
{
    //Klasa implementująca powinna zawierać obiekt o nazwie plik (typu file), do którego będą wyszukiwane tagi
    //Klasa implementująca powinna zawierać również obiekt tagi typu Dane (instancja klasy Dane)
    //Konstruktor klasy imlementującej powinien przyjmować argument String ze ścieżką do pliku
    interface BazaDanychMuzyka
    {
        //Metoda sprawdzająca, czy istnieje możliwość połączenia z bazą, zwraca true w przypadku udanego połączenia
        Boolean sprawdzPolaczenie();
        //Metoda pobierająca dane z serwera, zapisuje je do obiektu tagi i zwraca ten obiekt
        DaneUtworu pobierzDaneZSerwera();
        //dodatkowo powinny zostać zaimplementowane prywatne metody:
        //Przetwarzanie pliku do wysłania na serwer
        //private void PrzygotujPlikDowyslania()
        //Metoda przetwarzająca zapytania do bazy danych, jeśli potrzebne, należy zdefiniować klasę przechowującą wyniki zapytań
        //private <<klasa metadanych dla bazy>> query(String tresc);
    }
}
