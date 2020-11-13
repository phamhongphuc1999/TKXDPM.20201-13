using System;
using RentalBikeApp.Presentation;
using System.Windows.Forms;

namespace RentalBikeApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomePage homePage = new HomePage();
            Application.Run(homePage);
        }
    }
}
