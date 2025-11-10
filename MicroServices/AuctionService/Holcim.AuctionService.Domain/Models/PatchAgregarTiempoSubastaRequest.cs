
namespace Holcim.AuctionService.Domain.Models
{
    public class PatchAgregarTiempoSubastaRequest
    {
        public Guid IdSubasta { get; set; }
        public int Minutos { get; set; }
        public Guid UsuarioId {get; set;}
    }
}