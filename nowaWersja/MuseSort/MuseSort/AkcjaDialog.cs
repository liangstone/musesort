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
    public partial class AkcjaDialog : Form
    {
        public AkcjaDialog(String akcja)
        {
            InitializeComponent();
            label1.Text = "Rozpoczęto akcję: " + akcja;
            
        }

    }
}
