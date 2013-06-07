using System;
using System.IO;
using System.Reflection;
namespace MuseSort
{
    public abstract class Dane
    {
        //do ponownego merga
        /// <summary>Generuje ścieżkę dla katalogu na podstawie pól w sortowaniu.</summary>
        /// <param name="plik">Plik, dla którego ma być wygenerowana ścieżka.</param>
        /// <returns>Szukana ścieżka katalogu.</returns>
        public virtual string sciezkaKataloguZPol(string[] kategorie)
        {
            Type typ_utwor = this.GetType();
            string sciezka_katalogu = "";
            

            foreach (string kategoria in kategorie) //tworzymy ścieżkę katalogu docelowego pliku
            {
                string kat = "";
                //Console.WriteLine(kategoria);
                FieldInfo pole = typ_utwor.GetField(kategoria);         //pobiera pole

                if (pole.FieldType.Equals(typeof(String)))				//jeśli pole to String
                    kat = (string)pole.GetValue(this);
                else if (pole.FieldType.Equals(typeof(int)) || pole.FieldType.Equals(typeof(uint)))//jeśli pole to int lub uint
                    kat = Convert.ToString(pole.GetValue(this));
                else if (pole.FieldType.Equals(typeof(string[])))		//jeśli pole to tablica
                {
                    try
                    {
                        kat = ((string[])pole.GetValue(this))[0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        kat = "";
                    }
                }
                
                if (kat==null || kat == "")                                          //jeśli nie udało się pobrać
                {
                    sciezka_katalogu = "";
                    break;
                }
                //kat = ZamienNaWlasciwe(kat);
                System.Console.WriteLine(kat);
                sciezka_katalogu = Path.Combine(sciezka_katalogu, kat);
                //System.Console.WriteLine(sciezka_katalogu);
            }


            return sciezka_katalogu;
        }//end sciezka_z_pol()

    }
}
