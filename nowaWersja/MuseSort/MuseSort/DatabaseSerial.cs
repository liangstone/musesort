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
    public partial class DatabaseSerial : Form
    {
        public DatabaseSerial()
        {
            InitializeComponent();
            serialePanel.Visible = false;
        }

        private void wrocButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseStart().ShowDialog();
        }

        private void serialeButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void odcinkiButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void sezonyButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void datyButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
        }
    }
}
