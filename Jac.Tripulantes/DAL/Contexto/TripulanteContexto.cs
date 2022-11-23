using Jac.Tripulantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Jac.Tripulantes.DAL.Contexto
{
    public class TripulanteContexto : DbContext
    {
        public TripulanteContexto(DbContextOptions<TripulanteContexto> options) : base(options)
        {

        }

        public DbSet<Tripulante>? Tripulantes { get; set; } = default;
        public DbSet<Categoria>? Categorias { get; set; } = default;
    }
}
