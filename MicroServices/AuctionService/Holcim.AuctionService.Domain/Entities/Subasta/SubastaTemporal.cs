
namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class SubastaTemporal
    {
        public Guid IdSubastaTemporal { get; set; }
        public string JsonSubasta { get; set; }
        public Estado.Estado Estado { get; set; }
        public Guid EstadoId { get; set; }
    }
}
