namespace CineDAM.Formularios
{
    partial class FrmSala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSala));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            txtFilas = new TextBox();
            txtColumnas = new TextBox();
            txtNombre = new TextBox();
            lblFila = new Label();
            lblColumna = new Label();
            lblNombre = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
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
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(221, 18);
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
            panel2.Controls.Add(txtFilas);
            panel2.Controls.Add(txtColumnas);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(lblFila);
            panel2.Controls.Add(lblColumna);
            panel2.Controls.Add(lblNombre);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 183);
            panel2.TabIndex = 1;
            // 
            // txtFilas
            // 
            txtFilas.Location = new Point(87, 77);
            txtFilas.Name = "txtFilas";
            txtFilas.Size = new Size(240, 23);
            txtFilas.TabIndex = 6;
            // 
            // txtColumnas
            // 
            txtColumnas.Location = new Point(87, 118);
            txtColumnas.Name = "txtColumnas";
            txtColumnas.Size = new Size(240, 23);
            txtColumnas.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(84, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(243, 23);
            txtNombre.TabIndex = 4;
            // 
            // lblFila
            // 
            lblFila.AutoSize = true;
            lblFila.Location = new Point(32, 80);
            lblFila.Name = "lblFila";
            lblFila.Size = new Size(30, 15);
            lblFila.TabIndex = 3;
            lblFila.Text = "Filas";
            // 
            // lblColumna
            // 
            lblColumna.AutoSize = true;
            lblColumna.Location = new Point(7, 121);
            lblColumna.Name = "lblColumna";
            lblColumna.Size = new Size(61, 15);
            lblColumna.TabIndex = 2;
            lblColumna.Text = "Columnas";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
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
            ClientSize = new Size(379, 243);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmSala";
            Text = "Sala";
            Load += FrmSala_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private TextBox txtFilas;
        private TextBox txtColumnas;
        private TextBox txtNombre;
    }
}