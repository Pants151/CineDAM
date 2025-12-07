using CineDAM.Modelos;
using System.Runtime.InteropServices; // Necesario para mover la ventana

namespace CineDAM.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        // --- LÓGICA DE LOGIN ---
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            // Validamos quitando el texto por defecto
            string user = txtUsuario.Text == "USUARIO" ? "" : txtUsuario.Text;
            string pass = txtPassword.Text == "CONTRASEÑA" ? "" : txtPassword.Text;

            if (user == "admin" && pass == "admin")
            {
                Program.appCine.estadoApp = EstadoApp.AdminLogueado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (user == "taquilla" && pass == "taquilla")
            {
                Program.appCine.estadoApp = EstadoApp.TaquillaAbierta;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.\nPrueba admin/admin o taquilla/taquilla", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- EFECTOS VISUALES (PLACEHOLDER) ---
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true; // Ocultar caracteres
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false; // Mostrar texto "CONTRASEÑA"
            }
        }

        // --- MOVER VENTANA (Drag & Drop sin bordes) ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}