namespace CineDAM.Formularios
{
    partial class FrmSala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSala));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            numColumnas = new NumericUpDown();
            numFilas = new NumericUpDown();
            txtNombre = new TextBox();
            lblFila = new Label();
            lblColumna = new Label();
            lblNombre = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numColumnas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFilas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 183);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 60);
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
            btn_cancelar.Location = new Point(267, 18);
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
            btn_aceptar.Location = new Point(151, 18);
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
            panel2.Controls.Add(numColumnas);
            panel2.Controls.Add(numFilas);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(lblFila);
            panel2.Controls.Add(lblColumna);
            panel2.Controls.Add(lblNombre);
            panel2.Dock = DockStyle.Fill;
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 183);
            panel2.TabIndex = 1;
            // 
            // numColumnas
            // 
            numColumnas.BackColor = Color.FromArgb(40, 40, 40);
            numColumnas.BorderStyle = BorderStyle.FixedSingle;
            numColumnas.ForeColor = Color.White;
            numColumnas.Location = new Point(87, 121);
            numColumnas.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numColumnas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numColumnas.Name = "numColumnas";
            numColumnas.Size = new Size(240, 23);
            numColumnas.TabIndex = 6;
            numColumnas.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numFilas
            // 
            numFilas.BackColor = Color.FromArgb(40, 40, 40);
            numFilas.BorderStyle = BorderStyle.FixedSingle;
            numFilas.ForeColor = Color.White;
            numFilas.Location = new Point(87, 78);
            numFilas.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numFilas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFilas.Name = "numFilas";
            numFilas.Size = new Size(240, 23);
            numFilas.TabIndex = 5;
            numFilas.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(40, 40, 40);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.ForeColor = Color.White;
            txtNombre.Location = new Point(84, 22);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(243, 23);
            txtNombre.TabIndex = 4;
            // 
            // lblFila
            // 
            lblFila.AutoSize = true;
            lblFila.ForeColor = Color.LightGray;
            lblFila.Location = new Point(32, 80);
            lblFila.Name = "lblFila";
            lblFila.Size = new Size(30, 15);
            lblFila.TabIndex = 3;
            lblFila.Text = "Filas";
            // 
            // lblColumna
            // 
            lblColumna.AutoSize = true;
            lblColumna.ForeColor = Color.LightGray;
            lblColumna.Location = new Point(7, 121);
            lblColumna.Name = "lblColumna";
            lblColumna.Size = new Size(61, 15);
            lblColumna.TabIndex = 2;
            lblColumna.Text = "Columnas";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.LightGray;
            lblNombre.Location = new Point(11, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // FrmSala
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(379, 243);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmSala";
            Text = "Editar Sala";
            Load += FrmSala_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numColumnas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFilas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_cancelar;
        private Button btn_aceptar;
        private Panel panel2;
        private Label lblFila;
        private Label lblColumna;
        private Label lblNombre;
        private TextBox txtNombre;
        private NumericUpDown numColumnas;
        private NumericUpDown numFilas;
    }
}