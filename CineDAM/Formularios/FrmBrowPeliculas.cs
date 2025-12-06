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

            // Ocultamos la columna de texto original de la URL
            if (dgTabla.Columns.Contains("poster_url"))
                dgTabla.Columns["poster_url"].Visible = false;

            // Añadimos una columna de IMAGEN si no existe
            if (!dgTabla.Columns.Contains("imgPoster"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "imgPoster";
                imgCol.HeaderText = "Póster";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Para que se ajuste bien
                imgCol.Width = 60;
                dgTabla.Columns.Add(imgCol);
                // La movemos al principio para que quede chulo
                dgTabla.Columns["imgPoster"].DisplayIndex = 0;
            }

            dgTabla.Columns["titulo"].Width = 200;

            
            dgTabla.Columns["duracion_min"].Width = 100;
            dgTabla.Columns["clasificacion"].Width = 100;


            // Hacer las filas más altas para que quepa la imagen
            dgTabla.RowTemplate.Height = 80;

            // 3. Estilo general (opcional, para que se vea igual que el de Películas)
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgTabla.EnableHeadersVisualStyles = false; // Necesario para personalizar el color de cabecera
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya una fila seleccionada
            if (_bs.Current is DataRowView row)
            {
                // 2. Obtenemos el título para el mensaje (opcional, pero queda bien)
                string titulo = row["titulo"].ToString();

                // 3. Preguntamos confirmación al usuario
                if (MessageBox.Show($"¿Está seguro de que desea eliminar la película '{titulo}'?",
                                    "Confirmar eliminación",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        // 4. Eliminamos la fila del BindingSource
                        _bs.RemoveCurrent();

                        // 5. Guardamos los cambios en la BBDD
                        _tabla.GuardarCambios();

                        // 6. Actualizamos la barra de estado
                        ActualizarEstado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la película: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


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
            // Si estamos en la columna de imagen...
            if (dgTabla.Columns[e.ColumnIndex].Name == "imgPoster")
            {
                // Obtenemos el nombre del archivo de la fila actual (columna oculta "poster_url")
                var row = dgTabla.Rows[e.RowIndex];
                string nombreArchivo = row.Cells["poster_url"].Value?.ToString();

                if (!string.IsNullOrEmpty(nombreArchivo))
                {
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", nombreArchivo);

                    if (File.Exists(rutaCompleta))
                    {
                        // Cargar imagen (usando Image.FromFile o FromStream)
                        // Usamos una caché simple o carga directa (ojo con el rendimiento si son muchas)
                        e.Value = Image.FromFile(rutaCompleta);
                    }
                    else
                    {
                        // Si no encuentra el archivo, podrías poner una imagen "X" o null
                        e.Value = null;
                    }
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
                dt.TableName = "Pelicula";
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

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            // Verifica que la conexión con los datos esté establecida
            if (_bs?.DataSource == null || _tabla?.LaTabla == null)
            {
                MessageBox.Show("No se ha conectado correctamente con la tabla de Películas.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Añade un nuevo registro al BindingSource
            _bs.AddNew();

            // Abre el formulario de edición de película pasando el BindingSource y la Tabla
            using (FrmPelicula frm = new FrmPelicula(_bs, _tabla))
            {
                frm.edicion = true; // Marca que se está editando (o creando)

                // Si el usuario acepta, guarda los cambios en la base de datos
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
                else
                {
                    // Si cancela, deshace la creación del nuevo registro
                    _bs.CancelEdit();
                }
            }
        }
    }
}