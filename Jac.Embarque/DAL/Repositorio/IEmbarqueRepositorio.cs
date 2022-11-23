using Jac.Embarque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jac.Embarque.DAL.Repositorio
{
    public interface IEmbarqueRepositorio
    {
        Task<EmbarqueAvion?> DameEmbarquePorId(int Id);
        Task<List<Aeronave>?> FiltroAeronaves(Func<EmbarqueAvion, bool> predicate);
        Task<List<EmbarqueAvion>?> DameEmbarquesPorIdDeAvion(int Id);
        Task<List<Aeronave>?> DameAeronavePorTripulante(int Id);
        Task<List<Aeronave>?> DameAeronavesPorCategoria(int Id);
        Task ModificaEmbarqueAvion(int Id, int avionId);
        Task ModificaEmbarqueTripulante(int Id, string listaTripulantes);
     }
}