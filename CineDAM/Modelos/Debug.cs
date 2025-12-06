using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineDAM.Modelos
{
    public class Debug
    {
        public string rutaArchivoLog { get; set; }

        public Debug(string rutaArchivo)
        {
            rutaArchivoLog = rutaArchivo;
        }

        public void GuardarLog(string mensaje)
        {
            try
            {
                string? dir = Path.GetDirectoryName(rutaArchivoLog);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.AppendAllText(rutaArchivoLog, mensaje + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar log: {ex.Message}");
            }
        }

        // --- NUEVO MÉTODO PARA LEER ---
        public string LeerLog()
        {
            if (!File.Exists(rutaArchivoLog)) return "El archivo de log aún no existe.";

            try
            {
                // Usamos FileStream con FileShare.ReadWrite para evitar bloqueos
                // si el programa intenta escribir mientras leemos.
                using (var fs = new FileStream(rutaArchivoLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return $"Error al leer el log: {ex.Message}";
            }
        }
    }
}