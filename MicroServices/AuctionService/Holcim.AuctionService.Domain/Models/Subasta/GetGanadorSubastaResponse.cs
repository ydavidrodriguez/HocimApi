using Holcim.AuctionService.Domain.Models.Item;

namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class GetGanadorSubastaResponse
    {
        public Guid IdGanadorSubasta { get; set; }
        public Guid ItemId { get; set; }
        public Guid SubastaId { get; set; }
        public Entities.Subasta.Subasta Subasta { get; set; }
        public Guid ProveedorId { get; set; }
        public int Cantidad { get; set; }
        public long ValorOferta { get; set; }
        public ItemDtoResponse Item { get; set; }
        public Proveedor.GeProveedorResponseNew Proveedor { get; set; }

    }
}
