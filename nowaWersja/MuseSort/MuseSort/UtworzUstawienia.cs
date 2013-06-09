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
        //do ponownego merga
        String visiblePanel;
        List<IComponent> rozszerzenia;
        List<IComponent> rozszerzeniaFilmowe;
        public UtworzUstawienia()
        {
            InitializeComponent();
            folderyPanel.Show();
            visiblePanel = "foldery";
            sortowaniaPanel.Hide();
            rozszerzeniaFilmowePanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaListBox.SelectionMode = SelectionMode.One;
            rozszerzenia = new List<IComponent>();
            rozszerzeniaFilmowe = new List<IComponent>();
            rozszerzenia.Add(mp3CheckBox);
            rozszerzenia.Add(flacCheckBox);
            rozszerzeniaFilmowe.Add(mkvCheckBox);
            rozszerzeniaFilmowe.Add(mp4CheckBox);
            rozszerzeniaFilmowe.Add(aviCheckBox);
            rozszerzeniaFilmowe.Add(wmvCheckBox);

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

        private void dalej_Click(object sender, EventArgs e)
        {
            switch (visiblePanel)
            {
                case "foldery":
                    //MessageBox.Show("Wlazłem w switcha!");
                    if (defaultFolderCheckBox.Checked)
                    {
                        UstawieniaProgramu.getInstance().folderGlowny = @"C:\museSort\main";
                        aktywujPanel("sortowania");
                    }
                    else
                    {
                        if (sciezka.Text != "")
                        {
                            UstawieniaProgramu.getInstance().folderGlowny = sciezka.Text;
                            aktywujPanel("sortowania");
                        }
                        else
                        {
                            MessageBox.Show("Nie wybrano folderu!");
                        }
                    }
                    break;
                case "sortowania":
                    if (sortowaniaListBox.SelectedItems.Count > 0)
                    {
                        UstawieniaProgramu.getInstance().domyslneSortowanie = sortowaniaListBox.SelectedItem.ToString();
                        aktywujPanel("rozszerzenia");
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano sposobu sortowania!");
                    }
                    break;
                case "rozszerzenia":
                    foreach (CheckBox x in rozszerzenia)
                    {
                        if (x.Checked)
                        {
                            String temp = x.Name.Replace("CheckBox", "");
                            UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Add(temp);
                        }
                    }
                    aktywujPanel("rozszerzeniaFilmowe");
                    break;
                case "rozszerzeniaFilmowe":
                    foreach (CheckBox x in rozszerzeniaFilmowe)
                    {
                        if (x.Checked)
                        {
                            String temp = x.Name.Replace("CheckBox", "");
                            UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Add(temp);
                        }
                    }
                    aktywujPanel("none");
                    break;
                default:
                    UstawieniaProgramu.getInstance().zapiszUstawienia();
                    MessageBox.Show("Zapisano ustawienia programu!");
                    this.Dispose();
                    break;
            }
        }

        private void aktywujPanel(String nazwa)
        {
            visiblePanel = nazwa;
            folderyPanel.Hide();
            sortowaniaPanel.Hide();
            rozszerzeniaFilmowePanel.Hide();
            rozszerzeniaPanel.Hide();
            switch(nazwa)
            {
                case "foldery":
                    label1.Text = "Foldery programu";
                    infoLabel.Text = "Ustal główny folder programu, w którym będą przechowywane posortowane foldery.";
                    folderyPanel.Show();
                    break;
                case "sortowania":
                    label1.Text = "Domyślny sposób sortowania";
                    infoLabel.Text = "Wybierz domyślny sposób sortowania plików wykorzystywany przez program.";
                    sortowaniaPanel.Show();
                    break;
                case "rozszerzeniaFilmowe":
                    label1.Text = "Rozszerzenia plików filmowych do sortowania";
                    infoLabel.Text = "Wybierz rozszerzenia filmów, które program będzie brał pod uwagę w trakcie sortowania plików.";
                    rozszerzeniaFilmowePanel.Show();
                    break;
                case "rozszerzenia":
                    label1.Text = "Rozszerzenia plików do sortowania";
                    infoLabel.Text = "Wybierz rozszerzenia, które program będzie brał pod uwagę w trakcie sortowania plików.";
                    rozszerzeniaPanel.Show();
                    break;
                default:
                    label1.Text = "Pomyślnie przeprowadzono wstępną konfigurację!";
                    infoLabel.Text = "Udało się wprowadzić domyślne ustawienia programu. W każdej chwili można je zmienić wchodząc w zakładkę Opcje -> Ustawienia.";
                    break;
            }
        }
    }
}
