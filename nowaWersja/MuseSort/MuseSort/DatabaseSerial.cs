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
        SqlCeConnection conn;
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

        private void refresh()
        {
            try
            {
                string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select * from Seriale", conn);
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

        private void serialeButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
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
            refresh();
        }

        private void sezonyButton_Click(object sender, EventArgs e)
        {
            serialePanel.Visible = true;
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
            serialePanel.Visible = true;
            //TODO: obsługa bazy danych
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
    }
}
