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
            // 1. Limpiamos bindings previos
            txtNombre.DataBindings.Clear();
            numFilas.DataBindings.Clear();
            numColumnas.DataBindings.Clear();

            // 2. Añadimos los nuevos bindings.
            txtNombre.DataBindings.Add("Text", _bs, "nombre", true);

            // NumericUpDown se enlaza a "Value"
            // El último parámetro '1' es el valor por defecto si es null o nueva sala
            numFilas.DataBindings.Add("Value", _bs, "filas", true, DataSourceUpdateMode.OnPropertyChanged, 1);
            numColumnas.DataBindings.Add("Value", _bs, "columnas", true, DataSourceUpdateMode.OnPropertyChanged, 1);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            // --- CORRECCIÓN: Forzar guardado de valores numéricos ---
            // Si el usuario no toca los números, el Binding no se entera.
            // Aquí los asignamos manualmente para asegurar que no se envíen NULLs.
            if (_bs.Current is DataRowView row)
            {
                row["filas"] = (int)numFilas.Value;
                row["columnas"] = (int)numColumnas.Value;
            }
            // -------------------------------------------------------


            _bs.EndEdit();
            // Asegura que los valores numéricos se envíen al BindingSource
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la sala es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Aunque el control NumericUpDown ya impide escribir letras o bajar de 1,
            // esta validación extra protege contra errores lógicos.
            if (numFilas.Value < 1 || numColumnas.Value < 1)
            {
                MessageBox.Show("La sala debe tener al menos 1 fila y 1 columna.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}