using System;
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
       
        public MainGUI()
        {
            loadConfiguration();
            InitializeComponent();
            ListDirectory(directoryTreeView, @"C:\");
            flowLayoutPanel1.Hide();
            flowLayoutPanel2.Hide();
        }
        
        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            string[] dirs = System.IO.Directory.GetDirectories(@"C:\");
            foreach (string directory in dirs)
            {
                directoryNode.Nodes.Add(directory.ToString());
            }
            return directoryNode;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Modyfikuj_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Hide();
            flowLayoutPanel2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Hide();
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

        
    }
}
