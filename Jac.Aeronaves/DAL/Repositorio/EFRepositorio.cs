using Jac.Aeronaves.DAL.Contexto;
using Jac.Aeronaves.Models;
using Microsoft.EntityFrameworkCore;

namespace Jac.Aeronaves.DAL.Repositorio
{
    public class EFRepositorio : IAeronavesRepositorio
    {
        private readonly AeronavesContexto contexto;
        public EFRepositorio()
        {
            string[] args = { "" };
            contexto = new AeronavesContextoFactory().CreateDbContext(args);
        }

        public async Task<Models.Aeronave?> DameAeronavePorId(int Id)
        {
            if (contexto is not null && contexto.Aeronaves is not null)
                return await contexto.Aeronaves.FindAsync(Id);
            return null;
        }

        public async Task<List<Models.Aeronave>?> DameTodos()
        {
            if (contexto is not null && contexto.Aeronaves is not null)
                return await contexto.Aeronaves.ToListAsync();
            return null;
        }

        public Task<List<Models.Aeronave>?> FiltroAeronaves(Func<Models.Aeronave, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
