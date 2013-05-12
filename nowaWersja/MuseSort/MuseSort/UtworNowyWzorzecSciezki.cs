using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MuseSort
{
    public partial class UtworNowyWzorzecSciezki : Form
    {
        String nazwa;

        public UtworNowyWzorzecSciezki(String name)
        {
            InitializeComponent();
            nazwa = name;
            nazwaLabel.Text = nazwa;
            wzorzecTextBox.Text = nazwa;
            infoLabel.Text = "Do utworzenia wzorca zaznacz odpowiednie fragmenty i wciśnij przycisk mówiący, co zaznaczyłeś";
        }

        private void tytulButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<tytul>";
        }

        private void wykonawcaButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<wykonawca>";
        }

        private void numerButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<numer>";
        }

        private void albumButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<album>";
        }

        private void rokButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<rok>";
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            String regex = wzorzecTextBox.Text;
            regex = regex.Replace("[", @"\[");
            regex = regex.Replace("]", @"\]");
            regex = regex.Replace("{", @"\{");
            regex = regex.Replace("}", @"\}");
            regex = regex.Replace("\\", @"\\");
            regex = regex.Replace("(", @"\(");
            regex = regex.Replace(")", @"\)");
            regex = regex.Replace("<source>", @"[:\w\s\(\)\&\'\!\`\~\$\.\+\-\\]+");
            regex = regex.Replace("<tytul>", @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+");
            regex = regex.Replace("<wykonawca>", @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+");
            regex = regex.Replace("<album>", @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+");
            regex = regex.Replace("<numer>", @"[\d]+");
            regex = regex.Replace("<rok>", @"[\d]{4}");
            regex = regex = "^" + regex + "$";
            Regex rx = new Regex(regex);
            Utwor.dodajWzorzec(wzorzecTextBox.Text, regex, "wzorceSciezki");
            this.Dispose();
        }

        private void anulujButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.Text = nazwa;
        }

        private void folderNadrzednyButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<source>";
        }
    }
}
