namespace CineDAM.Formularios
{
    partial class FrmTaquilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaquilla));
            flpPeliculas = new FlowLayoutPanel();
            pnSesion = new Panel();
            btnBuscar = new Button();
            cmbSesion = new ComboBox();
            lblSesion = new Label();
            pnFooter = new Panel();
            btnComprar = new Button();
            lblInfo = new Label();
            lblPrecio = new Label();
            pnSala = new Panel();
            pnSesion.SuspendLayout();
            pnFooter.SuspendLayout();
            SuspendLayout();
            // 
            // flpPeliculas
            // 
            flpPeliculas.AutoScroll = true;
            flpPeliculas.BackColor = Color.FromArgb(20, 20, 20);
            flpPeliculas.Dock = DockStyle.Top;
            flpPeliculas.Location = new Point(0, 0);
            flpPeliculas.Name = "flpPeliculas";
            flpPeliculas.Padding = new Padding(10);
            flpPeliculas.Size = new Size(1000, 210);
            flpPeliculas.TabIndex = 0;
            flpPeliculas.WrapContents = false;
            // 
            // pnSesion
            // 
            pnSesion.BackColor = Color.FromArgb(30, 30, 30);
            pnSesion.Controls.Add(btnBuscar);
            pnSesion.Controls.Add(cmbSesion);
            pnSesion.Controls.Add(lblSesion);
            pnSesion.Dock = DockStyle.Top;
            pnSesion.Location = new Point(0, 210);
            pnSesion.Name = "pnSesion";
            pnSesion.Size = new Size(1000, 50);
            pnSesion.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(0, 122, 204);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(883, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "CARGAR SALA";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbSesion
            // 
            cmbSesion.BackColor = Color.FromArgb(45, 45, 48);
            cmbSesion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSesion.FlatStyle = FlatStyle.Flat;
            cmbSesion.Font = new Font("Segoe UI", 10F);
            cmbSesion.ForeColor = Color.White;
            cmbSesion.FormattingEnabled = true;
            cmbSesion.Location = new Point(75, 13);
            cmbSesion.Name = "cmbSesion";
            cmbSesion.Size = new Size(300, 25);
            cmbSesion.TabIndex = 3;
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSesion.ForeColor = Color.LightGray;
            lblSesion.Location = new Point(12, 16);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(62, 19);
            lblSesion.TabIndex = 2;
            lblSesion.Text = "SESIÓN:";
            // 
            // pnFooter
            // 
            pnFooter.BackColor = Color.FromArgb(25, 25, 25);
            pnFooter.Controls.Add(btnComprar);
            pnFooter.Controls.Add(lblInfo);
            pnFooter.Controls.Add(lblPrecio);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 590);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(1000, 60);
            pnFooter.TabIndex = 2;
            // 
            // btnComprar
            // 
            btnComprar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnComprar.BackColor = Color.SeaGreen;
            btnComprar.Enabled = false;
            btnComprar.FlatAppearance.BorderSize = 0;
            btnComprar.FlatStyle = FlatStyle.Flat;
            btnComprar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnComprar.ForeColor = Color.White;
            btnComprar.Location = new Point(819, 10);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(169, 40);
            btnComprar.TabIndex = 8;
            btnComprar.Text = "COMPRAR ENTRADA";
            btnComprar.UseVisualStyleBackColor = false;
            btnComprar.Click += btnComprar_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 11F);
            lblInfo.ForeColor = Color.LightGray;
            lblInfo.Location = new Point(190, 20);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(161, 20);
            lblInfo.TabIndex = 7;
            lblInfo.Text = "Selecciona un asiento...";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.Gold;
            lblPrecio.Location = new Point(12, 17);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(132, 25);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio: 0,00 €";
            // 
            // pnSala
            // 
            pnSala.AutoScroll = true;
            pnSala.BackColor = Color.FromArgb(45, 45, 48);
            pnSala.Dock = DockStyle.Fill;
            pnSala.Location = new Point(0, 260);
            pnSala.Name = "pnSala";
            pnSala.Size = new Size(1000, 330);
            pnSala.TabIndex = 3;
            // 
            // FrmTaquilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1000, 650);
            Controls.Add(pnSala);
            Controls.Add(pnFooter);
            Controls.Add(pnSesion);
            Controls.Add(flpPeliculas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 600);
            Name = "FrmTaquilla";
            Text = "Terminal de Taquilla - Selección Visual";
            Load += FrmTaquilla_Load;
            pnSesion.ResumeLayout(false);
            pnSesion.PerformLayout();
            pnFooter.ResumeLayout(false);
            pnFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpPeliculas; // NUEVO
        private Panel pnSesion;
        private Label lblSesion;
        private ComboBox cmbSesion;
        private Button btnBuscar;
        private Panel pnFooter;
        private Label lblPrecio;
        private Panel pnSala;
        private Label lblInfo;
        private Button btnComprar;
    }
}