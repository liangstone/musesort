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
        String visiblePanel;
        List<IComponent> rozszerzenia;
        public UtworzUstawienia()
        {
            InitializeComponent();
            folderyPanel.Show();
            visiblePanel = "foldery";
            sortowaniaPanel.Hide();
            bazyDanychPanel.Hide();
            rozszerzeniaPanel.Hide();
            sortowaniaListBox.SelectionMode = SelectionMode.One;
            rozszerzenia = new List<IComponent>();
            rozszerzenia.Add(mp3CheckBox);
            rozszerzenia.Add(flacCheckBox);


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
                        aktywujPanel("bazyDanych");
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano sposobu sortowania!");
                    }
                    break;
                case "bazyDanych":
                    if (bazyDanychListBox.SelectedItems.Count > 0)
                    {
                        UstawieniaProgramu.getInstance().domyslnaBazaDanych = bazyDanychListBox.SelectedItem.ToString();
                        aktywujPanel("rozszerzenia");
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano domyślnej bazy danych!");
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
                    aktywujPanel("none");
                    break;
                default:
                    UstawieniaProgramu.getInstance().zapiszUstawienia();
                    //MessageBox.Show("Zapisano ustawienia programu!");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    //this.Dispose();
                    break;
            }
        }

        private void aktywujPanel(String nazwa)
        {
            visiblePanel = nazwa;
            folderyPanel.Hide();
            sortowaniaPanel.Hide();
            bazyDanychPanel.Hide();
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
                case "bazyDanych":
                    label1.Text = "Zewnętrzne bazy danych";
                    infoLabel.Text = "Wybierz z listy bazę danych, z którą chesz, aby program się łączył w celu pobrania danych o utworach.";
                    bazyDanychPanel.Show();
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
