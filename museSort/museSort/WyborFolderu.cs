using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace museSort
{
    public partial class WyborFolderu : Form
    {
        private FolderBrowserDialog explorer;
        public static string[] wspierane_rozszerzenia = { "mp3", "flac" };
        private string[] kategorie;

        public WyborFolderu()
        {
            explorer = new FolderBrowserDialog();

            InitializeComponent();
            format_box.SelectedIndex = 0;
            format_box.DropDownStyle = ComboBoxStyle.DropDownList;
            schemat_box.SelectedIndex = 0;
            schemat_box.DropDownStyle = ComboBoxStyle.DropDownList;
            schemat_box.DropDownWidth = DropDownWidth(schemat_box);
            przetwarzaj_kategorie();
        }

        private void wyszukaj_Click(object sender, EventArgs e)                 //wlacza explorera
        {
            explorer.ShowNewFolderButton = false;
            explorer.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = explorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezka_box.Text = explorer.SelectedPath;
            }
        }

        private void zamknij_button_Click(object sender, EventArgs e)           //zamknij
        {
            this.Close();   
        }

        private void wykonaj_button_Click(object sender, EventArgs e)           //wyszukaj plikow
        {
            progress_bar.Value = 0;
            zamknij_button.Enabled = false;
            wykonaj_button.Enabled = false;
            lista_plikow_box.Items.Clear();
            if(!Directory.Exists(sciezka_box.Text))                            //sprawdz czy podana sciezka jest poprawna
            {
                MessageBox.Show("Podano nieprawidlowa sciezke folderu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                zamknij_button.Enabled = true;
                wykonaj_button.Enabled = true;
                return;
            }
            else if(Directory.GetLogicalDrives().Contains(sciezka_box.Text))
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
					zamknij_button.Enabled = true;
					wykonaj_button.Enabled = true;
                    //MessageBox.Show("Pomyślnie posortowano pliki.", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,ex.Message,"Przerwanie sortowania.");
                    Console.WriteLine(ex);
                }
            }
            zamknij_button.Enabled = true;
            wykonaj_button.Enabled = true;
            progress_bar.Value = 0;
        }

        private void sortuj()
        {
            if (kategorie[0] == "")
                return;
            if (!Directory.Exists(sciezka_box.Text))        //czy katalog który mamy sortować istnieje
            {
                MessageBox.Show("Podany katalog nie istnieje.");
                return;
            }


            // Tu: Wyświetl informację, że system sprawdza ilość plików


            progress_bar.Maximum = 0;
            progress_bar.Value = 0;
            progress_bar.Step = 1;
            lista_plikow_box.Items.Add("Znajdowanie plików...");
            lista_plikow_box.Refresh();
            Dictionary<string, List<string>> sciezki_plikow = znajdz_wspierane_pliki(sciezka_box.Text);

                
            
            lista_plikow_box.Items.Add("Znaleziono wszystkie wspierane pliki.");
            lista_plikow_box.Refresh();
            lista_plikow_box.Items.Clear();


            //tworzymy katalogi - punkt 4
            Directory.SetCurrentDirectory(sciezka_box.Text);
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
                    plik.przywroc_stare();
                    plik = new utwor(@"Musesort\Temp\" + nazwa_pliku);

                    string sciezka_katalogu;
                    if (schemat_box.Text == @"Piosenki\Wykonawca" && plik.wykonawca[0] != "" && plik.tytul != "")
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
                        Console.WriteLine(ex);       //w tym momencie duplikaty na zasadzie kto pierwszy, jako test
                        sciezka_katalogu = sciezka_katalogu_z_pol(plik, true);
                        if (!System.IO.Directory.Exists(sciezka_katalogu))
                            System.IO.Directory.CreateDirectory(sciezka_katalogu);
                        plik.zmien_nazwe_pliku(Path.Combine(sciezka_katalogu, nazwa_pliku));
                    }
                    lista_plikow_box.Items.Add(plik.nazwa.Clone());
                    lista_plikow_box.Refresh();
                    progress_bar.PerformStep();
                }
            return;
        }

        //zamienia tekst z comboBoxa na tablicę kategorii do organizowania folderów
        private string[] przetwarzaj_kategorie()
        {
            //zamienić na tablicę
            //string[] kategorie;
            {
                List<string> temp = new List<string>(schemat_box.Text.Split('\\'));//zamienianie w tę i z powrotem jest nieefektywne, 
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
        }

        //Zwraca listę ścieżek plików .mp3 i .flac
        Dictionary<string, List<string>> znajdz_wspierane_pliki(string katalog)
        {
            Dictionary<string, List<string>> wynik = new Dictionary<string, List<string>>();
            foreach (string rozszerzenie in utwor.wspierane_rozszerzenia)
            {
                List<string> sciezki_plikow = new List<string>(Directory.GetFiles(katalog, "*." + rozszerzenie));
                wynik.Add(rozszerzenie, sciezki_plikow);
                progress_bar.Maximum += sciezki_plikow.Count;
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
        }



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
                sciezka_katalogu = Path.Combine(sciezka_katalogu, kat);
            }
            if (duplikat && File.Exists(Path.Combine(sciezka_katalogu, plik.nazwa + '.' + plik.rozszerzenie)))
            {
                    string nazwa = plik.nazwa + '.' + plik.rozszerzenie;
                    string fullpath = Path.Combine(sciezka_katalogu, nazwa);
                    int i;
                    for (i = 1; File.Exists(fullpath);)
                    {
                        i++;
                        fullpath = Path.Combine(sciezka_katalogu + Convert.ToString(i), nazwa);
                    }
                    sciezka_katalogu += Convert.ToString(i);            
            }
            return sciezka_katalogu;
        }

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
        }

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
        }

        private void schemat_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            przetwarzaj_kategorie();
        }

    }
}
