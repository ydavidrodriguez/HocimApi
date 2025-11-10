namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class PutSubastaFechaPausaRequest
    {
        public Guid SubastaId { get; set; }
        public DateTime? FechaDetencion { get; set; }
        public DateTime? FechaReanudacion { get; set; }


    }
}
