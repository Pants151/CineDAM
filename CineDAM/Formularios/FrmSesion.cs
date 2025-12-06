using CineDAM.Modelos;
using MySql.Data.MySqlClient;
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
    public partial class FrmSesion : Form
    {
        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;

        public FrmSesion(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void FrmSesion_Load(object sender, EventArgs e)
        {
            CargarCombos();

            // 1. Limpiamos bindings previos
            cmbPelicula.DataBindings.Clear();
            cmbSala.DataBindings.Clear();
            dtpHora.DataBindings.Clear();
            numPrecio.DataBindings.Clear();

            // 2. Enlazamos datos
            // IMPORTANTE: Enlazamos "SelectedValue" al ID de la tabla foránea
            cmbPelicula.DataBindings.Add("SelectedValue", _bs, "id_pelicula", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbSala.DataBindings.Add("SelectedValue", _bs, "id_sala", true, DataSourceUpdateMode.OnPropertyChanged);

            // DateTimePicker
            // Usamos DateTime.Now como valor por defecto si es una nueva sesión
            dtpHora.DataBindings.Add("Value", _bs, "hora_inicio", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);

            // NumericUpDown
            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            // 1. Recoger los valores del formulario
            int idPeli = (int)cmbPelicula.SelectedValue;
            int idSala = (int)cmbSala.SelectedValue;
            decimal precio = numPrecio.Value;
            DateTime hora = dtpHora.Value;

            // 2. Obtener la fila actual para saber si es nueva
            DataRowView row = (DataRowView)_bs.Current;
            bool esNueva = row.IsNew; // Detecta si venimos de un .AddNew()

            string sql = "";

            // 3. Construir la consulta SQL
            if (esNueva)
            {
                // INSERTAR
                sql = "INSERT INTO Sesion (id_pelicula, id_sala, hora_inicio, precio) " +
                      "VALUES (@peli, @sala, @hora, @precio)";
            }
            else
            {
                // ACTUALIZAR
                // Necesitamos el ID original para el WHERE
                int idSesion = Convert.ToInt32(row["id_sesion"]);
                sql = "UPDATE Sesion SET id_pelicula=@peli, id_sala=@sala, hora_inicio=@hora, precio=@precio " +
                      "WHERE id_sesion = @id";
            }

            try
            {
                // 4. Ejecutar la consulta manualmente
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@peli", idPeli);
                    cmd.Parameters.AddWithValue("@sala", idSala);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@precio", precio);

                    if (!esNueva) cmd.Parameters.AddWithValue("@id", row["id_sesion"]);

                    cmd.ExecuteNonQuery();
                }

                // 5. Cerrar limpiamente
                // Cancelamos la edición del BindingSource porque ya hemos guardado en BD 
                // y queremos que la ventana padre recargue los datos frescos (con los nombres de peli/sala correctos)
                _bs.CancelEdit();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la sesión: " + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (cmbPelicula.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una película.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPelicula.Focus();
                return false;
            }

            if (cmbSala.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSala.Focus();
                return false;
            }

            // Validar que la fecha sea futura (opcional, pero recomendado para gestión)
            /*
            if (dtpHora.Value < DateTime.Now)
            {
                MessageBox.Show("La sesión debe ser en una fecha y hora futuras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            */

            if (numPrecio.Value < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarCombos()
        {
            // 1. Cargar Películas
            Tabla tPeliculas = new Tabla(Program.appCine.LaConexion);
            if (tPeliculas.InicializarDatos("SELECT id_pelicula, titulo FROM Pelicula"))
            {
                cmbPelicula.DataSource = tPeliculas.LaTabla;
                cmbPelicula.DisplayMember = "titulo";
                cmbPelicula.ValueMember = "id_pelicula";
                cmbPelicula.SelectedIndex = -1; // Para que empiece vacío si es nuevo
            }

            // 2. Cargar Salas
            Tabla tSalas = new Tabla(Program.appCine.LaConexion);
            if (tSalas.InicializarDatos("SELECT id_sala, nombre FROM Sala"))
            {
                cmbSala.DataSource = tSalas.LaTabla;
                cmbSala.DisplayMember = "nombre";
                cmbSala.ValueMember = "id_sala";
                cmbSala.SelectedIndex = -1;
            }
        }
    }
}