namespace Holcim.AuctionService.Domain.Models;

public class PostCreateOfferRequest
{
    public Guid SubastaId { get; set; }
    public Guid ItemId { get; set; }
    public decimal ValorOferta { get; set; }
    public Guid? UsuarioId { get; set; }
    public Guid? ProveedorId { get; set; }
}