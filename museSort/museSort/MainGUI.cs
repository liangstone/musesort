using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace museSort
{
    public partial class MainGUI : Form
    {

       
        public MainGUI()
        {
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

    }
}
