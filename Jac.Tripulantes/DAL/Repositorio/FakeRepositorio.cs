using Jac.Tripulantes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jac.Tripulantes.DAL.Repositorio
{
    public class FakeRepositorio : ITripulantesRepositorio
    {
        readonly List<Categoria> Categorias;
        readonly List<Tripulante> Tripulantes;

        public FakeRepositorio()
        {
            Categorias = new(){
                new Categoria(){ Id = 1, Descripcion = "Categoria normal", BonificacionAnual = 67f },
                new Categoria(){ Id = 2 , Descripcion = "Categoria premium", BonificacionAnual = 76f }
            };

            Tripulantes = new List<Tripulante>(){
                new Tripulante(){ Id = 1, Nombre ="Manolo", CategoriaId = 1, Experiencia = 6 },
                new Tripulante(){ Id = 2, Nombre ="Eustaquio", CategoriaId = 1, Experiencia =8 },
                new Tripulante(){ Id = 3, Nombre ="Ana", CategoriaId = 2, Experiencia =9 },
                new Tripulante(){ Id = 4, Nombre="Juana",CategoriaId = 2, Experiencia=10}
            };
        }
        public async Task<Categoria?> DameCategoriaPorId(int Id)
        {
            return await Task.Run(() => Categorias.Find(x => x.Id == Id));
        }

        public async Task<List<Categoria>?> DameTodasCategorias()
        {
            return await Task.Run(()=>Categorias.ToList());
        }

        public async Task<List<Tripulante>?> DameTodosTripulantes()
        {
            return await Task.Run(() => Tripulantes.ToList());
        }

        public async Task<TripulanteConCategoria?> DameTripulanteConCategoria(int Id)
        {
            var tripulante = await DameTripulantePorId(Id);
            if (tripulante != null)
            {
                var categoria = await DameCategoriaPorId(tripulante.CategoriaId);
                if (tripulante is not null && categoria is not null)
                {
                    return new TripulanteConCategoria()
                    {
                        Tripulante = tripulante,
                        Categoria = categoria
                    };
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<Tripulante?> DameTripulantePorId(int Id)
        {
            return await Task.Run(() => Tripulantes.Find(x => x.Id == Id));
        }

        public async Task<List<Categoria>?> FiltroCategorias(Func<Categoria, bool> predicate)
        {
            return await Task.Run(()=>Categorias.AsQueryable().Where(predicate).ToList());
        }

        public async Task<List<Tripulante>?> FiltroTripulantes(Func<Tripulante, bool> predicate)
        {
            return await Task.Run(()=>Tripulantes.AsQueryable().Where(predicate).ToList());
        }
    }
}
