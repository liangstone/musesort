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
    public partial class FilmNowyWzorzecNazwy : Form
    {
        String nazwa;
        public FilmNowyWzorzecNazwy(String name)
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

        private void rokButton_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.SelectedText = "<rok>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wzorzecTextBox.Text = nazwa;
        }

        private void anulujButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            /*String regex = wzorzecTextBox.Text;
            regex = regex.Replace("[", @"\[");
            regex = regex.Replace("]", @"\]");
            regex = regex.Replace("{", @"\{");
            regex = regex.Replace("}", @"\}");
            regex = regex.Replace("(", @"\(");
            regex = regex.Replace(")", @"\)");
            regex = regex.Replace("<tytul>", @"[\w\s\(\)\&\'\!\`\~\$\.\+\-]+");
            regex = regex.Replace("<rok>", @"[\d]{4}");
            regex = regex = "^" + regex + "$";
            Regex rx = new Regex(regex);*/
            Film.dodajWzorzecNazwy(wzorzecTextBox.Text);
            UstawieniaProgramu.getInstance().zapiszUstawienia();
            Dispose();
        }

        
    }
}
