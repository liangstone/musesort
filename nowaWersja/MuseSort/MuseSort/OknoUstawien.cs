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
    public partial class OknoUstawien : Form
    {
        //#############################PUBLICZNE METODY KLASY############################################
        //konstruktor
        public OknoUstawien()
        {
            InitializeComponent();
            domyslneSortowaniaPanel.Hide();
            folderGlownyPanel.Hide();
            folderyPanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaPanel.Hide();
            wspieranieRozszerzeniaPanel.Hide();
            zewnetrzneBazyDanychPanel.Hide();
            drzewoUstawien.NodeMouseClick += wyswietl;
        }
        //######################################METODY POMOCNICZE KLASY######################################

        //Wyśwetlanie listy ustawień
        private void wyswietl(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Foldery
            if (e.Node.Name == "folderyNode")
            {
                folderyPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderGlownyPanel.Hide();
                rozszerzeniaPanel.Hide();
                sortowaniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Folder Główny
            else if (e.Node.Name == "folderGlownyNode")
            {
                folderGlownyPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderyPanel.Hide();
                rozszerzeniaPanel.Hide();
                sortowaniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Sortowanie
            else if (e.Node.Name == "sortowaniaNode")
            {
                sortowaniaPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderGlownyPanel.Hide();
                folderyPanel.Hide();
                rozszerzeniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Domyślne ustawienia (Sortowanie)
            else if (e.Node.Name == "domyslneSortowanieNode")
            {
                domyslneSortowaniaPanel.Show();
                folderGlownyPanel.Hide();
                folderyPanel.Hide();
                rozszerzeniaPanel.Hide();
                sortowaniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Rozszerzenia
            else if (e.Node.Name == "rozszerzeniaNode")
            {
                rozszerzeniaPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderGlownyPanel.Hide();
                folderyPanel.Hide();
                sortowaniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Wspierane rozszerzenia
            else if (e.Node.Name == "wspieraneRozszerzeniaNode")
            {
                wspieranieRozszerzeniaPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderGlownyPanel.Hide();
                folderyPanel.Hide();
                rozszerzeniaPanel.Hide();
                sortowaniaPanel.Hide();
                zewnetrzneBazyDanychPanel.Hide();
            }
            //Zewnętrzne Bazy Danych
            else if (e.Node.Name == "bazyDanychNode")
            {
                zewnetrzneBazyDanychPanel.Show();
                domyslneSortowaniaPanel.Hide();
                folderGlownyPanel.Hide();
                folderyPanel.Hide();
                rozszerzeniaPanel.Hide();
                sortowaniaPanel.Hide();
                wspieranieRozszerzeniaPanel.Hide();
            }

        }//end void wyswietl(object sender, TreeNodeMouseClickEventArgs e)

        private void anulujButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

    }
}
