using CineDAM.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CineDAM.Formularios
{
    public partial class FrmBrowSesiones : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public FrmBrowSesiones()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
        }

        private void FrmBrowSesiones_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string sql = "SELECT s.id_sesion, s.id_pelicula, s.id_sala, " +
             "p.titulo AS Pelicula, sa.nombre AS Sala, s.hora_inicio, s.precio " +
             "FROM Sesion s " +
             "JOIN Pelicula p ON s.id_pelicula = p.id_pelicula " +
             "JOIN Sala sa ON s.id_sala = sa.id_sala " +
             "ORDER BY s.hora_inicio DESC";

            if (_tabla.InicializarDatos(sql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                PersonalizarDataGrid();
                ActualizarEstado();
            }
            else
            {
                MessageBox.Show("No se pudieron cargar las sesiones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarEstado();
            }
        }

        private void PersonalizarDataGrid()
        {
            // 1. Columnas
            dgTabla.Columns["id_sesion"].Visible = false;
            if (dgTabla.Columns.Contains("id_pelicula")) dgTabla.Columns["id_pelicula"].Visible = false;
            if (dgTabla.Columns.Contains("id_sala")) dgTabla.Columns["id_sala"].Visible = false;

            dgTabla.Columns["Pelicula"].HeaderText = "PELÍCULA";
            dgTabla.Columns["Sala"].HeaderText = "SALA";
            dgTabla.Columns["hora_inicio"].HeaderText = "FECHA Y HORA";
            dgTabla.Columns["precio"].HeaderText = "PRECIO";

            dgTabla.Columns["Pelicula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgTabla.Columns["Sala"].Width = 100;
            dgTabla.Columns["hora_inicio"].Width = 160;
            dgTabla.Columns["precio"].Width = 100;

            // Formatos
            dgTabla.Columns["hora_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgTabla.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgTabla.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 2. Estilos Dark Mode
            dgTabla.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgTabla.GridColor = Color.FromArgb(45, 45, 48);

            // Cabeceras
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgTabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgTabla.ColumnHeadersHeight = 40;

            // Filas
            dgTabla.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgTabla.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgTabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dgTabla.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternancia
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 38);
        }

        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // OJO: AddNew lo dejamos aquí para que el formulario sepa que es nuevo,
            // pero el guardado real lo hace FrmSesion manualmente.
            _bs.AddNew();
            using (FrmSesion frm = new FrmSesion(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Al volver, recargamos todo para actualizar los JOINs
                    CargarDatos();
                }
                else
                {
                    _bs.CancelEdit();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current == null) return;
            using (FrmSesion frm = new FrmSesion(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                if (MessageBox.Show("¿Eliminar sesión seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        // Borrado manual en BD
                        int idSesion = (int)row["id_sesion"];
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand($"DELETE FROM Sesion WHERE id_sesion={idSesion}", Program.appCine.LaConexion))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar de la vista
                        _bs.RemoveCurrent();
                        ActualizarEstado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        // Navegación y Exportación (Igual que los otros forms)
        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();
        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();
        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();
        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK) Export_A_CSV(sfd.FileName);
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML|*.xml" };
            if (sfd.ShowDialog() == DialogResult.OK) Export_A_XML(sfd.FileName);
        }

        private void Export_A_CSV(string ruta)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                List<string> lineas = new List<string>();
                lineas.Add(string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row in dt.Rows) lineas.Add(string.Join(";", row.ItemArray.Select(f => f?.ToString().Replace(";", ","))));
                File.WriteAllLines(ruta, lineas, Encoding.UTF8);
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Export_A_XML(string ruta)
        {
            try
            {
                ((DataTable)_bs.DataSource).WriteXml(ruta, XmlWriteMode.WriteSchema);
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        public void GuardarEstadoVentana() { }
        public void RestaurarEstadoVentana() { }
        private void FrmBrowEmisores_FormClosing(object sender, FormClosingEventArgs e) { GuardarEstadoVentana(); }
        private void FrmBrowEmisores_Shown(object sender, EventArgs e) { RestaurarEstadoVentana(); }
    }
}