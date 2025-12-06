namespace CineDAM.Formularios
{
    partial class FrmTaquilla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            pnHeader.Controls.Add(btnBuscar);
            pnHeader.Controls.Add(cmbSesion);
            pnHeader.Controls.Add(lblSesion);
            pnHeader.Controls.Add(cmbPelicula);
            pnHeader.Controls.Add(lblPelicula);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(800, 48);
            pnHeader.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(698, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbSesion
            // 
            cmbSesion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSesion.FormattingEnabled = true;
            cmbSesion.Location = new Point(322, 15);
            cmbSesion.Name = "cmbSesion";
            cmbSesion.Size = new Size(163, 23);
            cmbSesion.TabIndex = 3;
            // 
            // lblSesion
            // 
            lblSesion.AutoSize = true;
            lblSesion.Location = new Point(263, 19);
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(44, 15);
            lblSesion.TabIndex = 2;
            lblSesion.Text = "Sesión:";
            // 
            // cmbPelicula
            // 
            cmbPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPelicula.FormattingEnabled = true;
            cmbPelicula.Location = new Point(69, 15);
            cmbPelicula.Name = "cmbPelicula";
            cmbPelicula.Size = new Size(163, 23);
            cmbPelicula.TabIndex = 1;
            cmbPelicula.SelectedIndexChanged += cmbPelicula_SelectedIndexChanged;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(12, 18);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(51, 15);
            lblPelicula.TabIndex = 0;
            lblPelicula.Text = "Película:";
            // 
            // pnFooter
            // 
            pnFooter.Controls.Add(btnComprar);
            pnFooter.Controls.Add(lblInfo);
            pnFooter.Controls.Add(lblPrecio);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 408);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(800, 42);
            pnFooter.TabIndex = 1;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(698, 10);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(75, 23);
            btnComprar.TabIndex = 8;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(137, 18);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(124, 15);
            lblInfo.TabIndex = 7;
            lblInfo.Text = "Selecciona un asiento.";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(12, 18);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(58, 15);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio: 0€";
            // 
            // pnSala
            // 
            pnSala.AutoScroll = true;
            pnSala.BackColor = SystemColors.ControlDarkDark;
            pnSala.Dock = DockStyle.Fill;
            pnSala.Location = new Point(0, 48);
            pnSala.Name = "pnSala";
            pnSala.Size = new Size(800, 360);
            pnSala.TabIndex = 2;
            // 
            // FrmTaquilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnSala);
            Controls.Add(pnFooter);
            Controls.Add(pnHeader);
            Name = "FrmTaquilla";
            Text = "FrmTaquilla";
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