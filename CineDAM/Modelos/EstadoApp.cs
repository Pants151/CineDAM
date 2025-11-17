using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineDAM.Modelos
{
    public enum EstadoApp
    {
        Iniciando,
        SinConexion,
        Conectado, //Estado general
        AdminLoguedo, //Logueado como admin
        TaquillaAbierta //Logueado como vendedor
    }
}
