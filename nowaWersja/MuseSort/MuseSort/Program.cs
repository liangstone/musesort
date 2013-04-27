using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MuseSort
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", "../../BazaDanych");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
        }
    }
}
