namespace CineDAM.Formularios
{
    partial class FrmSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSesion));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            numPrecio = new NumericUpDown();
            dtpHora = new DateTimePicker();
            cmbSala = new ComboBox();
            cmbPelicula = new ComboBox();
            lblSala = new Label();
            lblHora = new Label();
            lblPrecio = new Label();
            lblPelicula = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 160);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 60);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_cancelar.BackColor = Color.FromArgb(40, 40, 40);
            btn_cancelar.FlatAppearance.BorderSize = 0;
            btn_cancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btn_cancelar.FlatStyle = FlatStyle.Flat;
            btn_cancelar.ForeColor = Color.White;
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(454, 18);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(100, 30);
            btn_cancelar.TabIndex = 1;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.TextAlign = ContentAlignment.MiddleRight;
            btn_cancelar.UseVisualStyleBackColor = false;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_aceptar
            // 
            btn_aceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_aceptar.BackColor = Color.FromArgb(0, 122, 204);
            btn_aceptar.FlatAppearance.BorderSize = 0;
            btn_aceptar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 180);
            btn_aceptar.FlatStyle = FlatStyle.Flat;
            btn_aceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_aceptar.ForeColor = Color.White;
            btn_aceptar.Image = (Image)resources.GetObject("btn_aceptar.Image");
            btn_aceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_aceptar.Location = new Point(338, 18);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(100, 30);
            btn_aceptar.TabIndex = 0;
            btn_aceptar.Text = "ACEPTAR";
            btn_aceptar.TextAlign = ContentAlignment.MiddleRight;
            btn_aceptar.UseVisualStyleBackColor = false;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(15, 15, 15);
            panel2.Controls.Add(numPrecio);
            panel2.Controls.Add(dtpHora);
            panel2.Controls.Add(cmbSala);
            panel2.Controls.Add(cmbPelicula);
            panel2.Controls.Add(lblSala);
            panel2.Controls.Add(lblHora);
            panel2.Controls.Add(lblPrecio);
            panel2.Controls.Add(lblPelicula);
            panel2.Dock = DockStyle.Fill;
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(566, 160);
            panel2.TabIndex = 1;
            // 
            // numPrecio
            // 
            numPrecio.BackColor = Color.FromArgb(40, 40, 40);
            numPrecio.BorderStyle = BorderStyle.FixedSingle;
            numPrecio.DecimalPlaces = 2;
            numPrecio.ForeColor = Color.White;
            numPrecio.Location = new Point(414, 80);
            numPrecio.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(120, 23);
            numPrecio.TabIndex = 7;
            numPrecio.TextAlign = HorizontalAlignment.Right;
            numPrecio.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // dtpHora
            // 
            dtpHora.CalendarMonthBackground = Color.White;
            dtpHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(80, 77);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(139, 23);
            dtpHora.TabIndex = 6;
            // 
            // cmbSala
            // 
            cmbSala.BackColor = Color.FromArgb(40, 40, 40);
            cmbSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSala.FlatStyle = FlatStyle.Flat;
            cmbSala.ForeColor = Color.White;
            cmbSala.FormattingEnabled = true;
            cmbSala.Location = new Point(414, 22);
            cmbSala.Name = "cmbSala";
            cmbSala.Size = new Size(121, 23);
            cmbSala.TabIndex = 5;
            // 
            // cmbPelicula
            // 
            cmbPelicula.BackColor = Color.FromArgb(40, 40, 40);
            cmbPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPelicula.FlatStyle = FlatStyle.Flat;
            cmbPelicula.ForeColor = Color.White;
            cmbPelicula.FormattingEnabled = true;
            cmbPelicula.Location = new Point(80, 22);
            cmbPelicula.Name = "cmbPelicula";
            cmbPelicula.Size = new Size(200, 23);
            cmbPelicula.TabIndex = 4;
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.ForeColor = Color.LightGray;
            lblSala.Location = new Point(358, 25);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(28, 15);
            lblSala.TabIndex = 3;
            lblSala.Text = "Sala";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.ForeColor = Color.LightGray;
            lblHora.Location = new Point(39, 83);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(33, 15);
            lblHora.TabIndex = 2;
            lblHora.Text = "Hora";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.ForeColor = Color.LightGray;
            lblPrecio.Location = new Point(346, 82);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio";
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.ForeColor = Color.LightGray;
            lblPelicula.Location = new Point(24, 25);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(48, 15);
            lblPelicula.TabIndex = 0;
            lblPelicula.Text = "Película";
            // 
            // FrmSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(566, 220);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmSesion";
            Text = "Editar Sesión";
            Load += FrmSesion_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
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
        private NumericUpDown numPrecio;
    }
}