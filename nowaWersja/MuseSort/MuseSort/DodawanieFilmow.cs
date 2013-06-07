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
    public partial class DodawanieFilmow : Form
    {
        //do ponownego merga
        SqlCeConnection conn;
        public String sciezkaFilmu = "";
        public int idFilmu;
        public DodawanieFilmow(String sciezkaPliku="")
        {
            InitializeComponent();
            zapisz.Show();
            updateButton.Dispose();
            sciezkaFilmu = sciezkaPliku;
        }
        public DodawanieFilmow(int id, String tyt, String gat, String pro, int rokPremiery, String rez, String opisFilmu,
            String ory, String sciezka)
        {
            InitializeComponent();
            zapisz.Dispose();
            updateButton.Show();
            idFilmu = id;
            tytul.Text = tyt;
            gatunek.Text = gat;
            produkcja.Text = pro;
            rok.Text = rokPremiery.ToString();
            rezyseria.Text = rez;
            opis.Text = opisFilmu;
            tytul_ory.Text = ory;
            sciezkaFilmu = sciezka;
        }

        private void anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            
            String tytulFilmu = tytul.Text;
            String gatunekFilmu = gatunek.Text;
            String produkcjaFilmu = produkcja.Text;
            int rokFilmu = Convert.ToInt32(rok.Text);
            String rezyserFilmu = rezyseria.Text;
            String opisFilmu = opis.Text;
            String tytulOryginalny = tytul_ory.Text;

            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {
                SqlCeCommand Query = new SqlCeCommand("INSERT INTO Filmy " +
                            "(Tytul, Gatunek, Produkcja, Rok, Rezyseria, Opis, Tytul_Oryginalu, Sciezka) " +
                            "VALUES (@Tytul, @Gatunek, @Produkcja, @Rok, @Rezyseria, @Opis, @Tytul_Oryginalu, @Sciezka)", conn);

                Query.Parameters.AddWithValue("@Tytul", tytulFilmu);
                Query.Parameters.AddWithValue("@Gatunek", gatunekFilmu);
                Query.Parameters.AddWithValue("@Produkcja", produkcjaFilmu);
                Query.Parameters.AddWithValue("@Rok", rokFilmu);
                Query.Parameters.AddWithValue("@Rezyseria", rezyserFilmu);
                Query.Parameters.AddWithValue("@Opis", opisFilmu);
                Query.Parameters.AddWithValue("@Tytul_Oryginalu", tytulOryginalny);
                Query.Parameters.AddWithValue("@Sciezka", sciezkaFilmu);
                Query.ExecuteNonQuery();
                MessageBox.Show("Pomyslnie dodano film do bazy danych");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wysypalo sie");
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            
            this.Dispose();
        }

        private void sciezka_Click(object sender, EventArgs e)
        {
            explorer.FileName = sciezkaFilmu;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezkaFilmu = explorer.FileName;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=|DataDirectory|\MyDatabase#1.sdf; Password = Projekt&4";
            conn = new SqlCeConnection(connectionString);
            conn.Open();
            try
            {

                SqlCeCommand Query = new SqlCeCommand("UPDATE Filmy SET " +
                            "Tytul = @Tytul, Gatunek = @Gatunek," +
                            "Produkcja = @Produkcja, Rok = @Rok, Rezyseria = @Rezyseria," +
                            "Opis = @Opis, Tytul_Oryginalu = @Tytul_Oryginalu, Sciezka = @Sciezka WHERE ID = @ID", conn);

                Query.Parameters.AddWithValue("@Tytul", tytul.Text);
                Query.Parameters.AddWithValue("@Gatunek", gatunek.Text);
                Query.Parameters.AddWithValue("@Produkcja", produkcja.Text);
                Query.Parameters.AddWithValue("@Rok", rok.Text);
                Query.Parameters.AddWithValue("@Rezyseria", rezyseria.Text);
                Query.Parameters.AddWithValue("@Opis", opis.Text);
                Query.Parameters.AddWithValue("@Tytul_Oryginalu", tytul_ory.Text);
                Query.Parameters.AddWithValue("@Sciezka", sciezkaFilmu);
                Query.Parameters.AddWithValue("@ID", idFilmu);
                Query.ExecuteNonQuery();
                MessageBox.Show("Pomyslnie edytowany film w bazie danych");
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
