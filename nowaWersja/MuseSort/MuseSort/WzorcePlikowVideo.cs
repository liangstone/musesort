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
    public partial class WzorcePlikowVideo : Form
    {
        public WzorcePlikowVideo()
        {
            InitializeComponent();
            bindData();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            if (listaWzorcow.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono obiektu do usunięcia!");
                return;
            }

            String nazwa = listaWzorcow.SelectedItems[0].Text;
            Wzorzec poszukiwany = null;
            foreach(Wzorzec wz in Film.wzorceNazwy)
            {
                if (wz.wzorzec.Equals(nazwa))
                {
                    poszukiwany = wz;
                }
            }

            if (poszukiwany == null)
            {
                MessageBox.Show("Nastąpił błąd obsługi danych");
                return;
            }

            Film.wzorceNazwy.Remove(poszukiwany);
            listaWzorcow.Items.Remove(listaWzorcow.SelectedItems[0]);
            UstawieniaProgramu.getInstance().zapiszUstawienia();
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.FileName = "";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filename = openFileDialog.FileName;
                filename = System.IO.Path.GetFileNameWithoutExtension(filename);
                FilmNowyWzorzecNazwy nowe = new FilmNowyWzorzecNazwy(filename);
                DialogResult resulta = nowe.ShowDialog();
                bindData();
                
            }
        }

        public void bindData()
        {
            listaWzorcow.Items.Clear();
            int i = 0;
            foreach(Wzorzec wz in Film.wzorceNazwy)
            {
                listaWzorcow.Items.Add(wz.wzorzec);
                listaWzorcow.Items[i].SubItems.Add(wz.regex.ToString());
                i++;
            }

        }
    }
}
