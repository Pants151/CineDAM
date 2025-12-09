using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

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

            // Suscripción al evento global de cambios
            AppCine.DatosActualizados += AppCine_DatosActualizados;
        }

        // --- PROTECCIÓN CONTRA ERROR DE INVOKE ---
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

        // --- DESUSCRIPCIÓN OBLIGATORIA AL CERRAR ---
        private void FrmBrowSesiones_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppCine.DatosActualizados -= AppCine_DatosActualizados;
            GuardarEstadoVentana();
        }

        private void FrmBrowSesiones_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Consulta con JOINs (la causa original del problema de guardado automático)
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

            dgTabla.Columns["hora_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgTabla.Columns["precio"].DefaultCellStyle.Format = "0.00 €"; 
            dgTabla.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Estilos Dark Mode
            dgTabla.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgTabla.GridColor = Color.FromArgb(45, 45, 48);
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgTabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgTabla.ColumnHeadersHeight = 40;
            dgTabla.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgTabla.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgTabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dgTabla.DefaultCellStyle.SelectionForeColor = Color.White;
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 38);
        }

        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }

        // --- BOTONES: USAR SOLO RECARGA (EL GUARDADO ESTÁ EN FrmSesion) ---
        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            using (FrmSesion frm = new FrmSesion(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos(); // Recargar tras el INSERT manual
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
                    CargarDatos(); // Recargar tras el UPDATE manual
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // --- BORRADO MANUAL (SQL) PARA EVITAR CONCURRENCIA ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                if (MessageBox.Show("¿Eliminar sesión seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int idSesion = (int)row["id_sesion"];

                        // Borrado directo en BD
                        string sql = $"DELETE FROM Sesion WHERE id_sesion={idSesion}";
                        using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Notificar y Recargar
                        AppCine.NotificarCambioDatos();
                        CargarDatos();

                        Program.appCine.RegistrarLog("Baja Sesión", $"Sesión ID {idSesion} eliminada.");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("foreign key"))
                            MessageBox.Show("No se puede borrar: Hay entradas vendidas para esta sesión.");
                        else
                            MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        // Navegación
        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();
        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();
        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();
        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        // Exportación
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
            catch (Exception ex) { 
                MessageBox.Show("Error: " + ex.Message); 
                
            }
        }

        private void Export_A_XML(string ruta)
        {
            try
            {
                ((DataTable)_bs.DataSource).WriteXml(ruta, XmlWriteMode.WriteSchema);
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex) { 
                MessageBox.Show("Error: " + ex.Message); 
            }
        }

        // Métodos de ventana vacíos
        public void GuardarEstadoVentana() { }
        public void RestaurarEstadoVentana() { }
        private void FrmBrowSesiones_Shown(object sender, EventArgs e) { RestaurarEstadoVentana(); }
    }
}