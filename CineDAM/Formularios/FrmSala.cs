using CineDAM.Modelos;
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

            if (_bs.Current is DataRowView row)
            {
                row["filas"] = (int)numFilas.Value;
                row["columnas"] = (int)numColumnas.Value;
            }

            _bs.EndEdit();
            _tabla.GuardarCambios();
            AppCine.NotificarCambioDatos();
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