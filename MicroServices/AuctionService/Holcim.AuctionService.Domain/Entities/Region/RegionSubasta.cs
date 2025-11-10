namespace Holcim.AuctionService.Domain.Entities.Region
{
    public class PaisSubasta
    {
        public Guid IdPaisSubasta { get; set; }
        public Guid IdPais { get; set; }
        public Subasta.Subasta Subasta { get; set; }
        public Guid SubastaId { get; set; }

    }
}
