namespace Holcim.AuctionService.Domain.Models
{
    public class PostListItemsRequest
    {
        public string Nombre { get; set; }
        public Guid UnidadMedidaId { get; set; }
        public Guid IdMoneda { get; set; }
        public int Cantidad { get; set; }
        public int valorUnidad { get; set; }
        public int? Index { get; set; }

    }
}
