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
    public partial class WzorcePlikowAudio : Form
    {
        public WzorcePlikowAudio()
        {
            InitializeComponent();
            bindData();
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.FileName = "";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filename = openFileDialog.FileName;
                String filepath = System.IO.Path.GetDirectoryName(filename);
                filename = System.IO.Path.GetFileNameWithoutExtension(filename);
                String res = filepath + "\\" + filename;
                UtworNowyWzorzecSciezki nowe = new UtworNowyWzorzecSciezki(res);
                DialogResult resulta = nowe.ShowDialog();
                bindData();

            }
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            if (listaWzorcowSciezki.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono obiektu do usunięcia!");
                return;
            }

            String nazwa = listaWzorcowSciezki.SelectedItems[0].Text;
            Wzorzec poszukiwany = null;
            foreach (Wzorzec wz in StaticUtwor.wzorceSciezki)
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

            StaticUtwor.wzorceSciezki.Remove(poszukiwany);
            listaWzorcowSciezki.Items.Remove(listaWzorcowSciezki.SelectedItems[0]);
            UstawieniaProgramu.getInstance().zapiszUstawienia();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void bindData()
        {
            listaWzorcowNazwy.Items.Clear();
            int i = 0;
            foreach (Wzorzec wz in StaticUtwor.wzorceNazwy)
            {
                listaWzorcowNazwy.Items.Add(wz.wzorzec);
                listaWzorcowNazwy.Items[i].SubItems.Add(wz.regex.ToString());
                i++;
            }

            listaWzorcowSciezki.Items.Clear();
            i = 0;
            foreach (Wzorzec wz in StaticUtwor.wzorceSciezki)
            {
                listaWzorcowSciezki.Items.Add(wz.wzorzec);
                listaWzorcowSciezki.Items[i].SubItems.Add(wz.regex.ToString());
                i++;
            }

        }

        private void dodajNazwyButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.FileName = "";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filename = openFileDialog.FileName;
                filename = System.IO.Path.GetFileNameWithoutExtension(filename);
                UtworNowyWzorzecNazwyForm nowe = new UtworNowyWzorzecNazwyForm(filename);
                DialogResult resulta = nowe.ShowDialog();
                bindData();

            }
        }

        private void usunNazwyButton_Click(object sender, EventArgs e)
        {
            if (listaWzorcowNazwy.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono obiektu do usunięcia!");
                return;
            }

            String nazwa = listaWzorcowNazwy.SelectedItems[0].Text;
            Wzorzec poszukiwany = null;
            foreach (Wzorzec wz in StaticUtwor.wzorceNazwy)
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

            StaticUtwor.wzorceNazwy.Remove(poszukiwany);
            listaWzorcowNazwy.Items.Remove(listaWzorcowNazwy.SelectedItems[0]);
            UstawieniaProgramu.getInstance().zapiszUstawienia();
        }

    }
}
