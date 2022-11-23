namespace Jac.Aeronaves.Models
{
    public class Aeronave : IEntidad
    {
        public int Id { get; set; }
        public string? Matricula { get; set; }
        public float IncrementoSueldo { get; set; }
        public int MesesDesdeMantenimento { get; set; }
        public int NumeroMotores { get; set; }
    }
}
