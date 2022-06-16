using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class SalasDeCineControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerSalasDeCineA5kilometrosOMenos()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            using (var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var salasDeCine = new List<SalaDeCine>()
                {
                    new SalaDeCine{ Nombre = "Plazuela Independencia", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-70.578375, -33.601335)) }
                };

                context.AddRange(salasDeCine);
                await context.SaveChangesAsync();
            }

            var filtro = new SalaDeCineCercanoFiltroDTO()
            {
                DistanciaEnKms = 1,
                Latitud = -70.590201,
                Longitud = -33.599142
            };

            using (var context = LocalDbDatabaseInitializer.GetDbContextLocalDb(false))
            {
                var mapper = ConfigurarAutoMapper();
                var controller = new SalasDeCineController(context, mapper, geometryFactory);
                var respuesta = await controller.Cercanos(filtro);
                var valor = respuesta.Value;
                Assert.AreEqual(0, valor?.Count);
            }

        }
    }
}
