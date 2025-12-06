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
            ApplicationConfiguration.Initialize();
            appCine = new AppCine(); // Inicia la App y carga la config

            // 1. Mostramos el Login
            FrmLogin frmLogin = new FrmLogin();
            DialogResult loginResult = frmLogin.ShowDialog();

            // 2. Si el login es exitoso, comprobamos el rol
            if (loginResult == DialogResult.OK)
            {
                // 3. Según el estado, abrimos un formulario u otro
                if (appCine.estadoApp == CineDAM.Modelos.EstadoApp.AdminLogueado)
                {
                    Application.Run(new Formularios.FrmAdminMDI()); // Lanza el panel de Admin
                }
                else if (appCine.estadoApp == CineDAM.Modelos.EstadoApp.TaquillaAbierta)
                {
                    Application.Run(new FrmTaquilla());
                }
            }
            // Si el loginResult es "Cancel", la aplicación simplemente se cierra.
        }
    }
}