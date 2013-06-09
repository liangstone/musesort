using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace MuseSort
{
    public partial class MainGUI : Form
    {
        //do ponownego merga
        FolderGlowny folderGlowny;
        #region publiczne metody klas
        //#############################PUBLICZNE METODY KLASY############################################
        
        //Konstruktor głównego okna
        public MainGUI()
        {
            InitializeComponent();
            drzewoFolderow.NodeMouseClick += wyswietl;
            listaSciezek(drzewoFolderow, @"C:\");
            zaladujUstawienia();
            niestandardoweSortowaniePanel.Visible = false;
        }
        #endregion
        #region metody pomocnicze klas
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

        //Pobieranie ustawień programu z pliku w katalogu domyślnym, tj. C:\MuseSort
        private void zaladujUstawienia()
        {
            XmlDocument plikXML = new XmlDocument();
            if (!File.Exists(@"C:\museSort\config.xml"))
            {
                logiTextBox.Text += "Brak pliku konfiguracyjnego." + Environment.NewLine;
                MessageBox.Show("Nie instnieje plik konfiguracyjny programu!");
                new UtworzUstawienia().Show();
                //Wywołanie okna pierwszego uruchomienia
            }
            else
            {
                try
                {

                    UstawieniaProgramu.getInstance().wczytajUstawienia();
                    folderGlowny = new FolderGlowny(UstawieniaProgramu.getInstance().folderGlowny);
                    logiTextBox.Text += "Pomyślnie wczytano ustawienia programu!" + Environment.NewLine;
                }
                catch (Exception e)
                {
                    logiTextBox.Text += "Błąd wczytywania ustawień programu: " + e.Message + "." + Environment.NewLine;
                    MessageBox.Show("Nastapil blad we wczytywaniu ustawien programu" + e.Message + Environment.NewLine + "Nacisnij OK, aby utworzyc nowy plik konfiguracyjny");
                    //Wyswietlanie okna tworzenia ustawień
                    UtworzUstawienia dialog = new UtworzUstawienia();
                    dialog.Show();
                    if (dialog.DialogResult.Equals(DialogResult.OK))
                    {
                        zaladujUstawienia();
                    }
                }
            }
        }

        //Otwieranie okna do edycji tagów pliku, jeśli plik nie zostanie zaznaczony, zostanie zwrócony komunikat o błędzie
        private void modyfikujButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
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
            niestandardoweSortowaniePanel.Visible = false;
            if (folderGlowny == null || folderGlowny.Sciezka == "")
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

            if (sciezka == folderGlowny.Sciezka)
            {
                MessageBox.Show("Próba dodania folderu głównego do folderu głównego!");
                return;
            }

            if (System.IO.Directory.Exists(sciezka))
            {
                Folder temp = new Folder(sciezka);
                if (temp.analizuj())
                {
                    folderGlowny.dodajFolder(sciezka);
                    logiTextBox.Text += folderGlowny.logi;
                }
                else
                {
                    MessageBox.Show("Folder nie został posortowany!");
                    return;
                }
            }
        }

        //Zamykanie programu za pomocą przycisku zamknij w zakładce program
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dodajPiosenkiButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            dodajPanel.Visible = true;
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OknoUstawien().ShowDialog();
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            String source;
            String destination;
            if (sourceFolderTextBox.Text == "")
            {
                MessageBox.Show("Nie został wybrany folder do dodania!");
                return;
            } else {
                source = sourceFolderTextBox.Text;
            }
            if (destinationFolderTextBox.Text == "")
            {
                MessageBox.Show("Nie został wybrany folder docelowy!");
                return;
            } else {
                destination = destinationFolderTextBox.Text;
            }
            if (!(Directory.Exists(source) || Directory.Exists(destination)))
            {
                MessageBox.Show("Błąd podanych katalogów!");
                return;
            }
            Folder docelowy = new Folder(destination);
            if (!docelowy.analizuj())
            {
                MessageBox.Show("Folder docelowy nie został posortowany!");
                return;
            }
            docelowy.dodajIPosortujFolder(source, UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio);
            logiTextBox.Text += docelowy.logi;
            MessageBox.Show("Pomyślnie dodano pliki.");
            dodajPanel.Visible = false;
        }

        private void ustalSourceButton_Click(object sender, EventArgs e)
        {
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie wybrano folderu!");
                return;
            }
            String source = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            sourceFolderTextBox.Text = source;
        }

        private void ustalDestinationButton_Click(object sender, EventArgs e)
        {
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie wybrano folderu!");
                return;
            }
            String destination = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            destinationFolderTextBox.Text = destination;
        }

        private void sortujButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany folder do posortowania!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (System.IO.Directory.Exists(sciezka))
            {
                Folder folder = new Folder(sciezka);
                folder.ustalSchemat(@"Wykonawca\Album\Piosenki");
                folder.progressBar2 = toolStripProgressBar1.ProgressBar;
                folder.sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio);
                logiTextBox.Text += folder.logi;
            }
        }
        
		
        private void SzczegolyPliku_Click(object sender, EventArgs e)
        {
            //sprawdzam, czy plik jest zaznaczony przez uzytkownika
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }

            //sciezka pliku
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            //MessageBox.Show(Path.GetExtension(sciezka));
            
            if (System.IO.File.Exists(sciezka))
            {
                //rozszerzenie pliku
                String rozszerzeniePliku = Path.GetExtension(sciezka);
                //sprawdzamy czy plik jest filmowy, czy tez muzyczny i wlaczamy odpowiednie okno
                if (rozszerzeniePliku.Equals(".mkv") || rozszerzeniePliku.Equals(".mov") || rozszerzeniePliku.Equals(".avi"))
                {
                    sciezka = Path.GetFileNameWithoutExtension(sciezka);
                    try
                    {
                        new SzczegolyFilmu(sciezka).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Blad! Sprawdz polaczenie z Internetem!" + Environment.NewLine + ex.Message);
                    }
                }
                else
                {
                    try
                    {

                        new SzczegolyMuzyki(sciezka).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Blad! Sprawdz polaczenie z Internetem!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }//end private void SzczegolyPliku_Click(object sender, EventArgs e)
        private void sortujCustom_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = true;
        }

        //autor:Karolina
        private void dodajDoBibliotekiButton_Click(object sender, EventArgs e)
        {
            //sprawdzam, czy plik jest zaznaczony przez uzytkownika
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }

            //sciezka pliku
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            //MessageBox.Show(Path.GetExtension(sciezka));

            if (System.IO.File.Exists(sciezka))
            {
                //rozszerzenie pliku
                String rozszerzeniePliku = Path.GetExtension(sciezka);
                //sprawdzamy czy plik jest filmowy, czy tez muzyczny i wlaczamy odpowiednie okno
                if (rozszerzeniePliku.Equals(".mkv") || rozszerzeniePliku.Equals(".mov") || rozszerzeniePliku.Equals(".avi"))
                {
                    new InterakcjaFilmSerial(sciezka).ShowDialog();
                }
                else
                {
                    new DodawanieMuzyki(sciezka).ShowDialog();
                }
            }
        }//end private void dodajDoBibliotekiButton_Click(object sender, EventArgs e)

        //autor:Karolina
        private void pokazBibliotekeButton_Click(object sender, EventArgs e)
        {
            new DatabaseStart().ShowDialog();
        }//end  private void pokazBibliotekeButton_Click(object sender, EventArgs e)

        #endregion
        private void wzorcePlikówVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WzorcePlikowVideo okno = new WzorcePlikowVideo();
            okno.Show();
        }

        private void wzorcePlikówAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WzorcePlikowAudio okno = new WzorcePlikowAudio();
            okno.Show();
        }

        private void modyfikujTagiButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (System.IO.File.Exists(sciezka))
            {
                String ext = System.IO.Path.GetExtension(sciezka).Replace(".", "");
                if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaVideo.Contains(ext))
                {
                    new EdycjaPlikuFilmowego(sciezka).ShowDialog();
                }
                else if (UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio.Contains(ext))
                {
                    new EdycjaPliku(sciezka).ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Nieobsługiwane rozszerzenie pliku: " + ext);
                }

                
            }
        }

        private void dodajPlikDoGlownegoFolderuButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            if (folderGlowny == null || folderGlowny.Sciezka == "")
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

            if (sciezka == folderGlowny.Sciezka)
            {
                MessageBox.Show("Próba dodania folderu głównego do folderu głównego!");
                return;
            }

            if (System.IO.Directory.Exists(sciezka))
            {
                Folder temp = new Folder(sciezka);
                if (temp.analizuj())
                {
                    folderGlowny.dodajFolder(sciezka);
                    logiTextBox.Text += folderGlowny.logi;
                }
                else
                {
                    MessageBox.Show("Folder nie został posortowany!");
                    return;
                }
            }
        }

        private void dodajPiosenkiDoFoldeuButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            dodajPanel.Visible = true;
        }

        private void pokazSzczegolyPlikuButton_Click(object sender, EventArgs e)
        {
            //sprawdzam, czy plik jest zaznaczony przez uzytkownika
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }

            //sciezka pliku
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            //MessageBox.Show(Path.GetExtension(sciezka));

            if (System.IO.File.Exists(sciezka))
            {
                //rozszerzenie pliku
                String rozszerzeniePliku = Path.GetExtension(sciezka);
                //sprawdzamy czy plik jest filmowy, czy tez muzyczny i wlaczamy odpowiednie okno
                if (rozszerzeniePliku.Equals(".mkv") || rozszerzeniePliku.Equals(".mov") || rozszerzeniePliku.Equals(".avi") || rozszerzeniePliku.Equals(".mp4") || rozszerzeniePliku.Equals(".wmv"))
                {
                    sciezka = Path.GetFileNameWithoutExtension(sciezka);
                    new SzczegolyFilmu(sciezka).ShowDialog();
                }
                else
                {
                    new SzczegolyMuzyki(sciezka).ShowDialog();
                }
            }
        }

        private void sortujPlikiButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = false;
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany folder do posortowania!");
                return;
            }
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            if (System.IO.Directory.Exists(sciezka))
            {
                Folder folder = new Folder(sciezka);
                folder.ustalSchemat(@"Wykonawca\Album\Piosenki");
                folder.progressBar2 = toolStripProgressBar1.ProgressBar;
                folder.sortuj(UstawieniaProgramu.getInstance().wspieraneRozszerzeniaAudio);
                logiTextBox.Text += folder.logi;
            }
        }

        private void sortowanieNiestanradoweButton_Click(object sender, EventArgs e)
        {
            niestandardoweSortowaniePanel.Visible = true;
        }

        private void dodajPlikDoBiblitekiButton_Click(object sender, EventArgs e)
        {
            //sprawdzam, czy plik jest zaznaczony przez uzytkownika
            if (drzewoFolderow.SelectedNode == null || aktualnyFolder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie został wybrany plik do otwarcia!");
                return;
            }

            //sciezka pliku
            String sciezka = drzewoFolderow.SelectedNode.Name + "\\" + aktualnyFolder.SelectedItems[0].Text;
            //MessageBox.Show(Path.GetExtension(sciezka));

            if (System.IO.File.Exists(sciezka))
            {
                //rozszerzenie pliku
                String rozszerzeniePliku = Path.GetExtension(sciezka);
                //sprawdzamy czy plik jest filmowy, czy tez muzyczny i wlaczamy odpowiednie okno
                if (rozszerzeniePliku.Equals(".mkv") || rozszerzeniePliku.Equals(".mov") || rozszerzeniePliku.Equals(".avi") || rozszerzeniePliku.Equals(".mp4") || rozszerzeniePliku.Equals(".wmv"))
                {
                    new InterakcjaFilmSerial(sciezka).ShowDialog();
                }
                else
                {
                    new DodawanieMuzyki(sciezka).ShowDialog();
                }
            }
        }

        private void otworzBibliotekeButton_Click(object sender, EventArgs e)
        {
            new DatabaseStart().ShowDialog();
        }

        private void samouczekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Samouczek().ShowDialog();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void folderLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
