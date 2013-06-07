using System;
using System.Windows.Forms;

namespace MuseSort
{
    static class Program
    {
        //do ponownego merga
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Konieczne dla prawidłowgo funkcjonowania bazy danych, 
            //ustala relatywną ścieżkę pliku bazodanowago względem katalogu początkowego.
            AppDomain.CurrentDomain.SetData("DataDirectory", "../../BazaDanych"); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
        }
    }
}
