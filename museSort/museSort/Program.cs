using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace museSort
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
            Application.Run(new Form1());

            //-----------------------TEST------------------------------
            //utwor a = new utwor("C:\\Users\\Krzysztof\\Music\\test\\1335292026.foxamoore_epicats.mp3");
            // zapisz wykonuje się teraz po pierwszym wczytaniu pliku
            //----------------------------------------------------------
        }
    }
}
