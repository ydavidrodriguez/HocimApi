namespace Holcim.AuctionService.Domain.Entities.Subasta
{
    public class InvitacionProveedorSubasta
    {
        public Guid IdInvitacionProveedorSubasta { get; set; }
        public Guid SubastaId { get; set; }
        public Subasta? Subasta {get; set;}
        public string? Correo { get; set; }

    }
}