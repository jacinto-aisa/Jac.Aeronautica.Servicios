using Jac.Tripulantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Tripulantes.Services.TripulanteSpecification
{
    public class VuelingTripulanteSpecification : ITripulanteSpecification
    {
        public bool IsValid(Tripulante Tripulante)
        {
            return Tripulante.CategoriaId == 2;
        }
    }
}