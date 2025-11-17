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
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.appCine.conectado) // Si ya estaba conectado, solo desconecta
                {
                    SetControlesEstadoConexion(true);
                    // Cerrar conexión
                    Program.appCine.DesconectarDB();
                    SetControlesEstadoConexion(false);
                }
                else // Si no está conectado, intentamos conectar
                {
                    // === ESTA ES LA PARTE NUEVA QUE ARREGLA EL ERROR ===

                    // 1. Validamos que el puerto sea un número
                    if (!int.TryParse(txtPuerto.Text, out int puertoNum))
                    {
                        MessageBox.Show("El puerto debe ser un valor numérico.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Detiene la ejecución
                    }

                    // 2. Creamos un nuevo objeto de configuración con los datos de los TextBox
                    ConfiguracionConexion config = new ConfiguracionConexion
                    {
                        servidor = txtServidor.Text,
                        puerto = puertoNum,
                        usuario = txtUsuario.Text,
                        password = txtPassword.Text,
                        baseDatos = txtBaseDatos.Text
                    };

                    // 3. Asignamos esta configuración a nuestra AppCine principal
                    Program.appCine.configConexion = config;

                    // =================== FIN DE LA CORRECCIÓN ===================


                    // 4. Ahora sí, intentamos la conexión
                    SetControlesEstadoConexion(true);
                    Program.appCine.ConectarDB(); // Ahora 'configConexion' ya no es null

                    // 5. Tras el intento, actualizamos los controles
                    SetControlesEstadoConexion(false);
                }
            }
            catch (Exception ex)
            {
                // Si falla (ej. contraseña incorrecta), lo mostramos
                SetControlesEstadoConexion(false, ex.Message);
            }
        }

        private void SetControlesEstadoConexion(bool enProceso, string aError = "")
        {
            tsProgressBarConexion.Visible = enProceso;

            if (enProceso)
            {
                // Mostrar mensajes en la barra de estado.
                tsStatusLabel.Text = enProceso ? "Conectando ..." : "";
                tsStatusLabel.ForeColor = Color.Black;
                tsProgressBarConexion.Style = ProgressBarStyle.Marquee;
                btnConexion.Enabled = false;
                pnData.Enabled = false;
            }
            else
            {
                pnData.Enabled = true;
                btnConexion.Enabled = true;
                tsProgressBarConexion.Style = ProgressBarStyle.Blocks;

                if (Program.appCine.estadoApp == EstadoApp.Conectado)
                {
                    tsStatusLabel.Text = "Conexión establecida correctamente.";
                    tsStatusLabel.ForeColor = Color.Green;
                    btnConexion.Text = "Cerrar conexión";
                }
                else
                {
                    if (aError == "")
                    {
                        tsStatusLabel.Text = "Conexión cerrada.";
                        tsStatusLabel.ForeColor = Color.Black;
                        btnConexion.Text = "Conectar";
                    }
                    else
                    {
                        tsStatusLabel.Text = "Se ha producido un error: " + aError;
                        tsStatusLabel.ForeColor = Color.Red;
                    }
                }
            }
        }


        private void GuardarConfiguracionEnArchivo(string aRuta, ConfiguracionConexion aConfig)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string jsonText = JsonSerializer.Serialize(aConfig, options);

            // Podría haber hecho lo anterior en la siguiente línea:
            // string json = JsonSerializer.Serialize(aConfig, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(aRuta, jsonText);
            tsLbRutaConfig.Text = aRuta;

        }

        private void tsBtnCargar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Archivo JSON|*.json",
                Title = "Seleccionar archivo de configuración"
            };

            if (dlg.ShowDialog() == DialogResult.OK) {
                
                try {
                    // Mientras se conecta desactivo controles.
                    SetControlesEstadoConexion(true);

                    // Configuro y conecto la base de datos
                    Program.appCine.ConfiguraYConectaDB(dlg.FileName);

                    txtServidor.Text = Program.appCine.configConexion.servidor;
                    txtPuerto.Text = Program.appCine.configConexion.puerto.ToString();
                    txtUsuario.Text = Program.appCine.configConexion.usuario;
                    txtPassword.Text = Program.appCine.configConexion.password;
                    txtBaseDatos.Text = Program.appCine.configConexion.baseDatos;

                    // Ajusto controles
                    SetControlesEstadoConexion(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {

            using SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Archivo JSON|*.json",
                Title = "Guardar configuración como..."
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
                    GuardarConfiguracionEnArchivo(dlg.FileName, config);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            if (Program.appCine.estadoApp == EstadoApp.Conectado)
            {
                txtServidor.Text = Program.appCine.configConexion.servidor;
                txtPuerto.Text = Program.appCine.configConexion.puerto.ToString();
                txtUsuario.Text = Program.appCine.configConexion.usuario;
                txtPassword.Text = Program.appCine.configConexion.password;
                txtBaseDatos.Text = Program.appCine.configConexion.baseDatos;
            }
            else
            {
                txtServidor.Text = "";
                txtPuerto.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtBaseDatos.Text = "";
            }

            // Ajusto controles
            SetControlesEstadoConexion(false);

        }
    }
}
