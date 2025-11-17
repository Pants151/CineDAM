using CineDAM.Formularios;
using CineDAM.Modelos;

namespace CineDAM
{
    internal static class Program
    {
        public static AppCine appCine;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            appCine = new AppCine();
            Application.Run(new FrmConfig());
        }
    }
}