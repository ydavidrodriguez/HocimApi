namespace Holcim.AuctionService.Domain.Models.Item
{
    public class ItemDtoResponse
    {
        public Guid idItem { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaActulizacion { get; set; }

    }
}

