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
    public partial class UtworzUstawienia : Form
    {
        public UtworzUstawienia()
        {
            InitializeComponent();
        }

        private void wyborSciezki_Click(object sender, EventArgs e)
        {
            explorer.ShowNewFolderButton = false;
            explorer.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezka.Text = explorer.SelectedPath;
            }
        }
    }
}
