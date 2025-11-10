namespace Holcim.Provider.Domain.Entities
{
    public class RespuestaPreguntaPorcentaje
    {
        public Guid IdRespuestaPreguntaPorcentaje { get; set; }
        public Guid RfxId { get; set; }
        public Guid ProveedorId { get; set; }
        public int Calificacion { get; set; }
        public string? Observacion { get; set; }

    }
}
