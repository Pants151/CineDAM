namespace CineDAM.Formularios
{
    partial class FrmAdminMDI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            ventasToolStripMenuItem = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            cascadaToolStripMenuItem = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem = new ToolStripMenuItem();
            cerrarTodasLasVentanasToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            conexiónABBDDToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            tsMenuItemDepura = new ToolStripMenuItem();
            pnStatus = new Panel();
            statusBar = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            tsLbEstado = new ToolStripStatusLabel();
            tsMenuPrincipal = new ToolStrip();
            tsPelicula = new ToolStripButton();
            tsSala = new ToolStripButton();
            tsSesion = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsVenta = new ToolStripButton();
            tsTaquilla = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsConfiguracion = new ToolStripButton();
            tsSalir = new ToolStripButton();
            toolStripMenuAcercaDe = new ToolStripMenuItem();
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
            pnMenu.Size = new Size(1040, 26);
            pnMenu.TabIndex = 3;
            // 
            // menuMain
            // 
            menuMain.BackColor = Color.FromArgb(30, 30, 30);
            menuMain.Dock = DockStyle.Fill;
            menuMain.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuMain.ForeColor = Color.LightGray;
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, gestiónToolStripMenuItem, ventanasToolStripMenuItem, configuraciónToolStripMenuItem, helpToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1040, 26);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem, tsItemMenuSalir });
            archivoToolStripMenuItem.ForeColor = Color.White;
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(63, 22);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            cerrarSesiónToolStripMenuItem.ForeColor = Color.White;
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(154, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += tsCerrarSesion_Click;
            // 
            // tsItemMenuSalir
            // 
            tsItemMenuSalir.BackColor = Color.FromArgb(40, 40, 40);
            tsItemMenuSalir.ForeColor = Color.White;
            tsItemMenuSalir.Name = "tsItemMenuSalir";
            tsItemMenuSalir.ShortcutKeys = Keys.Control | Keys.F4;
            tsItemMenuSalir.Size = new Size(154, 22);
            tsItemMenuSalir.Text = "&Salir";
            tsItemMenuSalir.Click += tsBtnSalir_Click;
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { películasToolStripMenuItem, salasToolStripMenuItem, sesionesToolStripMenuItem, ventasToolStripMenuItem });
            gestiónToolStripMenuItem.ForeColor = Color.White;
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(64, 22);
            gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // películasToolStripMenuItem
            // 
            películasToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            películasToolStripMenuItem.ForeColor = Color.White;
            películasToolStripMenuItem.Name = "películasToolStripMenuItem";
            películasToolStripMenuItem.Size = new Size(127, 22);
            películasToolStripMenuItem.Text = "Películas";
            películasToolStripMenuItem.Click += películasToolStripMenuItem_Click;
            // 
            // salasToolStripMenuItem
            // 
            salasToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            salasToolStripMenuItem.ForeColor = Color.White;
            salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            salasToolStripMenuItem.Size = new Size(127, 22);
            salasToolStripMenuItem.Text = "Salas";
            salasToolStripMenuItem.Click += salasToolStripMenuItem_Click;
            // 
            // sesionesToolStripMenuItem
            // 
            sesionesToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            sesionesToolStripMenuItem.ForeColor = Color.White;
            sesionesToolStripMenuItem.Name = "sesionesToolStripMenuItem";
            sesionesToolStripMenuItem.Size = new Size(127, 22);
            sesionesToolStripMenuItem.Text = "Sesiones";
            sesionesToolStripMenuItem.Click += sesionesToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            ventasToolStripMenuItem.ForeColor = Color.White;
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(127, 22);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // ventanasToolStripMenuItem
            // 
            ventanasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadaToolStripMenuItem, mosaicoHorizontalToolStripMenuItem, mosaicoVerticalToolStripMenuItem, cerrarTodasLasVentanasToolStripMenuItem });
            ventanasToolStripMenuItem.ForeColor = Color.White;
            ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            ventanasToolStripMenuItem.Size = new Size(72, 22);
            ventanasToolStripMenuItem.Text = "Ventanas";
            // 
            // cascadaToolStripMenuItem
            // 
            cascadaToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            cascadaToolStripMenuItem.ForeColor = Color.White;
            cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            cascadaToolStripMenuItem.Size = new Size(225, 22);
            cascadaToolStripMenuItem.Text = "Cascada";
            cascadaToolStripMenuItem.Click += cascadaToolStripMenuItem_Click;
            // 
            // mosaicoHorizontalToolStripMenuItem
            // 
            mosaicoHorizontalToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            mosaicoHorizontalToolStripMenuItem.ForeColor = Color.White;
            mosaicoHorizontalToolStripMenuItem.Name = "mosaicoHorizontalToolStripMenuItem";
            mosaicoHorizontalToolStripMenuItem.Size = new Size(225, 22);
            mosaicoHorizontalToolStripMenuItem.Text = "Mosaico Horizontal";
            mosaicoHorizontalToolStripMenuItem.Click += mosaicoHorizontalToolStripMenuItem_Click;
            // 
            // mosaicoVerticalToolStripMenuItem
            // 
            mosaicoVerticalToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            mosaicoVerticalToolStripMenuItem.ForeColor = Color.White;
            mosaicoVerticalToolStripMenuItem.Name = "mosaicoVerticalToolStripMenuItem";
            mosaicoVerticalToolStripMenuItem.Size = new Size(225, 22);
            mosaicoVerticalToolStripMenuItem.Text = "Mosaico Vertical";
            mosaicoVerticalToolStripMenuItem.Click += mosaicoVerticalToolStripMenuItem_Click;
            // 
            // cerrarTodasLasVentanasToolStripMenuItem
            // 
            cerrarTodasLasVentanasToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            cerrarTodasLasVentanasToolStripMenuItem.ForeColor = Color.White;
            cerrarTodasLasVentanasToolStripMenuItem.Name = "cerrarTodasLasVentanasToolStripMenuItem";
            cerrarTodasLasVentanasToolStripMenuItem.Size = new Size(225, 22);
            cerrarTodasLasVentanasToolStripMenuItem.Text = "Cerrar todas las ventanas";
            cerrarTodasLasVentanasToolStripMenuItem.Click += cerrarTodasLasVentanasToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { conexiónABBDDToolStripMenuItem });
            configuraciónToolStripMenuItem.ForeColor = Color.White;
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(101, 22);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // conexiónABBDDToolStripMenuItem
            // 
            conexiónABBDDToolStripMenuItem.BackColor = Color.FromArgb(40, 40, 40);
            conexiónABBDDToolStripMenuItem.ForeColor = Color.White;
            conexiónABBDDToolStripMenuItem.Name = "conexiónABBDDToolStripMenuItem";
            conexiónABBDDToolStripMenuItem.Size = new Size(177, 22);
            conexiónABBDDToolStripMenuItem.Text = "Conexión a BBDD";
            conexiónABBDDToolStripMenuItem.Click += conexiónABBDDToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsMenuItemDepura, toolStripMenuAcercaDe });
            helpToolStripMenuItem.ForeColor = Color.White;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(56, 22);
            helpToolStripMenuItem.Text = "Ay&uda";
            // 
            // tsMenuItemDepura
            // 
            tsMenuItemDepura.BackColor = Color.FromArgb(40, 40, 40);
            tsMenuItemDepura.ForeColor = Color.White;
            tsMenuItemDepura.Name = "tsMenuItemDepura";
            tsMenuItemDepura.Size = new Size(180, 22);
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
            statusBar.BackColor = Color.FromArgb(28, 28, 28);
            statusBar.Dock = DockStyle.Fill;
            statusBar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { lblEstado, tsLbEstado });
            statusBar.Location = new Point(0, 0);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1040, 38);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.LightGray;
            lblEstado.Margin = new Padding(0, 4, 6, 2);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(62, 32);
            lblEstado.Text = "ESTADO:";
            // 
            // tsLbEstado
            // 
            tsLbEstado.ForeColor = Color.White;
            tsLbEstado.Margin = new Padding(0, 4, 0, 2);
            tsLbEstado.Name = "tsLbEstado";
            tsLbEstado.Size = new Size(0, 32);
            // 
            // tsMenuPrincipal
            // 
            tsMenuPrincipal.AutoSize = false;
            tsMenuPrincipal.BackColor = Color.FromArgb(45, 45, 48);
            tsMenuPrincipal.Dock = DockStyle.Bottom;
            tsMenuPrincipal.GripStyle = ToolStripGripStyle.Hidden;
            tsMenuPrincipal.ImageScalingSize = new Size(50, 50);
            tsMenuPrincipal.Items.AddRange(new ToolStripItem[] { tsPelicula, tsSala, tsSesion, toolStripSeparator1, tsVenta, tsTaquilla, toolStripSeparator2, tsConfiguracion, tsSalir });
            tsMenuPrincipal.Location = new Point(0, 396);
            tsMenuPrincipal.Name = "tsMenuPrincipal";
            tsMenuPrincipal.Padding = new Padding(10, 5, 10, 5);
            tsMenuPrincipal.Size = new Size(1040, 95);
            tsMenuPrincipal.TabIndex = 7;
            tsMenuPrincipal.Text = "Menú principal";
            // 
            // tsPelicula
            // 
            tsPelicula.AutoSize = false;
            tsPelicula.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsPelicula.ForeColor = Color.White;
            tsPelicula.Image = (Image)resources.GetObject("tsPelicula.Image");
            tsPelicula.ImageTransparentColor = Color.Magenta;
            tsPelicula.Margin = new Padding(0, 0, 5, 0);
            tsPelicula.Name = "tsPelicula";
            tsPelicula.Size = new Size(90, 80);
            tsPelicula.Text = "PELÍCULAS";
            tsPelicula.TextImageRelation = TextImageRelation.ImageAboveText;
            tsPelicula.Click += tsPelicula_Click;
            // 
            // tsSala
            // 
            tsSala.AutoSize = false;
            tsSala.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsSala.ForeColor = Color.White;
            tsSala.Image = (Image)resources.GetObject("tsSala.Image");
            tsSala.ImageTransparentColor = Color.Magenta;
            tsSala.Margin = new Padding(0, 0, 5, 0);
            tsSala.Name = "tsSala";
            tsSala.Size = new Size(90, 80);
            tsSala.Text = "SALAS";
            tsSala.TextImageRelation = TextImageRelation.ImageAboveText;
            tsSala.Click += tsSala_Click;
            // 
            // tsSesion
            // 
            tsSesion.AutoSize = false;
            tsSesion.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsSesion.ForeColor = Color.White;
            tsSesion.Image = (Image)resources.GetObject("tsSesion.Image");
            tsSesion.ImageTransparentColor = Color.Magenta;
            tsSesion.Margin = new Padding(0, 0, 5, 0);
            tsSesion.Name = "tsSesion";
            tsSesion.Size = new Size(90, 80);
            tsSesion.Text = "SESIONES";
            tsSesion.TextImageRelation = TextImageRelation.ImageAboveText;
            tsSesion.Click += tsSesion_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.ForeColor = Color.White;
            toolStripSeparator1.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 85);
            // 
            // tsVenta
            // 
            tsVenta.AutoSize = false;
            tsVenta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsVenta.ForeColor = Color.White;
            tsVenta.Image = (Image)resources.GetObject("tsVenta.Image");
            tsVenta.ImageTransparentColor = Color.Magenta;
            tsVenta.Margin = new Padding(0, 0, 5, 0);
            tsVenta.Name = "tsVenta";
            tsVenta.Size = new Size(90, 80);
            tsVenta.Text = "VENTAS";
            tsVenta.TextImageRelation = TextImageRelation.ImageAboveText;
            tsVenta.Click += tsVenta_Click;
            // 
            // tsTaquilla
            // 
            tsTaquilla.AutoSize = false;
            tsTaquilla.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsTaquilla.ForeColor = Color.White;
            tsTaquilla.Image = (Image)resources.GetObject("tsTaquilla.Image");
            tsTaquilla.ImageTransparentColor = Color.Magenta;
            tsTaquilla.Margin = new Padding(0, 0, 5, 0);
            tsTaquilla.Name = "tsTaquilla";
            tsTaquilla.Size = new Size(90, 80);
            tsTaquilla.Text = "TAQUILLA";
            tsTaquilla.TextImageRelation = TextImageRelation.ImageAboveText;
            tsTaquilla.Click += tsTaquilla_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 85);
            // 
            // tsConfiguracion
            // 
            tsConfiguracion.Alignment = ToolStripItemAlignment.Right;
            tsConfiguracion.AutoSize = false;
            tsConfiguracion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsConfiguracion.ForeColor = Color.Silver;
            tsConfiguracion.Image = (Image)resources.GetObject("tsConfiguracion.Image");
            tsConfiguracion.ImageTransparentColor = Color.Magenta;
            tsConfiguracion.Name = "tsConfiguracion";
            tsConfiguracion.Size = new Size(90, 80);
            tsConfiguracion.Text = "Configuración";
            tsConfiguracion.TextImageRelation = TextImageRelation.ImageAboveText;
            tsConfiguracion.Click += tsConfiguracion_Click;
            // 
            // tsSalir
            // 
            tsSalir.Alignment = ToolStripItemAlignment.Right;
            tsSalir.AutoSize = false;
            tsSalir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsSalir.ForeColor = Color.Silver;
            tsSalir.Image = (Image)resources.GetObject("tsSalir.Image");
            tsSalir.ImageTransparentColor = Color.Magenta;
            tsSalir.Name = "tsSalir";
            tsSalir.Size = new Size(90, 80);
            tsSalir.Text = "Salir";
            tsSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            tsSalir.Click += tsCerrarSesion_Click;
            // 
            // toolStripMenuAcercaDe
            // 
            toolStripMenuAcercaDe.BackColor = Color.FromArgb(40, 40, 40);
            toolStripMenuAcercaDe.ForeColor = Color.White;
            toolStripMenuAcercaDe.Name = "toolStripMenuAcercaDe";
            toolStripMenuAcercaDe.Size = new Size(180, 22);
            toolStripMenuAcercaDe.Text = "Acerca de...";
            toolStripMenuAcercaDe.Click += toolStripMenuAcercaDe_Click;
            // 
            // FrmAdminMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1040, 529);
            Controls.Add(tsMenuPrincipal);
            Controls.Add(pnMenu);
            Controls.Add(pnStatus);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MinimumSize = new Size(1056, 568);
            Name = "FrmAdminMDI";
            Text = "CineDAM - Panel de Administración";
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
        private ToolStripButton tsSalir;
        private ToolStripButton tsVenta;
        private ToolStripButton tsConfiguracion;
        private ToolStripMenuItem toolStripMenuAcercaDe;
    }
}