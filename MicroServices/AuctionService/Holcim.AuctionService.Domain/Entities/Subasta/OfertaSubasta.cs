namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class OfertaSubasta
    {
        public Guid IdOfertaSubasta { get; set; }
        public Guid SubastaId { get; set; }
        public Subasta Subasta { get; set; }
        public Guid ItemId { get; set; }
        public decimal ValorOferta{ get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? ProveedorId { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}