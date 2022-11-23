using Jac.Tripulantes.Controllers;
using Jac.Tripulantes.DAL.Repositorio;
using Jac.Tripulantes.Services.TripulanteSpecification;
using Microsoft.AspNetCore.Mvc;

namespace Jac.Tripulantes.Test
{
    [TestClass]
    public class UnitTestTripulanteCategoria
    {
        readonly TripulantesController controller = new(new FakeRepositorio(),new IberiaTripulanteSpecification());
        [TestMethod]
        public async Task TestTripulanteCategoriaOK()
        {
            var tripulanteCategoriaEncontrado = await controller.GetTripulanteConCategoria(1);
            Assert.IsNotNull(tripulanteCategoriaEncontrado);
            Assert.IsNotNull(tripulanteCategoriaEncontrado.Tripulante);
            Assert.AreEqual(1, tripulanteCategoriaEncontrado.Tripulante.Id);
            Assert.IsNotNull(tripulanteCategoriaEncontrado.Categoria);
            Assert.AreEqual(1, tripulanteCategoriaEncontrado.Categoria.Id);
        }


        [TestMethod]
        public async Task TestTripulanteCategoriaError()
        {
            var tripulanteCategoriaEncontrado = await controller.GetTripulanteConCategoria(100);
            Assert.IsNull(tripulanteCategoriaEncontrado);
        }
    }
}
