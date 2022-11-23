using Jac.Embarque.DAL.Repositorio;
using Jac.Embarque.Models;

namespace Jac.Embarque.DAL.Repositorio
{
    public class FakeRepositorio : IEmbarqueRepositorio
    {
        readonly List<EmbarqueAvion> Embarques;
        readonly List<Aeronave> Aeronaves;
        readonly List<Tripulante> Tripulantes;
        readonly List<Categoria> Categorias;
        public FakeRepositorio()
        {
            Embarques = new List<EmbarqueAvion>(){
                new EmbarqueAvion() { Id = 1,Aeronave=1,NumeroPasajeros=234,TripulantesId="1,4",Fecha = DateTime.Now},
                new EmbarqueAvion() { Id = 2,Aeronave=1,NumeroPasajeros=134,TripulantesId="1,2,3,4",Fecha = DateTime.Now.AddDays(-1)},
                new EmbarqueAvion() { Id = 3,Aeronave=3,NumeroPasajeros=34,TripulantesId="1,3",Fecha =DateTime.Now.AddDays(-10)},
                new EmbarqueAvion() { Id = 4,Aeronave=2,NumeroPasajeros=23,TripulantesId="2,3",Fecha = DateTime.Now.AddDays(100)},
                new EmbarqueAvion() { Id = 5,Aeronave=1,NumeroPasajeros=334,TripulantesId="2,3",Fecha = DateTime.Now.AddDays(-100)},
                new EmbarqueAvion() { Id = 6,Aeronave=4,NumeroPasajeros=10,TripulantesId="2,3,4",Fecha = DateTime.Now.AddDays(-1)},
                new EmbarqueAvion() { Id = 7,Aeronave=3,NumeroPasajeros=134,TripulantesId="1,2,3",Fecha = DateTime.Now.AddDays(-1000)},
                new EmbarqueAvion() { Id = 8,Aeronave=2,NumeroPasajeros=134,TripulantesId="1",Fecha = DateTime.Now.AddDays(1)},
                new EmbarqueAvion() { Id = 9,Aeronave=1,NumeroPasajeros=534,TripulantesId="3",Fecha = DateTime.Now.AddDays(-1) }
            };

            Aeronaves = new(){
                new Aeronave() { Id = 1, Matricula = "uisdjxx", NumeroMotores=1, IncrementoSueldo=0.7f, MesesDesdeMantenimento=7 },
                new Aeronave() { Id = 2, Matricula = "udsisdjxx", NumeroMotores = 2, IncrementoSueldo = 0.1f, MesesDesdeMantenimento = 5 },
                new Aeronave() { Id = 3, Matricula = "uidddsdjxx", NumeroMotores = 3, IncrementoSueldo = 0.14f, MesesDesdeMantenimento = 4 },
                new Aeronave() { Id = 4, Matricula = "uzzzisdjxx", NumeroMotores = 2, IncrementoSueldo = 0.07f, MesesDesdeMantenimento = 72 }
            };

            Categorias = new(){
                new Categoria(){ Id = 1, Descripcion = "Categoria normal", BonificacionAnual = 67f },
                new Categoria(){ Id = 2 , Descripcion = "Categoria premium", BonificacionAnual = 76f }
            };

            Tripulantes = new(){
                new Tripulante(){ Id = 1, Nombre ="Manolo", CategoriaId = 1, Experiencia = 6 },
                new Tripulante(){ Id = 2, Nombre ="Eustaquio", CategoriaId = 1, Experiencia =8 },
                new Tripulante(){ Id = 3, Nombre ="Ana", CategoriaId = 2, Experiencia =9 },
                new Tripulante(){ Id = 4, Nombre="Juana",CategoriaId = 2, Experiencia=10}
            };
        }

        public async Task<List<Aeronave>?> DameAeronavePorTripulante(int Id)
        { 
            var EmbarquesDondeApareceUnTripulante = (from embarque in Embarques
                                                    join aeronave in Aeronaves on embarque.Aeronave equals aeronave.Id
                                                    where embarque.TripulantesId.Contains(Id.ToString())
                                                    select aeronave).Distinct();

            return EmbarquesDondeApareceUnTripulante.ToList();
        }

        public Task<List<Aeronave>?> DameAeronavesPorCategoria(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmbarqueAvion?> DameEmbarquePorId(int Id)
        {
            return await Task.Run(() =>Embarques.Find(x => x.Id == Id));
        }

        public async Task<List<EmbarqueAvion>?> DameEmbarquesPorIdDeAvion(int Id)
        {
            return await Task.Run(()=>(from embarque in Embarques
                                       where embarque.Aeronave == Id
                                       select embarque).ToList());

            
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
                }
            }
        }
    }
}
