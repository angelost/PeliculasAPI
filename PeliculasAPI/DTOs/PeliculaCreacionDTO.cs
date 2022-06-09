using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Helpers;
using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class PeliculaCreacionDTO : PeliculaPatchDTO
    {
        
        [PesoArchivoValidacion(pesoMaximoEnMegaBytes:4)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int> GenerosIDs { get; set; }
    }
}
