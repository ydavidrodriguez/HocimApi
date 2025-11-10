namespace Holcim.Domain.Entities.Rfx
{
    public class TrazabilidadRfx
    {
        public Guid IdTrazabilidadRfx { get; set; }
        public Usuario.Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
        public DateTime FechaCambio { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public string? MotivoEstado { get; set; }
    }
}
