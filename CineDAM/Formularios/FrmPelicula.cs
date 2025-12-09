using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace CineDAM.Formularios
{
    public partial class FrmPelicula : Form
    {
        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;
        private string _rutaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes");

        public FrmPelicula(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
            // Aseguramos que exista la carpeta al iniciar
            if (!Directory.Exists(_rutaImagenes)) Directory.CreateDirectory(_rutaImagenes);
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            // 1. Cargar el combo de clasificación
            cmbClasificacion.Items.Clear();
            cmbClasificacion.Items.AddRange(new string[] { "Apta", "Mayores 7", "Mayores 12", "Mayores 16", "Mayores 18", "Cine X" });

            // 2. Limpiar bindings antiguos
            txtTitulo.DataBindings.Clear();
            numDuracion.DataBindings.Clear();
            cmbClasificacion.DataBindings.Clear();
            txtPosterURL.DataBindings.Clear();

            // 3. Crear nuevos bindings
            txtTitulo.DataBindings.Add("Text", _bs, "titulo", true);

            // NumericUpDown -> Value
            numDuracion.DataBindings.Add("Value", _bs, "duracion_min", true, DataSourceUpdateMode.OnPropertyChanged, 0);

            cmbClasificacion.DataBindings.Add("Text", _bs, "clasificacion", true);
            txtPosterURL.DataBindings.Add("Text", _bs, "poster_url", true);

            // 4. Mostrar imagen si existe ruta
            if (txtPosterURL.Text.Length > 0)
            {
                CargarPrevisualizacion(txtPosterURL.Text);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string extension = Path.GetExtension(ofd.FileName);
                        string nombreArchivo = $"poster_{DateTime.Now.Ticks}{extension}";
                        string destino = Path.Combine(_rutaImagenes, nombreArchivo);

                        File.Copy(ofd.FileName, destino, true);

                        txtPosterURL.Text = nombreArchivo;
                        CargarPrevisualizacion(nombreArchivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar imagen: " + ex.Message);
                        Program.appCine.RegistrarLog("Error al cargar la imagen", ex.StackTrace);

                    }
                }
            }
        }

        private void CargarPrevisualizacion(string nombreArchivo)
        {
            string rutaCompleta = Path.Combine(_rutaImagenes, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                // Usamos FileStream para no bloquear el archivo
                using (var fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                {
                    pbPoster.Image = Image.FromStream(fs);
                }
            }
            else
            {
                pbPoster.Image = null;
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            // Recogemos valores de los controles
            string titulo = txtTitulo.Text;
            int duracion = (int)numDuracion.Value;
            string clasificacion = cmbClasificacion.Text;
            string poster = txtPosterURL.Text;

            DataRowView row = (DataRowView)_bs.Current;
            bool esNuevo = row.IsNew;

            string sql = "";
            if (esNuevo)
                sql = "INSERT INTO Pelicula (titulo, duracion_min, clasificacion, poster_url) VALUES (@tit, @dur, @clas, @post)";
            else
            {
                int id = Convert.ToInt32(row["id_pelicula"]);
                sql = "UPDATE Pelicula SET titulo=@tit, duracion_min=@dur, clasificacion=@clas, poster_url=@post WHERE id_pelicula=@id";
            }

            try
            {
                using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@tit", titulo);
                    cmd.Parameters.AddWithValue("@dur", duracion);
                    cmd.Parameters.AddWithValue("@clas", clasificacion);
                    cmd.Parameters.AddWithValue("@post", poster);
                    if (!esNuevo) cmd.Parameters.AddWithValue("@id", row["id_pelicula"]);

                    cmd.ExecuteNonQuery();
                }

                // Cancelar edición del BindingSource local para no confundir al grid padre
                _bs.CancelEdit();
                AppCine.NotificarCambioDatos(); // Avisar a todos

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
                Program.appCine.RegistrarLog("Error Guardar Película", ex.StackTrace);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numDuracion.Value <= 0)
            {
                MessageBox.Show("La duración debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbClasificacion.Text))
            {
                MessageBox.Show("Debe seleccionar una clasificación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // --- Comprobación de duplicados en BD ---
            try
            {
                string sql = "SELECT COUNT(*) FROM Pelicula WHERE titulo = @titulo";

                // Si estamos editando, excluimos la propia película que estamos tocando
                // (si no, detectaría que "choca" consigo misma).
                DataRowView row = (DataRowView)_bs.Current;
                if (!row.IsNew)
                {
                    sql += $" AND id_pelicula != {row["id_pelicula"]}";
                }

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe una película registrada con ese título.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTitulo.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar duplicados: " + ex.Message);
                Program.appCine.RegistrarLog("Error Validar Duplicados Película", ex.StackTrace);
                return false;
            }
            // ------------------------------------------------

            return true;
        }
    }
}