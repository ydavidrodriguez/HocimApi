
namespace Holcim.AuctionService.Domain.Models
{
    public class PutReasignarSubastaRequest
    {
        public Guid Motivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Guid IdSubasta { get; set; }
        public List<Guid>? UsuarioId { get; set; }
    }
}