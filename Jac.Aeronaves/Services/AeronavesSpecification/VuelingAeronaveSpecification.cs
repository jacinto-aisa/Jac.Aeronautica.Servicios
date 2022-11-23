using Jac.Aeronaves.Models;
using Jac.Aeronaves.Services.AeronavesSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Aeronaves.Services.AeronavesSpecification
{
    public class VuelingAeronaveSpecification : IAeronaveSpecification
    {
        public bool IsValid(Aeronaves.Models.Aeronave aeronave)
        {
            return aeronave.IncrementoSueldo < 0.1f && aeronave.MesesDesdeMantenimento < 16;
        }
    }
}