namespace PeliculasAPI.DTOs
{
    public class PeliculaDetalleDTO: PeliculaDTO
    {
        public List<GeneroDTO> Generos { get; set; }
        public List<ActorPeliculaDetalleDTO> Actores { get; set; }
    }
}
