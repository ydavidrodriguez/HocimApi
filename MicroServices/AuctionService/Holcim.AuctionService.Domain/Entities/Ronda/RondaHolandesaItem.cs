using System.ComponentModel.DataAnnotations;

namespace Holcim.AuctionService.Domain.Entities.Ronda
{
    public class RondaHolandesaItem
    {
        public Guid IdRondaHolandesaItem { get; set; }
        public long PrecioInicial { get; set; }
        public long DescuentoAumento { get; set; }
        public long LimiteOferta { get; set; }
        public long Oferta { get; set; }
        public Guid RondaId { get; set; }
        public Guid ItemId { get; set; }

    }
}
