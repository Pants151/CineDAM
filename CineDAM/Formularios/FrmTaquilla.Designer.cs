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
            pnHeader = new Panel();
            btnBuscar = new Button();
            cmbSesion = new ComboBox();
            lblSesion = new Label();
            cmbPelicula = new ComboBox();
            lblPelicula = new Label();
            pnFooter = new Panel();
            btnComprar = new Button();
            lblInfo = new Label();
            lblPrecio = new Label();
            pnSala = new Panel();
            pnHeader.SuspendLayout();
            pnFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.FromArgb(25, 25, 25);
            pnHeader.Controls.Add(btnBuscar);
            pnHeader.Controls.Add(cmbSesion);
            pnHeader.Controls.Add(lblSesion);
            pnHeader.Controls.Add(cmbPelicula);
            pnHeader.Controls.Add(lblPelicula);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(800, 60);
            pnHeader.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(0, 122, 204);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(683, 16);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "CARGAR SALA";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbSesion
            // 
            cmbSesion.BackColor = Color.FromArgb(40, 40, 40);
            cmbSesion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSesion.FlatStyle = FlatStyle.Flat;
            cmbSesion.ForeColor = Color.White;
            cmbSesion.FormattingEnabled = true;
            cmbSesion.Location = new Point(382, 20);
            cmbSesion.Name = "cmbSesion";
            cmbSesion.Size = new Size(220, 23);
            cmbSesion.TabIndex = 3;
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Font = new Font("Segoe UI", 9.75F);
            lblSesion.ForeColor = Color.LightGray;
            lblSesion.Location = new Point(326, 22);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(50, 17);
            lblSesion.TabIndex = 2;
            lblSesion.Text = "Sesión:";
            // 
            // cmbPelicula
            // 
            cmbPelicula.BackColor = Color.FromArgb(40, 40, 40);
            cmbPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPelicula.FlatStyle = FlatStyle.Flat;
            cmbPelicula.ForeColor = Color.White;
            cmbPelicula.FormattingEnabled = true;
            cmbPelicula.Location = new Point(75, 20);
            cmbPelicula.Name = "cmbPelicula";
            cmbPelicula.Size = new Size(220, 23);
            cmbPelicula.TabIndex = 1;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Font = new Font("Segoe UI", 9.75F);
            lblPelicula.ForeColor = Color.LightGray;
            lblPelicula.Location = new Point(15, 22);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(54, 17);
            lblPelicula.TabIndex = 0;
            lblPelicula.Text = "Película:";
            // 
            // pnFooter
            // 
            pnFooter.BackColor = Color.FromArgb(25, 25, 25);
            pnFooter.Controls.Add(btnComprar);
            pnFooter.Controls.Add(lblInfo);
            pnFooter.Controls.Add(lblPrecio);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 390);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(800, 60);
            pnFooter.TabIndex = 1;
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
            btnComprar.Location = new Point(628, 10);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(160, 40);
            btnComprar.TabIndex = 8;
            btnComprar.Text = "VENDER ENTRADA";
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
            lblPrecio.Size = new Size(137, 25);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio: 0,00 €";
            // 
            // pnSala
            // 
            pnSala.AutoScroll = true;
            pnSala.BackColor = Color.FromArgb(45, 45, 48); // Gris medio
            pnSala.Dock = DockStyle.Fill;
            pnSala.Location = new Point(0, 60);
            pnSala.Name = "pnSala";
            pnSala.Size = new Size(800, 330);
            pnSala.TabIndex = 2;
            // 
            // FrmTaquilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(800, 450);
            Controls.Add(pnSala);
            Controls.Add(pnFooter);
            Controls.Add(pnHeader);
            Name = "FrmTaquilla";
            Text = "Terminal de Taquilla";
            Load += FrmTaquilla_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnFooter.ResumeLayout(false);
            pnFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnHeader;
        private Label lblSesion;
        private ComboBox cmbPelicula;
        private Label lblPelicula;
        private ComboBox cmbSesion;
        private Button btnBuscar;
        private Panel pnFooter;
        private Label lblPrecio;
        private Panel pnSala;
        private Label lblInfo;
        private Button btnComprar;
    }
}