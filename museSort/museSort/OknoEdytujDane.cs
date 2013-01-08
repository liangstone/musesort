using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace museSort
{
    public partial class OknoEdytujDane : Form
    {
        utwor plik {get;set;} // plik na którym w danej chwili operujemy
        bool danezmienione = false;

        public OknoEdytujDane()
        {
            InitializeComponent();
        }


        //Otwórz plik
        private void otwoz_plik_button_Click(object sender, EventArgs e)
        {
            //string filepath = "";
            string filter = "Muzyka |";
            foreach (string extension in utwor.wspierane_rozszerzenia)
                filter += "*." + extension + ";";

            openFileDialog1.Filter = filter;
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);  // <--- TODO to powinna być zmienna konfiguracyjna w programie
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                //filepath = openFileDialog1.FileName;
                plik = new utwor(openFileDialog1.FileName);
                plik.pobierz_tagi();
                wczytaj_plik_do_boxow();
            }
                
        }

        // wczytuje odpowiednie informacje do text boxów
        private void wczytaj_plik_do_boxow()
        {

            string temp = "";
            NazwaPlikuBox.Text = System.IO.Path.GetFileNameWithoutExtension(plik.sciezka);//System.IO.Path.GetFileName(current.sciezka)
            TytulBox.Text = plik.tytul;
            temp = plik.wykonawca[0];
            for(int i=1;i<plik.wykonawca.Length;i++)
            {
                temp += ", "+plik.wykonawca[i];
            }
            WykonawcaBox.Text = temp; 
            AlbumBox.Text = plik.album;
            RokWydaniaBox.Text = plik.tagi.Tag.Year.ToString();
            temp = plik.gatunek[0];
            for (int i = 1; i < plik.gatunek.Length; i++)
            {
                temp += ", " + plik.gatunek[i];
            }
            GatunkiBox.Text = temp;
            NrSciezkiBox.Text = plik.numer.ToString();


            AktualizujButton.Enabled = false;
            PrzywrocDomyslneButton.Enabled = false;
            danezmienione = false;
        }

        private void AktualizujButton_Click(object sender, EventArgs e)
        {
            DialogResult potwierdzenie = MessageBox.Show("Czy jesteś pewien, że chcesz zapisać zmiany?","",MessageBoxButtons.YesNo);
            if (potwierdzenie == DialogResult.No)
                wczytaj_plik_do_boxow();
            else
            {
                //--------------------------------------------------------------------- przepisz tekst z boxów do tagów
                plik.nazwa = NazwaPlikuBox.Text + "." + plik.rozszerzenie;
                plik.tytul = TytulBox.Text;
                plik.wykonawca = WykonawcaBox.Text.Split(',');
                foreach (string wykonawca in plik.wykonawca)
                    wykonawca.TrimStart(' ');
                plik.album = AlbumBox.Text;
                plik.gatunek = GatunkiBox.Text.Split(',');
                foreach (string gatunek in plik.gatunek)
                    gatunek.TrimStart(' ');
                plik.numer = int.Parse(NrSciezkiBox.Text);

                plik.zapisz_tagi();
                plik.zmien_nazwe_pliku(System.IO.Path.GetDirectoryName(plik.sciezka)+@"\"+plik.nazwa);
                wczytaj_plik_do_boxow();
                MessageBox.Show("Zmiany zapisane pomyślnie.", "", MessageBoxButtons.OK);
            }
        }

        private void Box_TextChanged(object sender, EventArgs e)
        {
            if (plik == null)
                return;
            AktualizujButton.Enabled = true;
            PrzywrocDomyslneButton.Enabled = true;
            danezmienione = true;
        }


        private void PrzywrocDomyslneButton_Click(object sender, EventArgs e)
        {
            plik.przywroc_stare();
            wczytaj_plik_do_boxow();
        }

        private void ZamknijButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void OknoEdytujDane_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (danezmienione)
            {
                DialogResult potwierdzenie = MessageBox.Show("Zmiany nie zostały zapisane. Czy jesteś pewien, że chcesz wyjść?", "", MessageBoxButtons.YesNo);
                if (potwierdzenie == DialogResult.No)
                    e.Cancel = true;
            }
        }




    }
}
