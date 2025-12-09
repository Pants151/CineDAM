using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace CineDAM.Formularios
{
    public partial class FrmBrowPeliculas : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public FrmBrowPeliculas()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
            // Nos suscribimos a cambios globales
            AppCine.DatosActualizados += AppCine_DatosActualizados;
        }

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

        private void CargarDatos()
        {
            string sql = "SELECT id_pelicula, titulo, duracion_min, clasificacion, poster_url FROM Pelicula";
            if (_tabla.InicializarDatos(sql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                PersonalizarDataGrid();
                ActualizarEstado();
            }
        }

        private void FrmBrowPeliculas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // --- MÉTODOS DE VENTANA (Guardar/Restaurar) ---
        public void GuardarEstadoVentana() { /* Código opcional */ }
        public void RestaurarEstadoVentana() { /* Código opcional */ }
        private void FrmBrowEmisores_FormClosing(object sender, FormClosingEventArgs e) { GuardarEstadoVentana(); }
        private void FrmBrowEmisores_Shown(object sender, EventArgs e) { RestaurarEstadoVentana(); }

        // --- PERSONALIZACIÓN DEL GRID (ESTILO OSCURO) ---
        private void PersonalizarDataGrid()
        {
            // 1. Columnas y Nombres
            dgTabla.Columns["id_pelicula"].Visible = false;

            // Ocultamos URL de texto
            if (dgTabla.Columns.Contains("poster_url")) dgTabla.Columns["poster_url"].Visible = false;

            // Columna de Imagen (Póster)
            if (!dgTabla.Columns.Contains("imgPoster"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "imgPoster";
                imgCol.HeaderText = "PÓSTER";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 80;
                dgTabla.Columns.Add(imgCol);
                dgTabla.Columns["imgPoster"].DisplayIndex = 0;
            }

            // Textos de Cabecera
            dgTabla.Columns["titulo"].HeaderText = "TÍTULO";
            dgTabla.Columns["duracion_min"].HeaderText = "MINUTOS";
            dgTabla.Columns["clasificacion"].HeaderText = "CLASIFICACIÓN";

            // Anchos
            dgTabla.Columns["titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // El título ocupa el espacio sobrante
            dgTabla.Columns["duracion_min"].Width = 100;
            dgTabla.Columns["clasificacion"].Width = 150;

            // Altura de fila (para que se vea bien la foto)
            dgTabla.RowTemplate.Height = 100;

            // 2. Colores (Estilo Dark Cine) - Refuerzo por código
            // Fondo general
            dgTabla.BackgroundColor = Color.FromArgb(25, 25, 25);

            // Cabeceras
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul
            dgTabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgTabla.ColumnHeadersHeight = 40;

            // Filas
            dgTabla.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgTabla.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgTabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60); // Gris más claro al seleccionar
            dgTabla.DefaultCellStyle.SelectionForeColor = Color.White;

            // Filas Alternas (Efecto cebra sutil)
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 38);
        }

        // --- CARGA DE IMAGEN EN LA CELDA ---
        private void dgTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTabla.Columns[e.ColumnIndex].Name == "imgPoster")
            {
                var row = dgTabla.Rows[e.RowIndex];
                string nombreArchivo = row.Cells["poster_url"].Value?.ToString();

                if (!string.IsNullOrEmpty(nombreArchivo))
                {
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", nombreArchivo);
                    if (File.Exists(rutaCompleta))
                    {
                        try { e.Value = Image.FromFile(rutaCompleta); } catch { e.Value = null; }
                    }
                }
            }
        }

        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }

        // --- BOTONES ---
        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew(); // Solo para preparar el BindingSource
            using (FrmPelicula frm = new FrmPelicula(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Al volver, solo recargamos. FrmPelicula ya hizo el INSERT.
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
            using (FrmPelicula frm = new FrmPelicula(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Al volver, solo recargamos. FrmPelicula ya hizo el UPDATE.
                    CargarDatos();
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) { btnEdit_Click(sender, e); }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                string titulo = row["titulo"].ToString();
                if (MessageBox.Show($"¿Eliminar '{titulo}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(row["id_pelicula"]);

                        // SQL DIRECTO: Infalible
                        string sql = $"DELETE FROM Pelicula WHERE id_pelicula = {id}";
                        using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Avisamos y recargamos
                        AppCine.NotificarCambioDatos();
                        Program.appCine.RegistrarLog("Baja Película", $"Eliminada: {titulo}");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("foreign key"))
                            MessageBox.Show("No se puede borrar: Esta película tiene sesiones o ventas asociadas.");
                        else
                            MessageBox.Show("Error al borrar: " + ex.Message);
                    }
                }
            }
        }

        // Navegación
        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();
        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();
        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();
        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        // Exportación (CSV/XML) - Código resumido (el tuyo estaba bien)
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
            try { ((DataTable)_bs.DataSource).WriteXml(ruta, XmlWriteMode.WriteSchema); MessageBox.Show("Exportado correctamente."); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}