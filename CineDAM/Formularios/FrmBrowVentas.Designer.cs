namespace CineDAM.Formularios
{
    partial class FrmBrowVentas
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
            panel1 = new Panel();
            lblTotal = new Label();
            dgVentas = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgVentas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotal);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 400);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(12, 16);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(218, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total Recaudado: 0,00€";
            // 
            // dgVentas
            // 
            dgVentas.AllowUserToAddRows = false;
            dgVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgVentas.Dock = DockStyle.Fill;
            dgVentas.Location = new Point(0, 0);
            dgVentas.Name = "dgVentas";
            dgVentas.ReadOnly = true;
            dgVentas.Size = new Size(800, 400);
            dgVentas.TabIndex = 1;
            // 
            // FrmBrowVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgVentas);
            Controls.Add(panel1);
            Name = "FrmBrowVentas";
            Text = "FrmBrowVentas";
            Load += FrmBrowVentas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTotal;
        private DataGridView dgVentas;
    }
}