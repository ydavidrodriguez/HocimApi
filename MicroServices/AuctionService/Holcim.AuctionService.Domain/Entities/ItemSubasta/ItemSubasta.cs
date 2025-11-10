namespace Holcim.AuctionService.Domain.Entities.ItemSubasta
{
    public class ItemSubasta
    {
        public Guid IdItemSubasta { get; set; }
        public Guid ItemId { get; set; }
        public Guid SubastaId { get; set; }
        public Subasta.Subasta Subasta { get; set; }

    }
}
