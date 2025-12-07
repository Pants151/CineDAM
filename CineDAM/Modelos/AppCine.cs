using MySql.Data.MySqlClient;
using System.Text.Json;

namespace CineDAM.Modelos
{
    public class AppCine
    {

        public ConfiguracionConexion configConexion;
        public EstadoApp estadoApp;
        public string rutaBase { get; private set; }
        public string rutaConfigDB;
        public string rutaLog;

        public bool conectado => (_conexion != null) && (_conexion.State == System.Data.ConnectionState.Open);

        public string ultimoError { get; private set; }

        // 1. DESCOMENTAMOS LA PROPIEDAD
        public Debug debug { get; private set; }

        private MySqlConnection _conexion = null;

        public AppCine()
        {
            estadoApp = EstadoApp.Iniciando;
            _conexion = new MySqlConnection();
            InitApp();
        }

        private void InitApp()
        {
            rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            rutaConfigDB = Path.Combine(rutaBase, "configDB.json");
            rutaLog = Path.Combine(rutaBase, "logs", "info.log");

            // 2. INICIALIZAMOS EL OBJETO DEBUG
            debug = new Debug(rutaLog);

            ConfiguraYConectaDB(rutaConfigDB);
        }

        public void ConfiguraYConectaDB(string aRutaConfig)
        {
            ultimoError = "";
            configConexion = CargarConfiguracionDB(aRutaConfig);

            if (configConexion != null)
            {
                if (ConectarDB())
                    estadoApp = EstadoApp.Conectado;
                else
                    estadoApp = (ultimoError != "") ? EstadoApp.Error : EstadoApp.SinConexion;
            }
            else
                estadoApp = (ultimoError != "") ? EstadoApp.Error : EstadoApp.SinConexion;
        }

        private ConfiguracionConexion CargarConfiguracionDB(string aRuta)
        {
            ConfiguracionConexion resultado = null;
            if (File.Exists(aRuta))
            {
                try
                {
                    string jsonText = File.ReadAllText(aRuta);
                    resultado = JsonSerializer.Deserialize<ConfiguracionConexion>(jsonText);
                }
                catch (Exception ex)
                {
                    ultimoError = "Error al cargar archivo de configuración.\n" + ex.Message;
                    RegistrarLog("Cargar configuración DB", "Error al cargar archivo de configuración." + ex.Message);
                }
            }
            return resultado;
        }

        public bool ConectarDB()
        {
            if (conectado) _conexion.Close();
            _conexion.ConnectionString = configConexion.CadenaDeConexion();

            try
            {
                _conexion.Open();
                RegistrarLog("Conexión a la DB", "Conexión abierta correctamente");
            }
            catch (Exception ex)
            {
                ultimoError = "Error al intentar la conexión a la base de datos.\n" + ex.Message;
                RegistrarLog("Conexión a la DB", "Error al intentar la conexión a la base de datos." + ex.Message);
            }
            estadoApp = (conectado) ? EstadoApp.Conectado : EstadoApp.SinConexion;
            return conectado;
        }

        public void DesconectarDB()
        {
            if (conectado)
            {
                try
                {
                    _conexion.Close();
                    RegistrarLog("Desonexión de la DB", "Conexión cerrada correctamente.");
                }
                catch (Exception ex)
                {
                    ultimoError = "Error al intentar cerrar conexión a la base de datos.\n" + ex.Message;
                    RegistrarLog("Desonexión de la DB", "Error al intentar cerrar conexión a la base de datos." + ex.Message);
                }
            }
            estadoApp = (conectado) ? EstadoApp.Conectado : EstadoApp.SinConexion;
        }

        public void RegistrarLog(string proceso, string mensaje)
        {
            string textoLog = $"{DateTime.Now:yyyy-MM-dd} | {DateTime.Now:HH:mm:ss} | {proceso} | {mensaje}";
            // 3. LLAMAMOS AL MÉTODO REAL
            if (debug != null) debug.GuardarLog(textoLog);
        }

        public MySqlConnection LaConexion => _conexion;

        // Evento global para notificar cambios en tablas
        public static event EventHandler DatosActualizados;

        public static void NotificarCambioDatos()
        {
            DatosActualizados?.Invoke(null, EventArgs.Empty);
        }
    }
}