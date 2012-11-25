using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace museSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new OknoEdytujDane().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new WyborFolderu().ShowDialog();
        }
    }
}
