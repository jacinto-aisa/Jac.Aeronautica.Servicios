
using Jac.Embarque.DAL.Contexto;
using Jac.Embarque.DAL.Repositorio;
using Jac.Embarque.Models;

namespace Jac.Embarque.DAL.Repositorio
{
    public class EFRepositorio : IEmbarqueRepositorio
    {
        private readonly EmbarqueContexto contexto;
        public EFRepositorio()
        {
            string[] args = { "" };
            contexto = new EmbarqueContextoFactory().CreateDbContext(args);
        }

        public Task<List<Aeronave>?> DameAeronavePorTripulante(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aeronave>?> DameAeronavesPorCategoria(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmbarqueAvion?> DameEmbarquePorId(int Id)
        {
            if (contexto.Embarques is not null)
                return await contexto.Embarques.FindAsync(Id);
            return null;
        }

        public Task<List<EmbarqueAvion>?> DameEmbarquesPorIdDeAvion(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aeronave>?> FiltroAeronaves(Func<EmbarqueAvion, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task ModificaEmbarqueAvion(int Id, int avionId)
        {
            var EmbarqueOriginal = await DameEmbarquePorId(Id);
            if (EmbarqueOriginal is not null)
            {
                if (avionId != EmbarqueOriginal.Aeronave)
                {
                    //Lanzar el evento.
                    EmbarqueOriginal.Aeronave = avionId;
                    contexto.SaveChanges();
                }
            }
        }

        public async Task ModificaEmbarqueTripulante(int Id, string listaTripulantes)
        {
            var EmbarqueOriginal = await DameEmbarquePorId(Id);
            if (EmbarqueOriginal is not null)
            {
                if (listaTripulantes != EmbarqueOriginal.TripulantesId)
                {
                    //Lanzar el evento.
                    EmbarqueOriginal.TripulantesId = listaTripulantes;
                    contexto.SaveChanges();
                }
            }
        }
    }
}
