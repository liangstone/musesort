using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuseSort
{
    public partial class InterakcjaFilmSerial : Form
    {
        String sciezkaPliku;
        public InterakcjaFilmSerial(String sciezka)
        {
            InitializeComponent();
            sciezkaPliku = sciezka;
        }

        private void filmyButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DodawanieFilmow(sciezkaPliku).ShowDialog();
        }

        private void serialeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DodawanieSeriali(sciezkaPliku).ShowDialog();
        }

        private void anulujButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
