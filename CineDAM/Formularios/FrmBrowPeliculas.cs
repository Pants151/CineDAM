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

namespace CineDAM.Formularios
{
    public partial class FrmBrowPeliculas : Form
    {
        private Tabla _tabla; // Tabla a gestionar
        private BindingSource _bs; // Para comunicación con los controles visuales
        private Dictionary<int, string> _provincias; // Lista de provincias
        public FrmBrowPeliculas()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
        }

        private void FrmBrowPeliculas_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id_pelicula, titulo, duracion_min, clasificacion, poster_url FROM Pelicula";

            if (_tabla.InicializarDatos(sql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                PersonalizarDataGrid();

            }
            else
            {
                MessageBox.Show("No se pudieron cargar las películas. Revisa el log de errores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarEstado();
            }
        }

        /********* METODOS PRIVADOS ***********/

        // Guarda el estado de la ventana (posición y tamaño)
        public void GuardarEstadoVentana()
        {
            /*if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.BrowEmisoresSize = this.Size;
                Properties.Settings.Default.BrowEmisoresLocation = this.Location;
            }

            //Guardar el estado de la ventana como string: "Normal|Maximized|Minimized"
            Properties.Settings.Default.BrowEmisoresState = this.WindowState.ToString();
            Properties.Settings.Default.Save();*/

        }

        // Restaura el estado de la ventana (posición y tamaño)
        public void RestaurarEstadoVentana()
        {
            /*string estado = Properties.Settings.Default.BrowEmisoresState;
            switch (estado)
            {
                case "Maximized":
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case "Minimized":
                    this.WindowState = FormWindowState.Minimized;
                    break;
                default:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }

            if (Properties.Settings.Default.BrowEmisoresState == "Normal")
            {
                this.Size = Properties.Settings.Default.BrowEmisoresSize;
                this.Location = Properties.Settings.Default.BrowEmisoresLocation;
            }*/

        }

        //Personaliza las columnas del DataGridView
        private void PersonalizarDataGrid()
        {
            // Tu SQL es: SELECT id_pelicula AS ID, titulo AS Titulo, ...

            dgTabla.Columns["id_pelicula"].Visible = false; // Ocultamos el ID
            dgTabla.Columns["titulo"].Width = 250;
            dgTabla.Columns["duracion_min"].Width = 100;
            dgTabla.Columns["clasificacion"].Width = 100;

            // Estilo básico
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            // Colorear filas alternas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 255, 255);

            // Estilo para cabeceras (Color, fuente y altura)
            DataGridViewCellStyle estiloCabecera = new DataGridViewCellStyle
            {
                BackColor = Color.LightBlue,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                WrapMode = DataGridViewTriState.True
            };


        }

        private string ObtenerNombreProvincia(int idProvincia)
        {
            return _provincias.TryGetValue(idProvincia, out string nombre) ? nombre : "Desconocida";

        }

        private void ActualizarEstado()
        {
            tslbStatus.Text = $"Nº de registros: {_bs.Count}";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_bs?.DataSource == null || _tabla?.LaTabla == null)
            {
                MessageBox.Show("No se ha conectado correctamente con la tabla de Películas.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bs.AddNew();
            using (FrmPelicula frm = new FrmPelicula(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
                else
                {
                    _bs.CancelEdit();
                }
            }
        }
        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();

        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();

        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();


        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*if (_bs.Current is DataRowView row)
            {
                FrmEmisor frm = new FrmEmisor(_bs, _tabla);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*if (_bs.Current is DataRowView row)
            {
                // --- INICIO DE LA MODIFICACIÓN ---

                // 1. Obtener el ID de la fila que se quiere eliminar
                int idParaEliminar = Convert.ToInt32(row["id"]);

                // 2. Comprobar si el emisor global (Program.appDAM.emisor) existe
                //    y si su ID coincide con el que queremos borrar.
                if (Program.appCine.emisor != null && Program.appCine.emisor.id == idParaEliminar)
                {
                    // 3. Si coincide, mostrar un error y salir del método
                    MessageBox.Show("No puede eliminar el emisor que está actualmente en uso en el programa.",
                                    "Eliminación no permitida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Detenemos la ejecución
                }

                // --- FIN DE LA MODIFICACIÓN ---

                // Si el código continúa, significa que NO es el emisor activo.
                // Procedemos con la confirmación de borrado normal.
                if (MessageBox.Show("¿Está seguro de que desea eliminar el emisor seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
            }*/
        }

        /*private bool esEmisorSeleccionado(string aNifCif)
        {
            if (Program.appCine.emisor != null && Program.appCine.emisor.nifcif == aNifCif)
            {
                return true;
            }
            return false;
        }*/

        private bool TieneFacturasEmitidas(int emisorId)
        {
            using var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM FACTURAS WHERE EMISOR_ID = @EmisorId", Program.appCine.LaConexion);
            cmd.Parameters.AddWithValue("@EmisorId", emisorId);
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private bool TieneFacturasRecibidas(string aNifCif)
        {
            return false;
        }

        
        /*private void CargarProvincias()
        {
            _provincias = new Dictionary<int, string>();
            using var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT id, nombreprovincia FROM provincias", Program.appCine.LaConexion);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                _provincias[id] = nombre;
            }
        }*/

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Pasamos _bs y _tabla al formulario hijo para que pueda editar
            using (FrmPelicula frm = new FrmPelicula(_bs, _tabla))
            {
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // No hace falta Refrescar() si usamos BindingSource correctamente,
                    // pero sí actualizar el contador
                    ActualizarEstado();
                }
            }
        }

        // Formatear la celda de provincia para mostrar el nombre en lugar del ID
        private void dgTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTabla.Columns[e.ColumnIndex].Name == "idprovincia" && e.Value != null)
            {
                if (e.Value is int idProvincia)
                {
                    e.Value = ObtenerNombreProvincia(idProvincia);
                    e.FormattingApplied = true;
                }
            }
        }

        // Manejar el evento de cierre del formulario
        private void FrmBrowEmisores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarEstadoVentana();
        }

        private void FrmBrowEmisores_Shown(object sender, EventArgs e)
        {
            RestaurarEstadoVentana();
        }

        // Exportar a CSV
        private void Export_A_CSV(string rutaArchivo)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                List<string> lineas = new List<string>();

                //Cabezera
                var cabecera = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                lineas.Add(string.Join(";", cabecera));

                //Filas de datos
                foreach (DataRow row in dt.Rows)
                {
                    var campos = row.ItemArray.Select(field => field?.ToString()?.Replace(";", ","));
                    lineas.Add(string.Join(";", campos));
                }

                File.WriteAllLines(rutaArchivo, lineas, Encoding.UTF8);
                MessageBox.Show("Exportación a CSV completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //Program.appDAM.RegistrarLog($"Error al exportar a CSV: {ex.Message}");
                MessageBox.Show($"Error al exportar a CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exportar a XML
        private void Export_A_XML(string rutaArchivo)
        {

            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                dt.TableName = "Emisores";
                dt.WriteXml(rutaArchivo, XmlWriteMode.WriteSchema);
                MessageBox.Show("Exportación a XML completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //Program.appDAM.RegistrarLog($"Error al exportar a XML: {ex.Message}");
                MessageBox.Show($"Error al exportar a XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        // Boton que se encarga de exportar a CSV
        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_A_CSV(sfd.FileName);
            }
        }

        // Boton que se encarga de exportar a XML
        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_A_XML(sfd.FileName);
            }
        }
    }
}
