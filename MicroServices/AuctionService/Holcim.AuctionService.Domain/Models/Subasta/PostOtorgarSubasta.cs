namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class PostOtorgarSubasta
    {
        public Guid ItemId { get; set; }
        public Guid GanadorId { get; set; }
        public int Cantidad { get; set; }
        public long ValorOferta { get; set; }
        public Guid SubastaId { get; set; }


    }
}
