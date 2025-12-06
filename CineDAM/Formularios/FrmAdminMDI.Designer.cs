namespace CineDAM.Formularios
{
    partial class FrmAdminMDI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminMDI));
            pnMenu = new Panel();
            menuMain = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            tsItemMenuSalir = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            películasToolStripMenuItem = new ToolStripMenuItem();
            salasToolStripMenuItem = new ToolStripMenuItem();
            sesionesToolStripMenuItem = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            cascadaToolStripMenuItem = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem = new ToolStripMenuItem();
            cerrarTodasLasVentanasToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            conexiónABBDDToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            tsMenuItemDepura = new ToolStripMenuItem();
            pnStatus = new Panel();
            statusBar = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            // Eliminada lblEstadoActual
            tsLbEstado = new ToolStripStatusLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tsPelicula = new ToolStripButton();
            tsSala = new ToolStripButton();
            tsSesion = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsTaquilla = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsCerrarSesion = new ToolStripButton();
            tsMenuPrincipal = new ToolStrip();
            tsVenta = new ToolStripButton();
            tsConfiguracion = new ToolStripButton();
            pnMenu.SuspendLayout();
            menuMain.SuspendLayout();
            pnStatus.SuspendLayout();
            statusBar.SuspendLayout();
            tsMenuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(menuMain);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(1040, 24);
            pnMenu.TabIndex = 3;
            // 
            // menuMain
            // 
            menuMain.BackColor = Color.Azure;
            menuMain.Dock = DockStyle.Fill;
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, gestiónToolStripMenuItem, ventanasToolStripMenuItem, configuraciónToolStripMenuItem, helpToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1040, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem, tsItemMenuSalir });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(143, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += tsCerrarSesion_Click;
            // 
            // tsItemMenuSalir
            // 
            tsItemMenuSalir.Name = "tsItemMenuSalir";
            tsItemMenuSalir.ShortcutKeys = Keys.Control | Keys.F4;
            tsItemMenuSalir.Size = new Size(143, 22);
            tsItemMenuSalir.Text = "&Salir";
            tsItemMenuSalir.Click += tsBtnSalir_Click;
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { películasToolStripMenuItem, salasToolStripMenuItem, sesionesToolStripMenuItem, ventasToolStripMenuItem });
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 20);
            gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // películasToolStripMenuItem
            // 
            películasToolStripMenuItem.Name = "películasToolStripMenuItem";
            películasToolStripMenuItem.Size = new Size(120, 22);
            películasToolStripMenuItem.Text = "Películas";
            películasToolStripMenuItem.Click += películasToolStripMenuItem_Click;
            // 
            // salasToolStripMenuItem
            // 
            salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            salasToolStripMenuItem.Size = new Size(120, 22);
            salasToolStripMenuItem.Text = "Salas";
            salasToolStripMenuItem.Click += salasToolStripMenuItem_Click;
            // 
            // sesionesToolStripMenuItem
            // 
            sesionesToolStripMenuItem.Name = "sesionesToolStripMenuItem";
            sesionesToolStripMenuItem.Size = new Size(120, 22);
            sesionesToolStripMenuItem.Text = "Sesiones";
            sesionesToolStripMenuItem.Click += sesionesToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(120, 22);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // ventanasToolStripMenuItem
            // 
            ventanasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadaToolStripMenuItem, mosaicoHorizontalToolStripMenuItem, mosaicoVerticalToolStripMenuItem, cerrarTodasLasVentanasToolStripMenuItem });
            ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            ventanasToolStripMenuItem.Size = new Size(66, 20);
            ventanasToolStripMenuItem.Text = "Ventanas";
            // 
            // cascadaToolStripMenuItem
            // 
            cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            cascadaToolStripMenuItem.Size = new Size(205, 22);
            cascadaToolStripMenuItem.Text = "Cascada";
            cascadaToolStripMenuItem.Click += cascadaToolStripMenuItem_Click;
            // 
            // mosaicoHorizontalToolStripMenuItem
            // 
            mosaicoHorizontalToolStripMenuItem.Name = "mosaicoHorizontalToolStripMenuItem";
            mosaicoHorizontalToolStripMenuItem.Size = new Size(205, 22);
            mosaicoHorizontalToolStripMenuItem.Text = "Mosaico Horizontal";
            mosaicoHorizontalToolStripMenuItem.Click += mosaicoHorizontalToolStripMenuItem_Click;
            // 
            // mosaicoVerticalToolStripMenuItem
            // 
            mosaicoVerticalToolStripMenuItem.Name = "mosaicoVerticalToolStripMenuItem";
            mosaicoVerticalToolStripMenuItem.Size = new Size(205, 22);
            mosaicoVerticalToolStripMenuItem.Text = "Mosaico Vertical";
            mosaicoVerticalToolStripMenuItem.Click += mosaicoVerticalToolStripMenuItem_Click;
            // 
            // cerrarTodasLasVentanasToolStripMenuItem
            // 
            cerrarTodasLasVentanasToolStripMenuItem.Name = "cerrarTodasLasVentanasToolStripMenuItem";
            cerrarTodasLasVentanasToolStripMenuItem.Size = new Size(205, 22);
            cerrarTodasLasVentanasToolStripMenuItem.Text = "Cerrar todas las ventanas";
            cerrarTodasLasVentanasToolStripMenuItem.Click += cerrarTodasLasVentanasToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { conexiónABBDDToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(95, 20);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // conexiónABBDDToolStripMenuItem
            // 
            conexiónABBDDToolStripMenuItem.Name = "conexiónABBDDToolStripMenuItem";
            conexiónABBDDToolStripMenuItem.Size = new Size(166, 22);
            conexiónABBDDToolStripMenuItem.Text = "Conexión a BBDD";
            conexiónABBDDToolStripMenuItem.Click += conexiónABBDDToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsMenuItemDepura });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(53, 20);
            helpToolStripMenuItem.Text = "Ay&uda";
            // 
            // tsMenuItemDepura
            // 
            tsMenuItemDepura.Name = "tsMenuItemDepura";
            tsMenuItemDepura.Size = new Size(135, 22);
            tsMenuItemDepura.Text = "&Depuración";
            tsMenuItemDepura.Click += tsMenuItemDepura_Click;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusBar);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 491);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(1040, 38);
            pnStatus.TabIndex = 5;
            // 
            // statusBar
            // 
            statusBar.BackColor = Color.IndianRed;
            statusBar.Dock = DockStyle.Fill;
            statusBar.ImageScalingSize = new Size(20, 20);
            // CORREGIDO: Eliminado lblEstadoActual de la lista
            statusBar.Items.AddRange(new ToolStripItem[] { lblEstado, tsLbEstado });
            statusBar.Location = new Point(0, 0);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1040, 38);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.Margin = new Padding(0, 4, 6, 2);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(46, 32);
            lblEstado.Text = "Estado:";
            // 
            // tsLbEstado
            // 
            // CORREGIDO: Reducido el margen izquierdo de 10 a 0
            tsLbEstado.Margin = new Padding(0, 4, 0, 2);
            tsLbEstado.Name = "tsLbEstado";
            tsLbEstado.Size = new Size(0, 32);
            // 
            // tsPelicula
            // 
            tsPelicula.AutoSize = false;
            tsPelicula.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsPelicula.Image = (Image)resources.GetObject("tsPelicula.Image");
            tsPelicula.ImageTransparentColor = Color.Magenta;
            tsPelicula.Margin = new Padding(20, 10, 0, 2);
            tsPelicula.Name = "tsPelicula";
            tsPelicula.Size = new Size(100, 100);
            tsPelicula.Text = "Películas";
            tsPelicula.TextImageRelation = TextImageRelation.ImageAboveText;
            tsPelicula.Click += tsPelicula_Click;
            // 
            // tsSala
            // 
            tsSala.AutoSize = false;
            tsSala.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsSala.Image = (Image)resources.GetObject("tsSala.Image");
            tsSala.ImageTransparentColor = Color.Magenta;
            tsSala.Margin = new Padding(0, 10, 0, 2);
            tsSala.Name = "tsSala";
            tsSala.Size = new Size(100, 100);
            tsSala.Text = "Salas";
            tsSala.TextImageRelation = TextImageRelation.ImageAboveText;
            tsSala.Click += tsSala_Click;
            // 
            // tsSesion
            // 
            tsSesion.AutoSize = false;
            tsSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsSesion.Image = (Image)resources.GetObject("tsSesion.Image");
            tsSesion.ImageTransparentColor = Color.Magenta;
            tsSesion.Margin = new Padding(0, 10, 0, 2);
            tsSesion.Name = "tsSesion";
            tsSesion.Size = new Size(100, 100);
            tsSesion.Text = "Sesiones";
            tsSesion.TextImageRelation = TextImageRelation.ImageAboveText;
            tsSesion.Click += tsSesion_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(50, 0, 0, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 95);
            // 
            // tsTaquilla
            // 
            tsTaquilla.AutoSize = false;
            tsTaquilla.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsTaquilla.Image = (Image)resources.GetObject("tsTaquilla.Image");
            tsTaquilla.ImageTransparentColor = Color.Magenta;
            tsTaquilla.Margin = new Padding(0, 10, 0, 2);
            tsTaquilla.Name = "tsTaquilla";
            tsTaquilla.Size = new Size(100, 100);
            tsTaquilla.Text = "Taquilla";
            tsTaquilla.TextImageRelation = TextImageRelation.ImageAboveText;
            tsTaquilla.Click += tsTaquilla_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(50, 0, 0, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 95);
            // 
            // tsCerrarSesion
            // 
            tsCerrarSesion.AutoSize = false;
            tsCerrarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsCerrarSesion.Image = (Image)resources.GetObject("tsCerrarSesion.Image");
            tsCerrarSesion.ImageTransparentColor = Color.Magenta;
            tsCerrarSesion.Margin = new Padding(0, 0, 0, 0);
            tsCerrarSesion.Name = "tsCerrarSesion";
            tsCerrarSesion.Size = new Size(110, 100);
            tsCerrarSesion.Text = "Cerrar Sesión";
            tsCerrarSesion.TextImageRelation = TextImageRelation.ImageAboveText;
            tsCerrarSesion.Click += tsCerrarSesion_Click;
            // 
            // tsMenuPrincipal
            // 
            tsMenuPrincipal.AutoSize = false;
            tsMenuPrincipal.BackColor = Color.Firebrick;
            tsMenuPrincipal.Dock = DockStyle.Bottom;
            tsMenuPrincipal.ImageScalingSize = new Size(50, 50);
            tsMenuPrincipal.Items.AddRange(new ToolStripItem[] { tsPelicula, tsSala, tsSesion, toolStripSeparator1, tsVenta, tsTaquilla, toolStripSeparator2, tsConfiguracion, tsCerrarSesion });
            tsMenuPrincipal.Location = new Point(0, 396);
            tsMenuPrincipal.Name = "tsMenuPrincipal";
            tsMenuPrincipal.Size = new Size(1040, 95);
            tsMenuPrincipal.TabIndex = 7;
            tsMenuPrincipal.Text = "Menú principal";
            // 
            // tsVenta
            // 
            tsVenta.AutoSize = false;
            tsVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsVenta.Image = (Image)resources.GetObject("tsVenta.Image");
            tsVenta.ImageTransparentColor = Color.Magenta;
            tsVenta.Margin = new Padding(50, 10, 0, 2);
            tsVenta.Name = "tsVenta";
            tsVenta.Size = new Size(100, 100);
            tsVenta.Text = "Ventas";
            tsVenta.TextImageRelation = TextImageRelation.ImageAboveText;
            tsVenta.Click += tsVenta_Click;
            // 
            // tsConfiguracion
            // 
            tsConfiguracion.AutoSize = false;
            tsConfiguracion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tsConfiguracion.Image = (Image)resources.GetObject("tsConfiguracion.Image");
            tsConfiguracion.ImageTransparentColor = Color.Magenta;
            tsConfiguracion.Margin = new Padding(0, 0, 0, 0);
            tsConfiguracion.Name = "tsConfiguracion";
            tsConfiguracion.Size = new Size(120, 100);
            tsConfiguracion.Text = "Configuración";
            tsConfiguracion.TextImageRelation = TextImageRelation.ImageAboveText;
            tsConfiguracion.Click += tsConfiguracion_Click;
            // 
            // FrmAdminMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 529);
            Controls.Add(pnMenu);
            Controls.Add(tsMenuPrincipal);
            Controls.Add(pnStatus);
            IsMdiContainer = true;
            Name = "FrmAdminMDI";
            Text = "CineDAM";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            pnMenu.ResumeLayout(false);
            pnMenu.PerformLayout();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            tsMenuPrincipal.ResumeLayout(false);
            tsMenuPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnMenu;
        private MenuStrip menuMain;
        private Panel pnStatus;
        private StatusStrip statusBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripStatusLabel tsLbEstado;
        private ToolStripStatusLabel lblEstado;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem tsMenuItemDepura;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem tsItemMenuSalir;
        private ToolStripMenuItem ventanasToolStripMenuItem;
        private ToolStripMenuItem cascadaToolStripMenuItem;
        private ToolStripMenuItem mosaicoHorizontalToolStripMenuItem;
        private ToolStripMenuItem mosaicoVerticalToolStripMenuItem;
        private ToolStripMenuItem cerrarTodasLasVentanasToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem películasToolStripMenuItem;
        private ToolStripMenuItem salasToolStripMenuItem;
        private ToolStripMenuItem sesionesToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem conexiónABBDDToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStrip tsMenuPrincipal;
        private ToolStripButton tsPelicula;
        private ToolStripButton tsSala;
        private ToolStripButton tsSesion;
        private ToolStripButton tsTaquilla;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsCerrarSesion;
        private ToolStripButton tsVenta;
        private ToolStripButton tsConfiguracion;
    }
}