using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace MuseSort
{
    public partial class DodawanieMuzyki : Form
    {
        //do ponownego merga
        String sciezka = "";
        int idPiosenki;
        SqlCeConnection conn;
        public DodawanieMuzyki()
        {
            InitializeComponent();
            updateButton.Hide();
            zapiszButton.Show();
            anulujButton.Show();
        }
        public DodawanieMuzyki(String s)
        {
            InitializeComponent();
            updateButton.Hide();
            zapiszButton.Show();
            anulujButton.Show();
            Utwor x = new Utwor(s);
            String album = "";
            album = x.dane.album;
            String[] wykonawca = { "" };
            wykonawca = x.dane.wykonawca;
            uint rok = x.dane.rok;
            String tytul = "";
            tytul = x.dane.tytul;
            String[] gatunek = { "" };
            gatunek = x.dane.gatunek;

            wykonawcaTextBox.Text = wykonawca[0];
            tytulTextBox.Text = tytul;
            AlbumTextBox.Text = album;
            rokTextBox.Text = rok.ToString();
            gatunekTextBox.Text = gatunek[0];
            sciezka = s;
            
        }

        public DodawanieMuzyki(int id, String wyk, String tyt, String alb, int rok, String gat, String sc)
        {
            InitializeComponent();
            updateButton.Show();
            zapiszButton.Hide();
            anulujButton.Show();
            wykonawcaTextBox.Text = wyk;
            tytulTextBox.Text = tyt;
            AlbumTextBox.Text = alb;
            rokTextBox.Text = rok.ToString();
            gatunekTextBox.Text = gat;
            sciezka = sc;
            idPiosenki = id;

        }

        private void sciezkaButton_Click(object sender, EventArgs e)
        {
            explorer.FileName = sciezka;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezka = explorer.FileName;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {

                SqlCeCommand Query = new SqlCeCommand("UPDATE Muzyka SET " +
                            "Wykonawca = @Wykonawca, Tytul = @Tytul, Album = @Album, Rok = @Rok, Gatunek = @Gatunek," +
                            "Sciezka = @Sciezka WHERE ID = @ID", conn);

                Query.Parameters.AddWithValue("@Wykonawca", wykonawcaTextBox.Text);
                Query.Parameters.AddWithValue("@Tytul", tytulTextBox.Text);
                Query.Parameters.AddWithValue("@Album", AlbumTextBox.Text);
                Query.Parameters.AddWithValue("@Rok", rokTextBox.Text);
                Query.Parameters.AddWithValue("@Gatunek", gatunekTextBox.Text);
                Query.Parameters.AddWithValue("@Sciezka", sciezka);
                Query.Parameters.AddWithValue("@ID", idPiosenki);
                Query.ExecuteNonQuery();
                MessageBox.Show("Pomyslnie edytowana piosenka w bazie danych");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wysypalo sie");
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            this.Dispose();
        }

        private void anulujButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {
                SqlCeCommand Query = new SqlCeCommand("INSERT INTO Muzyka " +
                            "(Wykonawca, Tytul, Album, Rok, Gatunek, Sciezka) " +
                            "VALUES (@Wykonawca, @Tytul, @Album, @Rok, @Gatunek, @Sciezka)", conn);

                Query.Parameters.AddWithValue("@Wykonawca", wykonawcaTextBox.Text);
                Query.Parameters.AddWithValue("@Tytul", tytulTextBox.Text);
                Query.Parameters.AddWithValue("@Album", AlbumTextBox.Text);
                Query.Parameters.AddWithValue("@Rok", rokTextBox.Text);
                Query.Parameters.AddWithValue("@Gatunek", gatunekTextBox.Text);
                Query.Parameters.AddWithValue("@Sciezka", sciezka);
                Query.ExecuteNonQuery();
                MessageBox.Show("Dodano piosenke do bazy danych");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wysypalo sie");
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            this.Dispose();
        }
    }
}
