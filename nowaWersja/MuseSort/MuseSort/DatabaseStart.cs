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
    public partial class DatabaseStart : Form
    {
        public DatabaseStart()
        {
            InitializeComponent();
        }

        private void muzykaButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseMuzyka().ShowDialog();
        }

        private void filmyButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseFilm().ShowDialog();
        }

        private void serialeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new DatabaseSerial().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
