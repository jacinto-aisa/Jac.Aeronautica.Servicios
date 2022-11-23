using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Embarque.Models
{
    public class TripulanteConCategoria
    {
        public Tripulante? Tripulante { get; set; } = default;
        
        public Categoria? Categoria { get; set; }

    }
}