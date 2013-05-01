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
    public partial class DatabaseFilm : Form
    {
        public DatabaseFilm()
        {
            InitializeComponent();
            filmyPanel.Visible = false;
        }

        private void wrocButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseStart().ShowDialog();
        }

        private void filmyButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void gatunkiButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void produkcjaButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void rokButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            //TODO: obsługa bazy danych
        }
    }
}
