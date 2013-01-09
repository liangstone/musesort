﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace museSort
{
    public partial class MainGUI : Form
    {
        String folderGlowny;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };
        private string[] kategorie;
        private string preferowane;
       
        public MainGUI()
        {
            loadConfiguration();
            InitializeComponent();
            directoryTreeView.NodeMouseClick += wyswietl;
            ListDirectory(directoryTreeView, @"C:\");
            flowLayoutPanel1.Hide();
        }


        void wyswietl(object sender, TreeNodeMouseClickEventArgs e)
        {
            otwartyFolder.Items.Clear();
            if (e.Node.Nodes.Count == 0)
            {
                CreateDirectoryNode(e.Node, e.Node.Name);
            }
            else
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    CreateDirectoryNode(n, n.Name);
                }
            }
            String[] dirs = System.IO.Directory.GetDirectories(e.Node.Name);
            foreach (String d in dirs)
            {
                string[] folders = d.Split('\\');
                otwartyFolder.Items.Add(folders[folders.Length-1] + "  folder");
            }
            dirs = System.IO.Directory.GetFiles(e.Node.Name);
            foreach (String d in dirs)
            {
                string[] files = d.Split('\\');
                otwartyFolder.Items.Add(files[files.Length-1] + "  plik");
            }
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            TreeNode temp = new TreeNode(@"C:\");
            temp.Name = @"C:\";
            treeView.Nodes.Add(temp);
        }

        private static void CreateDirectoryNode(TreeNode directoryNode, String path)
        {
            if (path == "C:\\ProgramData\\Application Data" || path == "C:\\Documents and Settings" || path == "C:\\System Volume Information" || path == "C:\\BOOT\\System Volume Information")
            {
                return;
            }
            else
            {
                string[] dirs = System.IO.Directory.GetDirectories(path);
                foreach (string directory in dirs)
                {
                    string[] folders = directory.Split('\\');
                    TreeNode temp = new TreeNode(folders[folders.Length - 1]);
                    temp.Name = directory.ToString();
                    directoryNode.Nodes.Add(temp);
                }
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Modyfikuj_Click(object sender, EventArgs e)
        {
            new OknoEdytujDane().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            format.SelectedIndex = 0;
            format.DropDownStyle = ComboBoxStyle.DropDownList;
            schematy.SelectedIndex = 0;
            schematy.DropDownStyle = ComboBoxStyle.DropDownList;
            schematy.DropDownWidth = DropDownWidth(schematy);
            przetwarzaj_kategorie();
            preferowane = format.Text;
            preferowane = preferowane.ToLower();
            flowLayoutPanel1.Show();
        }

        public void utworzFolderGlowny(String path, String nazwa)
        {
            String sciezka = path + @"\" + nazwa;
            if (Directory.Exists(sciezka))
            {
                MessageBox.Show("Nie można utworzyć podanego katalogu, gdyż w podanej lokalizacji już taki istnieje");
                return;
            }
            else
            {
                Directory.CreateDirectory(sciezka);
                folderGlowny = sciezka;
                saveConfiguration();
            }
        }

        public void loadConfiguration()
        {
            XmlDocument plikXML;
            plikXML = new XmlDocument();
            if (Directory.Exists(@"C:\museSortConf"))
            {
                if (File.Exists(@"C:\museSortConf\conf.xml"))
                {
                    plikXML.Load(@"C:\museSortConf\conf.xml");
                    if (plikXML.GetElementsByTagName("glowny").Count > 0)
                    {
                        folderGlowny = plikXML.GetElementsByTagName("glowny").Item(0).InnerText;
                        if (!File.Exists(folderGlowny + "\\struktura_folderow.xml"))
                        {
                            mainFolderXML mainXML = new mainFolderXML();
                            mainXML.ustalFolder(folderGlowny + "\\struktura_folderow.xml");
                            mainXML.generujElementy();
                        }
                        else
                        {
                            mainFolderXML mainXML = new mainFolderXML(folderGlowny + "\\struktura_folderow.xml");
                            Boolean stan = mainXML.analizuj();
                            if (!stan)
                            {
                                MessageBox.Show("Zmieniono strukturę folderów");
                                mainXML.generujElementy();
                            }
                        }
                    }
                    else
                    {
                        folderGlowny = null;
                    }
                }
                else
                {
                    MessageBox.Show("Brak pliku konfiguracyjengo, dane zostały utracone, zostanie utworzony nowy plik!!!");
                    XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
                    plikXML.AppendChild(dec);
                    XmlElement main = plikXML.CreateElement("body");
                    plikXML.AppendChild(main);
                    plikXML.Save(@"C:\museSortConf\conf.xml");
                }
            }
            else
            {
                Directory.CreateDirectory(@"C:\museSortConf");
                XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
                plikXML.AppendChild(dec);
                XmlElement main = plikXML.CreateElement("body");
                plikXML.AppendChild(main);
                plikXML.Save(@"C:\museSortConf\conf.xml");
            }
        }

        public void saveConfiguration()
        {
            XmlDocument plikXML;
            plikXML = new XmlDocument();
            if (!Directory.Exists(@"C:\museSortConf"))
            {
                Directory.CreateDirectory(@"C:\museSortConf");
            }
            if (File.Exists(@"C:\museSortConf\conf.xml"))
            {
                File.Delete(@"C:\museSortConf\conf.xml");
            }
            XmlDeclaration dec = plikXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            plikXML.AppendChild(dec);
            XmlElement main = plikXML.CreateElement("body");
            XmlElement glowny = plikXML.CreateElement("glowny");
            XmlText wartosc = plikXML.CreateTextNode(folderGlowny);
            glowny.AppendChild(wartosc);
            main.AppendChild(glowny);
            plikXML.AppendChild(main);
            plikXML.Save(@"C:\museSortConf\conf.xml");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            button1.Enabled = false;
            Logi.Clear();
            if (!Directory.Exists(directoryTreeView.SelectedNode.Name))                            //sprawdz czy podana sciezka jest poprawna
            {
                MessageBox.Show("Podano nieprawidlowa sciezke folderu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = true;
                return;
            }
            else if (Directory.GetLogicalDrives().Contains(directoryTreeView.SelectedNode.Name))
            {
                DialogResult dr = MessageBox.Show("Czy jestes pewien przeszukiwania zawartosci calego dysku?\n"
                + "Moze to potrwac bardzo dlugo, a nawet zawiesic program.\n", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }
            else
            {
                /*Nie widziałem pliku xml, więc nie wiem, skąd pobrać schemat
                String tmp = sciezka_box.Text + "\\" + "struktura_logiczna.xml";
                if (File.Exists(@"" + tmp))           //ostrzeżenie przed zmianą schematu
                {
                    XmlDocument plikXML = new XmlDocument();
                    plikXML.Load(tmp);
                    //mozna w tym komunikacie dodac jaka jest aktualna sciezka
                    DialogResult wynik = MessageBox.Show("Czy chcesz zmienić sposób dotychczasowego sortowania?", "", MessageBoxButtons.YesNo);
                    if(wynik = DialogResult.No)
                    {
                        return;
                    }
                }
                */

                try
                {
                    sortuj();

                    MessageBox.Show("Pomyślnie posortowano pliki.", "", MessageBoxButtons.OK);
                    button1.Enabled = true;
                    //MessageBox.Show("Pomyślnie posortowano pliki.", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Przerwanie sortowania.");
                    Console.WriteLine(ex);
                }
            }
            button1.Enabled = true;
            progressBar2.Value = 0;
        }
        private void sortuj()
        {
            if (kategorie[0] == "")
                return;
            if (!Directory.Exists(directoryTreeView.SelectedNode.Name))        //czy katalog który mamy sortować istnieje
            {
                MessageBox.Show("Podany katalog nie istnieje.");
                return;
            }


            // Tu: Wyświetl informację, że system sprawdza ilość plików


            progressBar2.Maximum = 0;
            progressBar2.Value = 0;
            progressBar2.Step = 1;
            Logi.Text = "Znajdowanie plików..." + Environment.NewLine;
            //Logi.Items.Add("Znajdowanie plików...");
            Logi.Refresh();
            Dictionary<string, List<string>> sciezki_plikow = znajdz_wspierane_pliki(directoryTreeView.SelectedNode.Name);



            Logi.AppendText("Znaleziono wszystkie wspierane pliki.\n");
            Logi.Refresh();
            Logi.Clear();


            //tworzymy katalogi - punkt 4
            Directory.SetCurrentDirectory(directoryTreeView.SelectedNode.Name);
            Directory.CreateDirectory(@"Musesort\Temp");
            Directory.CreateDirectory(@"Musesort\Posegregowane\Nieprzydzielone");
            Directory.CreateDirectory(@"Musesort\Zduplikowane\Posegregowane\Nieprzydzielone");
            Directory.CreateDirectory(@"Musesort\Zduplikowane\Temp");


            foreach (string rozszerzenie in utwor.wspierane_rozszerzenia) //iterujemy po rozszerzeniach
                foreach (string sciezka in sciezki_plikow[rozszerzenie]) //iterujemy po plikach
                {
                    utwor plik = new utwor(sciezka);
                    if (plik.tagi == null)
                        continue;
                    string nazwa_pliku = Path.GetFileName(plik.sciezka);
                    plik.kopiuj(@"Musesort\Temp\" + nazwa_pliku);
                    plik = new utwor(@"Musesort\Temp\" + nazwa_pliku);
                    plik.pobierz_tagi();
                    plik.zapisz_tagi_standaryzuj_nazwe();

                    string sciezka_katalogu;
                    if (schematy.Text == @"Piosenki\Wykonawca" && plik.wykonawca[0] != "" && plik.tytul != "")
                    {
                        sciezka_katalogu = @"Musesort\Posegregowane";
                        nazwa_pliku = plik.wykonawca[0] + '_' + plik.tytul + '.' + plik.rozszerzenie;
                    }
                    else
                        sciezka_katalogu = sciezka_katalogu_z_pol(plik);


                    if (!Directory.Exists(sciezka_katalogu))
                        Directory.CreateDirectory(sciezka_katalogu); // to tworzy też wszystkie katalogi które są "po drodze"
                    // tzn. wyższego rzędu które też nie istnieją

                    //przenosimy pliki
                    //Console.WriteLine("Przenoszenie " + sciezka_katalogu + @"\" + nazwa_pliku);
                    try
                    {
                        plik.zmien_nazwe_pliku(Path.Combine(sciezka_katalogu, nazwa_pliku));
                    }
                    catch (System.IO.IOException ex) //rzucane w przypadku kolizji nazw plików
                    {
                        duplikat(Path.Combine(sciezka_katalogu, nazwa_pliku), plik.sciezka);
                    }
                    Logi.AppendText(plik.nazwa + Environment.NewLine);
                    Logi.Refresh();
                    progressBar2.PerformStep();
                }
            return;
        }//end sortuj()
        //zamienia tekst z comboBoxa na tablicę kategorii do organizowania folderów
        private string[] przetwarzaj_kategorie()
        {
            //zamienić na tablicę
            //string[] kategorie;
            {
                String qq = schematy.Text;
                List<string> temp = new List<string>(qq.Split('\\'));//zamienianie w tę i z powrotem jest nieefektywne, 
                temp.Remove("Piosenki");
                kategorie = temp.ToArray();                                       //ale i tak pracujemy na obiekcie kilkuelementowym
            }

            //sporządź listę kategorii, po których można sortować
            List<string> poprawne_kategorie = new List<string>();
            foreach (System.Reflection.FieldInfo pole in typeof(utwor).GetFields())
                poprawne_kategorie.Add(pole.Name);

            poprawne_kategorie.Remove("tagi");
            poprawne_kategorie.Remove("staraNazwa");
            poprawne_kategorie.Remove("stareTagi");
            poprawne_kategorie.Add("alfabetycznie");


            for (int i = 0; i < kategorie.Length; i++)
            {
                kategorie[i] = kategorie[i].ToLower();
                if (kategorie[i] == "artysta")
                    kategorie[i] = "wykonawca";
                if (!poprawne_kategorie.Contains(kategorie[i]))
                {
                    throw new Exception("Błąd. Nie można sortować po polu " + kategorie[i]);
                }
            }
            return kategorie;
        }//end przetwarzaj_kategorie()

        //Zwraca listę ścieżek plików .mp3 i .flac
        Dictionary<string, List<string>> znajdz_wspierane_pliki(string katalog)
        {
            Dictionary<string, List<string>> wynik = new Dictionary<string, List<string>>();
            foreach (string rozszerzenie in utwor.wspierane_rozszerzenia)
            {
                List<string> sciezki_plikow = new List<string>(Directory.GetFiles(katalog, "*." + rozszerzenie));
                wynik.Add(rozszerzenie, sciezki_plikow);
                progressBar2.Maximum += sciezki_plikow.Count;
            }

            //wersja możliwie szybsza: w linijce powyżej wykomentować Directory.GetFiles(katalog, "*." + rozszerzenie)
            //foreach(string plik in Directory.GetFiles(katalog))
            //{
            //    string rozszerzenie = Path.GetExtension(plik);
            //    if(utwor.wspierane_rozszerzenia.Contains(rozszerzenie))
            //        wynik[rozszerzenie].Add(plik);
            //}

            foreach (string podkatalog in Directory.GetDirectories(katalog))//dodajemy pliki z podkatalogów
            {
                Dictionary<string, List<string>> tmp = znajdz_wspierane_pliki(podkatalog);
                foreach (string rozszerzenie in utwor.wspierane_rozszerzenia)
                    wynik[rozszerzenie].AddRange(tmp[rozszerzenie]);
            }

            return wynik;
        }//end znajdz_wspierane_pliki(string katalog)


        //generuje ścieżkę dla katalogu na podstawie pól w sortowaniu
        private string sciezka_katalogu_z_pol(utwor plik, bool duplikat = false)
        {
            Type typ_utwor = typeof(utwor);
            string sciezka_katalogu;
            if (duplikat)
                sciezka_katalogu = @"Musesort\Zduplikowane\Posegregowane";
            else
                sciezka_katalogu = @"Musesort\Posegregowane";

            foreach (string kategoria in kategorie) //tworzymy ścieżkę katalogu docelowego pliku
            {
                string kat = "";
                if (kategoria == "Alfabetycznie")
                {
                    try
                    {
                        kat = plik.tytul.Substring(0, 1);
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                else
                {
                    System.Reflection.FieldInfo pole = typ_utwor.GetField(kategoria);         //pobiera pole

                    if (pole.FieldType.Equals(typeof(String)))				//jeśli pole to String
                        kat = (string)pole.GetValue(plik);
                    else if (pole.FieldType.Equals(typeof(int)))			//jeśli pole to int
                        kat = Convert.ToString(pole.GetValue(plik));
                    else if (pole.FieldType.Equals(typeof(string[])))		//jeśli pole to tablica
                        kat = ((string[])pole.GetValue(plik))[0];
                }
                if (kat == "")                                          //jeśli nie udało się pobrać
                {
                    if (duplikat)
                        sciezka_katalogu = @"Musesort\Zduplikowane\Posegregowane\Nieprzydzielone";
                    else
                        sciezka_katalogu = @"Musesort\Posegregowane\Nieprzydzielone";//przenieś do "Nieprzydzielone
                    break;
                }
                kat = ZamienNaWlasciwe(kat);
                System.Console.WriteLine(kat);
                sciezka_katalogu = Path.Combine(sciezka_katalogu, kat);
                System.Console.WriteLine(sciezka_katalogu);
            }
            if (duplikat && File.Exists(Path.Combine(sciezka_katalogu, plik.nazwa + '.' + plik.rozszerzenie)))
            {
                string nazwa = plik.nazwa + '.' + plik.rozszerzenie;
                string fullpath = Path.Combine(sciezka_katalogu, nazwa);
                int i;
                for (i = 1; File.Exists(fullpath); )
                {
                    i++;
                    fullpath = Path.Combine(sciezka_katalogu + Convert.ToString(i), nazwa);
                }
                sciezka_katalogu += Convert.ToString(i);
            }
            return sciezka_katalogu;
        }//end sciezka_z_pol()


        private String[] pobierz_foldery(String sciezka)    //zwraca foldery, do ktorych uzytkownik ma prawo dostepu
        {
            List<String> tmp = new List<string>();
            try
            {
                if (sciezka.Contains("$RECYCLE.BIN")) throw null;
                else foreach (String s in Directory.GetDirectories(@"" + sciezka))       //pobierz foldery ze sciezki
                    {
                        foreach (String rozszerzenie in wspierane_rozszerzenia)        //sprawdz czy mozna pobrac pliki
                            Directory.GetFiles(@"" + s, "*." + rozszerzenie);

                        tmp.Add(s);
                    }
            }
            catch (Exception) { };
            return tmp.ToArray();
        }//end pobierz_foldery

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }//end DropDownWidth

        private void schematy_SelectedIndexChanged(object sender, EventArgs e)
        {
            przetwarzaj_kategorie();
        }

        private void duplikat(String x, String y)
        {
            utwor plik1 = new utwor(x);
            utwor plik2 = new utwor(y);

            // do decydowania który jest lepszy będziemy używali ifów, chyba prościej będzie najpierw ustalić wartość boola
            bool pierwszy_jest_lepszy = plik1.tagi.Properties.AudioBitrate >= plik2.tagi.Properties.AudioBitrate;
            if ((preferowane == "najlepszy") || (preferowane == plik1.rozszerzenie && preferowane == plik2.rozszerzenie) || (preferowane != plik1.rozszerzenie && preferowane != plik2.rozszerzenie))
            {
                if (pierwszy_jest_lepszy) //pierwszy plik zostaje gdzie jest, drugi idzie do zduplikowanych
                {
                    string nowykatalog = sciezka_katalogu_z_pol(plik2, true);
                    Directory.CreateDirectory(nowykatalog);
                    plik2.zmien_nazwe_pliku(Path.Combine(nowykatalog, plik2.nazwa + '.' + plik2.rozszerzenie));
                }
                else //drugi plik zajmuje miejsce pierwszego, pierwszy idzie do zduplikowanych
                {
                    plik1.zmien_nazwe_pliku(@"Musesort\Zduplikowane\Temp\" + plik1.nazwa + '.' + plik1.rozszerzenie);
                    plik2.zmien_nazwe_pliku(x);
                    string nowykatalog = sciezka_katalogu_z_pol(plik1, true);
                    Directory.CreateDirectory(nowykatalog);
                    plik1.zmien_nazwe_pliku(Path.Combine(nowykatalog, plik1.nazwa + '.' + plik1.rozszerzenie));
                }
            }
            else if (preferowane == plik1.rozszerzenie && preferowane != plik2.rozszerzenie)
            {
                //pierwszy plik zostaje gdzie jest, drugi idzie do zduplikowanych
                string nowykatalog = sciezka_katalogu_z_pol(plik2, true);
                Directory.CreateDirectory(nowykatalog);
                plik2.zmien_nazwe_pliku(Path.Combine(nowykatalog, plik2.nazwa + '.' + plik2.rozszerzenie));
            }
            else if (preferowane != plik1.rozszerzenie && preferowane == plik2.rozszerzenie)
            {
                //drugi plik zajmuje miejsce pierwszego, pierwszy idzie do zduplikowanych
                plik1.zmien_nazwe_pliku(@"Musesort\Zduplikowane\Temp\" + plik1.nazwa + '.' + plik1.rozszerzenie);
                plik2.zmien_nazwe_pliku(x);
                string nowykatalog = sciezka_katalogu_z_pol(plik1, true);
                Directory.CreateDirectory(nowykatalog);
                plik1.zmien_nazwe_pliku(Path.Combine(nowykatalog, plik1.nazwa + '.' + plik1.rozszerzenie));
            }
            else
            {
                MessageBox.Show("Cos sie syplo!", "", MessageBoxButtons.OK);
            }
        }//end  private void duplikat(String x, String y)

        public String ZamienNaWlasciwe(String x)
        {
            /*Nazwę pliku oraz tagi należy zmienić w taki sposób, że będą one zapisane 
             * ze spacjami zamiast podkreśleń oraz dużymi i małymi literami. Każdy wyraz
             * ma się zaczynać od dużej litery, a cała reszta liter jest mała*/
            String[] wyrazy = x.Split('_');
            String nowe = "";
            String a = "";
            String b = "";
            for (int i = 0; i < wyrazy.Length; i++)
            {
                //System.Console.WriteLine(wyrazy[i]);
                a = wyrazy[i].Substring(0, 1);
                a = a.ToUpper();
                b = wyrazy[i].Substring(1, wyrazy[i].Length - 1);
                b = b.ToLower();
                //System.Console.WriteLine(wyrazy[i]);
                nowe += a + b;
                //System.Console.WriteLine(nowe);
                nowe += ' ';
                // System.Console.WriteLine(nowe);
            }
            //System.Console.WriteLine(nowe);
            //for (int k = 0; k < wyrazy.Length; k++)
            //{
            //    System.Console.WriteLine(wyrazy[k]);
            //}
            nowe = nowe.Trim();
            return nowe;
        }//end ZamienNaWlasciwe(String x)

        private void Eksport_Click(object sender, EventArgs e)
        {
            string tekst = Logi.Text;
            
            FileStream plik;
            StreamWriter zapisuj;
            String gdzie;
            String data;
            data = DateTime.Today.ToString();
            gdzie = directoryTreeView.SelectedNode.Name;
            gdzie = @"C:\museSortConf\nowy.txt";
            plik = new FileStream(gdzie, FileMode.Append);
            zapisuj = new StreamWriter(plik);
            zapisuj.WriteLine(data);

            zapisuj.Write(tekst);
            zapisuj.Close();
            plik.Close();
            String qq = "Utworzono plik " + gdzie;
            MessageBox.Show(qq, "Nowy plik", MessageBoxButtons.OK);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ustal_glowny_Click(object sender, EventArgs e)
        {

        }

        private void Dodaj_Do_Głównego_Click(object sender, EventArgs e)
        {

        }

    }
}
