namespace CineDAM.Formularios
{
    partial class FrmBrowSalas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowSalas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnTools = new Panel();
            tsHerramientas = new ToolStrip();
            btnNew = new ToolStripButton();
            btnEdit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnFirst = new ToolStripButton();
            btnPrev = new ToolStripButton();
            btnNext = new ToolStripButton();
            btnLast = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsBtnExportCSV = new ToolStripButton();
            tsBtnExportXML = new ToolStripButton();
            pnStatus = new Panel();
            statusStrip1 = new StatusStrip();
            tslbStatus = new ToolStripStatusLabel();
            pnData = new Panel();
            dgTabla = new DataGridView();
            pnTools.SuspendLayout();
            tsHerramientas.SuspendLayout();
            pnStatus.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTabla).BeginInit();
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
            tsHerramientas.Items.AddRange(new ToolStripItem[] { btnNew, btnEdit, toolStripSeparator1, btnDelete, toolStripSeparator2, btnFirst, btnPrev, btnNext, btnLast, toolStripSeparator3, tsBtnExportCSV, tsBtnExportXML });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Padding = new Padding(10, 2, 1, 0);
            tsHerramientas.RenderMode = ToolStripRenderMode.System;
            tsHerramientas.Size = new Size(800, 33);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Margin = new Padding(0, 1, 5, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(28, 28);
            btnNew.Text = "Nuevo";
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Margin = new Padding(0, 1, 5, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 28);
            btnEdit.Text = "Editar";
            btnEdit.Click += btnEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Margin = new Padding(5, 1, 5, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 28);
            btnDelete.Text = "Borrar";
            btnDelete.Click += btnDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // btnFirst
            // 
            btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFirst.Image = (Image)resources.GetObject("btnFirst.Image");
            btnFirst.ImageTransparentColor = Color.Magenta;
            btnFirst.Margin = new Padding(5, 1, 0, 2);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(28, 28);
            btnFirst.Text = "Primero";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.ImageTransparentColor = Color.Magenta;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(28, 28);
            btnPrev.Text = "Anterior";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(28, 28);
            btnNext.Text = "Siguiente";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(28, 28);
            btnLast.Text = "Último";
            btnLast.Click += btnLast_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // tsBtnExportCSV
            // 
            tsBtnExportCSV.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnExportCSV.Image = (Image)resources.GetObject("tsBtnExportCSV.Image");
            tsBtnExportCSV.ImageTransparentColor = Color.Magenta;
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
            // pnStatus
            // 
            pnStatus.Controls.Add(statusStrip1);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 424);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(800, 26);
            pnStatus.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(28, 28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslbStatus });
            statusStrip1.Location = new Point(0, 4);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusBar";
            // 
            // tslbStatus
            // 
            tslbStatus.ForeColor = Color.LightGray;
            tslbStatus.Name = "tslbStatus";
            tslbStatus.Size = new Size(118, 17);
            tslbStatus.Text = "toolStripStatusLabel1";
            // 
            // pnData
            // 
            pnData.Controls.Add(dgTabla);
            pnData.Dock = DockStyle.Fill;
            pnData.Location = new Point(0, 35);
            pnData.Name = "pnData";
            pnData.Padding = new Padding(10);
            pnData.Size = new Size(800, 389);
            pnData.TabIndex = 2;
            // 
            // dgTabla
            // 
            dgTabla.AllowUserToAddRows = false;
            dgTabla.AllowUserToDeleteRows = false;
            dgTabla.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgTabla.BorderStyle = BorderStyle.None;
            dgTabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgTabla.ColumnHeadersHeight = 35;
            dgTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgTabla.DefaultCellStyle = dataGridViewCellStyle2;
            dgTabla.Dock = DockStyle.Fill;
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.GridColor = Color.FromArgb(45, 45, 48);
            dgTabla.Location = new Point(10, 10);
            dgTabla.Name = "dgTabla";
            dgTabla.ReadOnly = true;
            dgTabla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgTabla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgTabla.RowHeadersVisible = false;
            dgTabla.RowTemplate.Height = 35;
            dgTabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTabla.Size = new Size(780, 369);
            dgTabla.TabIndex = 0;
            dgTabla.CellMouseDoubleClick += dgTabla_CellMouseDoubleClick;
            // 
            // FrmBrowSalas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(800, 450);
            Controls.Add(pnData);
            Controls.Add(pnStatus);
            Controls.Add(pnTools);
            Name = "FrmBrowSalas";
            Text = "Gestión de Salas";
            FormClosing += FrmBrowSalas_FormClosing;
            Load += FrmBrowSalas_Load;
            Shown += FrmBrowSalas_Shown;
            pnTools.ResumeLayout(false);
            pnTools.PerformLayout();
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgTabla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTools;
        private ToolStrip tsHerramientas;
        private ToolStripButton btnNew;
        private ToolStripButton btnEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrev;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsBtnExportCSV;
        private ToolStripButton tsBtnExportXML;
        private Panel pnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslbStatus;
        private Panel pnData;
        private DataGridView dgTabla;
    }
}