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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtPassword.Text == "admin")
            {
                Program.appCine.estadoApp = CineDAM.Modelos.EstadoApp.AdminLogueado;
                this.DialogResult = DialogResult.OK; // Indica que el login fue exitoso
                this.Close();
            }
            else if (txtUsuario.Text == "taquilla" && txtPassword.Text == "taquilla")
            {
                Program.appCine.estadoApp = CineDAM.Modelos.EstadoApp.TaquillaAbierta;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit(); // Cierra toda la aplicación
        }
    }
}
