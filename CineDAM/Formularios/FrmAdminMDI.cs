namespace CineDAM.Formularios
{
    public partial class FrmAdminMDI : Form
    {
        private System.Windows.Forms.Timer _timerEstado;

        // Bandera para saber si estamos cerrando sesión o saliendo de la app
        private bool _esCierreSesion = false;

        public FrmAdminMDI()
        {
            InitializeComponent();
            ConfigurarTimer();
            menuMain.Renderer = new DarkRenderer();
            tsMenuPrincipal.Renderer = new DarkRenderer();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
#if !DEBUG
            tsMenuItemDepura.Visible = false;
#endif
            menuMain.MdiWindowListItem = ventanasToolStripMenuItem;
            menuMain.ImageScalingSize = new Size(32, 32);

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient) ctl.BackColor = Color.FromArgb(15, 15, 15);
            }

            RefreshControles();
        }

        // --- GESTIÓN CRÍTICA DEL CIERRE ---

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CASO 1: Es un Cierre de Sesión (Volver al Login)
            if (_esCierreSesion)
            {
                // NO desconectamos la BD para que el Login siga teniendo conexión.
                // Simplemente dejamos que el formulario se cierre y el bucle de Program.cs hará el resto.
                return;
            }

            // CASO 2: Es un Cierre de Aplicación (Botón Salir o la X de la ventana)
            if (Program.appCine.conectado)
            {
                Program.appCine.DesconectarDB();
            }

            // Si el usuario pulsó la X, forzamos el cierre total para romper el bucle de Program.cs
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        // Botón "Salir" (Menú Archivo) -> Cierra TODO
        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Botón "Cerrar Sesión" -> Vuelve al Login
        private void tsCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _esCierreSesion = true; // Activamos la bandera
                this.Close();           // Cerramos este form, volviendo al bucle de Program.cs
            }
        }

        // ------------------------------------

        private void ConfigurarTimer()
        {
            _timerEstado = new System.Windows.Forms.Timer();
            _timerEstado.Interval = 1000;
            _timerEstado.Tick += (s, e) => RefreshControles();
            _timerEstado.Start();
        }

        #region Renderizador Oscuro (Sin cambios)
        private class DarkRenderer : ToolStripProfessionalRenderer { public DarkRenderer() : base(new DarkColors()) { } }
        private class DarkColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(60, 60, 60);
            public override Color MenuItemBorder => Color.FromArgb(0, 122, 204);
            public override Color MenuBorder => Color.FromArgb(40, 40, 40);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(30, 30, 30);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(30, 30, 30);
            public override Color ToolStripDropDownBackground => Color.FromArgb(30, 30, 30);
            public override Color ImageMarginGradientBegin => Color.FromArgb(30, 30, 30);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(30, 30, 30);
            public override Color ImageMarginGradientEnd => Color.FromArgb(30, 30, 30);
        }
        #endregion

        // --- Eventos de navegación (Sin cambios) ---
        private void tsMenuItemDepura_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmDebug>(); }
        private void tsPelicula_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowPeliculas>(); }
        private void tsSala_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowSalas>(); }
        private void tsSesion_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowSesiones>(); }
        private void tsVenta_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowVentas>(); }
        private void tsTaquilla_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmTaquilla>(); }
        private void tsConfiguracion_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmConfig>(); }

        private void películasToolStripMenuItem_Click(object sender, EventArgs e) { tsPelicula_Click(sender, e); }
        private void salasToolStripMenuItem_Click(object sender, EventArgs e) { tsSala_Click(sender, e); }
        private void sesionesToolStripMenuItem_Click(object sender, EventArgs e) { tsSesion_Click(sender, e); }
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e) { tsVenta_Click(sender, e); }
        private void conexiónABBDDToolStripMenuItem_Click(object sender, EventArgs e) { tsConfiguracion_Click(sender, e); }

        private void RefreshControles()
        {
            RefreshStatusBar();
            RefreshMenuState();
        }

        private void RefreshStatusBar()
        {
            if (Program.appCine.conectado)
            {
                tsLbEstado.Text = "CONECTADO A BASE DE DATOS";
                tsLbEstado.ForeColor = Color.LightGreen;
            }
            else
            {
                tsLbEstado.Text = "DESCONECTADO";
                tsLbEstado.ForeColor = Color.IndianRed;
            }
        }

        private void RefreshMenuState()
        {
            bool hayConexion = Program.appCine.conectado;

            // 1. Habilitar/Deshabilitar menús
            gestiónToolStripMenuItem.Enabled = hayConexion;
            ventanasToolStripMenuItem.Enabled = hayConexion;

            tsPelicula.Enabled = hayConexion;
            tsSala.Enabled = hayConexion;
            tsSesion.Enabled = hayConexion;
            tsVenta.Enabled = hayConexion;
            tsTaquilla.Enabled = hayConexion;

            tsConfiguracion.Enabled = true;
            tsSalir.Enabled = true;

            // Si no hay conexión, cerrar ventanas operativas (Hijas)
            if (!hayConexion)
            {
                // Recorremos los hijos abiertos al revés para poder cerrarlos sin romper el bucle
                // (Es una buena práctica al modificar una colección mientras se recorre)
                for (int i = this.MdiChildren.Length - 1; i >= 0; i--)
                {
                    Form hijo = this.MdiChildren[i];

                    // Cerramos todo MENOS Configuración y Debug
                    if (!(hijo is FrmConfig) && !(hijo is FrmDebug))
                    {
                        hijo.Close();
                    }
                }
            }
        }

        private void CerrarFormulariosHijos() { foreach (Form frm in this.MdiChildren) frm.Close(); }

        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            // 1. Buscar si ya existe
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

            // 2. Crear nueva instancia
            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;

            // 3. EXCEPCIÓN: Si es la Configuración, NO maximizar
            if (nuevoFrm is FrmConfig)
            {
                nuevoFrm.WindowState = FormWindowState.Normal;
                nuevoFrm.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                // El resto (Browsers, Taquilla) sí se maximizan
                nuevoFrm.WindowState = FormWindowState.Maximized;
            }

            nuevoFrm.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.Cascade); }
        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.TileHorizontal); }
        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.TileVertical); }
        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e) { CerrarFormulariosHijos(); }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frm = new FrmAcercaDe();
            frm.ShowDialog();
        }

        private void toolStripMenuAcercaDe_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frm = new FrmAcercaDe();
            frm.ShowDialog();
        }
    }
}