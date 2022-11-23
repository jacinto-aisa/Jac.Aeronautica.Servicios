using Jac.Tripulantes.DAL.Contexto;
using Jac.Tripulantes.Models;
using Jac.Tripulantes.Services.TripulanteSpecification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jac.Tripulantes.DAL.Repositorio
{
    public class EFRepositorio : ITripulantesRepositorio
    {
        private readonly TripulanteContexto? contexto;
        public EFRepositorio()
        {
            string[] args = { "" };
            contexto = new TripulanteContextoFactory().CreateDbContext(args);
        }
        public async Task<Categoria?> DameCategoriaPorId(int Id)
        {
            if (contexto is not null && contexto.Categorias is not null)
                return await contexto.Categorias.FindAsync(Id);
            return null;
        }

        public async Task<List<Categoria>?> DameTodasCategorias()
        {
            if (contexto is not null && contexto.Categorias is not null)
                return await contexto.Categorias.ToListAsync();
            return null;
        }

        public async Task<List<Tripulante>?> DameTodosTripulantes()
        {
            if (contexto is not null && contexto.Tripulantes is not null)
                return await contexto.Tripulantes.ToListAsync();
            return null;
        }

        public async Task<TripulanteConCategoria?> DameTripulanteConCategoria(int Id)
        {
            var tripulanteEncontrado = await DameTripulantePorId(Id);
            var categoriaEncontrada = await DameCategoriaPorId(Id);
            if (tripulanteEncontrado != null &&
                categoriaEncontrada != null)
            {
                return new TripulanteConCategoria()
                {
                    Tripulante = tripulanteEncontrado,
                    Categoria = categoriaEncontrada
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Tripulante?> DameTripulantePorId(int Id)
        {
            if (contexto is not null && contexto.Tripulantes is not null)
                return await contexto.Tripulantes.FindAsync(Id);
            else
                return null;
        }

        public async Task<List<Categoria>?> FiltroCategorias( Func<Categoria, bool> predicate)
        {
            if (contexto is not null)
                return await Task.Run(()=> contexto.Set<Categoria>().Where(predicate).ToList());
            else
                return null;
        }

        public async Task<List<Tripulante>?> FiltroTripulantes(Func<Tripulante, bool> predicate)
        {
            if (contexto is not null)
                return await Task.Run(()=> contexto.Set<Tripulante>().Where(predicate).ToList());
            else
                return null;
        }
    }





}
