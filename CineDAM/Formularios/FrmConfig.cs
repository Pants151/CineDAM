using MySql.Data.MySqlClient;
using System.Text.Json;
using CineDAM.Modelos;

namespace CineDAM.Formularios
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
            // Aseguramos que el evento Load se dispara
            this.Load += FrmConnection_Load;
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            // Esto funciona aunque el estado sea 'AdminLogueado'
            if (Program.appCine.conectado && Program.appCine.configConexion != null)
            {
                txtServidor.Text = Program.appCine.configConexion.servidor;
                txtPuerto.Text = Program.appCine.configConexion.puerto.ToString();
                txtUsuario.Text = Program.appCine.configConexion.usuario;
                txtPassword.Text = Program.appCine.configConexion.password;
                txtBaseDatos.Text = Program.appCine.configConexion.baseDatos;
            }
            else
            {
                // Si no hay conexión o configuración, limpiamos (o dejamos valores por defecto)
                txtServidor.Text = "";
                txtPuerto.Text = "3306";
                txtUsuario.Text = "root";
                txtPassword.Text = "";
                txtBaseDatos.Text = "cinedam";
            }

            // Actualizamos el estado visual de los botones y paneles
            SetControlesEstadoConexion(false);
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.appCine.conectado) // Si ya estaba conectado, desconecta
                {
                    SetControlesEstadoConexion(true);
                    Program.appCine.DesconectarDB();
                    SetControlesEstadoConexion(false);
                }
                else // Si no está conectado, intentamos conectar
                {
                    // Validar puerto
                    if (!int.TryParse(txtPuerto.Text, out int puertoNum))
                    {
                        MessageBox.Show("El puerto debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear configuración nueva con los datos del formulario
                    ConfiguracionConexion config = new ConfiguracionConexion
                    {
                        servidor = txtServidor.Text,
                        puerto = puertoNum,
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
                tsStatusLabel.ForeColor = Color.Black;
                tsProgressBarConexion.Style = ProgressBarStyle.Marquee;
                btnConexion.Enabled = false;
                pnData.Enabled = false; // Siempre deshabilitado mientras procesa
            }
            else
            {
                tsProgressBarConexion.Style = ProgressBarStyle.Blocks;
                btnConexion.Enabled = true;

                // CAMBIO CLAVE: Usamos .conectado aquí también
                if (Program.appCine.conectado)
                {
                    // Si estamos conectados:
                    // 1. Bloqueamos los campos para no editar en caliente
                    pnData.Enabled = false;

                    // 2. Botón sirve para desconectar
                    btnConexion.Text = "Cerrar conexión";

                    // 3. Status verde
                    tsStatusLabel.Text = "Conexión establecida correctamente.";
                    tsStatusLabel.ForeColor = Color.Green;
                }
                else
                {
                    // Si NO estamos conectados:
                    // 1. Habilitamos campos para poder escribir
                    pnData.Enabled = true;

                    // 2. Botón sirve para conectar
                    btnConexion.Text = "Conectar";

                    if (aError == "")
                    {
                        tsStatusLabel.Text = "Conexión cerrada.";
                        tsStatusLabel.ForeColor = Color.Black;
                    }
                    else
                    {
                        tsStatusLabel.Text = "Error: " + aError;
                        tsStatusLabel.ForeColor = Color.Red;
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
                    // Forzamos la recarga de los datos en pantalla llamando al Load o copiando la lógica
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
                    puerto = int.Parse(txtPuerto.Text),
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