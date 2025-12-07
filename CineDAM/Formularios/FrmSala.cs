using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace CineDAM.Formularios
{
    public partial class FrmSala : Form
    {
        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;

        public FrmSala(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void FrmSala_Load(object sender, EventArgs e)
        {
            txtNombre.DataBindings.Clear();
            numFilas.DataBindings.Clear();
            numColumnas.DataBindings.Clear();

            txtNombre.DataBindings.Add("Text", _bs, "nombre", true);
            numFilas.DataBindings.Add("Value", _bs, "filas", true, DataSourceUpdateMode.OnPropertyChanged, 1);
            numColumnas.DataBindings.Add("Value", _bs, "columnas", true, DataSourceUpdateMode.OnPropertyChanged, 1);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            string nombre = txtNombre.Text;
            int filas = (int)numFilas.Value;
            int columnas = (int)numColumnas.Value;

            DataRowView row = (DataRowView)_bs.Current;
            bool esNuevo = row.IsNew;

            string sql = "";
            if (esNuevo)
                sql = "INSERT INTO Sala (nombre, filas, columnas) VALUES (@nom, @fil, @col)";
            else
            {
                int id = Convert.ToInt32(row["id_sala"]);
                sql = "UPDATE Sala SET nombre=@nom, filas=@fil, columnas=@col WHERE id_sala=@id";
            }

            try
            {
                using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@fil", filas);
                    cmd.Parameters.AddWithValue("@col", columnas);
                    if (!esNuevo) cmd.Parameters.AddWithValue("@id", row["id_sala"]);

                    cmd.ExecuteNonQuery();
                }

                _bs.CancelEdit();
                AppCine.NotificarCambioDatos();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sala: " + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la sala es obligatorio.");
                return false;
            }
            if (numFilas.Value < 1 || numColumnas.Value < 1)
            {
                MessageBox.Show("La sala debe tener al menos 1 fila y 1 columna.");
                return false;
            }
            return true;
        }
    }
}