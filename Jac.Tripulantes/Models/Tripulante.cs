using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jac.Tripulantes.Models
{
    public class Tripulante : IEntidad
    {
        public int Id { get; set; }
        
        public string? Nombre { get; set; }  
 
        public int CategoriaId { get; set; }
  
        public int Experiencia { get; set; }
     }
}