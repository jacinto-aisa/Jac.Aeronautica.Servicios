
using Jac.Aeronaves.DAL.Repositorio;
using Jac.Aeronaves.Models;
using Jac.Aeronaves.Services.AeronavesSpecification;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Jac.Aeronaves.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AeronavesController : ControllerBase
    {
        private readonly IAeronavesRepositorio _aeronavesRepositorio;
        private readonly IAeronaveSpecification _aeronaveSpecification;

        public AeronavesController(IAeronavesRepositorio aeronaveRepositorio,
            IAeronaveSpecification aeronaveSpecification)

        {
            _aeronaveSpecification= aeronaveSpecification;
            _aeronavesRepositorio = aeronaveRepositorio;
        }

        [HttpGet("Aeronave/{Id}")]
        public async Task<Aeronaves.Models.Aeronave?> GetAeronaveAsync(int Id)
        {
            return await _aeronavesRepositorio.DameAeronavePorId(Id);
        }
       
        [HttpGet("ListaValidos")]
        public async Task<List<Aeronaves.Models.Aeronave>?> ListaAeronavesValidos()
        {
            var Criterio = _aeronaveSpecification.IsValid;
            return await _aeronavesRepositorio.FiltroAeronaves(Criterio);
        }

        [HttpGet("DameTodos")]
        public async Task<List<Aeronaves.Models.Aeronave>?> DameTodos()
        {
            return await _aeronavesRepositorio.DameTodos();
        }

    }

}
