using Jac.Aeronaves.Models;
using Jac.Aeronaves.Controllers;
using Jac.Aeronaves.DAL.Repositorio;
using Jac.Aeronaves.Services.AeronavesSpecification;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Jac.Aeronaves.Test
{
    [TestClass]
    public class UnitTestAeronave
    {
        readonly AeronavesController controller = new (new FakeRepositorio() , new IberiaAeronaveSpecification());
        [TestMethod]
        public void TestAeronaveObjeto()
        {
            Jac.Aeronaves.Models.Aeronave miAeronave = new() { Id = 1, Matricula = "xxx", MesesDesdeMantenimento = 12, IncrementoSueldo = 0.4f, NumeroMotores = 3 };
            Assert.IsNotNull(miAeronave);
            Assert.AreEqual(1, miAeronave.Id);
            Assert.AreEqual("xxx", miAeronave.Matricula);
            Assert.AreEqual(12, miAeronave.MesesDesdeMantenimento);
            Assert.AreEqual(0.4f, miAeronave.IncrementoSueldo);
            Assert.AreEqual(3, miAeronave.NumeroMotores);
        }

        [TestMethod]
        public async Task TestAeronaveOK()
        {
            var AeronaveEncontrada = await controller.GetAeronaveAsync(1);
            Assert.IsNotNull(AeronaveEncontrada);
            Assert.AreEqual(1, AeronaveEncontrada.Id);
            Assert.AreEqual("uisdjxx", AeronaveEncontrada.Matricula);
         }

        [TestMethod]
        public async Task TestAeronaveError()
        {
            var AeronaveEncontrada = await controller.GetAeronaveAsync(100);
            Assert.IsNull(AeronaveEncontrada);
        }
        [TestMethod]
        public async Task TestListaAeronaveValida()
        {
            var AeronavesValidas = await controller.ListaAeronavesValidos();
            Assert.IsNotNull(AeronavesValidas);
            Assert.AreEqual(2, AeronavesValidas.Count);
        }

        [TestMethod]
        public async Task TestListaAeronave()
        {
            var AeronaveEncontrada = await controller.DameTodos();
            Assert.IsNotNull(AeronaveEncontrada);
            Assert.AreEqual(4, AeronaveEncontrada.Count);
        }

    }
}