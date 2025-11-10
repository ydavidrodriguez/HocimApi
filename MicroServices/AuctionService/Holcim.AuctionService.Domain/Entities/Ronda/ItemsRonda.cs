namespace Holcim.AuctionService.Domain.Entities.Ronda
{
    public class ItemsRonda
    {
        public Guid IdItemsRonda { get; set; }
        public string? Nombre { get; set; }
        public long Cantidad { get; set; }
        public long? valorUnidad { get; set; }
        public Guid RondaId { get; set; }

    }
}
