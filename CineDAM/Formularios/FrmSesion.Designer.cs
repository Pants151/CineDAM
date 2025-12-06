namespace CineDAM.Formularios
{
    partial class FrmSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSesion));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            lblSala = new Label();
            lblHora = new Label();
            lblPrecio = new Label();
            lblPelicula = new Label();
            cmbPelicula = new ComboBox();
            cmbSala = new ComboBox();
            dtpHora = new DateTimePicker();
            txtPrecio = new NumericUpDown();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 60);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(375, 18);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(80, 23);
            btn_cancelar.TabIndex = 1;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.TextAlign = ContentAlignment.MiddleRight;
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_aceptar
            // 
            btn_aceptar.Image = (Image)resources.GetObject("btn_aceptar.Image");
            btn_aceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_aceptar.Location = new Point(92, 18);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(78, 23);
            btn_aceptar.TabIndex = 0;
            btn_aceptar.Text = "Aceptar";
            btn_aceptar.TextAlign = ContentAlignment.MiddleRight;
            btn_aceptar.UseVisualStyleBackColor = true;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPrecio);
            panel2.Controls.Add(dtpHora);
            panel2.Controls.Add(cmbSala);
            panel2.Controls.Add(cmbPelicula);
            panel2.Controls.Add(lblSala);
            panel2.Controls.Add(lblHora);
            panel2.Controls.Add(lblPrecio);
            panel2.Controls.Add(lblPelicula);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(566, 130);
            panel2.TabIndex = 1;
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.Location = new Point(358, 25);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(28, 15);
            lblSala.TabIndex = 3;
            lblSala.Text = "Sala";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(39, 80);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(33, 15);
            lblHora.TabIndex = 2;
            lblHora.Text = "Hora";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(346, 82);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio";
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(24, 25);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(48, 15);
            lblPelicula.TabIndex = 0;
            lblPelicula.Text = "Película";
            // 
            // cmbPelicula
            // 
            cmbPelicula.FormattingEnabled = true;
            cmbPelicula.Location = new Point(80, 22);
            cmbPelicula.Name = "cmbPelicula";
            cmbPelicula.Size = new Size(121, 23);
            cmbPelicula.TabIndex = 4;
            // 
            // cmbSala
            // 
            cmbSala.FormattingEnabled = true;
            cmbSala.Location = new Point(414, 22);
            cmbSala.Name = "cmbSala";
            cmbSala.Size = new Size(121, 23);
            cmbSala.TabIndex = 5;
            // 
            // dtpHora
            // 
            dtpHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(80, 74);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(139, 23);
            dtpHora.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(414, 80);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(120, 23);
            txtPrecio.TabIndex = 7;
            // 
            // FrmSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 190);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmSesion";
            Text = "Sesión";
            Load += FrmSesion_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_cancelar;
        private Button btn_aceptar;
        private Panel panel2;
        private Label lblSala;
        private Label lblHora;
        private Label lblPrecio;
        private Label lblPelicula;
        private DateTimePicker dtpHora;
        private ComboBox cmbSala;
        private ComboBox cmbPelicula;
        private NumericUpDown txtPrecio;
    }
}