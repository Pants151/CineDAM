namespace CineDAM.Formularios
{
    partial class CineDAM
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
            pnMenu = new Panel();
            menuMain = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
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
            helpToolStripMenuItem = new ToolStripMenuItem();
            tsMenuItemDepura = new ToolStripMenuItem();
            pnStatus = new Panel();
            statusBar = new StatusStrip();
            tsLbEtiquetaEmisor = new ToolStripStatusLabel();
            tsLbEmisor = new ToolStripStatusLabel();
            tsLbEtiquetaInfo = new ToolStripStatusLabel();
            tsLbEstado = new ToolStripStatusLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnMenu.SuspendLayout();
            menuMain.SuspendLayout();
            pnStatus.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(menuMain);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(936, 22);
            pnMenu.TabIndex = 3;
            // 
            // menuMain
            // 
            menuMain.BackColor = Color.Azure;
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, gestiónToolStripMenuItem, ventanasToolStripMenuItem, configuraciónToolStripMenuItem, helpToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(936, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsItemMenuSalir });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // tsItemMenuSalir
            // 
            tsItemMenuSalir.Name = "tsItemMenuSalir";
            tsItemMenuSalir.ShortcutKeys = Keys.Control | Keys.F4;
            tsItemMenuSalir.Size = new Size(142, 22);
            tsItemMenuSalir.Text = "&Salir";
            tsItemMenuSalir.Click += tsBtnSalir_Click;
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { películasToolStripMenuItem, salasToolStripMenuItem, sesionesToolStripMenuItem });
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 20);
            gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // películasToolStripMenuItem
            // 
            películasToolStripMenuItem.Name = "películasToolStripMenuItem";
            películasToolStripMenuItem.Size = new Size(180, 22);
            películasToolStripMenuItem.Text = "Películas";
            películasToolStripMenuItem.Click += películasToolStripMenuItem_Click;
            // 
            // salasToolStripMenuItem
            // 
            salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            salasToolStripMenuItem.Size = new Size(180, 22);
            salasToolStripMenuItem.Text = "Salas";
            // 
            // sesionesToolStripMenuItem
            // 
            sesionesToolStripMenuItem.Name = "sesionesToolStripMenuItem";
            sesionesToolStripMenuItem.Size = new Size(180, 22);
            sesionesToolStripMenuItem.Text = "Sesiones";
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
            pnStatus.Location = new Point(0, 595);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(936, 35);
            pnStatus.TabIndex = 5;
            // 
            // statusBar
            // 
            statusBar.Dock = DockStyle.Fill;
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { tsLbEtiquetaEmisor, tsLbEmisor, tsLbEtiquetaInfo, tsLbEstado });
            statusBar.Location = new Point(0, 0);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(936, 35);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // tsLbEtiquetaEmisor
            // 
            tsLbEtiquetaEmisor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tsLbEtiquetaEmisor.Margin = new Padding(0, 4, 6, 2);
            tsLbEtiquetaEmisor.Name = "tsLbEtiquetaEmisor";
            tsLbEtiquetaEmisor.Size = new Size(47, 29);
            tsLbEtiquetaEmisor.Text = "Emisor:";
            // 
            // tsLbEmisor
            // 
            tsLbEmisor.AutoSize = false;
            tsLbEmisor.Name = "tsLbEmisor";
            tsLbEmisor.Size = new Size(250, 30);
            tsLbEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tsLbEtiquetaInfo
            // 
            tsLbEtiquetaInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tsLbEtiquetaInfo.Margin = new Padding(0, 4, 6, 2);
            tsLbEtiquetaInfo.Name = "tsLbEtiquetaInfo";
            tsLbEtiquetaInfo.Size = new Size(46, 29);
            tsLbEtiquetaInfo.Text = "Estado:";
            // 
            // tsLbEstado
            // 
            tsLbEstado.Margin = new Padding(10, 4, 0, 2);
            tsLbEstado.Name = "tsLbEstado";
            tsLbEstado.Size = new Size(0, 29);
            // 
            // CineDAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 630);
            Controls.Add(pnStatus);
            Controls.Add(pnMenu);
            IsMdiContainer = true;
            Name = "CineDAM";
            Text = "Factura DAM";
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
            ResumeLayout(false);
        }

        #endregion
        private Panel pnMenu;
        private MenuStrip menuMain;
        private Panel pnStatus;
        private StatusStrip statusBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripStatusLabel tsLbEmisor;
        private ToolStripStatusLabel tsLbEstado;
        private ToolStripStatusLabel tsLbEtiquetaEmisor;
        private ToolStripStatusLabel tsLbEtiquetaInfo;
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
    }
}
