using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace CineDAM.Formularios
{
    public partial class FrmBrowSalas : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public FrmBrowSalas()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();

            // Suscripción al evento global de cambios
            AppCine.DatosActualizados += AppCine_DatosActualizados;
        }

        // --- MANEJO SEGURO DE EVENTOS DE OTRAS VENTANAS ---
        private void AppCine_DatosActualizados(object sender, EventArgs e)
        {
            try
            {
                // Doble verificación y manejo de errores silencioso
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.Invoke((MethodInvoker)delegate { CargarDatos(); });
                }
            }
            catch { } // Si falla al invocar (ventana cerrándose), lo ignoramos.
        }

        // --- DESUSCRIPCIÓN AL CERRAR (CRUCIAL PARA EVITAR ERRORES) ---
        private void FrmBrowSalas_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppCine.DatosActualizados -= AppCine_DatosActualizados;
            GuardarEstadoVentana();
        }

        private void FrmBrowSalas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string sql = "SELECT id_sala, nombre, filas, columnas FROM Sala";

            if (_tabla.InicializarDatos(sql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                PersonalizarDataGrid();
                ActualizarEstado();
            }
            else
            {
                MessageBox.Show("No se pudieron cargar las salas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarEstado();
            }
        }

        private void PersonalizarDataGrid()
        {
            // 1. Configuración de Columnas
            dgTabla.Columns["id_sala"].Visible = false;
            dgTabla.Columns["nombre"].HeaderText = "NOMBRE SALA";
            dgTabla.Columns["filas"].HeaderText = "FILAS";
            dgTabla.Columns["columnas"].HeaderText = "COLUMNAS";

            dgTabla.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgTabla.Columns["filas"].Width = 100;
            dgTabla.Columns["columnas"].Width = 100;

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

        // --- GESTIÓN DE EDICIÓN Y CREACIÓN ---
        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            using (FrmSala frm = new FrmSala(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Al volver, recargamos (FrmSala hace el INSERT manual)
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
            using (FrmSala frm = new FrmSala(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Al volver, recargamos (FrmSala hace el UPDATE manual)
                    CargarDatos();
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // --- BORRADO MANUAL (SQL) ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                string nombre = row["nombre"].ToString();
                if (MessageBox.Show($"¿Eliminar sala '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(row["id_sala"]);
                        string sql = $"DELETE FROM Sala WHERE id_sala = {id}";

                        using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        AppCine.NotificarCambioDatos(); // Avisamos a otras ventanas
                        Program.appCine.RegistrarLog("Baja Sala", $"Eliminada: {nombre}");

                        // En este form, recargamos directamente ya que la notificación puede tardar ms
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("foreign key"))
                            MessageBox.Show("No se puede borrar: Esta sala tiene sesiones o ventas asociadas.");
                        else
                            MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        // --- NAVEGACIÓN Y EXPORTACIÓN ---
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

        // Métodos de ventana vacíos
        public void GuardarEstadoVentana() { }
        public void RestaurarEstadoVentana() { }
        private void FrmBrowSalas_Shown(object sender, EventArgs e) { RestaurarEstadoVentana(); }
    }
}