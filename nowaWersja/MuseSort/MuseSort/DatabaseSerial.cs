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
    public partial class DatabaseSerial : Form
    {
        //do ponownego merga
        SqlCeConnection conn;
        public DatabaseSerial()
        {
            InitializeComponent();
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            serialePanel.Visible = false;
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
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select ID, Tytul_Odcinka, Tytul_Serialu, Rezyseria," +
                "Produkcja, Data_Premiery, Numer_Sezonu, Numer_Odcinka, Ogladalnosc_Odcinka, Sciezka, czyOgladniete AS Obejrzane from Seriale", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Seriale");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Seriale";
                tabela.Columns[10].ReadOnly = true;
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

        private void serialeButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select count(Tytul_Serialu) AS Ilosc_Odcinkow," +
                "Tytul_Serialu from Seriale GROUP BY Tytul_Serialu ORDER BY Ilosc_Odcinkow", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Seriale");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Seriale";
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

        private void odcinkiButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            usunButton.Show();
            dodajButton.Show();
            edytujButton.Show();
            refresh();
        }

        private void sezonyButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            usunButton.Hide();
            dodajButton.Hide();
            edytujButton.Hide();
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select Tytul_Serialu, Numer_Sezonu from Seriale ORDER BY Tytul_Serialu", conn);
                DataSet ds = new DataSet();
                conn.Open();
                dataadapter.Fill(ds, "Seriale");
                conn.Close();
                tabela.DataSource = ds;
                tabela.DataMember = "Seriale";
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

        private void datyButton_Click(object sender, EventArgs e)
        {
            new DatySeriali().ShowDialog();
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                String id = wiersz.Cells[0].Value.ToString();

                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                try
                {
                    SqlCeCommand Query = new SqlCeCommand("DELETE FROM Seriale WHERE ID=" + id, conn);

                    Query.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Usunąc możesz tylko wpis w widoku z odcinkami");
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
            serialePanel.Visible = true;
            new DodawanieSeriali().ShowDialog();
            refresh();
        }

        private void edytujButton_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow wiersz = tabela.SelectedRows[0];
                int id = Convert.ToInt32(wiersz.Cells[0].Value.ToString());
                String tytulOdcinka = wiersz.Cells[1].Value.ToString();
                String tytulSerialu = wiersz.Cells[2].Value.ToString();
                String rez = wiersz.Cells[3].Value.ToString();
                String prod = wiersz.Cells[4].Value.ToString();
                String data = wiersz.Cells[5].Value.ToString();
                int numerSez = Convert.ToInt32(wiersz.Cells[6].Value.ToString());
                int numerOdc = Convert.ToInt32(wiersz.Cells[7].Value.ToString());
                int ogl = Convert.ToInt32(wiersz.Cells[8].Value.ToString());
                String sciezka = wiersz.Cells[9].Value.ToString();
                Boolean czyOgl = Convert.ToBoolean(wiersz.Cells[10].Value.ToString());

                new DodawanieSeriali(id, tytulOdcinka, tytulSerialu, rez, prod, data, numerSez, numerOdc, ogl, sciezka, czyOgl).ShowDialog();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kliknij w pole po lewej stronie wiersza, aby go zaznaczyc do edycji");
            }
        }
    }
}
