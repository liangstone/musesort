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
        SqlCeConnection conn;

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
                Utwor x = new Utwor(sciezka);
                String album = "";
                album = x.dane.album;
                String[] wykonawca = {""};
                wykonawca = x.dane.wykonawca;
                uint rok = x.dane.rok;
                String tytul = "";
                tytul = x.dane.tytul;
                String[] gatunek = { "" };
                gatunek = x.dane.gatunek;
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                try
                {
                    SqlCeCommand Query = new SqlCeCommand("INSERT INTO Muzyka " +
                                "(Wykonawca, Tytul, Album, Rok, Gatunek, Sciezka) " +
                                "VALUES (@Wykonawca, @Tytul, @Album, @Rok, @Gatunek, @Sciezka)", conn);

                    Query.Parameters.AddWithValue("@Wykonawca", wykonawca[0]);
                    Query.Parameters.AddWithValue("@Tytul", tytul);
                    Query.Parameters.AddWithValue("@Album", album);
                    Query.Parameters.AddWithValue("@Rok", rok);
                    Query.Parameters.AddWithValue("@Gatunek", gatunek[0]);
                    Query.Parameters.AddWithValue("@Sciezka", sciezka);
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
        }
    }
}
