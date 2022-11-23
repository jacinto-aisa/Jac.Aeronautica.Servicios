using Jac.Tripulantes.Controllers;
using Jac.Tripulantes.DAL;
using Jac.Tripulantes.DAL.Repositorio;
using Jac.Tripulantes.Models;
using Jac.Tripulantes.Services.TripulanteSpecification;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Jac.Tripulantes.Test
{
    [TestClass]
    public class UnitTestCategoria
    {
        readonly TripulantesController controller = new (new FakeRepositorio() , new IberiaTripulanteSpecification());

        [TestMethod]
        public async Task TestCategoriaOK()
        {
            var TripulanteEncontrado = await controller.GetCategoriaAsync(1);
            Assert.IsNotNull(TripulanteEncontrado);
            Assert.AreEqual(1,TripulanteEncontrado.Id);
            Assert.AreEqual("Categoria normal", TripulanteEncontrado.Descripcion);
         }

        [TestMethod]
        public async Task TestCategoriaError()
        {
            var CategoriaEncontrada = await controller.GetCategoriaAsync(100);
            Assert.IsNull(CategoriaEncontrada);
        }

    }
}