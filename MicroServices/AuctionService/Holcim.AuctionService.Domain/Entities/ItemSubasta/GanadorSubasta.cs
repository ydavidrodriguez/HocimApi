namespace Holcim.AuctionService.Domain.Entities.GanadorSubasta
{
    public class GanadorSubasta
    {
        public Guid IdGanadorSubasta { get; set; }
        public Guid ItemId { get; set; }
        public Guid SubastaId { get; set; }
        public Subasta.Subasta Subasta { get; set; }
        public Guid ProveedorId { get; set; }
        public int Cantidad { get; set; }
        public long ValorOferta { get; set; }
    }
}