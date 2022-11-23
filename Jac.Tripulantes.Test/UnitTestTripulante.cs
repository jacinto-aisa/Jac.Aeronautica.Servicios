using Jac.Tripulantes.Controllers;
using Jac.Tripulantes.DAL;
using Jac.Tripulantes.DAL.Repositorio;
using Jac.Tripulantes.Models;
using Jac.Tripulantes.Services.TripulanteSpecification;

namespace Jac.Tripulantes.Test
{
    [TestClass]
    public class UnitTestTripulanteIberia
    {
        readonly TripulantesController controller = new(new FakeRepositorio(),new IberiaTripulanteSpecification());
        [TestMethod]
        public void TestTripulanteObjeto()
        {
            Tripulante miTripulante = new Tripulante() { Id = 1, Nombre = "fake", CategoriaId = 1, Experiencia = 9 };

            Assert.IsNotNull(miTripulante);
            Assert.AreEqual(1, miTripulante.Id);
            Assert.AreEqual("fake", miTripulante.Nombre);
            Assert.AreEqual(1, miTripulante.CategoriaId);
            Assert.AreEqual(9, miTripulante.Experiencia);
        }
        [TestMethod]
        public async Task TestTripulanteOK()
        {
            var tripulanteEncontrado = await controller.GetTripulanteAsync(1);
            Assert.IsNotNull(tripulanteEncontrado);
            Assert.AreEqual(1, tripulanteEncontrado.Id);
            Assert.AreEqual("Manolo", tripulanteEncontrado.Nombre);
        }

        [TestMethod]
        public async Task TestTripulanteError()
        {
            var tripulanteEncontrado = await controller.GetTripulanteAsync(100);
            Assert.IsNull(tripulanteEncontrado);
        }
    }
}