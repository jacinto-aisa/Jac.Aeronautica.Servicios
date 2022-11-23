namespace Jac.Embarque.Models
{
    public class EmbarqueAvion : IEntidad
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        //Será una cadena de texto separada por comas con los id de los tripulantes
        public String TripulantesId { get; set; } = "";
        public int Aeronave { get; set; }
        public int NumeroPasajeros { get; set; }
    }
}
