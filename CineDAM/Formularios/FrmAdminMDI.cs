using CineDAM.Modelos;
using System.Drawing;
using System.Windows.Forms;

namespace CineDAM.Formularios
{
    public partial class FrmAdminMDI : Form
    {
        private System.Windows.Forms.Timer _timerEstado;

        public FrmAdminMDI()
        {
            InitializeComponent();
            ConfigurarTimer();

            // Aplicar renderizador oscuro a los menús
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

            // --- TRUCO: CAMBIAR FONDO DEL ÁREA MDI A OSCURO ---
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(15, 15, 15); // Negro suave
                }
            }
            // -------------------------------------------------

            RefreshControles();
        }

        // ... (RESTO DE TU CÓDIGO DE EVENTOS IGUAL QUE ANTES) ...
        // ... (Copia aquí tus métodos de Click, Cerrar, etc.) ...

        // --- PARA NO COPIAR TODO DE NUEVO, MANTÉN TUS MÉTODOS CLICK ---
        // Solo asegúrate de incluir esta clase al final del archivo o en un archivo aparte:

        #region Renderizador Oscuro Personalizado
        // Esta clase le dice a Windows cómo pintar los menús para que sean oscuros
        private class DarkRenderer : ToolStripProfessionalRenderer
        {
            public DarkRenderer() : base(new DarkColors()) { }
        }

        private class DarkColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(60, 60, 60);
            public override Color MenuItemBorder => Color.FromArgb(0, 122, 204); // Azul borde
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

        // ... (RESTO DE TU CÓDIGO DE CONFIGURAR TIMER, REFRESH, ETC.) ...

        private void ConfigurarTimer()
        {
            _timerEstado = new System.Windows.Forms.Timer();
            _timerEstado.Interval = 1000;
            _timerEstado.Tick += (s, e) => RefreshControles();
            _timerEstado.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.appCine.conectado) Program.appCine.DesconectarDB();
        }

        // --- Eventos de botones ---
        private void tsBtnSalir_Click(object sender, EventArgs e) { CerrarFormulariosHijos(); this.Close(); }
        private void tsMenuItemDepura_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmDebug>(); }
        private void tsPelicula_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowPeliculas>(); }
        private void tsSala_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowSalas>(); }
        private void tsSesion_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowSesiones>(); }
        private void tsVenta_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmBrowVentas>(); }
        private void tsTaquilla_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmTaquilla>(); }
        private void tsConfiguracion_Click(object sender, EventArgs e) { AbrirFormularioHijo<FrmConfig>(); }
        private void tsCerrarSesion_Click(object sender, EventArgs e) { if (MessageBox.Show("¿Cerrar sesión?", "CineDAM", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close(); }

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
                tsLbEstado.ForeColor = Color.LightGreen; // Verde neón
            }
            else
            {
                tsLbEstado.Text = "DESCONECTADO";
                tsLbEstado.ForeColor = Color.IndianRed; // Rojo suave
            }
        }

        private void RefreshMenuState()
        {
            bool hayConexion = Program.appCine.conectado;
            gestiónToolStripMenuItem.Enabled = hayConexion;
            ventanasToolStripMenuItem.Enabled = hayConexion;
            tsPelicula.Enabled = hayConexion;
            tsSala.Enabled = hayConexion;
            tsSesion.Enabled = hayConexion;
            tsVenta.Enabled = hayConexion;
            tsTaquilla.Enabled = hayConexion;
            tsConfiguracion.Enabled = true;
            tsCerrarSesion.Enabled = true;
        }

        private void CerrarFormulariosHijos() { foreach (Form frm in this.MdiChildren) frm.Close(); }

        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            foreach (Form frm in this.MdiChildren) { if (frm is T) { if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal; frm.Activate(); return; } }
            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;
            nuevoFrm.WindowState = FormWindowState.Maximized;
            nuevoFrm.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.Cascade); }
        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.TileHorizontal); }
        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e) { this.LayoutMdi(MdiLayout.TileVertical); }
        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e) { CerrarFormulariosHijos(); }
    }
}