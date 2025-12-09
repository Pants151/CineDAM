using CineDAM.Modelos;
using System.Text.Json;

namespace CineDAM.Formularios
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
            this.Load += FrmConnection_Load;
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            if (Program.appCine.conectado && Program.appCine.configConexion != null)
            {
                txtServidor.Text = Program.appCine.configConexion.servidor;
                numPuerto.Value = Program.appCine.configConexion.puerto;
                txtUsuario.Text = Program.appCine.configConexion.usuario;
                txtPassword.Text = Program.appCine.configConexion.password;
                txtBaseDatos.Text = Program.appCine.configConexion.baseDatos;
            }
            else
            {
                txtServidor.Text = "localhost";
                numPuerto.Value = 3306;
                txtUsuario.Text = "root";
                txtPassword.Text = "";
                txtBaseDatos.Text = "cinedam_db";
            }

            SetControlesEstadoConexion(false);
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.appCine.conectado)
                {
                    SetControlesEstadoConexion(true);
                    Program.appCine.DesconectarDB();
                    SetControlesEstadoConexion(false);
                }
                else
                {
                    ConfiguracionConexion config = new ConfiguracionConexion
                    {
                        servidor = txtServidor.Text,
                        puerto = (int)numPuerto.Value, // Ahora usamos .Value
                        usuario = txtUsuario.Text,
                        password = txtPassword.Text,
                        baseDatos = txtBaseDatos.Text
                    };

                    Program.appCine.configConexion = config;

                    SetControlesEstadoConexion(true);
                    Program.appCine.ConectarDB();
                    SetControlesEstadoConexion(false);
                }
            }
            catch (Exception ex)
            {
                SetControlesEstadoConexion(false, ex.Message);
            }
        }

        private void SetControlesEstadoConexion(bool enProceso, string aError = "")
        {
            tsProgressBarConexion.Visible = enProceso;

            if (enProceso)
            {
                tsStatusLabel.Text = "Procesando...";
                tsStatusLabel.ForeColor = Color.White;
                tsProgressBarConexion.Style = ProgressBarStyle.Marquee;
                btnConexion.Enabled = false;
                pnData.Enabled = false;
            }
            else
            {
                tsProgressBarConexion.Style = ProgressBarStyle.Blocks;
                btnConexion.Enabled = true;

                if (Program.appCine.conectado)
                {
                    pnData.Enabled = false;

                    // Botón ROJO para desconectar
                    btnConexion.Text = "CERRAR CONEXIÓN";
                    btnConexion.BackColor = Color.FromArgb(192, 0, 0);

                    tsStatusLabel.Text = "Conexión establecida correctamente.";
                    tsStatusLabel.ForeColor = Color.LightGreen;
                }
                else
                {
                    pnData.Enabled = true;

                    // Botón AZUL para conectar
                    btnConexion.Text = "CONECTAR";
                    btnConexion.BackColor = Color.FromArgb(0, 122, 204);

                    if (aError == "")
                    {
                        tsStatusLabel.Text = "Conexión cerrada.";
                        tsStatusLabel.ForeColor = Color.White;
                    }
                    else
                    {
                        tsStatusLabel.Text = "Error: " + aError;
                        tsStatusLabel.ForeColor = Color.IndianRed;
                    }
                }
            }
        }

        private void tsBtnCargar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Archivo JSON|*.json",
                Title = "Seleccionar archivo de configuración"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Program.appCine.ConfiguraYConectaDB(dlg.FileName);
                    FrmConnection_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar: " + ex.Message);
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Archivo JSON|*.json",
                Title = "Guardar configuración"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ConfiguracionConexion config = new ConfiguracionConexion
                {
                    servidor = txtServidor.Text,
                    puerto = (int)numPuerto.Value,
                    usuario = txtUsuario.Text,
                    password = txtPassword.Text,
                    baseDatos = txtBaseDatos.Text
                };

                try
                {
                    string jsonText = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(dlg.FileName, jsonText);
                    tsLbRutaConfig.Text = dlg.FileName;
                    MessageBox.Show("Configuración guardada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }
    }
}