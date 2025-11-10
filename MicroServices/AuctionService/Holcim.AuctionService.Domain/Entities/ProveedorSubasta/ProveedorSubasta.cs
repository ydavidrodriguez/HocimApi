using subastaNamespace = Holcim.AuctionService.Domain.Entities.Subasta;
namespace Holcim.AuctionService.Domain.Entities.ProveedorSubasta
{
    public class ProveedorSubasta
    {
        public Guid IdProveedorSubasta { get; set; }
        public Guid? ProveedorId { get; set; }
        public Guid SubastaId { get; set; }
        public subastaNamespace.Subasta Subasta { get; set; }

    }
}
