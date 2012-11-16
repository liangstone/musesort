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
            utwor a = new utwor("D:\\Ściągnięte\\muzyka\\Back To The Stax - Back To The Stax.mp3");
            //----------------------------------------------------------
        }
    }
}
