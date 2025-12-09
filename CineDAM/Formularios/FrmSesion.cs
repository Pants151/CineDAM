using CineDAM.Modelos;
using System.Data;

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

            cmbPelicula.DataBindings.Clear();
            cmbSala.DataBindings.Clear();
            dtpHora.DataBindings.Clear();
            numPrecio.DataBindings.Clear();

            // Enlazar SelectedValue (claves foráneas)
            cmbPelicula.DataBindings.Add("SelectedValue", _bs, "id_pelicula", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbSala.DataBindings.Add("SelectedValue", _bs, "id_sala", true, DataSourceUpdateMode.OnPropertyChanged);

            dtpHora.DataBindings.Add("Value", _bs, "hora_inicio", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            // Recogemos valores para el SQL manual
            int idPeli = (int)cmbPelicula.SelectedValue;
            int idSala = (int)cmbSala.SelectedValue;
            decimal precio = numPrecio.Value;
            DateTime hora = dtpHora.Value;

            DataRowView row = (DataRowView)_bs.Current;
            bool esNueva = row.IsNew; // Detectar si es INSERT o UPDATE

            string sql = "";

            if (esNueva)
            {
                sql = "INSERT INTO Sesion (id_pelicula, id_sala, hora_inicio, precio) " +
                      "VALUES (@peli, @sala, @hora, @precio)";
            }
            else
            {
                int idSesion = Convert.ToInt32(row["id_sesion"]);
                sql = "UPDATE Sesion SET id_pelicula=@peli, id_sala=@sala, hora_inicio=@hora, precio=@precio " +
                      "WHERE id_sesion = @id";
            }

            try
            {
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@peli", idPeli);
                    cmd.Parameters.AddWithValue("@sala", idSala);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@precio", precio);

                    if (!esNueva) cmd.Parameters.AddWithValue("@id", row["id_sesion"]);

                    cmd.ExecuteNonQuery();
                }

                // IMPORTANTE: Cancelar la edición del BindingSource para evitar
                // conflictos con la vista compleja del padre. La BD ya está actualizada.
                _bs.CancelEdit();

                this.DialogResult = DialogResult.OK;
                AppCine.NotificarCambioDatos();
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
                return false;
            }
            if (cmbSala.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numPrecio.Value < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // --- VALIDACIÓN DE HORARIO ---
            try
            {
                // Usamos DATE_FORMAT para comparar solo Año-Mes-Día Hora:Minuto
                // Esto ignora los segundos y evita que "18:00:00" sea diferente de "18:00:05"
                string sql = "SELECT COUNT(*) FROM Sesion WHERE id_sala = @sala " +
                             "AND DATE_FORMAT(hora_inicio, '%Y-%m-%d %H:%i') = DATE_FORMAT(@hora, '%Y-%m-%d %H:%i')";

                DataRowView row = (DataRowView)_bs.Current;
                if (!row.IsNew)
                {
                    sql += $" AND id_sesion != {row["id_sesion"]}";
                }

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@sala", cmbSala.SelectedValue);
                    cmd.Parameters.AddWithValue("@hora", dtpHora.Value); // Pasamos la fecha completa, SQL se encarga de formatear

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("¡Conflicto de Horario!\n\nYa existe una sesión programada en esta sala en el mismo día y hora.",
                                        "Horario no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar horario: " + ex.Message);
                Program.appCine.RegistrarLog("Error Validar Duplicados Sesion", ex.StackTrace);
                return false;
            }
            // --------------------------------------------------

            return true;
        }

        private void CargarCombos()
        {
            Tabla tPeliculas = new Tabla(Program.appCine.LaConexion);
            if (tPeliculas.InicializarDatos("SELECT id_pelicula, titulo FROM Pelicula"))
            {
                cmbPelicula.DataSource = tPeliculas.LaTabla;
                cmbPelicula.DisplayMember = "titulo";
                cmbPelicula.ValueMember = "id_pelicula";
                cmbPelicula.SelectedIndex = -1;
            }

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