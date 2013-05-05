using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MuseSort
{
    [Serializable()]
    public class UlubioneUzytkownika
    {
        public List<string> filmy;
        public List<string> seriale;
        public List<string> muzyka;

        public UlubioneUzytkownika()
        {
            filmy = new List<string>();
            seriale = new List<string>();
            muzyka = new List<string>();
        }

        public UlubioneUzytkownika(string plikZrodlowy)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UlubioneUzytkownika));
            TextReader reader = new StreamReader(plikZrodlowy);
            UlubioneUzytkownika tmp = null;
            try
            {
                tmp = (UlubioneUzytkownika)serializer.Deserialize(reader);
            }
            catch (InvalidCastException)
            {
                System.Windows.Forms.MessageBox.Show("Podany plik " + plikZrodlowy
                    + " nie zawiera poprawnych danych o Ulubionych!");
            }
            catch (InvalidOperationException e)
            {
                System.Windows.Forms.MessageBox.Show("Przy próbie odzczytu pliku " + plikZrodlowy
                    + "wystąpił następujący błąd: \n" + e.Message);
            }
            this.seriale = tmp.seriale;
            this.muzyka = tmp.muzyka;
            this.filmy = tmp.filmy;
        }

        public void zapisz(string plikDocelowy)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            TextWriter writer = new StreamWriter(plikDocelowy);
            serializer.Serialize(writer, this);
            writer.Close();
        }

    }
}
