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
    public partial class DatabaseMuzyka : Form
    {
        //do ponownego merga
        SqlCeConnection conn;

        public DatabaseMuzyka()
        {
            InitializeComponent();
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
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
            usunButton.Show();
            dodajButton.Show();
            edytujButton.Show();
            refresh();
        }

        private void refresh()
        {
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select * FROM Muzyka", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Muzyka");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Muzyka";
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

        

        private void gatunkiButton_Click(object sender, EventArgs e)
        {
            muzykaPanel.Visible = true;
            //WierszTabeli x = new WierszTabeli("Muzyka");
            dodajButton.Hide();
            usunButton.Hide();
            edytujButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select count (gatunek) AS ilosc_piosenek, Gatunek FROM Muzyka group by Gatunek order by ilosc_piosenek", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Muzyka");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Muzyka";
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

        private void wykonawcyButton_Click(object sender, EventArgs e)
        {
            muzykaPanel.Visible = true;
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select count(Tytul) AS ilosc_piosenek,Wykonawca FROM Muzyka group by Wykonawca order by ilosc_piosenek", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Muzyka");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Muzyka";
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
            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                String id = wiersz.Cells[0].Value.ToString();

                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                try
                {
                    SqlCeCommand Query = new SqlCeCommand("DELETE FROM Muzyka WHERE ID=" + id, conn);

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
            
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                 
                String sciezka = explorer.FileName;
                new DodawanieMuzyki(sciezka).ShowDialog();
                
                 refresh();
            }
        }

        private void edytujButton_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                int id = Convert.ToInt32(wiersz.Cells[0].Value.ToString());
                String wyk = wiersz.Cells[1].Value.ToString();
                String tytul = wiersz.Cells[2].Value.ToString();
                String album = wiersz.Cells[3].Value.ToString();
                int rok = Convert.ToInt32(wiersz.Cells[4].Value.ToString());
                String gatunek = wiersz.Cells[5].Value.ToString();
                String sciezka = wiersz.Cells[6].Value.ToString();

                new DodawanieMuzyki(id, wyk, tytul, album, rok, gatunek, sciezka).ShowDialog();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kliknij w pole po lewej stronie wiersza, aby go zaznaczyc do edycji");
            }
            
        }
    }
}
