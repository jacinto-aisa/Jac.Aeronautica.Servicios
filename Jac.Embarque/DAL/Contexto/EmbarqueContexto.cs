
using Microsoft.EntityFrameworkCore;
using Jac.Embarque.Models;

namespace Jac.Embarque.DAL.Contexto
{
    public class EmbarqueContexto : DbContext
    {
        public EmbarqueContexto(DbContextOptions<EmbarqueContexto> options) : base(options)
        {

        }

        public DbSet<EmbarqueAvion>? Embarques { get; set; } = default;

    }
}
