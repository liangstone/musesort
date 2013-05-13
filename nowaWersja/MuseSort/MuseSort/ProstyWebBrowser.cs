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
    public partial class ProstyWebBrowser : Form
    {
        public ProstyWebBrowser()
        {
            InitializeComponent();
        }
        private string url;

        public void Start(string url)
        {
            this.url = url;
            string PostDataStr = @"form_logowanieMail=waaaggh&form_logowanieHaslo=d00pad00pa&form_loginZapamietaj=1&postAction=sendLogowanie";
            byte[] PostDataByte = Encoding.UTF8.GetBytes(PostDataStr);
            string AdditionalHeaders = "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine;
            this.Show();
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.Navigate("http://napisy24.pl/logowanie/", "", PostDataByte, AdditionalHeaders);
        }

        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webBrowser1.Navigated -= webBrowser1_Navigated;
            webBrowser1.Navigate(url);
        }

        private void ProstyWebBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
