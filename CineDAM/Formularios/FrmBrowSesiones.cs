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
    public partial class FrmBrowSesiones : Form
    {
        private Tabla _tabla; // Tabla a gestionar
        private BindingSource _bs; // Para comunicación con los controles visuales
        private Dictionary<int, string> _provincias; // Lista de provincias
        public FrmBrowSesiones()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
        }

        private void FrmBrowPeliculas_Load(object sender, EventArgs e)
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
            // 1. Ocultar la columna de ID (no le interesa al usuario)
            dgTabla.Columns["id_sesion"].Visible = false;

            //Ocultar columnas de FK
            if (dgTabla.Columns.Contains("id_pelicula")) dgTabla.Columns["id_pelicula"].Visible = false;
            if (dgTabla.Columns.Contains("id_sala")) dgTabla.Columns["id_sala"].Visible = false;

            // 2. Configurar cabeceras y anchos
            dgTabla.Columns["Pelicula"].HeaderText = "Película";
            dgTabla.Columns["Pelicula"].Width = 200; // Más espacio para el título

            dgTabla.Columns["Sala"].HeaderText = "Sala";
            dgTabla.Columns["Sala"].Width = 80;

            dgTabla.Columns["hora_inicio"].HeaderText = "Fecha y Hora";
            dgTabla.Columns["hora_inicio"].Width = 140;
            // IMPORTANTE: Formato personalizado para que se vea "06/12/2025 22:00"
            dgTabla.Columns["hora_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgTabla.Columns["precio"].HeaderText = "Precio";
            dgTabla.Columns["precio"].Width = 80;
            // Formato moneda (añade el símbolo € automáticamente)
            dgTabla.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgTabla.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            // 1. Creamos el formulario de sesión (sin pasarle el binding source complejo)
            // Nota: Necesitarás crear un constructor vacío en FrmSesion (ver Paso 2)
            using (FrmSesion frm = new FrmSesion()) 
            {
                // 2. Lo mostramos. Si el usuario guarda correctamente, devolverá OK.
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // 3. Recargamos la tabla para que aparezca la nueva sesión
                    // (Simplemente volvemos a llamar a InicializarDatos con la misma SQL del Load)
                    string sql = "SELECT s.id_sesion, s.id_pelicula, s.id_sala, " +
                                 "p.titulo AS Pelicula, sa.nombre AS Sala, s.hora_inicio, s.precio " +
                                 "FROM Sesion s " +
                                 "JOIN Pelicula p ON s.id_pelicula = p.id_pelicula " +
                                 "JOIN Sala sa ON s.id_sala = sa.id_sala " +
                                 "ORDER BY s.hora_inicio DESC";

                    _tabla.InicializarDatos(sql);
                    _bs.DataSource = _tabla.LaTabla; // Re-vinculamos por si acaso
                    ActualizarEstado();
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
            // 1. Verificamos que haya una fila seleccionada
            if (_bs.Current is DataRowView row)
            {

                // 3. Preguntamos confirmación al usuario
                if (MessageBox.Show($"¿Está seguro de que desea eliminar la sesión?",
                                    "Confirmar eliminación",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        // 1. Obtener el ID de la sesión que vamos a borrar
                        int idSesion = (int)row["id_sesion"];

                        // 2. Ejecutar el DELETE manual en la base de datos
                        string sqlDelete = $"DELETE FROM Sesion WHERE id_sesion = {idSesion}";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlDelete, Program.appCine.LaConexion))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Quitarlo de la lista visual (BindingSource) para que desaparezca
                        _bs.RemoveCurrent();

                        // ¡IMPORTANTE! NO llames a _tabla.GuardarCambios() aquí.

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
            using (FrmSesion frm = new FrmSesion(_bs, _tabla))
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
    }
}
