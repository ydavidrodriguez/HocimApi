
namespace Holcim.AuctionService.Domain.Models
{
    public class PutUpdateColaboratorsRequest
    {
        public Guid IdSubasta { get; set; }
        public List<Guid> UsuarioId {get; set;}
    }
}