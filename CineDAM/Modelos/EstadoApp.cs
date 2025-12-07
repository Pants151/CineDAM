namespace CineDAM.Modelos
{
    public enum EstadoApp
    {
        Iniciando,
        SinConexion,
        Conectado, //Estado general
        AdminLogueado, //Logueado como admin
        TaquillaAbierta, //Logueado como vendedor
        Error
    }
}
