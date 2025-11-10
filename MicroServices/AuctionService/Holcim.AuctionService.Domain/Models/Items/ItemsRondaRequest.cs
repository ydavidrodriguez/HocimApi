namespace Holcim.AuctionService.Domain.Models.Items
{
    public class ItemsRondaRequest
    {
        public Guid ItemId { get; set; }
        public int Descuento { get; set; }
        public int OfertaFinal { get; set; }
        public int OfertaIncial { get; set; }
        public Guid TipoOfertaId { get; set; }

    }
}
