namespace CineDAM.Formularios
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            pnData = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            txtBaseDatos = new TextBox();
            numPuerto = new NumericUpDown();
            txtServidor = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            btnConexion = new Button();
            statusStrip1 = new StatusStrip();
            tsStatusLabel = new ToolStripStatusLabel();
            tsProgressBarConexion = new ToolStripProgressBar();
            toolStrip1 = new ToolStrip();
            tsBtnCargar = new ToolStripButton();
            tsBtnGuardar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsLbRutaConfig = new ToolStripLabel();
            pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPuerto).BeginInit();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnData
            // 
            pnData.BackColor = Color.FromArgb(25, 25, 25);
            pnData.BorderStyle = BorderStyle.FixedSingle;
            pnData.Controls.Add(label5);
            pnData.Controls.Add(label4);
            pnData.Controls.Add(label3);
            pnData.Controls.Add(txtPassword);
            pnData.Controls.Add(txtUsuario);
            pnData.Controls.Add(txtBaseDatos);
            pnData.Controls.Add(numPuerto);
            pnData.Controls.Add(txtServidor);
            pnData.Controls.Add(label2);
            pnData.Controls.Add(label1);
            pnData.Location = new Point(20, 69);
            pnData.Name = "pnData";
            pnData.Size = new Size(510, 196);
            pnData.TabIndex = 10;
            // 
            // label5
            // 
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(16, 153);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 19;
            label5.Text = "Contraseña:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(16, 118);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 18;
            label4.Text = "Usuario:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(16, 83);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 17;
            label3.Text = "Base de datos:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(40, 40, 40);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(122, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(215, 23);
            txtPassword.TabIndex = 16;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(40, 40, 40);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.ForeColor = Color.White;
            txtUsuario.Location = new Point(122, 118);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(215, 23);
            txtUsuario.TabIndex = 15;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.BackColor = Color.FromArgb(40, 40, 40);
            txtBaseDatos.BorderStyle = BorderStyle.FixedSingle;
            txtBaseDatos.ForeColor = Color.White;
            txtBaseDatos.Location = new Point(122, 83);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(215, 23);
            txtBaseDatos.TabIndex = 14;
            // 
            // numPuerto
            // 
            numPuerto.BackColor = Color.FromArgb(40, 40, 40);
            numPuerto.ForeColor = Color.White;
            numPuerto.Location = new Point(122, 48);
            numPuerto.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPuerto.Name = "numPuerto";
            numPuerto.Size = new Size(80, 23);
            numPuerto.TabIndex = 13;
            numPuerto.Value = new decimal(new int[] { 3306, 0, 0, 0 });
            // 
            // txtServidor
            // 
            txtServidor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServidor.BackColor = Color.FromArgb(40, 40, 40);
            txtServidor.BorderStyle = BorderStyle.FixedSingle;
            txtServidor.ForeColor = Color.White;
            txtServidor.Location = new Point(122, 13);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(362, 23);
            txtServidor.TabIndex = 12;
            // 
            // label2
            // 
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(16, 48);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 11;
            label2.Text = "Puerto:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(16, 13);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 10;
            label1.Text = "Servidor:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(22, 35);
            label6.Name = "label6";
            label6.Size = new Size(300, 25);
            label6.TabIndex = 11;
            label6.Text = "Conexión a bases de datos MySQL";
            // 
            // btnConexion
            // 
            btnConexion.BackColor = Color.FromArgb(0, 122, 204);
            btnConexion.FlatAppearance.BorderSize = 0;
            btnConexion.FlatStyle = FlatStyle.Flat;
            btnConexion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConexion.ForeColor = Color.White;
            btnConexion.Location = new Point(143, 275);
            btnConexion.Name = "btnConexion";
            btnConexion.Size = new Size(160, 45);
            btnConexion.TabIndex = 12;
            btnConexion.Text = "Probar conexión";
            btnConexion.UseVisualStyleBackColor = false;
            btnConexion.Click += btnProbarConexion_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(25, 25, 25);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatusLabel, tsProgressBarConexion });
            statusStrip1.Location = new Point(0, 332);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(562, 22);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            tsStatusLabel.ForeColor = Color.White;
            tsStatusLabel.Name = "tsStatusLabel";
            tsStatusLabel.Size = new Size(85, 17);
            tsStatusLabel.Text = "No conectado.";
            // 
            // tsProgressBarConexion
            // 
            tsProgressBarConexion.Name = "tsProgressBarConexion";
            tsProgressBarConexion.Size = new Size(100, 16);
            tsProgressBarConexion.Style = ProgressBarStyle.Marquee;
            tsProgressBarConexion.Visible = false;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(45, 45, 48);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsBtnCargar, tsBtnGuardar, toolStripSeparator1, tsLbRutaConfig });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(562, 25);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnCargar
            // 
            tsBtnCargar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnCargar.Image = (Image)resources.GetObject("tsBtnCargar.Image");
            tsBtnCargar.ImageTransparentColor = Color.Magenta;
            tsBtnCargar.Name = "tsBtnCargar";
            tsBtnCargar.Size = new Size(23, 22);
            tsBtnCargar.Text = "Cargar archivo de configuración";
            tsBtnCargar.Click += tsBtnCargar_Click;
            // 
            // tsBtnGuardar
            // 
            tsBtnGuardar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnGuardar.Image = (Image)resources.GetObject("tsBtnGuardar.Image");
            tsBtnGuardar.ImageTransparentColor = Color.Magenta;
            tsBtnGuardar.Name = "tsBtnGuardar";
            tsBtnGuardar.Size = new Size(23, 22);
            tsBtnGuardar.Text = "Guardar configuración";
            tsBtnGuardar.Click += tsBtnGuardar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsLbRutaConfig
            // 
            tsLbRutaConfig.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsLbRutaConfig.ForeColor = Color.LightGray;
            tsLbRutaConfig.Name = "tsLbRutaConfig";
            tsLbRutaConfig.Size = new Size(0, 22);
            tsLbRutaConfig.TextAlign = ContentAlignment.MiddleLeft;
            tsLbRutaConfig.ToolTipText = "Ruta del archivo de configuración";
            // 
            // FrmConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(562, 354);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(btnConexion);
            Controls.Add(label6);
            Controls.Add(pnData);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmConfig";
            Text = "Configuración de BBDD";
            Load += FrmConnection_Load;
            pnData.ResumeLayout(false);
            pnData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPuerto).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnData;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private TextBox txtBaseDatos;
        private NumericUpDown numPuerto;
        private TextBox txtServidor;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button btnConexion;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsStatusLabel;
        private ToolStrip toolStrip1;
        private ToolStripButton tsBtnCargar;
        private ToolStripButton tsBtnGuardar;
        private ToolStripLabel tsLbRutaConfig;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripProgressBar tsProgressBarConexion;
    }
}