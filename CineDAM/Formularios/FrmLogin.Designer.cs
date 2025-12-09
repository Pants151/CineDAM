namespace CineDAM.Formularios
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            panelSide = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            txtUsuario = new TextBox();
            panelUserLine = new Panel();
            txtPassword = new TextBox();
            panelPassLine = new Panel();
            lblLogin = new Label();
            btnAcceder = new Button();
            btnCerrar = new PictureBox();
            btnMinimizar = new PictureBox();
            panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            SuspendLayout();
            // 
            // panelSide
            // 
            panelSide.BackColor = Color.FromArgb(0, 122, 204);
            panelSide.Controls.Add(pictureBox1);
            panelSide.Controls.Add(lblTitulo);
            panelSide.Dock = DockStyle.Left;
            panelSide.Location = new Point(0, 0);
            panelSide.Name = "panelSide";
            panelSide.Size = new Size(250, 330);
            panelSide.TabIndex = 0;
            panelSide.MouseDown += Panel_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(65, 190);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(117, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CINE DAM";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.DimGray;
            txtUsuario.Location = new Point(310, 80);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(408, 20);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUser_Enter;
            txtUsuario.Leave += txtUser_Leave;
            // 
            // panelUserLine
            // 
            panelUserLine.BackColor = Color.DimGray;
            panelUserLine.Enabled = false;
            panelUserLine.Location = new Point(310, 107);
            panelUserLine.Name = "panelUserLine";
            panelUserLine.Size = new Size(408, 1);
            panelUserLine.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(15, 15, 15);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(310, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(408, 20);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "CONTRASEÑA";
            txtPassword.Enter += txtPass_Enter;
            txtPassword.Leave += txtPass_Leave;
            // 
            // panelPassLine
            // 
            panelPassLine.BackColor = Color.DimGray;
            panelPassLine.Enabled = false;
            panelPassLine.Location = new Point(310, 177);
            panelPassLine.Name = "panelPassLine";
            panelPassLine.Size = new Size(408, 1);
            panelPassLine.TabIndex = 4;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.DimGray;
            lblLogin.Location = new Point(450, 9);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(100, 33);
            lblLogin.TabIndex = 5;
            lblLogin.Text = "LOGIN";
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnAcceder.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.LightGray;
            btnAcceder.Location = new Point(310, 240);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(408, 40);
            btnAcceder.TabIndex = 3;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.ErrorImage = (Image)resources.GetObject("btnCerrar.ErrorImage");
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(753, 9);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(21, 19);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 7;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.Location = new Point(0, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(100, 50);
            btnMinimizar.TabIndex = 0;
            btnMinimizar.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(btnCerrar);
            Controls.Add(btnAcceder);
            Controls.Add(lblLogin);
            Controls.Add(panelPassLine);
            Controls.Add(txtPassword);
            Controls.Add(panelUserLine);
            Controls.Add(txtUsuario);
            Controls.Add(panelSide);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            MouseDown += Panel_MouseDown;
            panelSide.ResumeLayout(false);
            panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSide;
        private Label lblTitulo;
        private PictureBox pictureBox1;
        private TextBox txtUsuario;
        private Panel panelUserLine;
        private TextBox txtPassword;
        private Panel panelPassLine;
        private Label lblLogin;
        private Button btnAcceder;
        private PictureBox btnCerrar;
        private PictureBox btnMinimizar;
    }
}