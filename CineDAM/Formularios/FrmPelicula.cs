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
    public partial class FrmPelicula : Form
    {

        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;

        public FrmPelicula(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;

        }

        private void FrmEmisor_Load(object sender, EventArgs e)
        {
            /*if (_bs?.DataSource == null)
            {
                MessageBox.Show("No hay fuente de datos disponible. Abortando...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }*/
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            _bs.EndEdit();
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
            /*
            if (string.IsNullOrWhiteSpace(txt_nifcif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.");
                txt_nifcif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_razonsocial.Text))
            {
                MessageBox.Show("El campo \"Nombre Comercial\" no puede estar vacío.");
                txt_razonsocial.Focus();
                return false;
            }

            //Validacion 2: Si el email no está vacio, que sea un email valido
            string email = txt_email.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) &&
                !System.Text.RegularExpressions.Regex.IsMatch(email,
                    @"^[a-zA-Z0-9._%-+]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El email introducido no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_email.Focus();
                return false;
            }

            //Validacion 3: NIF/CIF duplicado
            if (NifDuplicado(txt_nifcif.Text.Trim()))
            {
                return true;
            }
            else
            {
                MessageBox.Show("El NIF/CIF introducido ya existe en otro emisor. Por favor, introduce uno diferente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nifcif.Focus();
                return false;
            }*/

            return true;
        }
        /*private bool NifDuplicado(string nifcif)
        {
            using MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM EMISORES WHERE NIFCIF=@NIFCIF", Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@NIFCIF", nifcif);
            if (edicion && _bs.Current is DataRowView row)
            {
                int id = (int)row["id"];
                cmd.CommandText += " AND id<>@ID";
                cmd.Parameters.AddWithValue("@ID", id);
            }

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return (count > 0);
        }*/
    }
}
