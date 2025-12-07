using System.Data;
using MySql.Data.MySqlClient;

namespace CineDAM.Modelos
{
    public class Tabla
    {
        private MySqlConnection _conexion;
        private MySqlDataAdapter _adapter;
        private MySqlCommandBuilder _builder;
        private DataTable _tabla;

        public DataTable LaTabla => _tabla;

        public Tabla(MySqlConnection conexion)
        {
            _conexion = conexion;
            _tabla = new DataTable();
            _adapter = new MySqlDataAdapter();
        }

        public bool InicializarDatos(string sql)
        {
            try
            {
                _tabla.Clear();
                _adapter.SelectCommand = new MySqlCommand(sql, _conexion);
                _builder = new MySqlCommandBuilder(_adapter);

                // --- SOLUCIÓN AL ERROR DE CONCURRENCIA ---
                // Esto le dice al sistema: "Si vas a borrar o actualizar, búscalo SOLO por su ID.
                // Me da igual si el título ha cambiado mientras tanto, bórralo igual".
                _builder.ConflictOption = ConflictOption.OverwriteChanges;
                // -----------------------------------------

                _adapter.Fill(_tabla);
                return true;
            }
            catch (Exception ex)
            {
                // Sería bueno registrar este error en tu log también
                Console.WriteLine("Error al inicializar datos: " + ex.Message);
                return false;
            }
        }

        public void GuardarCambios()
        {
            _adapter.Update(_tabla);
        }
    }
}