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
        //do ponownego merga
        List<IComponent> rozszerzenia;
        List<IComponent> rozszerzeniaVideo;
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
            rozszerzeniaVideoPanel.Hide();
            sortowaniaPanel.Hide();
            wspieranieRozszerzeniaPanel.Hide();
            drzewoUstawien.NodeMouseClick += wyswietl;
            rozszerzenia = new List<IComponent>();
            rozszerzeniaVideo = new List<IComponent>();
            rozszerzenia.Add(mp3CheckBox);
            rozszerzenia.Add(flacCheckBox);
            rozszerzeniaVideo.Add(mkvCheckBox);
            rozszerzeniaVideo.Add(mp4CheckBox);
            rozszerzeniaVideo.Add(aviCheckBox);
            rozszerzeniaVideo.Add(wmvCheckBox);
        }
        #endregion
        #region metody pomocnicze klas
        //######################################METODY POMOCNICZE KLASY######################################

        //Wyśwetlanie listy ustawień
        private void wyswietl(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Foldery
            switch (e.Node.Name)
            {
                case "folderyNode":
                    aktywujPanel("foldery");
                    sciezkaBox.Text = UstawieniaProgramu.getInstance().folderGlowny;
                    break;
                case "folderGlownyNode":
                    aktywujPanel("folderGlowny");
                    sciezka2Box.Text = UstawieniaProgramu.getInstance().folderGlowny;
                    break;
                case "sortowaniaNode":
                    aktywujPanel("sortowania");
                    sposobSortowaniaBox.Text = UstawieniaProgramu.getInstance().domyslneSortowanieMuzyki;
                    break;
                case "domyslneSortowanieNode":
                    aktywujPanel("domyslneSortowania");
                    sposobSortowania2Box.Text = UstawieniaProgramu.getInstance().domyslneSortowanieMuzyki;
                    break;
                case "rozszerzeniaNode":
                    {
                        aktywujPanel("rozszerzenia");
                        String extensions = "";
                        foreach (String x in UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio)
                        {
                            extensions += x + "; ";
                        }
                        rozszerzeniaBox.Text = extensions;
                    }
                    break;
                case "wspieraneRozszerzeniaNode":
                    {
                        aktywujPanel("wspieraneRozszerzenia");
                        String extensions = "";
                        foreach (String x in UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio)
                        {
                            extensions += x + "; ";
                        }
                        textBox1.Text = extensions;
                        foreach (CheckBox x in rozszerzenia)
                        {
                            if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Contains(x.Name.Replace("CheckBox", "")))
                            {
                                x.Checked = true;
                            }
                        }
                    }
                    break;
                case "wspieraneRozszerzeniaVideoNode":
                    {
                        aktywujPanel("wspieraneRozszerzeniaVideo");
                        String extensions = "";
                        foreach (String x in UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo)
                        {
                            extensions += x + "; ";
                        }
                        textBox2.Text = extensions;
                        foreach (CheckBox x in rozszerzeniaVideo)
                        {
                            if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains(x.Name.Replace("CheckBox", "")))
                            {
                                x.Checked = true;
                            }
                        }
                    }
                    break;
            }
        }

//end void wyswietl(object sender, TreeNodeMouseClickEventArgs e)

        private void anulujButton_MouseClick(object sender, MouseEventArgs e)
        {
            UstawieniaProgramu.getInstance().wczytajUstawienia();
            Dispose();
        }

        private void aktywujPanel(String nazwa)
        {
            folderyPanel.Hide();
            domyslneSortowaniaPanel.Hide();
            folderGlownyPanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaPanel.Hide();
            wspieranieRozszerzeniaPanel.Hide();
            rozszerzeniaVideoPanel.Hide();
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
                case "wspieraneRozszerzeniaVideo":
                    rozszerzeniaVideoPanel.Show();
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
                UstawieniaProgramu.getInstance().folderGlowny = nowaSciezkaBox.Text;
                sciezka2Box.Text = UstawieniaProgramu.getInstance().folderGlowny;
                sciezkaBox.Text = UstawieniaProgramu.getInstance().folderGlowny;
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
                UstawieniaProgramu.getInstance().domyslneSortowanieMuzyki = sortowaniaListBox.SelectedItem.ToString();
                sposobSortowaniaBox.Text = UstawieniaProgramu.getInstance().domyslneSortowanieMuzyki;
                sposobSortowania2Box.Text = UstawieniaProgramu.getInstance().domyslneSortowanieMuzyki;
            }
            else
            {
                MessageBox.Show("Nie wybrano sposobu sortowania!");
            }
        }

        private void dodajRozszerzenieButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Clear();
            foreach (CheckBox x in rozszerzenia)
            {
                if (x.Checked)
                {
                    String temp = x.Name.Replace("CheckBox", "");
                    UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Add(temp);
                }
            }
        }

        private void przywrocDomyslneButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.getInstance().wczytajUstawienia();
            aktywujPanel("");
        }

        private void zapiszButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz zapisać zmiany?", "Potwierdź zmiany", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    UstawieniaProgramu.getInstance().zapiszUstawienia();
                    MessageBox.Show("Zapisano ustawienia programu!");
                } catch (Exception ex) {
                    MessageBox.Show("Błąd zapisu danych " + ex.Message);
                }
            }
        }
        #endregion

        private void dodajRozszerzenieVideoButton_Click(object sender, EventArgs e)
        {
            UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Clear();
            foreach (CheckBox x in rozszerzeniaVideo)
            {
                if (x.Checked)
                {
                    String temp = x.Name.Replace("CheckBox", "");
                    UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add(temp);
                }
            }
        }
    }
}
