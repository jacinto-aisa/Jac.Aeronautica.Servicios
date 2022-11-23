
using Jac.Aeronaves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Aeronaves.Services.AeronavesSpecification
{
    public interface IAeronaveSpecification
    {
        bool IsValid(Models.Aeronave Aeronave);
    }
}