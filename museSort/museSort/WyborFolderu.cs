using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace museSort
{
    public partial class WyborFolderu : Form
    {
        private FolderBrowserDialog explorer;
        List<String> lista;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };

        public WyborFolderu()
        {
            explorer = new FolderBrowserDialog();

            InitializeComponent();
        }

        private void wyszukaj_Click(object sender, EventArgs e)                 //wlacza explorera
        {
            explorer.ShowNewFolderButton = false;
            explorer.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezka_box.Text = explorer.SelectedPath;
            }
        }

        private void zamknij_button_Click(object sender, EventArgs e)           //zamknij
        {
            this.Close();   
        }

        private void wykonaj_button_Click(object sender, EventArgs e)           //wyszukaj plikow
        {
            lista = new List<string>();
            utwor tmp_utwor;
            String sciezka;
            Queue<String> tmp_sciezka = new Queue<string>();

            if (!Directory.Exists(sciezka_box.Text))                            //sprawdz czy podana sciezka jest poprawna
            {
                MessageBox.Show("Podano nieprawidlowa sciezke folderu", "", MessageBoxButtons.OK);
            }
            else if(Directory.GetLogicalDrives().Contains(sciezka_box.Text))
            {
                MessageBox.Show("Czy jestes pewien przeszukiwania zawartosci calego dysku?\n"
                + "Moze to potrwac bardzo dlugo, a nawet zawiesic program.\n", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                tmp_sciezka.Enqueue(sciezka_box.Text);                              //dodaj sciezke

                while (tmp_sciezka.Count > 0) 
                {
                    sciezka = tmp_sciezka.Dequeue();      
                    try{
                    foreach (String s in Directory.GetDirectories(@"" + sciezka))   //pobierz podfolderyfoldery ze sciezki
                    {
                        tmp_sciezka.Enqueue(s);
                    }
                    }catch(Exception exc){}

                    foreach (String rozszerzenie in wspierane_rozszerzenia)     //stworz utwor i dodaj jego nazwe do wyswietlenia
                    {
                        try
                        { 
                            foreach (String plik in Directory.GetFiles(@"" + sciezka, "*." + rozszerzenie))
                            {
                                    tmp_utwor = new utwor(plik);        
                                    lista.Add(tmp_utwor.nazwa);
                            }
                        }
                        catch (Exception exc) { }
                    }
                    
                }
                lista_plikow_box.DataSource = lista;                //ustawia tekst do wyswietlenia
            }
        }

        private String[] pobierz_foldery(String sciezka)    //zwraca foldery, do ktorych uzytkownik ma prawo dostepu
        {
            List<String> tmp = new List<string>();
            try
            {
                if (sciezka.Contains("$RECYCLE.BIN")) throw null;
                else foreach (String s in Directory.GetDirectories(@"" + sciezka))       //pobierz foldery ze sciezki
                {
                    foreach (String rozszerzenie in wspierane_rozszerzenia)        //sprawdz czy mozna pobrac pliki
                        Directory.GetFiles(@"" + s, "*." + rozszerzenie);

                    tmp.Add(s);
                }
            }
            catch (Exception exc) { };
            return tmp.ToArray();
        }
    }
}
