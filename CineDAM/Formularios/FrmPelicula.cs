using CineDAM.Modelos;
using System.IO; // Necesario para manejar archivos

namespace CineDAM.Formularios
{
    public partial class FrmPelicula : Form
    {
        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;

        // Ruta base donde guardaremos las imágenes
        private string _rutaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes");

        public FrmPelicula(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;

            // Crear carpeta si no existe
            if (!Directory.Exists(_rutaImagenes)) Directory.CreateDirectory(_rutaImagenes);
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            cmbClasificacion.Items.Clear();
            cmbClasificacion.Items.AddRange(new string[] { "Todos", "Apta", "Mayores 7", "Mayores 12", "Mayores 16", "Mayores 18", "Mayores 19" });

            txtTitulo.DataBindings.Clear();
            numDuracion.DataBindings.Clear();
            cmbClasificacion.DataBindings.Clear();
            txtPosterURL.DataBindings.Clear();

            txtTitulo.DataBindings.Add("Text", _bs, "titulo", true);
            numDuracion.DataBindings.Add("Value", _bs, "duracion_min", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            cmbClasificacion.DataBindings.Add("Text", _bs, "clasificacion", true);
            txtPosterURL.DataBindings.Add("Text", _bs, "poster_url", true);

            // Cargar imagen en el PictureBox si ya existe ruta
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
                        // 1. Generar un nombre único para evitar duplicados (ej: poster_12345.jpg)
                        string extension = Path.GetExtension(ofd.FileName);
                        string nombreArchivo = $"poster_{DateTime.Now.Ticks}{extension}";
                        string destino = Path.Combine(_rutaImagenes, nombreArchivo);

                        // 2. Copiar la imagen a nuestra carpeta local
                        File.Copy(ofd.FileName, destino, true);

                        // 3. Guardar solo el nombre del archivo en el TextBox (y en la BD)
                        txtPosterURL.Text = nombreArchivo;

                        // 4. Mostrar
                        CargarPrevisualizacion(nombreArchivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar imagen: " + ex.Message);
                    }
                }
            }
        }

        private void CargarPrevisualizacion(string nombreArchivo)
        {
            string rutaCompleta = Path.Combine(_rutaImagenes, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                // Usamos FileStream para no bloquear el archivo en disco
                using (var fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                {
                    pbPoster.Image = Image.FromStream(fs);
                }
            }
            else
            {
                pbPoster.Image = null; // O poner una imagen "No disponible" por defecto
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;
            _bs.EndEdit();
            this.ValidateChildren();
            _tabla.GuardarCambios();
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                MessageBox.Show("El título es obligatorio.");
                return false;
            }
            if (numDuracion.Value <= 0)
            {
                MessageBox.Show("La duración incorrecta.");
                return false;
            }
            return true;
        }
    }
}