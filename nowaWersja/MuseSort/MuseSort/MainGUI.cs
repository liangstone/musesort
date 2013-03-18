using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuseSort
{
    public partial class MainGUI : Form
    {
        FolderGlowny folderGlowny;
        //#############################PUBLICZNE METODY KLASY############################################
        
        //Konstruktor głównego okna
        public MainGUI()
        {
            zaladujUstawienia();
            InitializeComponent();
            drzewoFolderow.NodeMouseClick += wyswietl;
            listaSciezek(drzewoFolderow, @"C:\");
            folderGlowny = new FolderGlowny(MuseSort.Properties.Settings.Default.folderGlowny);
        }

        //######################################METODY POMOCNICZE KLASY######################################

        //Wyśwetlanie listy plików i folderów w drzewie folderów i liście plików
        void wyswietl(object sender, TreeNodeMouseClickEventArgs e)
        {
            aktualnyFolder.View = View.Details;
            aktualnyFolder.Items.Clear();
            if (e.Node.Nodes.Count == 0)
            {
                utworzWezelSciezki(e.Node, e.Node.Name);
            }
            else
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    if (n.Nodes.Count == 0)
                    {
                        utworzWezelSciezki(n, n.Name);
                    }
                }
            }
            String[] dirs = System.IO.Directory.GetDirectories(e.Node.Name);
            String[] dirstemp;
            int i = 0;
            foreach (String d in dirs)
            {
                string[] folders = d.Split('\\');
                Boolean flaga = true;
                try
                {
                    dirstemp = System.IO.Directory.GetDirectories(d);
                }
                catch
                {
                    flaga = false;
                }
                if (flaga)
                {
                    aktualnyFolder.Items.Add(folders[folders.Length - 1]);
                    aktualnyFolder.Items[i].SubItems.Add("folder");
                    i++;

                }
            }
            dirs = System.IO.Directory.GetFiles(e.Node.Name);
            foreach (String d in dirs)
            {
                string[] files = d.Split('\\');
                Boolean dostep = true;
                System.Security.AccessControl.FileSecurity sec;
                try
                {
                    sec = System.IO.File.GetAccessControl(d);
                    dostep = sec.AreAccessRulesProtected;
                }
                catch
                {
                    dostep = true;
                }

                if (!dostep)
                {
                    aktualnyFolder.Items.Add(files[files.Length - 1]);
                    string[] roz = files[files.Length - 1].Split('.');

                    aktualnyFolder.Items[i].SubItems.Add(roz[roz.Length - 1]);
                    i++;
                }

            }
        }

        //Inicjacja listy węzłów w drzewie folderów, wykorzystywana w konstruktorze
        private void listaSciezek(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            TreeNode temp = new TreeNode(@"C:\");
            temp.Name = @"C:\";
            treeView.Nodes.Add(temp);
        }

        //Tworzenie węzłów kolejnych folderów w drzewie folderów
        private static void utworzWezelSciezki(TreeNode directoryNode, String path)
        {

            string[] dirs = System.IO.Directory.GetDirectories(path);
            string[] dirstemp;
            foreach (string directory in dirs)
            {
                string[] folders = directory.Split('\\');
                Boolean flaga = true;
                try
                {
                    dirstemp = System.IO.Directory.GetDirectories(directory);
                }
                catch
                {
                    flaga = false;
                }
                if (flaga)
                {
                    TreeNode temp = new TreeNode(folders[folders.Length - 1]);
                    temp.Name = directory.ToString();
                    directoryNode.Nodes.Add(temp);
                }

            }
        }

        private void zaladujUstawienia()
        {
            //Pobieranie ustawień programu z pliku w katalogu domyślnym, tj. C:\MuseSort
        }

        //Otwieranie okna do edycji tagów pliku, jeśli plik nie zostanie zaznaczony, zostanie zwrócony komunikat o błędzie
        private void modyfikujButton_Click(object sender, EventArgs e)
        {
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (System.IO.File.Exists(sciezka))
            {
                new EdycjaPliku(sciezka).ShowDialog();
            }
        }

        //Dodawanie folderu z muzyką do głównego folderu
        private void dodajDoGlownegoFolderuButton_Click(object sender, EventArgs e)
        {
            if (folderGlowny.Sciezka == "")
            {
                MessageBox.Show("Nie został ustawiony folder główny!");
                return;
            }

            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany folder do dodania!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (sciezka == MuseSort.Properties.Settings.Default.folderGlowny || (sciezka + "\\Musesort") == MuseSort.Properties.Settings.Default.folderGlowny)
            {
                MessageBox.Show("Próbujesz dodać folder główny do folderu głównego!");
                return;
            }
            if (System.IO.Directory.Exists(sciezka))
            {
                folderGlowny.dodajFolder(sciezka);
            }
        }

        //Zamykanie programu za pomocą przycisku zamknij w zakładce program
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void sortujButton_Click(object sender, EventArgs e)
        {
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany folder do dodania!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (System.IO.Directory.Exists(sciezka))
            {
                Folder folder = new Folder(sciezka);
                folder.ustalSchemat(@"Wykonawca\Album\Piosenki");
                folder.progressBar2 = toolStripProgressBar1.ProgressBar;
                folder.sortuj();
            }
        }

        private void dodajPiosenkiButton_Click(object sender, EventArgs e)
        {
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany folder do dodania!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;

            Folder docelowy = new Folder(@"C:\Users\KrzysztofD\Music\alchemist");
            docelowy.ustalSchemat(@"Wykonawca\Album\Piosenki");
            docelowy.progressBar2 = toolStripProgressBar1.ProgressBar;
            docelowy.dodajIPosortujFolder(sciezka);
        }
    }
}
