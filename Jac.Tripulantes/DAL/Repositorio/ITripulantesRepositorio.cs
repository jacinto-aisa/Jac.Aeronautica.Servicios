using Jac.Tripulantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jac.Tripulantes.DAL.Repositorio
{
    public interface ITripulantesRepositorio
    {
        Task<Tripulante?> DameTripulantePorId(int Id);
        Task<Categoria?> DameCategoriaPorId(int Id);
        Task<TripulanteConCategoria?> DameTripulanteConCategoria(int Id);
        Task<List<Tripulante>?> FiltroTripulantes(Func<Tripulante, bool> predicate);
        Task<List<Categoria>?> FiltroCategorias(Func<Categoria, bool> predicate);

        Task<List<Categoria>?> DameTodasCategorias();
        Task<List<Tripulante>?> DameTodosTripulantes();

    }
}