using Jac.Embarque.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jac.Embarque.Services.Aeronaves
{
    public interface IServicioAeronave
    {
        public Task<Aeronave?> GetAeronaveAsync(int Id);


        public Task<List<Aeronave>?> DameTodos();
    }
}