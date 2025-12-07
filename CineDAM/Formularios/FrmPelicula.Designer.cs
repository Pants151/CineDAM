namespace CineDAM.Formularios
{
    partial class FrmPelicula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPelicula));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            btnSeleccionarImagen = new Button();
            pbPoster = new PictureBox();
            txtPosterURL = new TextBox();
            cmbClasificacion = new ComboBox();
            numDuracion = new NumericUpDown();
            txtTitulo = new TextBox();
            label4 = new Label();
            lblDuracion = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPoster).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 266);
            panel1.Name = "panel1";
            panel1.Size = new Size(530, 60);
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
            btn_cancelar.Location = new Point(418, 18);
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
            btn_aceptar.Location = new Point(302, 18);
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
            panel2.Controls.Add(btnSeleccionarImagen);
            panel2.Controls.Add(pbPoster);
            panel2.Controls.Add(txtPosterURL);
            panel2.Controls.Add(cmbClasificacion);
            panel2.Controls.Add(numDuracion);
            panel2.Controls.Add(txtTitulo);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblDuracion);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(530, 266);
            panel2.TabIndex = 1;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.BackColor = Color.FromArgb(60, 60, 60);
            btnSeleccionarImagen.FlatAppearance.BorderSize = 0;
            btnSeleccionarImagen.FlatStyle = FlatStyle.Flat;
            btnSeleccionarImagen.ForeColor = Color.White;
            btnSeleccionarImagen.Location = new Point(275, 122);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(36, 23);
            btnSeleccionarImagen.TabIndex = 9;
            btnSeleccionarImagen.Text = "...";
            btnSeleccionarImagen.UseVisualStyleBackColor = false;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // pbPoster
            // 
            pbPoster.BackColor = Color.FromArgb(30, 30, 30);
            pbPoster.BorderStyle = BorderStyle.FixedSingle;
            pbPoster.Location = new Point(334, 22);
            pbPoster.Name = "pbPoster";
            pbPoster.Size = new Size(164, 226);
            pbPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pbPoster.TabIndex = 8;
            pbPoster.TabStop = false;
            // 
            // txtPosterURL
            // 
            txtPosterURL.BackColor = Color.FromArgb(40, 40, 40);
            txtPosterURL.BorderStyle = BorderStyle.FixedSingle;
            txtPosterURL.ForeColor = Color.White;
            txtPosterURL.Location = new Point(98, 122);
            txtPosterURL.MaxLength = 255;
            txtPosterURL.Name = "txtPosterURL";
            txtPosterURL.ReadOnly = true;
            txtPosterURL.Size = new Size(171, 23);
            txtPosterURL.TabIndex = 7;
            // 
            // cmbClasificacion
            // 
            cmbClasificacion.BackColor = Color.FromArgb(40, 40, 40);
            cmbClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasificacion.FlatStyle = FlatStyle.Flat;
            cmbClasificacion.ForeColor = Color.White;
            cmbClasificacion.FormattingEnabled = true;
            cmbClasificacion.Location = new Point(98, 71);
            cmbClasificacion.Name = "cmbClasificacion";
            cmbClasificacion.Size = new Size(213, 23);
            cmbClasificacion.TabIndex = 6;
            // 
            // numDuracion
            // 
            numDuracion.BackColor = Color.FromArgb(40, 40, 40);
            numDuracion.BorderStyle = BorderStyle.FixedSingle;
            numDuracion.ForeColor = Color.White;
            numDuracion.Location = new Point(98, 172);
            numDuracion.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(213, 23);
            numDuracion.TabIndex = 5;
            numDuracion.Value = new decimal(new int[] { 90, 0, 0, 0 });
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.FromArgb(40, 40, 40);
            txtTitulo.BorderStyle = BorderStyle.FixedSingle;
            txtTitulo.ForeColor = Color.White;
            txtTitulo.Location = new Point(98, 22);
            txtTitulo.MaxLength = 100;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(213, 23);
            txtTitulo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(18, 74);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 3;
            label4.Text = "Clasificación";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.ForeColor = Color.LightGray;
            lblDuracion.Location = new Point(37, 174);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(55, 15);
            lblDuracion.TabIndex = 2;
            lblDuracion.Text = "Duración";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(52, 125);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Póster";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(54, 25);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Título";
            // 
            // FrmPelicula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(530, 326);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmPelicula";
            Text = "Editar Película";
            Load += FrmPelicula_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_cancelar;
        private Button btn_aceptar;
        private Panel panel2;
        private Label label4;
        private Label lblDuracion;
        private Label label2;
        private Label label1;
        private TextBox txtPosterURL;
        private ComboBox cmbClasificacion;
        private NumericUpDown numDuracion;
        private TextBox txtTitulo;
        private PictureBox pbPoster;
        private Button btnSeleccionarImagen;
    }
}