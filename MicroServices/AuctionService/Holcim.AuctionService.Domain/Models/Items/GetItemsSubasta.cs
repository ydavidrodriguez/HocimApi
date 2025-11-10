namespace Holcim.AuctionService.Domain.Models.Items
{
    public class GetItemsSubasta
    {
        public string? Nombre { get; set; }
        public Guid IdItem { get; set; }
        public long Cantidad { get; set; }
        public long valorUnidad { get; set; }
        public Guid IdMoneda { get; set; }
        public string? NombreMoneda { get; set; }
        public Guid IdUnidadMedida { get; set; }
        public string? UdmCode { get; set; }
        public long ValorTotal { get; set; }
        public int? Index { get; set; }

    }
}
