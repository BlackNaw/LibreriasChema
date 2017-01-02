using LibreriaV3._1.Vista;
using System;
using System.Windows.Forms;

namespace LibreriaV3._1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
           
        }
    }
}
