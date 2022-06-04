namespace PeliculasAPI.Servicios
{
    public interface IAlmacenadorArchivos
    {
        Task<string> GuardarArchivo(byte[] contenido, string extension, string contendor, string contenType);
        Task<string> EditarArchivo(byte[] contenido, string extension, string contendor, string ruta, string contenType);
        Task BorrarArchivo(string ruta, string contenedor);
    }
}
