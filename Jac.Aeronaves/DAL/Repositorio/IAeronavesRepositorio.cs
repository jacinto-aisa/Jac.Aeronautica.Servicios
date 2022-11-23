using Jac.Aeronaves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jac.Aeronaves.DAL.Repositorio
{
    public interface IAeronavesRepositorio
    {
        Task<Models.Aeronave?> DameAeronavePorId(int Id);
        Task<List<Models.Aeronave>?> FiltroAeronaves(Func<Models.Aeronave, bool> predicate);
        Task<List<Models.Aeronave>?> DameTodos();
     }
}