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
        SqlCeConnection conn;
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
            refresh();
        }

        private void gatunkiButton_Click(object sender, EventArgs e)
        {
            filmyPanel.Visible = true;
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
    }
}
