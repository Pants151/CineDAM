namespace CineDAM.Formularios
{
    partial class FrmSala
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 60);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(184, 18);
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
            btn_aceptar.Location = new Point(56, 18);
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
            panel2.Controls.Add(numColumnas);
            panel2.Controls.Add(numFilas);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(lblFila);
            panel2.Controls.Add(lblColumna);
            panel2.Controls.Add(lblNombre);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(343, 130);
            panel2.TabIndex = 1;
            // 
            // numColumnas
            // 
            numColumnas.Location = new Point(268, 78);
            numColumnas.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numColumnas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numColumnas.Name = "numColumnas";
            numColumnas.Size = new Size(47, 23);
            numColumnas.TabIndex = 6;
            numColumnas.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numFilas
            // 
            numFilas.Location = new Point(56, 78);
            numFilas.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numFilas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFilas.Name = "numFilas";
            numFilas.Size = new Size(47, 23);
            numFilas.TabIndex = 5;
            numFilas.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(84, 22);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(243, 23);
            txtNombre.TabIndex = 4;
            // 
            // lblFila
            // 
            lblFila.AutoSize = true;
            lblFila.Location = new Point(12, 80);
            lblFila.Name = "lblFila";
            lblFila.Size = new Size(33, 15);
            lblFila.TabIndex = 3;
            lblFila.Text = "Filas:";
            // 
            // lblColumna
            // 
            lblColumna.AutoSize = true;
            lblColumna.Location = new Point(201, 80);
            lblColumna.Name = "lblColumna";
            lblColumna.Size = new Size(64, 15);
            lblColumna.TabIndex = 2;
            lblColumna.Text = "Columnas:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(11, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // FrmSala
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 190);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmSala";
            Text = "Sala";
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