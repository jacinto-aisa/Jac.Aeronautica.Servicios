using Jac.Embarque.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jac.Embarque.Services.Tripulantes
{
    public interface IServicioTripulante
    {
        public Task<Tripulante?> GetTripulanteAsync(int Id);

        public Task<Categoria?> GetCategoriaAsync(int Id);

        public Task<TripulanteConCategoria?> GetTripulanteConCategoria(int Id);

        public Task<List<Tripulante>?> DameTodosTripulantes();

        public Task<List<Categoria>?> DameTodasLasCategorias();

    }
}
