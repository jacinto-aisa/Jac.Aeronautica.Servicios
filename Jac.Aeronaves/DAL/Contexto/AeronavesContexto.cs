using Jac.Aeronaves.Models;
using Microsoft.EntityFrameworkCore;

namespace Jac.Aeronaves.DAL.Contexto
{
    public class AeronavesContexto : DbContext
    {
        public AeronavesContexto(DbContextOptions<AeronavesContexto> options) : base(options)
        {

        }

        public DbSet<Models.Aeronave>? Aeronaves { get; set; } = default;

    }
}
