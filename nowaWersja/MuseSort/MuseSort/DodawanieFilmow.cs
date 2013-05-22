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
        public String sciezkaFilmu = "";
        public DodawanieFilmow(String sciezkaPliku="")
        {
            InitializeComponent();
            sciezkaFilmu = sciezkaPliku;
        }

        private void anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            SqlCeConnection conn;
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
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezkaFilmu = explorer.FileName;
            }
        }
    }
}
