namespace Holcim.Provider.Domain.Models.Pregunta
{
    public class CreateQuestionPercent
    {
        public Guid RfxId { get; set; }
        public Guid ProveedorId { get; set; }
        public int Calificacion { get; set; }
        public string? Observacion  { get; set; }
    }
}
