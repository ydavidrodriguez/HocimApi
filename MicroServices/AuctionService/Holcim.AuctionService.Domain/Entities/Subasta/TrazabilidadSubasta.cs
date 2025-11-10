namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class TrazabilidadSubasta
    {
        public Guid IdTrazabilidadSubasta { get; set; }
        public Guid UsuarioId { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
        public DateTime FechaCambio { get; set; }
        public Subasta Subasta { get; set; }
        public Guid SubastaId { get; set; }
        public string? MotivoEstado { get; set; }
    }
}