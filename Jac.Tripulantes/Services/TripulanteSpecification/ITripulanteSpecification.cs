using Jac.Tripulantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Tripulantes.Services.TripulanteSpecification
{
    public interface ITripulanteSpecification
    {
        bool IsValid(Tripulante Tripulante);
    }
}