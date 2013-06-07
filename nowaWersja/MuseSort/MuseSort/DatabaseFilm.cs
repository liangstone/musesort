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
    public partial class DatabaseFilm : Form
    {
        //do ponownego merga
        SqlCeConnection conn;
        public DatabaseFilm()
        {
            InitializeComponent();
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            filmyPanel.Visible = false;
        }

        private void wrocButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseStart().ShowDialog();
        }

        private void refresh()
        {
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select * from Filmy", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Filmy");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Filmy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void filmyButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            usunButton.Show();
            edytujButton.Show();
            dodajButton.Show();
            refresh();
        }

        private void gatunkiButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            usunButton.Hide();
            edytujButton.Hide();
            dodajButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select count (gatunek) AS ilosc_filmow, Gatunek FROM Filmy group by Gatunek order by ilosc_filmow", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Filmy");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Filmy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void produkcjaButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            usunButton.Hide();
            edytujButton.Hide();
            dodajButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select count (produkcja) AS ilosc_filmow, Produkcja FROM Filmy group by Produkcja order by ilosc_filmow", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Filmy");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Filmy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void rokButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select * from Filmy order by rok", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Filmy");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Filmy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;

            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                String id = wiersz.Cells[0].Value.ToString();

                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                try
                {
                    SqlCeCommand Query = new SqlCeCommand("DELETE FROM Filmy WHERE ID=" + id, conn);

                    Query.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wysypalo sie");
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kliknij w pole po lewej stronie wiersza, aby go zaznaczyc do usuniecia");
            }
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
            new DodawanieFilmow().ShowDialog();
        }

        private void edytujButton_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                int id = Convert.ToInt32(wiersz.Cells[0].Value.ToString());
                String tytul = wiersz.Cells[1].Value.ToString();
                String gatunek = wiersz.Cells[2].Value.ToString();
                String prod = wiersz.Cells[3].Value.ToString();
                int rok = Convert.ToInt32(wiersz.Cells[4].Value.ToString());
                String rez = wiersz.Cells[5].Value.ToString();
                String opis = wiersz.Cells[6].Value.ToString();
                String tytory = wiersz.Cells[7].Value.ToString();
                String sciezka = wiersz.Cells[8].Value.ToString();

                new DodawanieFilmow(id, tytul, gatunek, prod, rok, rez, opis, tytory, sciezka).ShowDialog();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kliknij w pole po lewej stronie wiersza, aby go zaznaczyc do edycji");
            }
        }
    }
}
