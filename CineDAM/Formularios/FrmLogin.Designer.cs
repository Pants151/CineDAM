namespace CineDAM.Formularios
{
    partial class FrmLogin
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
            lbl_usuario = new Label();
            lbl_contrasenya = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnAceptar = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            btnCancelar = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.Location = new Point(32, 27);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(47, 15);
            lbl_usuario.TabIndex = 0;
            lbl_usuario.Text = "Usuario";
            // 
            // lbl_contrasenya
            // 
            lbl_contrasenya.AutoSize = true;
            lbl_contrasenya.Location = new Point(12, 66);
            lbl_contrasenya.Name = "lbl_contrasenya";
            lbl_contrasenya.Size = new Size(67, 15);
            lbl_contrasenya.TabIndex = 1;
            lbl_contrasenya.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(86, 24);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(204, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(85, 66);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(204, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(32, 24);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(88, 33);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(lbl_contrasenya);
            panel1.Controls.Add(lbl_usuario);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 123);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnAceptar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 78);
            panel2.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(202, 24);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 33);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 201);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmLogin";
            Text = "FrmLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_usuario;
        private Label lbl_contrasenya;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnAceptar;
        private Panel panel1;
        private Panel panel2;
        private Button btnCancelar;
    }
}