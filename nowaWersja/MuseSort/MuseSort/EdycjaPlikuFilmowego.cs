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
    public partial class EdycjaPlikuFilmowego : Form
    {
        Film daneWejsciowe;
        Film dane;
        Boolean zapisane;
        String sciezka;

        public EdycjaPlikuFilmowego(String path)
        {
            sciezka = path;
            dane = new Film(sciezka);
            daneWejsciowe = new Film(sciezka);
            InitializeComponent();

            wypelnijPola(dane);
            rozszerzenieBox.Enabled = false;
            zapiszButton.Enabled = true;
            przwrocButton.Enabled = false;
            zapisane = true;
        }

        private void przwrocButton_Click(object sender, EventArgs e)
        {
            daneWejsciowe.zapiszTagi();
            wypelnijPola(daneWejsciowe);
            przwrocButton.Enabled = false;
            zapisane = true;
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            dane.dane.tytul = tytulBox.Text;
            dane.dane.rezyser = rezyserBox.Text;
            dane.dane.jezyk = jezykBox.Text;
            dane.dane.aktorzy = aktorzyBox.Text;
            dane.dane.gatunki = gatunkiBox.Text;
            dane.dane.opis = opisBox.Text;

            dane.zapiszTagi();
            zapisane = true;
        }

        private void zamknijButton_Click(object sender, EventArgs e)
        {
            if (!zapisane)
            {
                var wybor = MessageBox.Show("Masz niezapisane zmiany. Czy chesz je zapisać?", "Uwaga!", MessageBoxButtons.YesNoCancel);
                if (wybor == DialogResult.Yes)
                {
                    zapiszButton.PerformClick();
                }
                else if (wybor == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.Close();
        }

        private void wypelnijPola(Film dane)
        {
            tytulBox.Text = dane.dane.tytul;
            rozszerzenieBox.Text = System.IO.Path.GetExtension(sciezka);
            tytulBox.Text = dane.dane.tytul;
            rezyserBox.Text = dane.dane.rezyser;
            jezykBox.Text = dane.dane.jezyk;
            aktorzyBox.Text =dane.dane.aktorzy;
            gatunkiBox.Text = dane.dane.gatunki;
            opisBox.Text = dane.dane.opis;
        }

        private void rezyserBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void tytulBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void jezykBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void aktorzyBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void gatunkiBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        private void opisBox_TextChanged(object sender, EventArgs e)
        {
            przwrocButton.Enabled = true;
            zapisane = false;
        }

        
    }
}
