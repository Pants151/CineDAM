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
            appCine = new AppCine();

            bool salirAplicacion = false;

            while (!salirAplicacion)
            {
                // 1. Mostrar Login
                FrmLogin frmLogin = new FrmLogin();
                DialogResult loginResult = frmLogin.ShowDialog();

                if (loginResult == DialogResult.OK)
                {
                    // 2. Si login OK, abrir formulario principal según rol
                    if (appCine.estadoApp == CineDAM.Modelos.EstadoApp.AdminLogueado)
                    {
                        // Ejecutamos el Admin MDI como modal también para controlar el retorno
                        FrmAdminMDI frmAdmin = new FrmAdminMDI();
                        frmAdmin.ShowDialog();

                        // Al cerrar frmAdmin, el bucle while vuelve a empezar (mostrando Login)
                    }
                    else if (appCine.estadoApp == CineDAM.Modelos.EstadoApp.TaquillaAbierta)
                    {
                        FrmTaquilla frmTaquilla = new FrmTaquilla();
                        frmTaquilla.ShowDialog();
                    }
                }
                else
                {
                    // Si cancela el login, salimos del bucle y de la app
                    salirAplicacion = true;
                }
            }
        }
    }
}