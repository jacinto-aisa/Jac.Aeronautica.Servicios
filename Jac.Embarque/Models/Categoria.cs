using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Embarque.Models
{
    public class Categoria : IEntidad
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; } =  default;


        public float BonificacionAnual { get; set; }

        public virtual ICollection<Tripulante>? Tripulantes { get; set; }
    }
}