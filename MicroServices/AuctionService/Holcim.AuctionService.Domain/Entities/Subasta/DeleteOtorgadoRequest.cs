namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class DeleteOtorgadoRequest
    {
        public Guid? IdGanadorSubasta { get; set; }
        public Guid? Rondaid { get; set; }
        public Guid? ItemRondaId { get; set; }

    }
}
