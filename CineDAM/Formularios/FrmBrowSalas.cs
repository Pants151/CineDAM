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
    public partial class FrmBrowSalas : Form
    {
        private Tabla _tabla; // Tabla a gestionar
        private BindingSource _bs; // Para comunicación con los controles visuales
        private Dictionary<int, string> _provincias; // Lista de provincias
        public FrmBrowSalas()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
        }

        private void FrmBrowSalas_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id_sala, nombre, filas, columnas FROM Sala";

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
            dgTabla.Columns["id_sala"].Visible = false;
            dgTabla.Columns["nombre"].HeaderText = "Nombre Sala";
            dgTabla.Columns["filas"].HeaderText = "Filas";
            dgTabla.Columns["columnas"].HeaderText = "Columnas";

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
                MessageBox.Show("No se ha conectado correctamente con la tabla de Salas.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bs.AddNew();
            using (FrmSala frm = new FrmSala(_bs, _tabla))
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
            // 1. Verificamos que haya una fila seleccionada
            if (_bs.Current is DataRowView row)
            {
                // 2. Obtenemos el título para el mensaje (opcional, pero queda bien)
                string titulo = row["nombre"].ToString();

                // 3. Preguntamos confirmación al usuario
                if (MessageBox.Show($"¿Está seguro de que desea eliminar la sala '{titulo}'?",
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

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Pasamos _bs y _tabla al formulario hijo para que pueda editar
            using (FrmSala frm = new FrmSala(_bs, _tabla))
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
                dt.TableName = "Sala";
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
