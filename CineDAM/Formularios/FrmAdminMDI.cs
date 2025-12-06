using CineDAM.Modelos;

namespace CineDAM.Formularios
{
    public partial class CineDAM : Form
    {
        public CineDAM()
        {
            InitializeComponent();
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
            SeleccionarEmisor();
            RefreshControles();
        }

        private void tsBtnConfig_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmConfig>();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            this.Close();
        }

        private void tsMenuItemDepura_Click(object sender, EventArgs e)
        {
#if DEBUG
            //AbrirFormularioHijo<FrmDepuracion>();
#endif

        }

        private void tsBtnEmisores_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<FrmBrowEmisores>();
        }


        private void tsItemMenuSeleccionarEmisor_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            SeleccionarEmisor();
            RefreshControles();
        }


        /*************** MÉTODOS PRIVADOS *******************/

        private void SeleccionarEmisor()
        {
            /*if ((Program.appCine.estadoApp == EstadoApp.ConectadoSinEmisor) ||
                 (Program.appCine.estadoApp == EstadoApp.Conectado))
            {
                using (var frm = new FrmSeleccionarEmisor())
                {
                    var resultado = frm.ShowDialog();

                    Program.appCine.estadoApp =
                        (Program.appCine.emisor == null) ? EstadoApp.ConectadoSinEmisor : EstadoApp.Conectado;

                }
            }*/
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
                //  if (frm is not FrmDepuracion)
                frm.Close();
        }


        /// <summary>
        /// Abre un formulario hijo MDI del tipo indicado. 
        /// Si ya existe, lo activa y lo restaura si estaba minimizado.
        /// </summary>
        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            // Buscar si ya existe un formulario hijo de ese tipo
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    // Si estaba minimizado, lo restauramos
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.Activate();
                    return;
                }
            }

            // No estaba abierto: creamos una nueva instancia
            T nuevoFrm = new T();
            nuevoFrm.MdiParent = this;
            nuevoFrm.WindowState = FormWindowState.Maximized;
            nuevoFrm.Show();
        }


        private void RefreshToolBar()
        {
            /*if (Program.appCine.estadoApp != EstadoApp.Conectado)
            {
                foreach (ToolStripItem item in tsToolMain.Items)
                {
                    if (item is ToolStripButton)
                    {
                        switch (item.Name)
                        {
                            case "tsBtnConfig":
                                item.Enabled = true;
                                break;
                            case "tsBtnSalir":
                                item.Enabled = true;
                                break;
                            case "tsBtnEmisores":
                                //item.Enabled = (Program.appCine.estadoApp == EstadoApp.ConectadoSinEmisor) ? true : false;
                                break;
                            default:
                                item.Enabled = false;
                                break;

                        }
                    }
                }
            }*/
        }

        private void RefreshStatusBar()
        {
            /*if (Program.appCine.emisor == null)
                tsLbEmisor.Text = "Sin emisor seleccionado";
            else
                tsLbEmisor.Text = $"{Program.appCine.emisor.nombre} {Program.appCine.emisor.apellidos};  NIF: {Program.appDAM.emisor.nifcif}";

            switch (Program.appCine.estadoApp)
            {
                case EstadoApp.Conectado:
                    tsLbEstado.Text = "Conectado a la base de datos";
                    break;
                case EstadoApp.SinConexion:
                    tsLbEstado.Text = "No se ha establecido la conexión a la base de datos.";
                    break;
                case EstadoApp.ConectadoSinEmisor:
                    tsLbEstado.Text = "Conectado a la base de datos, pero no se ha seleccionado un emisor.";
                    break;
                case EstadoApp.Error:
                    if (Program.appCine.ultimoError != "")
                        tsLbEstado.Text = "Se ha producido un error, revisa el log para más detalles.";
                    else
                        tsLbEstado.Text = "Se ha producido un error";
                    break;
            }*/
        }

        private void RefreshControles()
        {
            RefreshToolBar();
            RefreshStatusBar();
        }

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

        private void tsBtnClientes_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<FrmBrowClientes>();
        }

        private void conceptosDeFacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<FrmBrowConceptos>();
        }

        private void tiposDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<FrmBrowTiposIVA>();
        }

        private void productosYServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo<FrmBrowProductos>();
        }

        private void tsBtnVentas_Click(object sender, EventArgs e)
        {
            /*if(!Program.appCine.HayClientes())
                MessageBox.Show("No hay clientes registrados. \n Debe registrarse al menos un cliente antes\n" + "de crear facturas emitidas", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                AbrirFormularioHijo<FrmBrowFacemi>();*/
        }

        private void conexiónABBDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmConfig>();
        }

        private void películasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowPeliculas>();
        }
    }
}
