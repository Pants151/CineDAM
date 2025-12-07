namespace CineDAM.Formularios
{
    partial class FrmBrowVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowVentas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnTools = new Panel();
            tsHerramientas = new ToolStrip();
            tsBtnExportCSV = new ToolStripButton();
            tsBtnExportXML = new ToolStripButton();
            pnFooter = new Panel();
            lblTotal = new Label();
            pnData = new Panel();
            dgVentas = new DataGridView();
            pnTools.SuspendLayout();
            tsHerramientas.SuspendLayout();
            pnFooter.SuspendLayout();
            pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgVentas).BeginInit();
            SuspendLayout();
            // 
            // pnTools
            // 
            pnTools.BackColor = Color.FromArgb(45, 45, 48);
            pnTools.Controls.Add(tsHerramientas);
            pnTools.Dock = DockStyle.Top;
            pnTools.Location = new Point(0, 0);
            pnTools.Name = "pnTools";
            pnTools.Size = new Size(800, 35);
            pnTools.TabIndex = 0;
            // 
            // tsHerramientas
            // 
            tsHerramientas.BackColor = Color.Gray;
            tsHerramientas.GripStyle = ToolStripGripStyle.Hidden;
            tsHerramientas.ImageScalingSize = new Size(24, 24);
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsBtnExportCSV, tsBtnExportXML });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Padding = new Padding(10, 2, 1, 0);
            tsHerramientas.RenderMode = ToolStripRenderMode.System;
            tsHerramientas.Size = new Size(800, 33);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
            // 
            // tsBtnExportCSV
            // 
            tsBtnExportCSV.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnExportCSV.Image = (Image)resources.GetObject("tsBtnExportCSV.Image");
            tsBtnExportCSV.ImageTransparentColor = Color.Magenta;
            tsBtnExportCSV.Margin = new Padding(0, 1, 5, 2);
            tsBtnExportCSV.Name = "tsBtnExportCSV";
            tsBtnExportCSV.Size = new Size(28, 28);
            tsBtnExportCSV.Text = "Exportar a CSV";
            tsBtnExportCSV.Click += tsBtnExportCSV_Click;
            // 
            // tsBtnExportXML
            // 
            tsBtnExportXML.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnExportXML.Image = (Image)resources.GetObject("tsBtnExportXML.Image");
            tsBtnExportXML.ImageTransparentColor = Color.Magenta;
            tsBtnExportXML.Name = "tsBtnExportXML";
            tsBtnExportXML.Size = new Size(28, 28);
            tsBtnExportXML.Text = "Exportar a XML";
            tsBtnExportXML.Click += tsBtnExportXML_Click;
            // 
            // pnFooter
            // 
            pnFooter.BackColor = Color.FromArgb(25, 25, 25);
            pnFooter.Controls.Add(lblTotal);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 400);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(800, 50);
            pnFooter.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.LightGreen;
            lblTotal.Location = new Point(488, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(300, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total Recaudado: 0,00 €";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnData
            // 
            pnData.Controls.Add(dgVentas);
            pnData.Dock = DockStyle.Fill;
            pnData.Location = new Point(0, 35);
            pnData.Name = "pnData";
            pnData.Padding = new Padding(10);
            pnData.Size = new Size(800, 365);
            pnData.TabIndex = 2;
            // 
            // dgVentas
            // 
            dgVentas.AllowUserToAddRows = false;
            dgVentas.AllowUserToDeleteRows = false;
            dgVentas.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgVentas.BorderStyle = BorderStyle.None;
            dgVentas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgVentas.ColumnHeadersHeight = 35;
            dgVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgVentas.DefaultCellStyle = dataGridViewCellStyle2;
            dgVentas.Dock = DockStyle.Fill;
            dgVentas.EnableHeadersVisualStyles = false;
            dgVentas.GridColor = Color.FromArgb(45, 45, 48);
            dgVentas.Location = new Point(10, 10);
            dgVentas.Name = "dgVentas";
            dgVentas.ReadOnly = true;
            dgVentas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgVentas.RowHeadersVisible = false;
            dgVentas.RowTemplate.Height = 35;
            dgVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgVentas.Size = new Size(780, 345);
            dgVentas.TabIndex = 0;
            // 
            // FrmBrowVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(800, 450);
            Controls.Add(pnData);
            Controls.Add(pnFooter);
            Controls.Add(pnTools);
            Name = "FrmBrowVentas";
            Text = "Historial de Ventas";
            Load += FrmBrowVentas_Load;
            pnTools.ResumeLayout(false);
            pnTools.PerformLayout();
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            pnFooter.ResumeLayout(false);
            pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTools;
        private ToolStrip tsHerramientas;
        private ToolStripButton tsBtnExportCSV;
        private ToolStripButton tsBtnExportXML;
        private Panel pnFooter;
        private Label lblTotal;
        private Panel pnData;
        private DataGridView dgVentas;
    }
}