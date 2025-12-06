using CineDAM.Modelos;
using System.Drawing; // Necesario para los colores
using System.Windows.Forms;

namespace CineDAM.Formularios
{
    public partial class FrmAdminMDI : Form
    {
        // Timer para mantener la interfaz actualizada automáticamente
        private System.Windows.Forms.Timer _timerEstado;

        public FrmAdminMDI()
        {
            InitializeComponent();
            ConfigurarTimer();
        }

        /******** CONFIGURACIÓN DEL TIMER *********/
        private void ConfigurarTimer()
        {
            _timerEstado = new System.Windows.Forms.Timer();
            _timerEstado.Interval = 1000; // Revisar cada 1 segundo
            _timerEstado.Tick += (s, e) => RefreshControles();
            _timerEstado.Start();
        }

        /******** EVENTOS DEL FORMULARIO Y CONTROLES *********/

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.appCine.conectado)
                Program.appCine.DesconectarDB();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
#if !DEBUG
            // Si no estamos en compilación DEBUG, ocultamos el menú de depuración
            tsMenuItemDepura.Visible = false;
#endif
            menuMain.MdiWindowListItem = ventanasToolStripMenuItem;

            // Forzar tamaño de iconos del menú superior
            menuMain.ImageScalingSize = new Size(32, 32);

            RefreshControles();
        }

        // --- Eventos del Menú Superior "Archivo" y "Ayuda" ---

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            this.Close();
        }

        private void tsMenuItemDepura_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmDebug>();
        }

        // --- Eventos de la Nueva Barra Inferior (ToolStrip) ---
        // Estos son los que te daban error por faltar

        private void tsPelicula_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowPeliculas>();
        }

        private void tsSala_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowSalas>();
        }

        private void tsSesion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowSesiones>();
        }

        private void tsVenta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowVentas>();
        }

        private void tsTaquilla_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmTaquilla>();
        }

        private void tsConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmConfig>();
        }

        private void tsCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cerrar la aplicación?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // --- Eventos del Menú "Gestión" (Redirigen a los botones de abajo para no repetir código) ---

        private void películasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsPelicula_Click(sender, e);
        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsSala_Click(sender, e);
        }

        private void sesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsSesion_Click(sender, e);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsVenta_Click(sender, e);
        }

        private void conexiónABBDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsConfiguracion_Click(sender, e);
        }

        /*************** MÉTODOS DE REFRESCO DE INTERFAZ *******************/

        private void RefreshControles()
        {
            RefreshStatusBar();
            RefreshMenuState();
        }

        private void RefreshStatusBar()
        {
            // Actualizamos la barra de estado según la conexión
            if (Program.appCine.conectado)
            {
                tsLbEstado.Text = "CONECTADO A LA BASE DE DATOS";
                tsLbEstado.ForeColor = Color.DarkGreen;
            }
            else
            {
                tsLbEstado.Text = "NO CONECTADO - Revise la configuración";
                tsLbEstado.ForeColor = Color.Red;
            }
        }

        private void RefreshMenuState()
        {
            bool hayConexion = Program.appCine.conectado;

            // 1. Menús superiores
            gestiónToolStripMenuItem.Enabled = hayConexion;
            ventanasToolStripMenuItem.Enabled = hayConexion;

            // 2. Barra de herramientas inferior (Botones grandes)
            tsPelicula.Enabled = hayConexion;
            tsSala.Enabled = hayConexion;
            tsSesion.Enabled = hayConexion;
            tsVenta.Enabled = hayConexion;
            tsTaquilla.Enabled = hayConexion;

            // La configuración y cerrar sesión siempre activos
            tsConfiguracion.Enabled = true;
            tsCerrarSesion.Enabled = true;
        }

        /*************** MÉTODOS PRIVADOS *******************/

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();
        }

        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            // Buscar si ya existe un formulario hijo de ese tipo
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.Activate();
                    return;
                }
            }

            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;
            nuevoFrm.WindowState = FormWindowState.Maximized;
            nuevoFrm.Show();
        }

        /******** EVENTOS DE VENTANAS (MDI) *********/

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
        }
    }
}