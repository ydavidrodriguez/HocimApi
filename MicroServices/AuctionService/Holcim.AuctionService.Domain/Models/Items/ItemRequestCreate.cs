namespace Holcim.AuctionService.Domain.Models.Items
{
    public class ItemRequestCreate
    {
        public string nombre { get; set; }
        public Guid unidadMedidaId { get; set; }
        public int cantidad { get; set; }
        public long valorUnidad { get; set; }
        public string observacion { get; set; }
        public Guid monedaId { get; set; }
        public int? index { get; set; }
    }
}
