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
                MessageBox.Show("Debe seleccionar una película.");
                return false;
            }
            if (cmbSala.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala.");
                return false;
            }
            if (numPrecio.Value < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                return false;
            }
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