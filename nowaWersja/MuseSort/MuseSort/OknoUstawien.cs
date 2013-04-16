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
        List<IComponent> rozszerzenia;
        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################
        //konstruktor
        public OknoUstawien()
        {
            InitializeComponent();
            domyslneSortowaniaPanel.Hide();
            folderyPanel.Hide();
            folderGlownyPanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaPanel.Hide();
            wspieranieRozszerzeniaPanel.Hide();
            zewnetrzneBazyDanychPanel.Hide();
            drzewoUstawien.NodeMouseClick += wyswietl;
            rozszerzenia = new List<IComponent>();
            rozszerzenia.Add(mp3CheckBox);
            rozszerzenia.Add(flacCheckBox);
        }
        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        //Wyśwetlanie listy ustawień
        private void wyswietl(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Foldery
            if (e.Node.Name == "folderyNode")
            {
                aktywujPanel("foldery");
                sciezkaBox.Text = UstawieniaProgramu.folderGlowny;
            }
            //Folder Główny
            else if (e.Node.Name == "folderGlownyNode")
            {
                aktywujPanel("folderGlowny");
                sciezka2Box.Text = UstawieniaProgramu.folderGlowny;
            }
            //Sortowanie
            else if (e.Node.Name == "sortowaniaNode")
            {
                aktywujPanel("sortowania");
                sposobSortowaniaBox.Text = UstawieniaProgramu.domyslneSortowanie;
            }
            //Domyślne ustawienia (Sortowanie)
            else if (e.Node.Name == "domyslneSortowanieNode")
            {
                aktywujPanel("domyslneSortowania");
                sposobSortowania2Box.Text = UstawieniaProgramu.domyslneSortowanie;
            }
            //Rozszerzenia
            else if (e.Node.Name == "rozszerzeniaNode")
            {
                aktywujPanel("rozszerzenia");
                String extensions = "";
                foreach (String x in UstawieniaProgramu.wspieraneRozszerzeniaAudio)
                {
                    extensions += x + "; ";
                }
                rozszerzeniaBox.Text = extensions;
            }
            //Wspierane rozszerzenia
            else if (e.Node.Name == "wspieraneRozszerzeniaNode")
            {
                aktywujPanel("wspieraneRozszerzenia");
                String extensions = "";
                foreach (String x in UstawieniaProgramu.wspieraneRozszerzeniaAudio)
                {
                    extensions += x + "; ";
                }
                textBox1.Text = extensions;
                foreach (CheckBox x in rozszerzenia)
                {
                    if(UstawieniaProgramu.wspieraneRozszerzeniaAudio.Contains(x.Name.Replace("CheckBox", "")))
                    {
                        x.Checked = true;
                    }
                }
            }
            //Zewnętrzne Bazy Danych
            else if (e.Node.Name == "bazyDanychNode")
            {
                aktywujPanel("zewnetrzneBazyDanych");
                dataBaseListBox.SelectedItem = UstawieniaProgramu.domyslnaBazaDanych;
            }

        }//end void wyswietl(object sender, TreeNodeMouseClickEventArgs e)

        private void anulujButton_MouseClick(object sender, MouseEventArgs e)
        {
            UstawieniaProgramu.wczytajUstawienia();
            this.Dispose();
        }

        private void aktywujPanel(String nazwa)
        {
            folderyPanel.Hide();
            domyslneSortowaniaPanel.Hide();
            folderGlownyPanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaPanel.Hide();
            wspieranieRozszerzeniaPanel.Hide();
            zewnetrzneBazyDanychPanel.Hide();
            switch(nazwa)
            {
                case "foldery":
                    folderyPanel.Show();
                    break;
                case "folderGlowny":
                    folderGlownyPanel.Show();
                    break;
                case "sortowania":
                    sortowaniaPanel.Show();
                    break;
                case "domyslneSortowania":
                    domyslneSortowaniaPanel.Show();
                    break;
                case "rozszerzenia":
                    rozszerzeniaPanel.Show();
                    break;
                case "wspieraneRozszerzenia":
                    wspieranieRozszerzeniaPanel.Show();
                    break;
                case "zewnetrzneBazyDanych":
                    zewnetrzneBazyDanychPanel.Show();
                    break;
                default:
                    break;
            }
        }

        private void wybierzNowyFolderGlownyButton_Click(object sender, EventArgs e)
        {
            explorer.ShowNewFolderButton = false;
            explorer.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                nowaSciezkaBox.Text = explorer.SelectedPath;
            }
        }

        private void ustawNowyFolderGlownyButton_Click(object sender, EventArgs e)
        {
            if (nowaSciezkaBox.Text != "")
            {
                UstawieniaProgramu.folderGlowny = nowaSciezkaBox.Text;
                sciezka2Box.Text = UstawieniaProgramu.folderGlowny;
                sciezkaBox.Text = UstawieniaProgramu.folderGlowny;
            }
            else
            {
                MessageBox.Show("Nie wybrano nowego folderu!");
            }
            
        }

        private void zmienSposobSortowaniaButton_Click(object sender, EventArgs e)
        {
            if (sortowaniaListBox.SelectedItems.Count > 0)
            {
                UstawieniaProgramu.domyslneSortowanie = sortowaniaListBox.SelectedItem.ToString();
                sposobSortowaniaBox.Text = UstawieniaProgramu.domyslneSortowanie;
                sposobSortowania2Box.Text = UstawieniaProgramu.domyslneSortowanie;
            }
            else
            {
                MessageBox.Show("Nie wybrano sposobu sortowania!");
            }
        }

        private void dodajRozszerzenieButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.wspieraneRozszerzeniaAudio.Clear();
            foreach (CheckBox x in rozszerzenia)
            {
                if (x.Checked)
                {
                    String temp = x.Name.Replace("CheckBox", "");
                    UstawieniaProgramu.wspieraneRozszerzeniaAudio.Add(temp);
                }
            }
        }

        private void wybierzBazeButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.domyslnaBazaDanych = dataBaseListBox.SelectedItem.ToString();
        }

        private void przywrocDomyslneButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.wczytajUstawienia();
            aktywujPanel("");
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz zapisać zmiany?", "Potwierdź zmiany", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    UstawieniaProgramu.zapiszUstawienia();
                    MessageBox.Show("Zapisano ustawienia programu!");
                } catch (Exception ex) {
                    MessageBox.Show("Błąd zapisu danych " + ex.Message);
                }
            }
        }
        #endregion
    }
}
