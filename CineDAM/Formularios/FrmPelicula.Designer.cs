namespace CineDAM.Formularios
{
    partial class FrmPelicula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPelicula));
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aceptar = new Button();
            panel2 = new Panel();
            txtPosterURL = new TextBox();
            txtClasificacion = new TextBox();
            txtDuracion = new TextBox();
            txtTitulo = new TextBox();
            label4 = new Label();
            lblDuracion = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(btn_aceptar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(660, 60);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Image = (Image)resources.GetObject("btn_cancelar.Image");
            btn_cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancelar.Location = new Point(436, 18);
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
            btn_aceptar.Location = new Point(141, 18);
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
            panel2.Controls.Add(txtPosterURL);
            panel2.Controls.Add(txtClasificacion);
            panel2.Controls.Add(txtDuracion);
            panel2.Controls.Add(txtTitulo);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblDuracion);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(660, 130);
            panel2.TabIndex = 1;
            // 
            // txtPosterURL
            // 
            txtPosterURL.Location = new Point(414, 79);
            txtPosterURL.Name = "txtPosterURL";
            txtPosterURL.Size = new Size(224, 23);
            txtPosterURL.TabIndex = 7;
            // 
            // txtClasificacion
            // 
            txtClasificacion.Location = new Point(414, 22);
            txtClasificacion.Name = "txtClasificacion";
            txtClasificacion.Size = new Size(224, 23);
            txtClasificacion.TabIndex = 6;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(68, 79);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(243, 23);
            txtDuracion.TabIndex = 5;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(68, 22);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(243, 23);
            txtTitulo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(334, 25);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 3;
            label4.Text = "Clasificación";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(7, 82);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(55, 15);
            lblDuracion.TabIndex = 2;
            lblDuracion.Text = "Duración";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 82);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Póster";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 25);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Título";
            // 
            // FrmPelicula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 190);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmPelicula";
            Text = "Película";
            Load += FrmPelicula_Load;
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
        private Label label4;
        private Label lblDuracion;
        private Label label2;
        private Label label1;
        private TextBox txtPosterURL;
        private TextBox txtClasificacion;
        private TextBox txtDuracion;
        private TextBox txtTitulo;
    }
}