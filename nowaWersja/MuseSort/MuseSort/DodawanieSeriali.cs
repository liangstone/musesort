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
        //do ponownego merga
        String sciezkaOdcinka = "";
        SqlCeConnection conn;
        int idOdcinka;
        public DodawanieSeriali(String sciezkaPliku = "")
        {
            InitializeComponent();
            zapisz.Show();
            updateButton.Dispose();
            sciezkaOdcinka = sciezkaPliku;
        }

        public DodawanieSeriali(int id, String TytulOdcinka, String TytulSerialu, String Rezyser, String Prod, 
                                String Data, int NumerSezonu, int NumerOdcinka, int Ogladalnosc, String Sciezka, Boolean czyOgl)
        {
            InitializeComponent();
            idOdcinka = id;
            tytulOdcinkaTextBox.Text = TytulOdcinka;
            tytulSerialuTextBox.Text = TytulSerialu;
            rezyserTextBox.Text = Rezyser;
            produkcjaTextBox.Text = Prod;
            dataPremieryTextBox.Text = Data;
            numerSezonuTextBox.Text = NumerSezonu.ToString();
            numerOdcinkaTextBox.Text = NumerOdcinka.ToString();
            ogladalnoscTextBox.Text = Ogladalnosc.ToString();
            sciezkaOdcinka = Sciezka;
            watchCheckBox.Checked = czyOgl;
            zapisz.Dispose();
            updateButton.Show();
            

        }

      

        private void zapisz_Click(object sender, EventArgs e)
        {
            String tytulOdcinka = tytulOdcinkaTextBox.Text;
            String tytulSerialu = tytulSerialuTextBox.Text;
            String rezyseria = rezyserTextBox.Text;
            String produkcja = produkcjaTextBox.Text;
            String dataPremiery = dataPremieryTextBox.Text;
            int numerSezonu = Convert.ToInt32(numerSezonuTextBox.Text);
            int numerOdcinka = Convert.ToInt32(numerOdcinkaTextBox.Text);
            int ogladalnosc = Convert.ToInt32(ogladalnoscTextBox.Text);
            Boolean czyOgl = watchCheckBox.Checked;

            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {
                SqlCeCommand Query = new SqlCeCommand("INSERT INTO Seriale " +
                            "(Tytul_Odcinka, Tytul_Serialu, Rezyseria, Produkcja, Data_Premiery, Numer_Sezonu, Numer_Odcinka, Ogladalnosc_Odcinka, Sciezka, czyOgladniete) " +
                            "VALUES (@Tytul_Odcinka, @Tytul_Serialu, @Rezyseria, @Produkcja, @Data_Premiery, @Numer_Sezonu, @Numer_Odcinka, @Ogladalnosc_Odcinka, @Sciezka, @czyOgladniete)", conn);

                Query.Parameters.AddWithValue("@Tytul_Odcinka", tytulOdcinka);
                Query.Parameters.AddWithValue("@Tytul_Serialu", tytulSerialu);
                Query.Parameters.AddWithValue("@Rezyseria", rezyseria);
                Query.Parameters.AddWithValue("@Produkcja", produkcja);
                Query.Parameters.AddWithValue("@Data_Premiery", dataPremiery);
                Query.Parameters.AddWithValue("@Numer_Sezonu", numerSezonu);
                Query.Parameters.AddWithValue("@Numer_Odcinka", numerOdcinka);
                Query.Parameters.AddWithValue("@Ogladalnosc_Odcinka", ogladalnosc);
                Query.Parameters.AddWithValue("@Sciezka", sciezkaOdcinka);
                Query.Parameters.AddWithValue("@czyOgladniete", czyOgl);
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
            explorer.FileName = sciezkaOdcinka;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezkaOdcinka = explorer.FileName;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {
                SqlCeCommand Query = new SqlCeCommand("UPDATE Seriale SET " +
                            "Tytul_Odcinka = @Tytul_Odcinka, Tytul_Serialu = @Tytul_Serialu, Rezyseria = @Rezyseria, " +
                            "Produkcja = @Produkcja, Data_Premiery = @Data_Premiery, Numer_Sezonu = @Numer_Sezonu, Numer_Odcinka = @Numer_Odcinka," +
                            "Ogladalnosc_Odcinka = @Ogladalnosc_Odcinka, Sciezka = @Sciezka, CzyOgladniete = @CzyOgladniete WHERE ID = @ID", conn);

                Query.Parameters.AddWithValue("@Tytul_Odcinka", tytulOdcinkaTextBox.Text);
                Query.Parameters.AddWithValue("@Tytul_Serialu", tytulSerialuTextBox.Text);
                Query.Parameters.AddWithValue("@Rezyseria", rezyserTextBox.Text);
                Query.Parameters.AddWithValue("@Produkcja", produkcjaTextBox.Text);
                Query.Parameters.AddWithValue("@Data_Premiery", dataPremieryTextBox.Text);
                Query.Parameters.AddWithValue("@Numer_Sezonu", Convert.ToInt32(numerSezonuTextBox.Text));
                Query.Parameters.AddWithValue("@Numer_Odcinka", Convert.ToInt32(numerOdcinkaTextBox.Text));
                Query.Parameters.AddWithValue("@Ogladalnosc_Odcinka", Convert.ToInt32(ogladalnoscTextBox.Text));
                Query.Parameters.AddWithValue("@Sciezka", sciezkaOdcinka);
                Query.Parameters.AddWithValue("@CzyOgladniete", watchCheckBox.Checked);
                Query.Parameters.AddWithValue("@ID", idOdcinka);
                Query.ExecuteNonQuery();
                MessageBox.Show("Pomyslnie edytowany odcinek w bazie danych");
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
