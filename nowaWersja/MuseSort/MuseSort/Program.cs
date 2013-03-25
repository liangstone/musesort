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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Film tmp = new Film("D:\\YouTube - Herbata dla Boymka.wmv");
            //Application.Run(new MainGUI());
        }
    }
}
