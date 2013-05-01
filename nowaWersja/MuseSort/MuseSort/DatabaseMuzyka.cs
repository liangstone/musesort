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
    public partial class DatabaseMuzyka : Form
    {
        public DatabaseMuzyka()
        {
            InitializeComponent();
            muzykaPanel.Visible = false;
        }

        private void wrocButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseStart().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            muzykaPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void gatunkiButton_Click(object sender, EventArgs e)
        {
            muzykaPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void wykonawcyButton_Click(object sender, EventArgs e)
        {
            muzykaPanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void usunButton_Click(object sender, EventArgs e)
        {

        }

        private void dodajButton_Click(object sender, EventArgs e)
        {

        }
    }
}
