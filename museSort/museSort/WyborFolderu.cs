using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace museSort
{
    public partial class WyborFolderu : Form
    {
        private FolderBrowserDialog explorer;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };
        private bool stop = false;

        public WyborFolderu()
        {
            explorer = new FolderBrowserDialog();

            InitializeComponent();

            format_box.SelectedIndex = 0;
            format_box.DropDownStyle = ComboBoxStyle.DropDownList;
            schemat_box.SelectedIndex = 0;
            schemat_box.DropDownStyle = ComboBoxStyle.DropDownList;
            schemat_box.DropDownWidth = DropDownWidth(schemat_box);
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
            progress.Value = 0;
            zamknij_button.Enabled = false;
            wykonaj_button.Enabled = false;
            lista_plikow_box.Items.Clear();
            utwor tmp_utwor;
            String sciezka;
            Queue<String> tmp_sciezka = new Queue<string>();if(!Directory.Exists(sciezka_box.Text))                            //sprawdz czy podana sciezka jest poprawna
            {
                MessageBox.Show("Podano nieprawidlowa sciezke folderu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                zamknij_button.Enabled = true;
                wykonaj_button.Enabled = true;
                return;
            }
            else if(Directory.GetLogicalDrives().Contains(sciezka_box.Text))
            {
                DialogResult dr = MessageBox.Show("Czy jestes pewien przeszukiwania zawartosci calego dysku?\n"
                + "Moze to potrwac bardzo dlugo, a nawet zawiesic program.\n", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }
            else
            {
                /*Nie widziałem pliku xml, więc nie wiem, skąd pobrać schemat
                String tmp = sciezka_box.Text + "\\" + "struktura_logiczna.xml";
                if (File.Exists(@"" + tmp))           //ostrzeżenie przed zmianą schematu
                {
                    XmlDocument plikXML = new XmlDocument();
                    plikXML.Load(tmp);
                    //mozna w tym komunikacie dodac jaka jest aktualna sciezka
                    DialogResult wynik = MessageBox.Show("Czy chcesz zmienić sposób dotychczasowego sortowania?", "", MessageBoxButtons.YesNo);
                    if(wynik = DialogResult.No)
                    {
                        return;
                    }
                }
                */
                int ilosc_plikow=0;
                tmp_sciezka.Enqueue(sciezka_box.Text);                              //dodaj sciezke
                while (tmp_sciezka.Count > 0 && !stop)                              //zliczenie plików
                {
                    sciezka = tmp_sciezka.Dequeue();
                    try
                    {
                        foreach (String s in Directory.GetDirectories(@"" + sciezka))   //pobierz podfolderyfoldery ze sciezki
                        {
                            tmp_sciezka.Enqueue(s);
                        }
                    }
                    catch (Exception exc) { }

                    foreach (String rozszerzenie in wspierane_rozszerzenia)     //stworz utwor i dodaj jego nazwe do wyswietlenia
                    {
                        ilosc_plikow += Directory.GetFiles(@"" + sciezka, "*." + rozszerzenie).Length;
                    }
                }
                progress.Maximum = ilosc_plikow;
                tmp_sciezka.Enqueue(sciezka_box.Text);                              //dodaj sciezke
                while (tmp_sciezka.Count > 0 && !stop)
                {
                    sciezka = tmp_sciezka.Dequeue();
                    try
                    {
                        foreach (String s in Directory.GetDirectories(@"" + sciezka))   //pobierz podfolderyfoldery ze sciezki
                        {
                            tmp_sciezka.Enqueue(s);
                        }
                    }
                    catch (Exception exc) { }

                    foreach (String rozszerzenie in wspierane_rozszerzenia)     //stworz utwor i dodaj jego nazwe do wyswietlenia
                    {
                        try
                        {
                            foreach (String plik in Directory.GetFiles(@"" + sciezka, "*." + rozszerzenie))
                            {
                                progress.Value++;
                                tmp_utwor = new utwor(plik);
                                lista_plikow_box.Items.Add(tmp_utwor.nazwa);
                                lista_plikow_box.Refresh();
                            }
                        }
                        catch (Exception exc) { }
                    }
                }
            }
            progress.Value = progress.Maximum;
            MessageBox.Show("Pomyślnie posortowano pliki.", "", MessageBoxButtons.OK);
            zamknij_button.Enabled = true;
            wykonaj_button.Enabled = true;
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

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

    }
}
