namespace CineDAM.Formularios
{
    partial class FrmDebug
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
            btnRefrescar = new Button();
            chkRefrescar = new CheckBox();
            txtDebug = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(chkRefrescar);
            panel1.Controls.Add(btnRefrescar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 403);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(12, 12);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(75, 23);
            btnRefrescar.TabIndex = 0;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // chkRefrescar
            // 
            chkRefrescar.AutoSize = true;
            chkRefrescar.Location = new Point(105, 16);
            chkRefrescar.Name = "chkRefrescar";
            chkRefrescar.Size = new Size(171, 19);
            chkRefrescar.TabIndex = 1;
            chkRefrescar.Text = "Refrescar automáticamente";
            chkRefrescar.UseVisualStyleBackColor = true;
            // 
            // txtDebug
            // 
            txtDebug.BackColor = SystemColors.ActiveCaptionText;
            txtDebug.Dock = DockStyle.Fill;
            txtDebug.ForeColor = SystemColors.Menu;
            txtDebug.Location = new Point(0, 0);
            txtDebug.Multiline = true;
            txtDebug.Name = "txtDebug";
            txtDebug.ReadOnly = true;
            txtDebug.ScrollBars = ScrollBars.Vertical;
            txtDebug.Size = new Size(800, 403);
            txtDebug.TabIndex = 1;
            // 
            // FrmDebug
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDebug);
            Controls.Add(panel1);
            Name = "FrmDebug";
            Text = "FrmDebug";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private CheckBox chkRefrescar;
        private Button btnRefrescar;
        private TextBox txtDebug;
    }
}