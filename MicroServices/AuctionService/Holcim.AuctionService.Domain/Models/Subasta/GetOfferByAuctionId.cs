using Holcim.AuctionService.Domain.Models.Items;
using Holcim.AuctionService.Domain.Models.Region;

namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class GetOfferByAuctionId
    {
        public Guid IdOfertaSubasta { get; set; }
        public Guid SubastaId { get; set; }
        public Guid ItemId { get; set; }
        public GetItemsSubasta? Item {get; set;}
        public decimal ValorOferta{ get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? ProveedorId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<GetItemsSubasta>? GetItemsSubasta { get; set; }

    }
}
