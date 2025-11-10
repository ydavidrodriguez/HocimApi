namespace Holcim.Domain.Models.Rfx
{
    public class RfxTrazabilidadRequest
    {
        public Guid RfxId { get; set; }
        public Guid EstadoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Motivo { get; set; }
        public DateTime? FechaInicioNew { get; set; }
        public DateTime? FechaFinNew { get; set; }
    }
}
