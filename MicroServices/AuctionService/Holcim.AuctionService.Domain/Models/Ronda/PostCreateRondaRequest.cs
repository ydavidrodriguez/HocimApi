using Holcim.AuctionService.Domain.Models.Items;
using Holcim.AuctionService.Domain.Models.Proveedor;

namespace Holcim.AuctionService.Domain.Models.Ronda
{
    public class PostCreateRondaRequest
    {
        public  List<ItemsRondaRequest>? Item { get; set; }
       // public List<GetProveedorRequest>? Proveedores { get; set; }
        public int Ronda { get; set; }
        public int TiempoRonda { get; set; }
        public Guid SubastaId { get; set; }

    }
}
