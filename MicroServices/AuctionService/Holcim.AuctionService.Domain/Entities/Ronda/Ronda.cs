namespace Holcim.AuctionService.Domain.Entities.Ronda
{
    public class Ronda
    {
        public Guid IdRonda { get; set; }
        public Guid SubastaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Tiempo { get; set; }
        public int Round { get; set; }

    }
}
