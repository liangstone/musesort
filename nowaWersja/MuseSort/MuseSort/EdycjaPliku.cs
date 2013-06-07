using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuseSort
{
    public partial class EdycjaPliku : Form
    {
        //do ponownego merga
        Utwor daneWejsciowe;
        Utwor dane;
        Boolean zapisane;
        String sciezka;
        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################

        public EdycjaPliku(String path)
        {
            sciezka = path;
            dane = new Utwor(sciezka);
            daneWejsciowe = new Utwor(sciezka);
            InitializeComponent();

            wypelnijPola(dane);
            rozszerzenieBox.Enabled = false;
            zapiszButton.Enabled = false;
            przwrocButton.Enabled = false;
            zapisane = true;
        }

        #endregion
        #region prywatne metody klas
        //######################################METODY POMOCNICZE KLASY######################################

        private void zapiszClick(object sender, EventArgs e)
        {
            UInt32.TryParse(rokWydaniaBox.Text, out dane.dane.rok);
            UInt32.TryParse(numerBox.Text, out dane.dane.numer);
            dane.dane.tytul = tytulBox.Text;
            dane.dane.album = albumBox.Text;
            dane.dane.wykonawca = wykonawcaBox.Text.Split(new string[] { ", ","," }, StringSplitOptions.None);
            dane.dane.gatunek = gatunekBox.Text.Split(new string[] { ", ","," }, StringSplitOptions.None);

            dane.zapiszTagi();
            zapiszButton.Enabled = false;
            zapisane = true;
        }

        private void zamknijClick(object sender, EventArgs e)
        {
            if (!zapisane)
            {
                var wybor = MessageBox.Show("Masz niezapisane zmiany. Czy chesz je zapisać?", "Uwaga!", MessageBoxButtons.YesNoCancel);
                if (wybor == DialogResult.Yes)
                {
                    zapiszButton.PerformClick();
                }
                else if(wybor == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.Close();
        }

        private void przywrocClick(object sender, EventArgs e)
        {
            daneWejsciowe.zapiszTagi();
            wypelnijPola(daneWejsciowe);
            zapiszButton.Enabled = false;
            przwrocButton.Enabled = false;
            zapisane = true;
        }

        private void wypelnijPola(Utwor dane)
        {
            tytulBox.Text = dane.dane.tytul;
            albumBox.Text = dane.dane.album;
            rokWydaniaBox.Text = dane.dane.rok.ToString();
            numerBox.Text = dane.dane.numer.ToString();
            rozszerzenieBox.Text = System.IO.Path.GetExtension(sciezka);
            wykonawcaBox.Text = "";
            foreach (String s in dane.dane.wykonawca)
            {
                wykonawcaBox.Text += s + ", ";
            }
            wykonawcaBox.Text = wykonawcaBox.Text.Substring(0, wykonawcaBox.Text.Length - 2);
            gatunekBox.Text = "";
            foreach (String s in dane.dane.gatunek)
            {
                gatunekBox.Text += s + ", ";
            }
            if (gatunekBox.Text.Length > 0)
            {
                gatunekBox.Text = gatunekBox.Text.Substring(0, gatunekBox.Text.Length - 2);
            }
        }

        //Wykrywanie zmian w poalch tekstowych
        private void tytulTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void wykonawcaTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void albumTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void rokTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void gatunekTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void numerTextChanged(object sender, EventArgs e)
        {
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = true;
            zapisane = false;
        }
        #endregion
    }
}
