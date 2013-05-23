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
    public partial class DodawanieSeriali : Form
    {
        String sciezkaOdcinka = "";
        public DodawanieSeriali(String sciezkaPliku = "")
        {
            InitializeComponent();
            sciezkaOdcinka = sciezkaPliku;
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            SqlCeConnection conn;
            String tytulOdcinka = tytulOdcinkaTextBox.Text;
            String tytulSerialu = tytulSerialuTextBox.Text;
            String rezyseria = rezyserTextBox.Text;
            String produkcja = produkcjaTextBox.Text;
            String dataPremiery = dataPremieryTextBox.Text;
            int numerSezonu = Convert.ToInt32(numerSezonuTextBox.Text);
            int numerOdcinka = Convert.ToInt32(numerOdcinkaTextBox.Text);
            int ogladalnosc = Convert.ToInt32(ogladalnoscTextBox.Text);
            

            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {
                SqlCeCommand Query = new SqlCeCommand("INSERT INTO Seriale " +
                            "(Tytul_Odcinka, Tytul_Serialu, Rezyseria, Produkcja, Data_Premiery, Numer_Sezonu, Numer_Odcinka, Ogladalnosc_Odcinka, Sciezka) " +
                            "VALUES (@Tytul_Odcinka, @Tytul_Serialu, @Rezyseria, @Produkcja, @Data_Premiery, @Numer_Sezonu, @Numer_Odcinka, @Ogladalnosc_Odcinka, @Sciezka)", conn);

                Query.Parameters.AddWithValue("@Tytul_Odcinka", tytulOdcinka);
                Query.Parameters.AddWithValue("@Tytul_Serialu", tytulSerialu);
                Query.Parameters.AddWithValue("@Rezyseria", rezyseria);
                Query.Parameters.AddWithValue("@Produkcja", produkcja);
                Query.Parameters.AddWithValue("@Data_Premiery", dataPremiery);
                Query.Parameters.AddWithValue("@Numer_Sezonu", numerSezonu);
                Query.Parameters.AddWithValue("@Numer_Odcinka", numerOdcinka);
                Query.Parameters.AddWithValue("@Ogladalnosc_Odcinka", ogladalnosc);
                Query.Parameters.AddWithValue("@Sciezka", sciezkaOdcinka);
                Query.ExecuteNonQuery();
                MessageBox.Show("Pomyslnie dodano odcinek do bazy danych");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wysypalo sie");
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            
            this.Dispose();
        }

        private void anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void sciezka_Click(object sender, EventArgs e)
        {
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezkaOdcinka = explorer.FileName;
            }
        }
    }
}
