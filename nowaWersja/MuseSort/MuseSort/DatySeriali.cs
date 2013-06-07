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
    public partial class DatySeriali : Form
    {
        SqlCeConnection conn;
        String odData = "";
        String doData = "";
        string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";

        public DatySeriali()
        {
            InitializeComponent();
            edytujButton.Hide();
        }

        private void anulujButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            edytujButton.Show();
            refresh();

        }

        private void refresh()
        {
            odData = odBox.Text;
            doData = doBox.Text;
            try
            {
                conn = new SqlCeConnection(connectionString);
                SqlCeDataAdapter dataadapter = new SqlCeDataAdapter("Select * from Seriale WHERE Data_Premiery BETWEEN '" + odData + "' AND '"
                    + doData + "'", conn);
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
