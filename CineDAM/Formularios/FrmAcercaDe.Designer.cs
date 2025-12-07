namespace CineDAM.Formularios
{
    partial class FrmAcercaDe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcercaDe));
            lblApp = new Label();
            lblVersion = new Label();
            lblDesarrollado = new Label();
            lblAutor = new Label();
            btnAceptar = new Button();
            panelLine = new Panel();
            pbIcono = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbIcono).BeginInit();
            SuspendLayout();
            // 
            // lblApp
            // 
            lblApp.AutoSize = true;
            lblApp.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApp.ForeColor = Color.FromArgb(0, 122, 204);
            lblApp.Location = new Point(162, 20);
            lblApp.Name = "lblApp";
            lblApp.Size = new Size(138, 37);
            lblApp.TabIndex = 0;
            lblApp.Text = "CineDAM";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.ForeColor = Color.Gray;
            lblVersion.Location = new Point(162, 57);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(63, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Versión 1.0";
            // 
            // lblDesarrollado
            // 
            lblDesarrollado.AutoSize = true;
            lblDesarrollado.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesarrollado.ForeColor = Color.White;
            lblDesarrollado.Location = new Point(136, 125);
            lblDesarrollado.Name = "lblDesarrollado";
            lblDesarrollado.Size = new Size(112, 17);
            lblDesarrollado.TabIndex = 2;
            lblDesarrollado.Text = "Desarrollado por:";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAutor.ForeColor = Color.LightGreen;
            lblAutor.Location = new Point(49, 153);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(251, 42);
            lblAutor.TabIndex = 3;
            lblAutor.Text = "José Antonio Valenzuela Núñez\n2º DAM";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(40, 40, 40);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(125, 198);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(100, 30);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panelLine
            // 
            panelLine.BackColor = Color.FromArgb(0, 122, 204);
            panelLine.Location = new Point(0, 0);
            panelLine.Name = "panelLine";
            panelLine.Size = new Size(10, 250);
            panelLine.TabIndex = 5;
            // 
            // pbIcono
            // 
            pbIcono.Image = (Image)resources.GetObject("pbIcono.Image");
            pbIcono.Location = new Point(40, 20);
            pbIcono.Name = "pbIcono";
            pbIcono.Size = new Size(90, 122);
            pbIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pbIcono.TabIndex = 6;
            pbIcono.TabStop = false;
            // 
            // FrmAcercaDe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(360, 251);
            Controls.Add(pbIcono);
            Controls.Add(panelLine);
            Controls.Add(btnAceptar);
            Controls.Add(lblAutor);
            Controls.Add(lblDesarrollado);
            Controls.Add(lblVersion);
            Controls.Add(lblApp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de";
            ((System.ComponentModel.ISupportInitialize)pbIcono).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblApp;
        private Label lblVersion;
        private Label lblDesarrollado;
        private Label lblAutor;
        private Button btnAceptar;
        private Panel panelLine;
        private PictureBox pbIcono;
    }
}